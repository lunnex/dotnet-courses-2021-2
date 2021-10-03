using System;

namespace Task1
{
    class Program
    {
        public const int ARRLEN = 9;

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public static int[] GenerateArray()
        {
            Random rnd = new Random();
            int[] arr = new int[ARRLEN];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 100);
            }
            return arr;
        }

        private static void QuickSort(int[] arr, int beg, int end)
        {
            int l = (beg + end) / 2;    // Середина массива
            int left = beg;             // Левая граница массива
            int right = end - 1;          // Правая граница массива
            int a;                      // Вспомогательная переменная

            while (left < right)
            {

                while (arr[left] < arr[l])          // Ищем элемент, который больше опорного слева
                {
                    left++;
                }

                while (arr[right] > arr[l])         // Ищем элемент, который меньше опорного справа
                {
                    right--;
                }

                if (left <= right)                  // Меняем местами элементы
                {
                    a = arr[left];
                    arr[left] = arr[right];
                    arr[right] = a;
                }

                if (beg < right)                    // Пробегаемся, пока все элементы не будут на месте
                {
                    QuickSort(arr, beg, right);
                }
                if (end > left)
                {
                    QuickSort(arr, left, end);
                }
            }
        }

        public static int[] SortAndGetMinAndMaxValues(int[] arr, out int min, out int max)
        {
            //QuickSort(arr, 0, ARRLEN);

           // int bubble;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int bubble = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = bubble;
                    }
                }
            }

            min = arr[0];
            max = arr[arr.Length - 1];

            return arr;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[ARRLEN];
            int a;
            int b;

            arr = GenerateArray();
            PrintArray(arr);
            Console.WriteLine("-------------------------------------");
            arr = SortAndGetMinAndMaxValues(arr, out a, out b);
            PrintArray(arr);
            Console.WriteLine($"Минимальный элемент: {a}, Максимальный элемент: {b}");

        }
    }
}
