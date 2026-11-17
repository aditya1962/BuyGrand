package controllers;

import com.itextpdf.kernel.geom.Rectangle;
import com.itextpdf.kernel.pdf.*;
import com.itextpdf.kernel.pdf.filespec.PdfFileSpec;
import com.itextpdf.signatures.*;
import org.bouncycastle.jce.provider.BouncyCastleProvider;
import org.json.JSONObject;

import java.io.*;
import java.nio.charset.StandardCharsets;
import java.security.*;
import java.security.cert.Certificate;
import java.util.Properties;

public class FaceSignController 
{
    private static final boolean WINDOWS = System.getProperty("os.name").toLowerCase().contains("win");

    // ---------------------------------------------------------------- paths
    /** Project root: works from NetBeans (build/classes) and from dist/BuyGrand.jar. */
    public static File projectDir() {
        try {
            File loc = new File(FaceSignController.class.getProtectionDomain()
                    .getCodeSource().getLocation().toURI());
            return loc.getParentFile().getParentFile();   // build/classes -> root, dist/BuyGrand.jar -> root
        } catch (Exception e) {
            return new File(System.getProperty("user.dir"));   // fallback: working directory
        }
    }

    public static File scriptsDir() { return new File(projectDir(), "scripts"); }
    public static File modelsDir()  { return new File(projectDir(), "models"); }
    public static File scriptFile() { return new File(scriptsDir(), "face_verify.py"); }

    /** Uses scripts/venv if present, otherwise the system Python. */
    private static String pythonCommand() {
        File venvPython = WINDOWS ? new File(scriptsDir(), "venv\\Scripts\\python.exe")
                                  : new File(scriptsDir(), "venv/bin/python");
        if (venvPython.isFile()) return venvPython.getAbsolutePath();
        return WINDOWS ? "python" : "python3";
    }

    // ---------------------------------------------------------------- 1. invoice hash
    public static String sha256(String canonicalInvoice) throws Exception {
        byte[] h = MessageDigest.getInstance("SHA-256")
                .digest(canonicalInvoice.getBytes(StandardCharsets.UTF_8));
        StringBuilder sb = new StringBuilder();
        for (byte b : h) sb.append(String.format("%02x", b));
        return sb.toString();
    }

    // ---------------------------------------------------------------- 2. face enrolment / verification
    public static JSONObject enrollFace(String userId) throws Exception {
        return runFaceScript("enroll", "--user", userId);
    }

    public static JSONObject verifyFace(String userId, String invoiceHash) throws Exception {
        return runFaceScript("verify", "--user", userId, "--invoice-hash", invoiceHash);
    }

    /** Second factor at login (after username + password): 1:1 check against this user's template. */
    public static JSONObject verifyLogin(String userId) throws Exception {
        return runFaceScript("verify", "--user", userId);
    }

    /** Sign-in without a username: returns status "identified" and user_id, or "rejected"/"error". */
    public static JSONObject identifyFace() throws Exception {
        return runFaceScript("identify");
    }

    private static JSONObject runFaceScript(String... args) throws Exception {
        if (!scriptFile().isFile())
            throw new FileNotFoundException("Script not found: " + scriptFile().getAbsolutePath());
        if (!modelsDir().isDirectory())
            throw new FileNotFoundException("Models folder not found: " + modelsDir().getAbsolutePath());

        java.util.List<String> cmd = new java.util.ArrayList<>();
        cmd.add(pythonCommand());
        cmd.add(scriptFile().getAbsolutePath());
        cmd.addAll(java.util.Arrays.asList(args));
        cmd.add("--model-dir");
        cmd.add(modelsDir().getAbsolutePath());

        ProcessBuilder pb = new ProcessBuilder(cmd);
        pb.directory(scriptsDir());          // submitted_image.png is written to scripts/
        pb.redirectErrorStream(true);
        Process p = pb.start();

        String last = null;
        StringBuilder log = new StringBuilder();
        try (BufferedReader r = new BufferedReader(new InputStreamReader(p.getInputStream(), StandardCharsets.UTF_8))) {
            for (String line; (line = r.readLine()) != null; ) {
                log.append(line).append('\n');
                if (line.trim().startsWith("{")) last = line.trim();
            }
        }
        p.waitFor();
        if (last == null) throw new IOException("No JSON result from face_verify.py:\n" + log);
        return new JSONObject(last);
    }

    // ---------------------------------------------------------------- 3. embed evidence in the PDF
    public static void embedEvidence(String srcPdf, String destPdf, JSONObject evidence) throws IOException {
        try (PdfDocument doc = new PdfDocument(new PdfReader(srcPdf), new PdfWriter(destPdf))) {
            byte[] data = evidence.toString(2).getBytes(StandardCharsets.UTF_8);
            PdfFileSpec spec = PdfFileSpec.createEmbeddedFileSpec(doc, data,
                    "Face verification evidence", "face_evidence.json",
                    new PdfName("application/json"), null, PdfName.Data);
            doc.addFileAttachment("face_evidence.json", spec);
            doc.getDocumentInfo().setMoreInfo("FaceVerified", evidence.optString("verified_at"));
        }
    }

    // ---------------------------------------------------------------- 4. sign (PAdES, optional timestamp)
    public static void sign(String srcPdf, String destPdf, String p12Path, char[] password,
                            String tsaUrl, String reason) throws Exception {
        BouncyCastleProvider provider = new BouncyCastleProvider();
        Security.addProvider(provider);

        KeyStore ks = KeyStore.getInstance("PKCS12");
        try (InputStream in = new FileInputStream(p12Path)) { ks.load(in, password); }
        String alias = ks.aliases().nextElement();
        PrivateKey pk = (PrivateKey) ks.getKey(alias, password);
        Certificate[] chain = ks.getCertificateChain(alias);

        PdfSigner signer = new PdfSigner(new PdfReader(srcPdf), new FileOutputStream(destPdf),
                new StampingProperties());
        signer.setFieldName("FaceVerifiedSignature");
        signer.getSignatureAppearance().setReason(reason).setLocation("BuyGrand");

        IExternalSignature pks = new PrivateKeySignature(pk, DigestAlgorithms.SHA256, provider.getName());
        IExternalDigest digest = new BouncyCastleDigest();
        ITSAClient tsa = (tsaUrl == null) ? null : new TSAClientBouncyCastle(tsaUrl);

        signer.signDetached(digest, pks, chain, null, null, tsa, 0, PdfSigner.CryptoStandard.CADES);
    }

    // ---------------------------------------------------------------- 5. one call: embed + sign an invoice
    /**
     * Embeds the face evidence into the unsigned invoice and signs it with the shop certificate.
     * Settings come from keys/signing.properties (keystore, password, tsa, visible signature box).
     * @return the signed PDF file
     */
    public static File signInvoice(File unsignedPdf, JSONObject evidence) throws Exception {
        Properties cfg = loadSigningConfig();
        File keystore = new File(projectDir(), cfg.getProperty("keystore", "keys/buygrand_shop.p12"));
        char[] password = cfg.getProperty("password", "").toCharArray();
        String tsa = cfg.getProperty("tsa", "").trim();
        boolean visible = Boolean.parseBoolean(cfg.getProperty("signature.visible", "true"));
        if (!keystore.isFile())
            throw new FileNotFoundException("Signing keystore not found: " + keystore.getAbsolutePath());

        String base = unsignedPdf.getAbsolutePath().replaceAll("\\.pdf$", "");
        File withEvidence = new File(base + "_ev.pdf");
        File signed = new File(base + "_signed.pdf");

        embedEvidence(unsignedPdf.getAbsolutePath(), withEvidence.getAbsolutePath(), evidence);
        signVisible(withEvidence.getAbsolutePath(), signed.getAbsolutePath(), keystore.getAbsolutePath(),
                password, tsa.isEmpty() ? null : tsa, buildReason(evidence), visible);

        withEvidence.delete();
        return signed;
    }

    private static Properties loadSigningConfig() throws IOException {
        File f = new File(projectDir(), "keys/signing.properties");
        if (!f.isFile()) throw new FileNotFoundException("Signing settings not found: " + f.getAbsolutePath());
        Properties p = new Properties();
        try (InputStream in = new FileInputStream(f)) { p.load(in); }
        return p;
    }

    private static String buildReason(JSONObject ev) {
        JSONObject v = ev.optJSONObject("verification");
        String d = (v == null) ? "-" : String.format(java.util.Locale.ROOT, "%.3f", v.optDouble("distance_median"));
        return "Invoice approved by " + ev.optString("user_id") + " - face verified (distance " + d + ")";
    }

    /** Same as sign(), plus an optional visible signature box at the bottom-left of the last page. */
    public static void signVisible(String srcPdf, String destPdf, String p12Path, char[] password,
                                   String tsaUrl, String reason, boolean visible) throws Exception {
        BouncyCastleProvider provider = new BouncyCastleProvider();
        Security.addProvider(provider);

        KeyStore ks = KeyStore.getInstance("PKCS12");
        try (InputStream in = new FileInputStream(p12Path)) { ks.load(in, password); }
        String alias = ks.aliases().nextElement();
        PrivateKey pk = (PrivateKey) ks.getKey(alias, password);
        Certificate[] chain = ks.getCertificateChain(alias);

        int lastPage;
        try (PdfDocument tmp = new PdfDocument(new PdfReader(srcPdf))) { lastPage = tmp.getNumberOfPages(); }

        PdfSigner signer = new PdfSigner(new PdfReader(srcPdf), new FileOutputStream(destPdf),
                new StampingProperties());
        signer.setFieldName("FaceVerifiedSignature");
        PdfSignatureAppearance app = signer.getSignatureAppearance();
        app.setReason(reason).setLocation("BuyGrand");
        if (visible) {
            app.setPageNumber(lastPage)
               .setPageRect(new Rectangle(36, 36, 260, 54))      // x, y, width, height in points
               .setLayer2Text("Digitally signed by BuyGrand\n" + reason + "\n"
                       + new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(new java.util.Date()))
               .setLayer2FontSize(7)
               .setRenderingMode(PdfSignatureAppearance.RenderingMode.DESCRIPTION);
        }

        IExternalSignature pks = new PrivateKeySignature(pk, DigestAlgorithms.SHA256, provider.getName());
        IExternalDigest digest = new BouncyCastleDigest();
        ITSAClient tsa = (tsaUrl == null) ? null : new TSAClientBouncyCastle(tsaUrl);

        signer.signDetached(digest, pks, chain, null, null, tsa, 0, PdfSigner.CryptoStandard.CADES);
    }
}
