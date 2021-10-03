using System;
using System.Text.RegularExpressions;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"<.*?>");
            String input = Console.ReadLine();
            input = regex.Replace(input, "_");
            Console.WriteLine("Результат замены: " + input);
            // <div a=""><span>
        }
    }
}
