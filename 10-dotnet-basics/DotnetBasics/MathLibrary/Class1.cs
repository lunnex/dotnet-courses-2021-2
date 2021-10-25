using System;

namespace MathLibrary
{
    public class MathFunctions
    {
        public long Factorial(int x)
        {
            long factorial = 1;

            for (int i = 1; i <= x; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public double Power(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
}
