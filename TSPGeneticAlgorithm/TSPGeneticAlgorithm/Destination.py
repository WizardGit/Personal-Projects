class Destination(object):
    """Class describing a destination's coordinates"""

    def __init__(self, x, y):
        self.x = x
        self.y = y   
    
    def __repr__(self):
        return "(" + str(self.x) + "," + str(self.y) + ")"


