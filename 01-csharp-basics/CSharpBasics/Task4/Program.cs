using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            String str = "*"; //Строка звездочек
            //String emptStr = ""; //Строка пробелов

            Console.WriteLine("Программа, которая выводит ёлочку из ёлочек. Необходимо ввести целое число, которое больше нуля");

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

            //char[] emptStr = new char[(int)a]; //Строка пробелов
            int? b = a;

            for (int j = 0; j < a; j++)
            {
                char[] emptStr = new char[(int)a]; //Строка пробелов

                for (int i = 0; i < j+1; i++)
                {
                    for (int k = 0; k < emptStr.Length - 1; k++)
                    {
                        emptStr[k] = ' '; //Заполняем строку пробелов
                    }

                    string finEmptStr = new string(emptStr); //Получаем строку из массива символов
                    finEmptStr = finEmptStr.Replace("\0", "");
                    Console.WriteLine(finEmptStr + str);
                    emptStr = new char[(int)a - i -1]; //Cоздаём новый массив
                    str += "**";
                }

                //emptStr = new char[(int)a]; //Создаем пустой массив для пробелов
                str = "*";
                b--;

            }
        }
    }
}
