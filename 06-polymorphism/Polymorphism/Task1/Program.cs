using System;

namespace Task1
{
    abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Exception e = new Exception();
        public abstract void Draw();
    }

    class Rectangle : Figure
    {
        private int _a = 0, _b = 0, _c = 0;
        
        public override void Draw()
        {
            Console.WriteLine("Rectangle " + _a + " " + _b + " " + _c);
        }

        public Rectangle(int x, int y, int a, int b, int c)
        {
            if ((a + b) > c && (b + c) > a && (a + c) > b && a > 0 && b > 0 && c > 0)
            {
                X = x;
                Y = y;
                _a = a;
                _b = b;
                _c = c;
            }
            else
            {
                throw e;
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

        public Circle(int x, int y, int radius)
        {
            if (radius > 0)
            {
                _radius = radius;
            }
            else throw e;
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

        public Line(int x, int y, int x1, int y1)
        {
            X = x;
            Y = y;
            X1 = x1;
            Y1 = y1;
        }
    }

    class Round : Figure
    {
        private int _radius = 0;
        public override void Draw()
        {
            Console.WriteLine("Round: Радиус: " + _radius + "Площадь: " + Math.PI * Math.Pow(_radius, 2));
        }

        public Round(int x, int y, int radius)
        {
            if (radius > 0)
            {
                _radius = radius;
            }
            else throw e;
        }
    }

    class Ring : Figure
    {
        private int _radius = 0;
        private int _innerRadius = 0;

        public override void Draw()
        {
            Console.WriteLine("Ring: " + "Radius: " + _radius + " Inner radius: " + _innerRadius);
        }

        public Ring(int x, int y, int radius, int innerRadius)
        {
            if ((radius > 0) && (innerRadius < radius))
            {
                _radius = radius;
                _innerRadius = innerRadius;
            }
            else throw e;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Figure[] figures = { new Rectangle(0, 0, 3, 4, 5), new Circle(0, 0, 5), new Line(0, 0, 1, 1), new Round(0, 0, 1), new Ring(0, 0, 7, 5) };


            for (int i = 0; i < figures.Length; i++)
            {
                figures[i].Draw();
            }
        }
    }
}
