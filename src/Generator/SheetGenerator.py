from ..Object.Map import Map
import csv


class SheetGenerator:
    def __init__(self) -> None:
        pass

    def generate(self, map: Map, dest: str) -> None:
        f = open(dest, "w")
        writer = csv.writer(f)

        for y in range(0, Map.MAX_Y + 1):
            row = []

            for x in range(0, Map.MAX_X + 1):
                cell = []

                points = map.getPointsFor(x, y)
                for point in points:
                    cell.append(str(point.getMarker()))

                row.append(''.join(cell))

            writer.writerow(row)
        f.close()
