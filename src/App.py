from .Generator.MapGenerator import MapGenerator

class App:
    def __init__(self) -> None:
        self.map = MapGenerator().generate()

    def run(self) -> None:
        pass
