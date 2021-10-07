using System;

namespace Task2
{
    class Circle
    {
        private int _radius;
        public Exception e = new ArgumentException();

        public Circle(int radius, int x, int y)
        {
            Radius = radius;
            X = x;
            Y = y;
        }

        public int Radius
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

        public int X { get; set; }


        public int Y { get; set; }

        public virtual double Circumference
        {
            get
            {
                return 2 * Math.PI * Radius;
            }
        }

        public virtual double Area
        {
            get
            {
                return Math.PI * Math.Pow(Radius, 2);
            }
        }

    }

    class Ring : Circle
    {
        private int _innerRadius;
        public Ring( int radius, int x, int y, int innerRadius) : base (radius, x, y)
        {
            InnerRadius = innerRadius;
        }

        public int InnerRadius
        {
            get { return _innerRadius; }
            set { 
                if ((value > 0) && (Radius > value))
                {
                    _innerRadius = value;
                }
                else
                {
                    throw e;
                }
            }
        }

        public override double Circumference
        {
            get
            {
                return 2 * Math.PI * Radius + 2 * Math.PI * InnerRadius;
            }
        }

        public override double Area
        {
            get
            {
                return Math.PI * Math.Pow(Radius, 2) - Math.PI * Math.Pow(InnerRadius, 2);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Ring ring = new Ring(6, 0, 0, 2);
            Console.WriteLine(ring.Area);
            Console.WriteLine(ring.Circumference);
        }
    }
}
