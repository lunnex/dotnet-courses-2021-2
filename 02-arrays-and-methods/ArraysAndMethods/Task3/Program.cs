using System;

namespace Task3
{
    class Program
    {
        public const int ARRLEN = 9;
        public static int[] GenerateArray()
        {
            Random rnd = new Random();

            int[] arr = new int[ARRLEN];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-10, 10);
            }
            return arr;
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public static int GetSumOfNonNegativeElements(int[] arr)
        {
            int sum = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    sum += arr[i];
                }
            }

            return sum;
        }

        static void Main(string[] args)
        {
            int[] arr = GenerateArray();
           // arr = GenerateArray();
            PrintArray(arr);
            Console.WriteLine($"Сумма неотрицательных элементов: {GetSumOfNonNegativeElements(arr)}");
        }
    }
}
