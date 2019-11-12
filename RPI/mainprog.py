import smbus
import time
import RPi.GPIO as GPIO
import cv2
import numpy as np
import serial #Serial port API http://pyserial.sourceforge.net/pyserial_api.html
import socket
from bluepy.btle import Peripheral

#GPIO variables
GPIO.setwarnings(False)
GPIO.setmode(GPIO.BCM)
GPIO.setup(17, GPIO.OUT) #LED diode on if local controll is selected
GPIO.setup(27, GPIO.OUT) #LED diode on if motion detection is on
GPIO.setup(22, GPIO.OUT) #LED diode should blink if alarm is triggered
GPIO.setup(18, GPIO.IN)  #Switch on for local controll / off for UI controll
GPIO.setup(23, GPIO.IN)  #Switch on for local controll / off motion detection
GPIO.setup(24, GPIO.IN)  #Switch for reseting triggered alarm when switch is high
alarmTriggered = False
resetAlarmInput = GPIO.input(24)

# Camera variables
motionDetection = None
motionDetectionControllInput = GPIO.input(23)
cam = None
fgbg = cv2.createBackgroundSubtractorMOG2(50, 200, True)
frameCount = 0
cameraSensitivity = 1000
sendEmailWhenTriggered = True

# Nunchuck variables
localControllInput = GPIO.input(18)
bus = smbus.SMBus(1)
address = 0x52
bus.write_byte_data(address, 0x40, 0x00)
bus.write_byte_data(address, 0xF0, 0x55)
bus.write_byte_data(address, 0xFB, 0x00)

# Serial com variables
port = "/dev/ttyACM0"
SerialIOmbed = serial.Serial(port, 9600) #setup the serial port and baudrate
SerialIOmbed.flushInput()

# UDP variables
OUTGOING_UDP_IP = "128.39.112.226"
UDP_PORT = 9050
out_sock = socket.socket(socket.AF_INET,  # Internet protocol
                         socket.SOCK_DGRAM)  # User Datagram (UDP)

INCOMING_UDP_IP = "0.0.0.0"
in_sock = socket.socket(socket.AF_INET,  # Internet protocol
                         socket.SOCK_DGRAM)  # User Datagram (UDP)
in_sock.bind((INCOMING_UDP_IP, UDP_PORT))
in_sock.settimeout(1.0)

#Bluetooth variables
BLEunit = "c8:8a:08:a8:96:90"
p = Peripheral(BLEunit, "random")
chList = p.getCharacteristics()

def sendAlarmTriggeredToBT():
    chList[5].write(bytearray([0x01]))

def sendAlarmResetToBT():
    chList[5].write(bytearray([0x00]))

# Sends inital values at system start up to UI
def init_UI():
    global localControllInput
    global motionDetectionControllInput
    global cameraSensitivity

    localControllInput = GPIO.input(18)
    motionDetectionControllInput = GPIO.input(23)

    out_sock.sendto("$ALARM," + "RESET", (OUTGOING_UDP_IP, UDP_PORT))
    out_sock.sendto("$CAM_SENS," + str(cameraSensitivity), (OUTGOING_UDP_IP, UDP_PORT))
    out_sock.sendto("$CAM_POST, 0", (OUTGOING_UDP_IP, UDP_PORT))

    if (localControllInput == 0):
        udpValue = "UI"
    else:
        udpValue = "Local"

    out_sock.sendto("$CTRL_MODE," + udpValue, (OUTGOING_UDP_IP, UDP_PORT))

    if (motionDetectionControllInput == 0):
        udpValue = "OFF"
    else:
        udpValue = "ON"

    out_sock.sendto("$MOTION_DETECT," + udpValue + "," + "", (OUTGOING_UDP_IP, UDP_PORT))

# Reads GPIO if alarm should be resetted if triggered
def read_reset_alarm():
    global resetAlarmInput
    resetAlarmInput = GPIO.input(24)

def send_rotate_cw_serial_message():
    global out_sock

    print "Rotate clockwise"
    SerialIOmbed.write("1\n")
    if (SerialIOmbed.inWaiting() > 0):
        feedback = SerialIOmbed.readline().strip()  # read a '\n' terminated line()
        out_sock.sendto("$CAM_POS," + feedback + "," + "", (OUTGOING_UDP_IP, UDP_PORT))
        print "Feedback from Nucleo:  " + feedback

def send_rotate_ccw_serial_message():
    global out_sock
    print "Rotate counter-clockwise"
    SerialIOmbed.write("2\n")
    if (SerialIOmbed.inWaiting() > 0):
        feedback = SerialIOmbed.readline().strip()  # read a '\n' terminated line()
        out_sock.sendto("$CAM_POS," + feedback + "," + "", (OUTGOING_UDP_IP, UDP_PORT))
        print "Feedback from Nucleo:  " + feedback

# Reads GPIO if local controll is low / high
def read_local_controll_input():
    global localControllInput
    newValue = GPIO.input(18)

    if (newValue != localControllInput):
        localControllInput = newValue
        if (localControllInput == 0):
            udpValue = "UI"
        else:
            udpValue = "Local"

        out_sock.sendto("$CTRL_MODE," + udpValue, (OUTGOING_UDP_IP, UDP_PORT))

# Reads GPIO if motion detection is low / high
def read_motion_detection_input():
    global motionDetectionControllInput
    newValue = GPIO.input(23)
    changedBy = "Local"

    if (newValue != motionDetectionControllInput):
        motionDetectionControllInput = newValue
        if (motionDetectionControllInput == 0):
            udpValue = "OFF"
        else:
            udpValue = "ON"

        out_sock.sendto("$MOTION_DETECT," + udpValue + "," + changedBy, (OUTGOING_UDP_IP, UDP_PORT))

# Reads UDP messages from UI
def read_udp_message():
    try:
        data, addr = in_sock.recvfrom(1280)  # Max recieve size is 1280 bytes
        commandArgs = data.split(',')
        command = commandArgs[0].strip()
        if len(commandArgs) > 1:
            value = commandArgs[1].strip()
        else:
            value = "NO_DATA_RECIEVED"

        print "received message: ", command, " ", value
        preform_udp_message_action(command, value)
    except:  # fail after 2 second of no activity
        print("Didn't receive data! [Timeout]")

# Parses UDP messages from UI, and preforms action based on message
def preform_udp_message_action(command, value):
    global motionDetectionControllInput
    global cameraSensitivity

    print "performing udp action, command:"
    print command
    print "value: "
    print value

    if (command == "$MOTION_DETECT" and value == "ON"):
        print "turning on motion detection"
        motionDetectionControllInput = 1
    elif (command == "$MOTION_DETECT" and value == "OFF"):
        print "turning off motion detection"
        motionDetectionControllInput = 0

    if (command == "$ROTATE" and value == "CW"):
        send_rotate_cw_serial_message()
    elif (command == "$ROTATE" and value == "CCW"):
        send_rotate_ccw_serial_message()

    if (command == "$IMAGE_CAPTURE"):
        take_picture()

    if (command == "$CAM_SENS"):
        cameraSensitivity = int(value)
        print "New camera sens: ", cameraSensitivity

# Updates system status based on GPIO inputs
def update_system_status():
    global localControllInput
    global motionDetectionControllInput
    global resetAlarmInput
    global motionDetection
    global alarmTriggered
    global out_sock
    global sendEmailWhenTriggered

    if (localControllInput == 0):
        GPIO.output(17, GPIO.LOW)
    else:
        GPIO.output(17, GPIO.HIGH)

    if (motionDetectionControllInput == 0):
        motionDetection = False
        GPIO.output(27, GPIO.LOW)
    else:
        motionDetection = True
        GPIO.output(27, GPIO.HIGH)

    if (resetAlarmInput == 1):
        alarmTriggered = False
        sendEmailWhenTriggered = True
        sendAlarmResetToBT()
        out_sock.sendto("$ALARM," + "RESET", (OUTGOING_UDP_IP, UDP_PORT))
        GPIO.output(22, GPIO.LOW)

    if (alarmTriggered):
        GPIO.output(22, GPIO.HIGH)

def take_picture():
    global cam
    global motionDetection

    turnBackMotionDetection = False

    if (motionDetection == True):
       motionDetection = False
       turnBackMotionDetection = True

    time.sleep(0.5)
    ret,img = cam.read()

    if (ret):
        cv2.imshow("Bilde", img)
        cv2.imwrite('Picture.jpg', img)
        print "Saved picture..."
    else:
        print("The camera is not working!")
        print("File not saved...")

    if (turnBackMotionDetection):
        motionDetection = True

def update_frame():
    global cam
    global frameCount
    global fgbg
    global alarmTriggered
    global out_sock
    global cameraSensitivity
    global sendEmailWhenTriggered

    ret, frame = cam.read()

    if (ret):
       frameCount += 1
       resizedFrame = cv2.resize(frame, (0, 0), fx=0.5, fy=0.5)
       fgmask = fgbg.apply(resizedFrame)
       count = np.count_nonzero(fgmask)

       if (frameCount > 1 and count > cameraSensitivity):
           print "motion detected!"
           alarmTriggered = True
           sendAlarmTriggeredToBT()
           out_sock.sendto("$ALARM," + "TRIGGERED", (OUTGOING_UDP_IP, UDP_PORT))
           if (sendEmailWhenTriggered == True):
               out_sock.sendto("Alarm triggered!", ("127.0.0.1", 9051))
               sendEmailWhenTriggered = False

def read_nunchuck():
    global cam
    global motionDetection

    try:
        bus.write_byte(address, 0x00)
        data0 = bus.read_byte(address)
        data1 = bus.read_byte(address)
        data2 = bus.read_byte(address)
        data3 = bus.read_byte(address)
        data4 = bus.read_byte(address)
        data5 = bus.read_byte(address)
        data = [data0, data1, data2, data3, data4, data5]
        joy_x = data[0]
        button_z = data[5]&0x01

        if (joy_x == 0):
            send_rotate_cw_serial_message()

        if (joy_x == 255):
            send_rotate_ccw_serial_message()

        if (button_z == 0):
            print "Z pressed"
            take_picture()

    except IOError as e:
        print e

init_UI()

while True:
    global showVideoCam
    global localControllInput
    global motionDetectionControllInput
    global motionDetection
    global cam

    if (cam) == None:
        print "Restarting camera"
        cam = cv2.VideoCapture(0)
        time.sleep(2)

    read_local_controll_input()
    read_reset_alarm()
    update_system_status()

    if (localControllInput == 1):
        read_nunchuck()
        read_motion_detection_input()
    else:
        read_udp_message()

    if (motionDetectionControllInput == 1):
        update_frame()
