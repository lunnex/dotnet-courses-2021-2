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

        public Circle(int radius, int x, int y)
        {
            Radius = radius;
            X = x;
            Y = y;
        }

        int Radius
        {
            get
            {
                return (_radius);
            }
            set
            {
                if (value > 0)
                {
                    _radius = value;
                }
                else
                {
                    throw e;
                }
            }
        }

        int X{ get; set; }


        int Y { get; set; }

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

    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(-1, 0, 0);
            Console.WriteLine(circle.Circumference);
            Console.WriteLine(circle.Area);
        }
    }
}
