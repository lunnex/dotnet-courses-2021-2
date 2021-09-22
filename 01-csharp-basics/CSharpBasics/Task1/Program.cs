using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int ?a = null; //Длина первой стороны
            int ?b = null; //Длина второй стороны
            bool flg1 = false; //Флаг, который становится true, если первое значение введено правильно
            bool flg2 = false; //Флаг, который становится true, если второе значение введено правильно

            Console.WriteLine("Это программа, которая считает площадь прямоугольника. Сначала введите длину первой стороны, потом длину второй стороны. Значения должны быть целочисленными");

            while (flg1 == false)
            {
                try
                {
                    a = int.Parse(Console.ReadLine());
                }
                catch{ }

                if (a <= 0)
                {
                    Console.WriteLine("Такого прямоуголиника не существует. Допускается целочисленные положительные значения");
                    a = null;
                }
                else if (a == null) { }

                else
                {
                    flg1 = true;
                }
            }

            while (flg2 == false)
            {
                try
                {
                     b = int.Parse(Console.ReadLine());
                }
                catch{ }

                if (b <= 0)
                {
                    Console.WriteLine("Такого прямоуголиника не существует. Допускается целочисленные положительные значения");
                    b = null;
                }
                else if (b == null){ }
                
                else
                {
                    flg2 = true;
                }
            }

            Console.WriteLine(a*b);

        }
    }
}
