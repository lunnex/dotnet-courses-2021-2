using System;
using MathLibrary;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            MathFunctions mathFunctions = new MathFunctions();
            Console.WriteLine(mathFunctions.Power(2, 2));
            Console.WriteLine(mathFunctions.Factorial(5));
        }
    }
}
