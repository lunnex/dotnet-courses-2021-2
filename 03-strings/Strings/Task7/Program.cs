using System;
using System.Text.RegularExpressions;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex timeRegex = new Regex(@"(([0-9]:[0-5][0-9])|([0-1][0-9]:[0-5][0-9])|(2[0-3]:[0-5][0-9]))");

            String input = Console.ReadLine();

            var matches = timeRegex.Matches(input);

            Console.WriteLine($"Время в тексте присутствует {matches.Count} раз.") ;
        }
    }
}
