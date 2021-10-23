﻿using System;
using System.Threading;

namespace Task3
{
    class Program
    {
        public static void Sort(string[] arr, Comparation comparation, Action callback)
        {
            bool flag = false;
            while (flag == false)
            {
                for (int i = 1; i < arr.Length; i++)
                {
                    flag = true;
                    if (comparation(arr[i - 1], arr[i]) == 1)
                    {
                        string allux = arr[i - 1];
                        arr[i - 1] = arr[i];
                        arr[i] = allux;
                        flag = false;
                        break;
                    }
                }
            }
            callback();
        }

        public static Thread SortAsync(string[] arr, Comparation comparation)
        {
            Action callback = () => OnEndOfSort(arr);
            Thread thread = new Thread(() => Sort(arr, comparation, callback));
            return thread;
        }

        public static int CompareStrings(string str1, string str2)
        {
            if (str1.Length > str2.Length)
            {
                return 1;
            }
            else if (str1.Length < str2.Length)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < str1.Length;)
                {
                    if (str1[i] > str2[i])
                    {
                        return 1;
                    }
                    else if (str1[i] < str2[i])
                    {
                        return -1;
                    }
                    else i++;
                }

            }
            return 0;
        }

        public static void OnEndOfSort(string[] arr)
        {
            foreach (string str in arr)
            {
                Console.WriteLine(str);
            }
        }

        public delegate int Comparation(string str1, string str2);

        static void Main(string[] args)
        {
            Comparation comparation = new Comparation(CompareStrings);
            string[] strArr = new string[] { "ac", "abc", "ab", "a" };

            Thread thread = SortAsync(strArr, comparation);

            thread.Start();
        }
    }
}
