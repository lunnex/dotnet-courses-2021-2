using System;

namespace Task2
{

    class Circle
    {
        private int _radius;
        private int _x;
        private int _y;
        private double _len;
        private double _square;
        Exception e = new ArgumentException();

        int Radius
        {
            get
            {
                return (_radius);
            }
            set
            {
                if (_radius > 0)
                {
                    _radius = value;
                }
                else
                {
                    throw e;
                }
            }
        }

        int X
        {
            get
            {
                return (_x);
            }
            set
            {
                _x = value;
            }
        }

        int Y
        {
            get
            {
                return (_y);
            }
            set
            {
                _y = value;
            }
        }

        public double Circumference
        {
            get
            {
                return 2 * Math.PI * _radius;
            }
        }

        public double Area
        {
            get
            {
                return Math.PI * Math.Pow(_radius, 2);
            }
        }

        public Circle(int radius, int x, int y)
        {
            Radius = radius;
            X = x;
            Y = y;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(1, 0, 0);
            Console.WriteLine(circle.Circumference);
            Console.WriteLine(circle.Area);
        }
    }
}
