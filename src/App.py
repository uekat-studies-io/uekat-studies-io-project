from .Generator.MapGenerator import MapGenerator
from .Generator.SheetGenerator import SheetGenerator


class App:
    def __init__(self) -> None:
        self.map = MapGenerator().generate()

    def run(self) -> None:
        SheetGenerator().generate(self.map, 'var/main.csv')
