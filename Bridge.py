# Abstraction
class Shape:
    def __init__(self, draw):
        self._draw = draw

    def draw(self):
        pass


# Implementor
class IDraw:
    def draw_triangle(self, a, b, c):
        pass


# Concrete implementor
class Draw1(IDraw):
    def draw_triangle(self, a, b, c):
        print(f"Креслимо синій трикутник... Сторона a {a}, сторона b {b}, сторона c {c}")


# Concrete implementor
class Draw2(IDraw):
    def draw_triangle(self, a, b, c):
        print(f"Креслимо зелений трикутник... Сторона a {a}, сторона b {b}, сторона c {c}")


# Refined abstraction
class Triangle(Shape):
    def __init__(self, a, b, c, draw):
        super().__init__(draw)
        self._a = a
        self._b = b
        self._c = c

    def draw(self):
        self._draw.draw_triangle(self._a, self._b, self._c)


def main():
    blue_triangle = Triangle(10, 10, 10, Draw1())
    green_triangle = Triangle(8, 9, 10, Draw2())

    blue_triangle.draw()
    green_triangle.draw()


if __name__ == "__main__":
    main()
