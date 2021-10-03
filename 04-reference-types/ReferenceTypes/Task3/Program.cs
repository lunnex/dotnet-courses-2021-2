using System;

namespace Task3
{
    class Triangle
    {
        private int _a;
        private int _b;
        private int _c;
        Exception e = new ArgumentException();

        public int A
        {
            set { _a = value; }
            get { return _a; }
        }

        public int B
        {
            set { _b = value; }
            get { return _b; }
        }

        public int C
        {
            set { _c = value; }
            get { return _c; }
        }

        public int GetPerimeter()
        {
            return _a + _b + _c;
        }

        public double GetArea()
        {
            return (Math.Sqrt(((double)GetPerimeter() / 2) * ((double)GetPerimeter() / 2 - _a) * ((double)GetPerimeter() / 2 - _b) * ((double)GetPerimeter() / 2 - _c)));
        }

        public Triangle(int a, int b, int c)
        {
            if ((a + b > c) && (a + c > b) && (b + c > a))
            {
                A = a;
                B = b;
                C = c;
            }
            else
            {
                throw e;
            }
        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(7, 5, 9);

            Console.WriteLine(triangle.GetPerimeter());
            Console.WriteLine(triangle.GetArea());
        }
    }
}
