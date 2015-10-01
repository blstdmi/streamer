from time import time

class ImageProcessing(object):
    def __init__(self):
        self.frames = [open('resources/' + f + '.jpg', 'rb').read() for f in ['0', '1', '2', '3']]

    def get_frame(self, num):
		return self.frames[int(num)]
