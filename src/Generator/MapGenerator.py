from ..Object.Map import Map
from ..Object.Store import Store
from ..Object.Vechicle import Vechicle
import random

class MapGenerator:
    def __init__(self) -> None:
        pass

    def generate(self, storesNumber = None, vechiclesNumber = None) -> Map:
        if storesNumber is None:
            storesNumber = random.randint(5, 10)

        if vechiclesNumber is None:
            vechiclesNumber = random.randint(3, 6)

        map = Map()

        for i in range(1, storesNumber):
            x = random.randint(0, 100)
            y = random.randint(0, 100)
            point = Store(x, y)
            map.addPoint(point)

        for i in range(1, vechiclesNumber):
            x = random.randint(0, 100)
            y = random.randint(0, 100)
            point = Vechicle(x, y)
            map.addPoint(point)

        return map
