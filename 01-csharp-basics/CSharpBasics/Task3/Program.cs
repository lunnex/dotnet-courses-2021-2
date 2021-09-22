using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            String str = "*"; //Строка звездочек

            Console.WriteLine("Программа, которая выводит ёлочку. Необходимо ввести целое число, которое больше нуля");

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

            char[] emptStr = new char[(int)a]; //Строка пробелов

            for (int i = 0; i < a-1; i++)
            {
                emptStr[i] = ' ';
            }

            for (int i = 0; i < a; i++)
            {
                string finEmptStr = new string(emptStr); //Получаем строку из массива символов
                Console.WriteLine(finEmptStr + str + finEmptStr);
                emptStr[i] = '\0'; //Один пробел превращаем в пустой символ
                str += "**";
            }

        }
    }
}
