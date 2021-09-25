using System;

namespace Task1
{
    class Task1
    {
        Random rnd = new Random();
        public const int ARRLEN = 9;

        public void PrintArray(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public int[] GenerateArray()
        {
            int[] arr = new int[ARRLEN];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 100);
            }
            return arr;
        }

        private void QuickSort(int[] arr, int beg, int end)
        {
            int l = (beg + end) / 2;    // Середина массива
            int left = beg;             // Левая граница массива
            int right = end-1;          // Правая граница массива
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
                    QuickSort(arr,beg, right);
                }
                if (end > left)
                {
                    QuickSort(arr, left, end);
                }
            }
        }

        public int[] SortAndGetMinAndMaxValues(int[] arr, out int min, out int max)
        {
            QuickSort(arr, 0, ARRLEN);

            min = arr[0];
            max = arr[arr.Length-1];

            return arr;
        }
    }

    class Program
    {
       
        static void Main(string[] args)
        {
            Task1 tsk = new Task1();

            int[] arr = new int[Task1.ARRLEN];
            int a;
            int b;

            arr = tsk.GenerateArray();
            tsk.PrintArray(arr);
            Console.WriteLine("-------------------------------------");
            arr = tsk.SortAndGetMinAndMaxValues(arr, out a, out b);
            tsk.PrintArray(arr);

        }
    }
}
