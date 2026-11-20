"""
face_verify.py - face enrolment, face verification and liveness check for BuyGrand.

Replaces face_detection.py. Face detection still uses dlib's CNN (MMOD) detector
(mmod_human_face_detector.dat), and the script adds:
  * face verification against the user's enrolled template (dlib ResNet, 128-D embedding)
  * direct-facing capture by default: several frontal samples, all checked against the template
  * an optional active liveness check (--challenge): a random challenge of blinks and a head turn
  * a JSON evidence record for the Java app to embed in the invoice and sign

Usage (called from the JFrame app with ProcessBuilder, or run manually):
  python face_verify.py enroll --user u_1043
  python face_verify.py verify --user u_1043 --invoice-hash <sha256 of invoice data>
  python face_verify.py identify          (sign-in without a username: 1:N search of enrolled users)

The LAST line printed to stdout is a JSON result. Exit codes: 0 = verified / identified / enrolled,
1 = rejected (no match or liveness failed), 2 = error or cancelled.

Model files (download from http://dlib.net/files/ and unzip the .bz2):
  mmod_human_face_detector.dat               (you already have this)
  shape_predictor_68_face_landmarks.dat      (iBUG 300-W licence: non-commercial use only)
  dlib_face_recognition_resnet_model_v1.dat
"""

import argparse
import datetime
import hashlib
import json
import os
import random
import sys
import time

import cv2
import dlib
import numpy as np

# ---------------------------------------------------------------- configuration
# Paths are resolved relative to this script, so it works from any working directory.
# Expected project layout:
#   <project>/scripts/face_verify.py      (this file)
#   <project>/models/*.dat                (dlib model files)
# Model folder: --model-dir argument > BUYGRAND_MODEL_DIR environment variable > <project>/models
SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))
PROJECT_DIR = os.path.dirname(SCRIPT_DIR)
MODEL_DIR = os.environ.get("BUYGRAND_MODEL_DIR", os.path.join(PROJECT_DIR, "models"))
DETECTOR_FILE = "mmod_human_face_detector.dat"
LANDMARKS_FILE = "shape_predictor_68_face_landmarks.dat"
RECOGNITION_FILE = "dlib_face_recognition_resnet_model_v1.dat"
TEMPLATE_DIR = os.path.join(SCRIPT_DIR, "templates")   # enrolled templates; protect or encrypt in production
CAPTURE_DIR = os.path.join(SCRIPT_DIR, "captures")     # best face crop per verification; protect as well

CAMERA_INDEX = 0
WINDOW = "Verify User"
DEBUG = False                   # --debug: show EAR, yaw, distance and FPS on screen
FULLSCREEN = True               # full-screen camera preview; set False for a normal window
DETECT_WIDTH = 480              # frames are downscaled to this width before CNN detection (speed)
DETECT_UPSAMPLE = 0             # 0 = fastest (faces > ~80 px at DETECT_WIDTH); 1 finds smaller faces but is ~4x slower
REDETECT_EVERY = 10             # run the CNN detector every N frames; track the face in between
TRACKER_MIN_QUALITY = 5.0       # re-detect if the correlation tracker's confidence drops below this

MATCH_THRESHOLD = 0.6           # dlib embedding distance; lower = stricter (0.6 is dlib's default)
MATCH_MIN_FRACTION = 0.8        # share of samples that must be within the threshold (median must be too)
MIN_IDENTITY_SAMPLES = 3        # embeddings that must be collected during the liveness challenge
LIVENESS_CHALLENGE = False      # False = direct facing only (no blink/turn); True or --challenge = active liveness
DIRECT_SAMPLES = 5              # direct-facing mode: frontal samples to collect before deciding
DIRECT_TIMEOUT_S = 20           # direct-facing mode: time limit
IDENTITY_SAMPLE_EVERY = 5       # compute an embedding every N frames while the face is frontal
ENROL_SAMPLES = 5               # captures averaged into the enrolled template
MAX_IDENTITY_SAMPLES = 40       # cap on samples kept during a challenge (memory)
IDENTIFY_MARGIN = 0.06          # 1:N - best user must beat the runner-up by this distance

EAR_CLOSED = 0.21               # fallback "eyes closed" level, used only before calibration
EAR_CLOSED_RATIO = 0.75         # after calibration: closed = EAR below 75% of the user's own open-eye EAR
EAR_REOPEN_RATIO = 0.88         # ...and the blink counts once EAR is back above 88% (hysteresis)
EAR_CONSEC_FRAMES = 1           # frames below the closed level needed (blinks are short; webcams are slow)
YAW_FRONTAL = (-0.10, 0.10)     # head-turn range treated as "facing the camera" (enrolment, before calibration)
YAW_TURN_DELTA = 0.12           # head turn = measure moves this far from the user's straight-ahead value (~17 deg)
YAW_LEFT_SIGN = 1               # +1: ratio rises when the user turns to THEIR left; set -1 if turns are reversed
BASELINE_FRAMES = 8             # frames used to measure the user's straight-ahead yaw at the start
FRONTAL_TOL = 0.08              # after calibration: frontal = within this of the straight-ahead value (~11 deg)
TURN_HOLD_FRAMES = 3            # frames the turn must be held
CHALLENGE_TIMEOUT_S = 40

SAVE_LEGACY_IMAGE = True        # keep writing submitted_image.png until the Java app switches to signing
LEGACY_IMAGE_PATH = "submitted_image.png"


# ---------------------------------------------------------------- helpers
def emit(result, code):
    """Print the JSON result as the last stdout line and exit with the given code."""
    print(json.dumps(result))
    sys.exit(code)


def now_iso():
    return datetime.datetime.now().astimezone().isoformat(timespec="seconds")


def load_models():
    detector, landmarks, recognition = (os.path.join(MODEL_DIR, f)
                                        for f in (DETECTOR_FILE, LANDMARKS_FILE, RECOGNITION_FILE))
    for path in (detector, landmarks, recognition):
        if not os.path.isfile(path):
            raise FileNotFoundError("Model file not found: " + path)
    return (dlib.cnn_face_detection_model_v1(detector),
            dlib.shape_predictor(landmarks),
            dlib.face_recognition_model_v1(recognition))


def open_camera():
    # DirectShow opens webcams much faster on Windows
    backend = cv2.CAP_DSHOW if os.name == "nt" else cv2.CAP_ANY
    camera = cv2.VideoCapture(CAMERA_INDEX, backend)
    if not camera.isOpened():
        raise RuntimeError("Could not open the webcam. Check Windows camera privacy settings.")
    return camera


def detect_faces(detector, rgb):
    """Run the MMOD CNN detector on a downscaled copy; return [(dlib.rectangle, confidence)] in full-size coordinates."""
    h, w = rgb.shape[:2]
    scale = DETECT_WIDTH / float(w) if w > DETECT_WIDTH else 1.0
    small = cv2.resize(rgb, (int(w * scale), int(h * scale))) if scale != 1.0 else rgb
    faces = []
    for d in detector(small, DETECT_UPSAMPLE):
        r = d.rect
        rect = dlib.rectangle(int(r.left() / scale), int(r.top() / scale),
                              int(r.right() / scale), int(r.bottom() / scale))
        faces.append((rect, float(d.confidence)))
    return faces


def landmarks_to_np(shape):
    return np.array([[p.x, p.y] for p in shape.parts()], dtype=np.float64)


def eye_aspect_ratio(eye):
    """EAR from the 6 landmarks of one eye (Soukupova & Cech, 2016)."""
    a = np.linalg.norm(eye[1] - eye[5])
    b = np.linalg.norm(eye[2] - eye[4])
    c = np.linalg.norm(eye[0] - eye[3])
    return (a + b) / (2.0 * c) if c > 0 else 0.0


def mean_ear(pts):
    return (eye_aspect_ratio(pts[36:42]) + eye_aspect_ratio(pts[42:48])) / 2.0


def yaw_ratio(pts):
    """Head-turn measure: horizontal offset of the nose tip (landmark 30) from the midpoint of the
    outer eye corners (36, 45), divided by the distance between those corners (raw, un-mirrored image).
    About 0 when facing the camera; roughly 0.39 x tan(yaw), so a 20-degree turn gives about 0.14.
    Uses inner-face landmarks, which follow head rotation far better than the jaw outline."""
    left_eye, right_eye, nose = pts[36], pts[45], pts[30]
    span = right_eye[0] - left_eye[0]
    if span <= 0:
        return 0.0
    return (nose[0] - (left_eye[0] + right_eye[0]) / 2.0) / span


def descriptor(recognizer, rgb, shape):
    return np.array(recognizer.compute_face_descriptor(rgb, shape), dtype=np.float64)


def crop(frame, rect, margin=0.25):
    h, w = frame.shape[:2]
    mx, my = int(rect.width() * margin), int(rect.height() * margin)
    x1, y1 = max(rect.left() - mx, 0), max(rect.top() - my, 0)
    x2, y2 = min(rect.right() + mx, w), min(rect.bottom() + my, h)
    return frame[y1:y2, x1:x2].copy()


_screen_size = None
_window_ready = False


def screen_size():
    """Screen resolution in pixels (DPI-aware on Windows so the window really fills the screen)."""
    global _screen_size
    if _screen_size is None:
        try:
            if os.name == "nt":
                import ctypes
                try:
                    ctypes.windll.shcore.SetProcessDpiAwareness(1)
                except Exception:
                    ctypes.windll.user32.SetProcessDPIAware()
            import tkinter
            root = tkinter.Tk()
            root.withdraw()
            _screen_size = (root.winfo_screenwidth(), root.winfo_screenheight())
            root.destroy()
        except Exception:
            _screen_size = (1280, 720)
    return _screen_size


def setup_window():
    """Create the preview window once: full screen and on top of the Java app."""
    global _window_ready
    if _window_ready:
        return
    cv2.namedWindow(WINDOW, cv2.WINDOW_NORMAL)
    if FULLSCREEN:
        cv2.setWindowProperty(WINDOW, cv2.WND_PROP_FULLSCREEN, cv2.WINDOW_FULLSCREEN)
    try:
        cv2.setWindowProperty(WINDOW, cv2.WND_PROP_TOPMOST, 1)
    except Exception:
        pass  # older OpenCV versions do not support "always on top"
    _window_ready = True


def close_window():
    global _window_ready
    cv2.destroyAllWindows()
    _window_ready = False


def fit_to_screen(view, screen_w, screen_h):
    """Scale the frame to fill the screen without distortion; pad the rest with black."""
    h, w = view.shape[:2]
    s = min(screen_w / float(w), screen_h / float(h))
    new_w, new_h = int(w * s), int(h * s)
    resized = cv2.resize(view, (new_w, new_h), interpolation=cv2.INTER_LINEAR)
    canvas = np.zeros((screen_h, screen_w, 3), dtype=np.uint8)
    x0, y0 = (screen_w - new_w) // 2, (screen_h - new_h) // 2
    canvas[y0:y0 + new_h, x0:x0 + new_w] = resized
    return canvas


def show(frame_bgr, lines, rect=None, colour=(0, 200, 0)):
    """Display a mirrored, full-screen preview (feels natural to users) with instructions on top."""
    setup_window()
    view = frame_bgr.copy()
    if rect is not None:
        cv2.rectangle(view, (rect.left(), rect.top()), (rect.right(), rect.bottom()), colour, 3)
    view = cv2.flip(view, 1)
    if FULLSCREEN:
        view = fit_to_screen(view, *screen_size())
    # text size follows the window height so instructions stay readable at full screen
    k = view.shape[0] / 720.0
    font_scale, thick = 1.0 * k, max(2, int(round(2 * k)))
    x, y0, step = int(30 * k), int(55 * k), int(48 * k)
    for i, text in enumerate(lines):
        if not text:
            continue
        y = y0 + step * i
        cv2.putText(view, text, (x, y), cv2.FONT_HERSHEY_SIMPLEX, font_scale, (0, 0, 0), thick + 3)
        cv2.putText(view, text, (x, y), cv2.FONT_HERSHEY_SIMPLEX, font_scale, (255, 255, 255), thick)
    cv2.imshow(WINDOW, view)
    return cv2.waitKey(1) & 0xFF


def template_path(user_id):
    safe = "".join(ch for ch in user_id if ch.isalnum() or ch in "-_")
    return os.path.join(TEMPLATE_DIR, safe + ".npy")


# ---------------------------------------------------------------- enrolment
def enroll(user_id):
    detector, predictor, recognizer = load_models()
    camera = open_camera()
    samples, confidences = [], []
    message = ""
    try:
        while len(samples) < ENROL_SAMPLES:
            ok, frame = camera.read()
            if not ok:
                raise RuntimeError("Could not read from the webcam.")
            key = show(frame, ["Enrolment: look at the camera",
                               "SPACE = capture ({}/{})   ESC = cancel".format(len(samples), ENROL_SAMPLES),
                               message])
            if key == 27:
                emit({"status": "error", "user_id": user_id, "reason": "cancelled"}, 2)
            if key != 32:
                continue
            rgb = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
            faces = detect_faces(detector, rgb)
            if len(faces) != 1:
                message = "No face found" if not faces else "More than one face - only the user please"
                continue
            rect, conf = faces[0]
            shape = predictor(rgb, rect)
            yaw = yaw_ratio(landmarks_to_np(shape))
            if not (YAW_FRONTAL[0] <= yaw <= YAW_FRONTAL[1]):
                message = "Please face the camera directly"
                continue
            samples.append(descriptor(recognizer, rgb, shape))
            confidences.append(conf)
            message = "Captured"
    finally:
        camera.release()
        close_window()

    template = np.mean(samples, axis=0)
    spread = float(max(np.linalg.norm(s - template) for s in samples))
    os.makedirs(TEMPLATE_DIR, exist_ok=True)
    np.save(template_path(user_id), template)
    emit({"status": "enrolled", "user_id": user_id, "enrolled_at": now_iso(),
          "samples": len(samples), "sample_spread": round(spread, 4),
          "detection_confidence_min": round(min(confidences), 3),
          "model": "dlib_resnet_v1"}, 0)


# ---------------------------------------------------------------- verification
def make_challenge():
    steps = [{"type": "blink", "count": random.randint(1, 2)},
             {"type": "turn", "direction": random.choice(["left", "right"])}]
    random.shuffle(steps)
    return steps


def step_text(step):
    if step["type"] == "blink":
        n = step["count"]
        return "Blink {} time{}".format(n, "" if n == 1 else "s")
    return "Turn your head to your {}".format(step["direction"].upper())


def run_challenge(detector, predictor, recognizer, template=None):
    """Run the random liveness challenge and collect face descriptors from frontal frames.
    Returns a dict used by verify() (1:1) and identify() (1:N)."""
    camera = open_camera()
    challenge = make_challenge() if LIVENESS_CHALLENGE else []
    required = MIN_IDENTITY_SAMPLES if challenge else DIRECT_SAMPLES
    timeout = CHALLENGE_TIMEOUT_S if challenge else DIRECT_TIMEOUT_S
    # direct-facing mode: sample every frontal frame and calibrate quickly (no motion to wait for)
    sample_every = IDENTITY_SAMPLE_EVERY if challenge else 1
    baseline_frames = BASELINE_FRAMES if challenge else 3
    step_idx = 0
    blinks, closed_frames, turn_frames = 0, 0, 0
    descs, crops, confidences = [], [], []
    tracker, rect = None, None
    frame_no = 0
    multiple_faces = False
    reason = None
    start = time.time()
    last_d = None
    ear = yaw = 0.0
    base_yaws, baseline = [], None      # user's own straight-ahead yaw (camera may be off-centre)
    base_ears, ear_open = [], None      # user's own open-eye EAR (eye shape and camera differ per user)
    ear_min = 1.0
    eyes_closed = False
    yaw_min, yaw_max = 1.0, 0.0

    try:
        while True:
            if time.time() - start > timeout:
                reason = ("liveness challenge timed out" if challenge
                          else "timed out - face the camera directly in good light")
                break
            ok, frame = camera.read()
            if not ok:
                reason = "could not read from the webcam"
                break
            frame_no += 1
            rgb = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)

            # 1. find the face: CNN detection periodically, correlation tracking in between
            if tracker is None or frame_no % REDETECT_EVERY == 0:
                faces = detect_faces(detector, rgb)
                if len(faces) > 1:
                    multiple_faces = True
                    reason = "more than one face detected"
                    break
                if not faces:
                    tracker, rect = None, None
                    if show(frame, ["No face detected - look at the camera", "ESC = cancel"]) == 27:
                        reason = "cancelled"
                        break
                    continue
                rect, conf = faces[0]
                confidences.append(conf)
                tracker = dlib.correlation_tracker()
                tracker.start_track(rgb, rect)
            else:
                if tracker.update(rgb) < TRACKER_MIN_QUALITY:
                    tracker = None
                    continue
                p = tracker.get_position()
                rect = dlib.rectangle(int(p.left()), int(p.top()), int(p.right()), int(p.bottom()))

            # 2. landmarks -> eye openness and head yaw
            shape = predictor(rgb, rect)
            pts = landmarks_to_np(shape)
            ear = mean_ear(pts)
            yaw = yaw_ratio(pts)
            yaw_min, yaw_max = min(yaw_min, yaw), max(yaw_max, yaw)
            if baseline is None:
                if YAW_FRONTAL[0] - 0.10 <= yaw <= YAW_FRONTAL[1] + 0.10:
                    base_yaws.append(yaw)
                    base_ears.append(ear)
                if len(base_yaws) >= baseline_frames:
                    baseline = float(np.median(base_yaws))
                    ear_open = float(np.median(base_ears))
                frontal = YAW_FRONTAL[0] <= yaw <= YAW_FRONTAL[1]
            else:
                frontal = abs(yaw - baseline) <= FRONTAL_TOL
            # signed turn: positive = towards the user's LEFT
            turn_delta = 0.0 if baseline is None else (yaw - baseline) * YAW_LEFT_SIGN

            # 3. identity samples on frontal frames throughout the challenge
            ear_min = min(ear_min, ear)
            closed_thr = EAR_CLOSED if ear_open is None else ear_open * EAR_CLOSED_RATIO
            reopen_thr = EAR_CLOSED if ear_open is None else ear_open * EAR_REOPEN_RATIO
            # (skip frames with closed eyes: they match less well and are not representative)
            if (frontal and ear >= closed_thr and frame_no % sample_every == 0
                    and len(descs) < MAX_IDENTITY_SAMPLES):
                desc = descriptor(recognizer, rgb, shape)
                descs.append(desc)
                crops.append(crop(frame, rect))
                if template is not None:
                    last_d = float(np.linalg.norm(desc - template))

            # 4. liveness challenge
            if baseline is not None and step_idx < len(challenge):
                step = challenge[step_idx]
                if step["type"] == "blink":
                    # blink = eyes drop below the closed level, then reopen above the reopen level
                    if ear < closed_thr:
                        closed_frames += 1
                        if closed_frames >= EAR_CONSEC_FRAMES:
                            eyes_closed = True
                    elif ear > reopen_thr:
                        if eyes_closed:
                            blinks += 1
                        eyes_closed, closed_frames = False, 0
                    if blinks >= step["count"]:
                        step_idx, blinks = step_idx + 1, 0
                else:
                    wanted = turn_delta if step["direction"] == "left" else -turn_delta
                    turned = wanted >= YAW_TURN_DELTA
                    turn_frames = turn_frames + 1 if turned else 0
                    if turn_frames >= TURN_HOLD_FRAMES:
                        step_idx, turn_frames = step_idx + 1, 0

            if baseline is None:
                prompt = "Look straight at the camera"
            elif step_idx >= len(challenge):
                if len(descs) >= required:
                    break
                prompt = ("Look straight at the camera" if challenge else
                          "Look straight at the camera - capturing {}/{}".format(len(descs), required))
            else:
                prompt = "Step {}/{}: {}".format(step_idx + 1, len(challenge), step_text(challenge[step_idx]))

            lines = [prompt, "ESC = cancel"]
            if DEBUG:
                fps = frame_no / max(time.time() - start, 1e-6)
                lines += ["", "EAR {:.3f}  open {}  closed < {:.3f}  blinks {}".format(
                              ear, "-" if ear_open is None else "{:.3f}".format(ear_open), closed_thr, blinks),
                          "yaw {:.2f}  straight-ahead {}  turn {:+.2f} (LEFT needs >= +{}, RIGHT <= -{})".format(
                              yaw, "-" if baseline is None else "{:.2f}".format(baseline),
                              turn_delta, YAW_TURN_DELTA, YAW_TURN_DELTA),
                          "samples {}   last distance {}   threshold {}   FPS {:.1f}".format(
                              len(descs), "-" if last_d is None else "{:.3f}".format(last_d), MATCH_THRESHOLD, fps)]
            if show(frame, lines, rect) == 27:
                reason = "cancelled"
                break
    finally:
        camera.release()
        close_window()

    return {"challenge": challenge, "steps_completed": step_idx,
            "yaw_baseline": None if baseline is None else round(baseline, 3),
            "ear_open": None if ear_open is None else round(ear_open, 3),
            "ear_min": round(ear_min, 3) if ear_min < 1.0 else None,
            "fps": round(frame_no / max(time.time() - start, 1e-6), 1),
            "yaw_min": round(yaw_min, 3) if yaw_max > 0 else None,
            "yaw_max": round(yaw_max, 3) if yaw_max > 0 else None,
            "liveness_passed": step_idx >= len(challenge) and not multiple_faces,
            "descs": descs, "crops": crops, "confidences": confidences,
            "reason": reason, "elapsed_s": round(time.time() - start, 2)}


def save_capture(label, face_crop):
    """Store the best face crop as evidence; return its SHA-256."""
    ok, png = cv2.imencode(".png", face_crop)
    if not ok:
        return None
    data = png.tobytes()
    os.makedirs(CAPTURE_DIR, exist_ok=True)
    stamp = datetime.datetime.now().strftime("%Y%m%d_%H%M%S")
    with open(os.path.join(CAPTURE_DIR, "{}_{}.png".format(label, stamp)), "wb") as f:
        f.write(data)
    return hashlib.sha256(data).hexdigest()


def liveness_block(ch):
    if not ch["challenge"]:
        return {"method": "none", "passed": None, "elapsed_s": ch["elapsed_s"],
                "note": "direct-facing capture only; no presentation attack detection",
                "yaw_baseline": ch.get("yaw_baseline"), "fps": ch.get("fps")}
    return {"method": "active_challenge", "challenge": ch["challenge"],
            "steps_completed": ch["steps_completed"], "passed": ch["liveness_passed"],
            "elapsed_s": ch["elapsed_s"], "yaw_baseline": ch.get("yaw_baseline"),
            "yaw_min": ch.get("yaw_min"), "yaw_max": ch.get("yaw_max"),
            "ear_open": ch.get("ear_open"), "ear_min": ch.get("ear_min"), "fps": ch.get("fps"),
            "turn_delta_required": YAW_TURN_DELTA}


def detection_block(ch):
    return {"model": "dlib_mmod_cnn",
            "confidence_min": round(min(ch["confidences"]), 3) if ch["confidences"] else None}


def r4(x):
    return round(x, 4) if x is not None else None


def verify(user_id, invoice_hash):
    """1:1 - is this the enrolled user <user_id>?"""
    tpl_file = template_path(user_id)
    if not os.path.exists(tpl_file):
        emit({"status": "error", "user_id": user_id, "reason": "user not enrolled"}, 2)
    template = np.load(tpl_file)

    detector, predictor, recognizer = load_models()
    ch = run_challenge(detector, predictor, recognizer, template)

    distances = [float(np.linalg.norm(d - template)) for d in ch["descs"]]
    enough_samples = len(distances) >= MIN_IDENTITY_SAMPLES
    median_d = float(np.median(distances)) if distances else None
    max_d = float(max(distances)) if distances else None
    # every sampled frame must match, so a different face cannot be swapped in during the challenge
    within = sum(1 for d in distances if d <= MATCH_THRESHOLD)
    frac_ok = within / float(len(distances)) if distances else 0.0
    # median must match AND most samples must match, so a different face cannot be swapped in mid-challenge
    match = bool(enough_samples and median_d <= MATCH_THRESHOLD and frac_ok >= MATCH_MIN_FRACTION)

    capture_hash, best_crop = None, None
    if distances:
        best_crop = ch["crops"][int(np.argmin(distances))]
        capture_hash = save_capture(user_id, best_crop)

    verified = ch["liveness_passed"] and match
    if verified and SAVE_LEGACY_IMAGE:
        save_legacy_image(best_crop)

    reason = ch["reason"]
    if reason is None and not verified:
        reason = "liveness check failed" if not ch["liveness_passed"] else (
            "not enough frontal samples" if not enough_samples else "face does not match the enrolled user")

    result = {
        "status": "verified" if verified else ("error" if reason == "cancelled" else "rejected"),
        "reason": None if verified else reason,
        "mode": "verify",
        "user_id": user_id,
        "invoice_sha256": invoice_hash,
        "verified_at": now_iso(),
        "detection": detection_block(ch),
        "verification": {"model": "dlib_resnet_v1", "metric": "euclidean",
                         "distance_median": r4(median_d), "distance_max": r4(max_d),
                         "threshold": MATCH_THRESHOLD, "min_fraction": MATCH_MIN_FRACTION,
                         "fraction_within": round(frac_ok, 3), "samples": len(distances), "match": match,
                         "distances": [round(d, 4) for d in distances]},
        "liveness": liveness_block(ch),
        "capture_sha256": capture_hash,
    }
    emit(result, 0 if verified else (2 if reason == "cancelled" else 1))


def load_all_templates():
    templates = {}
    if os.path.isdir(TEMPLATE_DIR):
        for name in os.listdir(TEMPLATE_DIR):
            if name.endswith(".npy"):
                templates[name[:-4]] = np.load(os.path.join(TEMPLATE_DIR, name))
    return templates


def identify():
    """1:N - which enrolled user is this, if any? Used for sign-in without a username."""
    templates = load_all_templates()
    if not templates:
        emit({"status": "error", "mode": "identify", "reason": "no enrolled users"}, 2)

    detector, predictor, recognizer = load_models()
    ch = run_challenge(detector, predictor, recognizer)
    descs = ch["descs"]
    enough_samples = len(descs) >= MIN_IDENTITY_SAMPLES

    # score every enrolled user by the median distance over all samples
    ranking = []
    for uid, tpl in templates.items():
        d = [float(np.linalg.norm(x - tpl)) for x in descs]
        if d:
            ranking.append((float(np.median(d)), float(max(d)), uid, d))
    ranking.sort(key=lambda r: r[0])

    best = ranking[0] if ranking else None
    second = ranking[1] if len(ranking) > 1 else None
    margin = (second[0] - best[0]) if (best and second) else None

    frac_ok = (sum(1 for d in best[3] if d <= MATCH_THRESHOLD) / float(len(best[3]))) if best else 0.0
    match = bool(enough_samples and best is not None and best[0] <= MATCH_THRESHOLD
                 and frac_ok >= MATCH_MIN_FRACTION)
    unambiguous = margin is None or margin >= IDENTIFY_MARGIN
    identified = ch["liveness_passed"] and match and unambiguous
    user_id = best[2] if identified else None

    capture_hash, best_crop = None, None
    if best is not None:
        best_crop = ch["crops"][int(np.argmin(best[3]))]
        capture_hash = save_capture(user_id or "unidentified", best_crop)

    reason = ch["reason"]
    if reason is None and not identified:
        if not ch["liveness_passed"]:
            reason = "liveness check failed"
        elif not enough_samples:
            reason = "not enough frontal samples"
        elif not match:
            reason = "face does not match any enrolled user"
        else:
            reason = "face matches more than one user too closely"

    result = {
        "status": "identified" if identified else ("error" if reason == "cancelled" else "rejected"),
        "reason": None if identified else reason,
        "mode": "identify",
        "user_id": user_id,                 # only set when identified; other users are never disclosed
        "verified_at": now_iso(),
        "detection": detection_block(ch),
        "identification": {"model": "dlib_resnet_v1", "metric": "euclidean",
                           "enrolled_users": len(templates),
                           "distance_median": r4(best[0]) if best else None,
                           "distance_max": r4(best[1]) if best else None,
                           "margin_to_next": r4(margin),
                           "threshold": MATCH_THRESHOLD, "required_margin": IDENTIFY_MARGIN,
                           "samples": len(descs), "match": match},
        "liveness": liveness_block(ch),
        "capture_sha256": capture_hash,
    }
    emit(result, 0 if identified else (2 if reason == "cancelled" else 1))


def save_legacy_image(frame):
    """Face image with a date stamp (300 px wide) so the current invoice code keeps working.
    Remove once the Java app embeds the evidence JSON and signs the PDF instead."""
    img = frame.copy()
    text = "Face verified " + datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    cv2.putText(img, text, (5, 20), cv2.FONT_HERSHEY_SIMPLEX, 0.6, (255, 255, 255), 2)
    h, w = img.shape[:2]
    img = cv2.resize(img, (300, int(h * 300.0 / w)), interpolation=cv2.INTER_AREA)
    cv2.imwrite(LEGACY_IMAGE_PATH, img)


# ---------------------------------------------------------------- entry point
def main():
    parser = argparse.ArgumentParser(description="BuyGrand face enrolment, verification and identification")
    parser.add_argument("mode", choices=["enroll", "verify", "identify"])
    parser.add_argument("--user", default=None, help="user ID (required for enroll and verify)")
    parser.add_argument("--invoice-hash", default=None, help="SHA-256 of the invoice data (verify mode)")
    parser.add_argument("--model-dir", default=None, help="folder containing the three dlib .dat files")
    parser.add_argument("--debug", action="store_true", help="show EAR, yaw, distance and FPS on screen")
    parser.add_argument("--challenge", action="store_true", help="enable the blink / head-turn liveness challenge")
    args = parser.parse_args()
    if args.challenge:
        global LIVENESS_CHALLENGE
        LIVENESS_CHALLENGE = True
    if args.debug:
        global DEBUG
        DEBUG = True
    if args.model_dir:
        global MODEL_DIR
        MODEL_DIR = os.path.abspath(args.model_dir)
    if args.mode in ("enroll", "verify") and not args.user:
        emit({"status": "error", "reason": "--user is required for " + args.mode}, 2)
    try:
        if args.mode == "enroll":
            enroll(args.user)
        elif args.mode == "verify":
            verify(args.user, args.invoice_hash)
        else:
            identify()
    except (FileNotFoundError, RuntimeError) as exc:
        emit({"status": "error", "user_id": args.user, "reason": str(exc)}, 2)


if __name__ == "__main__":
    main()
