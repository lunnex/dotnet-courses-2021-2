using System;

namespace Task4
{
    class Program
    {
        public const int ARRLEN = 2;
        public static int[,] MakeArr()
        {
            int[,] arr = new int[ARRLEN, ARRLEN];
            Random rnd = new Random();

            for (int i = 0; i < ARRLEN; i++)
            {
                for (int j = 0; j < ARRLEN; j++)
                {
                arr[i, j] = rnd.Next(-100, 100);
                }
            }
            return arr;
        }

        public static int GetSumOfElementsOnEvenPositions(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < ARRLEN; i++)
            {
                for (int j = 0; j < ARRLEN; j++)
                {
                    if (((i + j) % 2) == 0)
                    {
                        sum += arr[i, j];
                    }
                }
            }
            return sum;
        }

        public static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < ARRLEN; i++)
            {
                for(int j = 0; j < ARRLEN; j++)
                {
                    Console.WriteLine(arr[i, j]);
                }
            }
        }

        static void Main(string[] args)
        {
            int[,] arr = new int[ARRLEN, ARRLEN];
            arr = MakeArr();
            PrintArray(arr);
            Console.WriteLine($"Сумма элементов, стоящих на четных позициях: {GetSumOfElementsOnEvenPositions(arr)}");
        }
    }
}
