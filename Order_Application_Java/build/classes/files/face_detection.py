import dlib
import numpy as np
import cv2
import imageio
from PIL import Image
from PIL import ImageFont
from PIL import ImageDraw
import face_recognition
import datetime

#Section to capture video and save images ####

#get video input from webcamera
camera = cv2.VideoCapture(0)

#name of the window used to capture the video
cv2.namedWindow("Verify User")

#counter to increment the file name of the image being captured
img_counter = 0

#use infinite loop to continously capture video
while True:
    #initialize frames from the camera's read
    ret, frame = camera.read()

    #show the current frame to the user so that the user can decide when to capture a frame    
    cv2.imshow("Verify User", frame)

    #if the returning value is false, then break the loop and end frame capture
    if not ret:
        break
    k = cv2.waitKey(1)

    #if escape (esc) key is pressed end capturing frames and end video
    if k%256 == 27:
        break
    
    #if space button is pressed, create image file and write to disk. Then increase counter so that a new file could be written.
    elif k%256 == 32:
        img_name = "frame_{}.png".format(img_counter)
        cv2.imwrite(img_name, frame)
        img_counter += 1

#when the loop is broken release resources        
camera.release()

cv2.destroyAllWindows()

####Sections to identify human faces and create digital image signature ####

###decrease image counter to read last image written to disk
img_value = img_counter-1

#get image name of the last image
img_name = "frame_{}.png".format(img_value)

#read last image using imageio package's imread
img = imageio.imread(img_name)
#face detector model. CNN (Convolution Neural Network) based detector us used with the given data file
cnn_face_detector = dlib.cnn_face_detection_model_v1("mmod_human_face_detector.dat")
print(cnn_face_detector)
##
###get mmod_rectangle object from CNN detector
dets = cnn_face_detector(img, 1)
print(dets)

#check the number of detected faces by getting the length of the dlib.rectangle object
#a request is considered valid only if one face is detected - the face of the authenticated user
if(len(dets)==1):

    #if 1 face is detected print results such as the four corners of the area detected and the confidence score
    for i, a in enumerate(dets):
            print("Detection {}: Left: {} Top: {} Right: {} Bottom: {} Confidence: {}".format(
                i, a.rect.left(), a.rect.top(), a.rect.right(), a.rect.bottom(), a.confidence))

    #write the digital signature to the image
    #open the image to write data
    img = Image.open(img_name)

    #write data to the image using PIL package's functions and use the font type face with color white and time as current time
    draw = ImageDraw.Draw(img)
    font = ImageFont.truetype("Times_New_Java.ttf",16)
    draw.text((0,0),"Submitted on "+datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S"),(255,255,255),font = font)

    #resize and save image as a new image to disk
    basewidth = 300
    widthpercent = (basewidth/float(img.size[0]))
    heightsize = int(float(img.size[1])*float(widthpercent))
    img = img.resize((basewidth,heightsize),Image.ANTIALIAS)        
    img.save("submitted_image.png")

#if no faces are detected then either a human is not detected in high brightness or the brightness of the background is low
#in case of low brightness, increase brightness in control panel and re-run process
elif (len(dets)==0):
    print("Exception in capture: Low brightness of background or non-human in background detected")

#if more than one face is detected, the request is not considered valid since the digital signature of the user in focus is not true
else:
    print("More than one face detected. Please pose only the user submitting the order.")





