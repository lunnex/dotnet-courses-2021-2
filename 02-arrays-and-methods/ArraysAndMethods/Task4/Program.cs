using System;

namespace Task4
{
    class Program
    {
        //public const int ARRLEN = 2;
        public static int[,] MakeArr()
        {
            int[,] arr = { { 4, 7, 1, 8, 5, 2, 8}, {9,2,1,0,4,1,9 }, {1,7,0,1,7,1,9 } };
            Random rnd = new Random();
            return arr;
        }

        public static int GetSumOfElementsOnEvenPositions(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
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
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine(arr[i, j]);
                }
            }
        }

        static void Main(string[] args)
        {
            int[,] arr;
            arr = MakeArr();
            PrintArray(arr);
            Console.WriteLine($"Сумма элементов, стоящих на четных позициях: {GetSumOfElementsOnEvenPositions(arr)}");
        }
    }
}
