using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int ?a = null;
            String str = "";

            Console.WriteLine("Программа, которая выводит звездочки, выровненные по левому краю. Необходимо ввести целое число, которое больше нуля");

            while (a == null)
            {
                Console.WriteLine("Введите целое число");
                try
                {
                    a = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Значение неверно. Необходимо ввести целое число, которое больше нуля");
                }
                if (a <= 0)
                {
                    Console.WriteLine("Значение неверно. Необходимо ввести целое число, которое больше нуля");
                    a = null;
                }
            }
           
            do
            {
                str = str + "*";
                a--;
                Console.WriteLine(str);
            }
            while (a > 0);
        }
    }
}
