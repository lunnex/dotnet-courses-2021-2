using System;

namespace Task1
{
    abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Figure (int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract void Draw();
    }

    class Triangle : Figure
    {
        private int _a = 0, _b = 0, _c = 0;
        
        public override void Draw()
        {
            Console.WriteLine("Rectangle " + _a + " " + _b + " " + _c);
        }

        public Triangle(int x, int y, int a, int b, int c) : base (x,y)
        {
            if ((a + b) > c && (b + c) > a && (a + c) > b && a > 0 && b > 0 && c > 0)
            {
                _a = a;
                _b = b;
                _c = c;
            }
            else
            {
                throw new Exception();
            }
        }
    }

    class Circle : Figure
    {
        private int _radius = 0;
        public override void Draw()
        {
            Console.WriteLine("Circle: " + _radius);
        }

        public Circle(int x, int y, int radius) : base(x, y)
        {
            if (radius > 0)
            {
                _radius = radius;
            }
            else throw new Exception();
        }

    }

    class Line : Figure
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public override void Draw()
        {
            Console.WriteLine("Line: X Начало : " + X + " Y Начало : " + Y + " X Конец : " + X1 + " Y Конец : " + Y1 );
        }

        public Line(int x, int y, int x1, int y1) : base(x, y)
        {
            X1 = x1;
            Y1 = y1;
        }
    }

    class Round : Figure
    {
        public int Radius = 0;
        public override void Draw()
        {
            Console.WriteLine("Round: Радиус: " + Radius + "Площадь: " + Math.PI * Math.Pow(Radius, 2));
        }

        public Round(int x, int y, int radius) : base(x, y)
        {
            if (radius > 0)
            {
                Radius = radius;
            }
            else throw new Exception();
        }
    }

    class Ring : Round
    {
        private int _innerRadius = 0;

        public override void Draw()
        {
            Console.WriteLine("Ring: " + "Radius: " + Radius + " Inner radius: " + _innerRadius);
        }

        public Ring(int x, int y, int radius, int innerRadius) : base(x, y, radius)
        {
            if ((radius > 0) && (innerRadius < radius))
            {
                _innerRadius = innerRadius;
            }
            else throw new Exception();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Figure[] figures = { new Triangle(0, 0, 3, 4, 5), new Circle(0, 0, 5), new Line(0, 0, 1, 1), new Round(0, 0, 1), new Ring(0, 0, 7, 5) };


            for (int i = 0; i < figures.Length; i++)
            {
                figures[i].Draw();
            }
        }
    }
}
