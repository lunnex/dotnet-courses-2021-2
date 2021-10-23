using System;

namespace Task1
{
    class Program
    {
        public static void Sort(string[] arr, Comparation comparation)
        {
            bool flag = false;
            while(flag == false)
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

        public delegate int Comparation(string str1, string str2);

        static void Main(string[] args)
        {
            Comparation comparation = new Comparation(CompareStrings);
            string[] strArr = new string[] { "ac", "abc", "ab", "a" };
            Sort(strArr, comparation);

            foreach(string str in strArr)
            {
                Console.WriteLine(str);
            }
        }
    }
}
