from .Point import Point


class Store(Point):
    def __init__(self, x: int, y: int) -> None:
        super().__init__(x, y, 'x')
