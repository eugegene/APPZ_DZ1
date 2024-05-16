using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1_Bridge
{
// Abstraction
    abstract class Shape
    {
        protected IDraw draw;
        protected Shape(IDraw draw)
        {
            this.draw = draw;
        }
        public abstract void Draw();
    }

    // Implementor
    interface IDraw
    {
        void DrawTriangle(int a, int b, int c);
    }

    // Concrete implementor
    class DrawBlueTriangle : IDraw
    {
        public void DrawTriangle(int a, int b, int c) 
        {
            Console.WriteLine($"Креслимо синій трикутник... Сторона а {a}, сторона b {b}, сторона c {c}");
        }
    }

    // Concrete implementor
    class DrawGreenTriangle : IDraw
    {
        public void DrawTriangle(int a, int b, int c) 
        {
            Console.WriteLine($"Креслимо зелений трикутник... Сторона а {a}, сторона b {b}, сторона c {c}");
        }
    }

    // Refined abstraction
    class Triangle : Shape
    {
        private int a, b, c;

        public Triangle(int a, int b, int c, IDraw draw) : base(draw)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override void Draw()
        {
            draw.DrawTriangle(a, b, c);
        }
    }
}
