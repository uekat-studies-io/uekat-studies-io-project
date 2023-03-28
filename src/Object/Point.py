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
