from ..Object.Map import Map
from ..Object.Store import Store
from ..Object.Vechicle import Vechicle
import random


class MapGenerator:
    def __init__(self) -> None:
        pass

    def generate(self, storesNumber=None, vechiclesNumber=None) -> Map:
        if storesNumber is None:
            storesNumber = random.randint(5, 10)

        if vechiclesNumber is None:
            vechiclesNumber = random.randint(3, 6)

        map = Map()

        for i in range(0, storesNumber):
            x = random.randint(Map.MIN_X, Map.MAX_X)
            y = random.randint(Map.MIN_X, Map.MAX_Y)
            point = Store(x, y)
            map.addPoint(point)

        for i in range(0, vechiclesNumber):
            x = random.randint(Map.MIN_X, Map.MAX_X)
            y = random.randint(Map.MIN_X, Map.MAX_Y)
            point = Vechicle(x, y)
            map.addPoint(point)

        return map
