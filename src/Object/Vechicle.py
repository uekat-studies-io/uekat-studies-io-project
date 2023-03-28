from .Point import Point


class Vechicle(Point):
    def __init__(self, x: int, y: int) -> None:
        super().__init__(x, y, 'o')
