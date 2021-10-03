using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> arrList = new List<char>();

            Console.Write("Введите первую строку: ");
            String s1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            String s2 = Console.ReadLine();

            char[] c1 = s1.ToCharArray();
            char[] c2 = s2.ToCharArray();

            for (int i = 0; i < c1.Length; i++)
            {
                for (int j = 0; j < c2.Length; j++)
                {
                    if (c1[i] == c2[j])
                    {
                        arrList.Add(c1[i]);
                        break;
                    }
                }

                arrList.Add(c1[i]);
            }

            String finalStr = new String(arrList.ToArray());
            Console.WriteLine(finalStr);

        }
    }
}
