from enum import Enum

class Product(Enum):
    GenericProduct = 1

class Point:
    def __init__(self, x: int, y: int, marker: str) -> None:
        self.x = x
        self.y = y
        self.marker = marker

    def getX(self) -> int:
        return self.x

    def getY(self) -> int:
        return self.y

    def getMarker(self) -> str:
        return self.marker
    
class Warehouse(Point):
    def __init__(self, x: int, y: int) -> None:
        super().__init__(x, y, 'Warehouse')

class Store(Point):
    def __init__(self, x: int, y: int, need: dict[Product, int]) -> None:
        super().__init__(x, y, 'Store')
        self.need = need

class Vehicle(Point):
    def __init__(self, x: int, y: int) -> None:
        super().__init__(x, y, 'o')
        self.carrying: dict[Product, int] = {}
        self.capacity: int = 1000;