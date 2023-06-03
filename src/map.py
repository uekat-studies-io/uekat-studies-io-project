import random
from domain import *

class Map:
    MIN_X = 0
    MIN_Y = 0
    MAX_X = 100
    MAX_Y = 100

    def __init__(self) -> None:
        self.warehouses: list[Warehouse] = []
        self.stores: list[Store] = []
        self.cars: list[Vehicle] = []

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
            if isinstance(point, Warehouse):
                result.append(point)

        return result

    def getStores(self) -> list:
        result = []

        for point in self.getPoints():
            if isinstance(point, Vehicle):
                result.append(point)

        return result

    def getPointsFor(self, x: int, y: int):
        return filter(lambda point: point.getX() == x and point.getY() == y, self.points)

class MapGenerator:
    def __init__(self) -> None:
        pass

    def generate(self, storesNumber=None, vehiclesNumber=None) -> Map:
        if storesNumber is None:
            storesNumber = random.randint(5, 10)

        if vehiclesNumber is None:
            vehiclesNumber = random.randint(3, 6)

        map = Map()

        warehouse_x = random.randint(Map.MIN_X, Map.MAX_X)
        warehouse_y = random.randint(Map.MIN_X, Map.MAX_X)
        map.warehouses.append(Warehouse(warehouse_x, warehouse_y))

        for i in range(0, storesNumber):
            x = random.randint(Map.MIN_X, Map.MAX_X)
            y = random.randint(Map.MIN_X, Map.MAX_Y)
            car = Store(x, y)
            map.stores.append(car);

        for i in range(0, vehiclesNumber):
            x = random.randint(Map.MIN_X, Map.MAX_X)
            y = random.randint(Map.MIN_X, Map.MAX_Y)
            car = Vehicle(warehouse_x, warehouse_y) # cars start in the warehouse
            map.cars.append(car)

        return map