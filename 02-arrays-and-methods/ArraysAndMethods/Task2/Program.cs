using System;

namespace Task2
{
    class Program
    {
        const int ARRLEN = 2;

        public static int[,,] MakeArr()
        {
            int[,,] arr = new int[ARRLEN, ARRLEN, ARRLEN];
            Random rnd = new Random();

            for (int i = 0; i < ARRLEN; i++)
            {
                for (int j = 0; j < ARRLEN; j++)
                {
                    for (int k = 0; k < ARRLEN; k++)
                    {
                        arr[i, j, k] = rnd.Next(-100, 100);
                    }
                }
            }
            return arr;
        }

        public static void ReplacePositiveElementsWithZero(int[,,] arr)
        {
            for (int i = 0; i < ARRLEN; i++)
            {
                for (int j = 0; j < ARRLEN; j++)
                {
                    for (int k = 0; k < ARRLEN; k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        public static void PrintArray(int[,,] arr)
        {
            for (int i = 0; i < ARRLEN; i++)
            {
                for (int j = 0; j < ARRLEN; j++)
                {
                    for (int k = 0; k < ARRLEN; k++)
                    {
                        Console.WriteLine(arr[i, j, k]);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[,,] arr = new int[ARRLEN, ARRLEN, ARRLEN];
            arr = MakeArr();
            PrintArray(arr);
            //Console.WriteLine("----------------------------------------------------------");
            ReplacePositiveElementsWithZero(arr);
            PrintArray(arr);

        }
    }
}
