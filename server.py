#!/usr/bin/python
from qrcode import *
import PIL
from PIL import Image
import shutil
import os
import socket
import netifaces
import subprocess
import threading
import time

def checkDir():
    if not os.path.exists("resources"):
        os.makedirs("resources")
def getIp(osName):
    if not osName == "nt":
        address = netifaces.ifaddresses('wlan0')[netifaces.AF_INET][0]['addr']
        return address
    else:
        hostname = socket.gethostname()
        IP = socket.gethostbyname(hostname)
        return IP

def generateQr():
    qr = QRCode(version=2, error_correction=ERROR_CORRECT_L)
    osName = os.name
    qr.add_data('http://' + getIp(osName))
    qr.make()
    im = qr.make_image()
    im.save("qr_code.jpg")

    basewidth = 300
    img = Image.open('qr_code.jpg')
    wpercent = (basewidth / float(img.size[0]))
    hsize = int((float(img.size[1]) * float(wpercent)))
    img = img.resize((basewidth, hsize), PIL.Image.ANTIALIAS)
    img.save('qr_small.jpg')

def copyQr():
    for num in range (0,4):
        name = "resources/" + str(num) + ".jpg"
        shutil.copy('qr_small.jpg', name)


def startMjpeg():
    os.system("python app.py")
    #os.system("node app.js")
    #pass

def startBasic(osName):
    print "Basic"
    if not osName == "nt":
        print "Mono"
        os.system("mono serverTest.exe")
    else:
        print "Windows"
        os.system("serverTest.exe")

def startNode(osName):
    print "Node"
    quit = 0
    execNode = False
    print "Nacisnij [p] dla Python (stara wersja) \nNacisnij [n] dla NodeJS (nowa wersja)"
    while quit == 0:
        python = set('p')
        node = set('n')
        choice = raw_input().lower()
        if choice in python:
            execNode = False
            quit = 1
        elif choice in node:
            execNode = True
            quit = 1
        else:
            print "Prosze wybrac odpowiednia opcje:\n[p] - Python\n[n] - NodeJS"
            quit = 0
    if not  osName == "nt":
        if execNode == True:
            os.system("node app.js &")
        else:
            os.system("python app.py &")
    else:
        #os.startfile("node app.js")
        if execNode == True:
            child_process = subprocess.Popen("node app.js")
        else:
            child_process = subprocess.Popen("python app.py")

def main():
    checkDir()
    generateQr()
    copyQr()
    osName = os.name
    startNode(osName)

    while True:
        print "Basic"
        startBasic(osName)
        #os.system("mono serverTest.exe")
        print "Generate QR"
        copyQr()

if __name__ == "__main__":
    main()
