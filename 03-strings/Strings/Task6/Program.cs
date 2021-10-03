using System;
using System.Text.RegularExpressions;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regularNumber = new Regex(@"^((\d+\.\d*)|([+-]?\d+)|([-+]\d+\.\d+))$");
            Regex sienceNumber = new Regex(@"^(([+-]?\d+\.?\d*e[+-]?\d+))$");

            String input = Console.ReadLine();

            if (regularNumber.IsMatch(input) && !sienceNumber.IsMatch(input))
            {
                Console.WriteLine("Это число в обычной нотации");
            }
            else if (sienceNumber.IsMatch(input))
            {
                Console.WriteLine("Это число в научной нотации");
            }
            else
            {
                Console.WriteLine("Это не число");
            }
        }
    }
}
