from .Point import Point
from .Store import Store
from .Vechicle import Vechicle


class Map:
    MIN_X = 0
    MIN_Y = 0
    MAX_X = 100
    MAX_Y = 100

    def __init__(self) -> None:
        self.points = []

    def addPoint(self, point: Point):
        if point.getX() not in range(self.MIN_X, self.MAX_X + 1) or point.getY() not in range(self.MIN_Y, self.MAX_Y + 1):
            raise Exception("Store out of map range: (" +
                            str(point.getX()) + "; " + str(point.getY()) + ")")

        self.points.append(point)

    def getPoints(self) -> list:
        return self.points

    def getStores(self) -> list:
        result = []

        for point in self.getPoints():
            if isinstance(point, Store):
                result.append(point)

        return result

    def getStores(self) -> list:
        result = []

        for point in self.getPoints():
            if isinstance(point, Vechicle):
                result.append(point)

        return result

    def getPointsFor(self, x: int, y: int):
        return filter(lambda point: point.getX() == x and point.getY() == y, self.points)
