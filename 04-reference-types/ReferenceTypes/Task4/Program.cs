using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class MyString
    {
        public char[] value;
        public MyString()
        {
            value = new char[0];
        }

        public MyString (string s)
        {
            value = new char[s.Length];
            for(int i  = 0; i < value.Length; i++)
            {
                value[i] = s[i];
            }
        }

        public MyString (char[] charArr)
        {
            string str = new string(charArr);
            value = new char[charArr.Length];
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = charArr[i];
            }
        }


        public static MyString operator + (MyString prevStr, string addStr)
        {
            char[] bubbleCharArray = new char[prevStr.value.Length];
            prevStr.value.CopyTo(bubbleCharArray, 0);
            prevStr.value = new char[prevStr.value.Length + addStr.Length];
            bubbleCharArray.CopyTo(prevStr.value, 0);
            for (int i = bubbleCharArray.Length; i < prevStr.value.Length; i++)
            {
                prevStr.value[i] = addStr[i - bubbleCharArray.Length];
            }

            return prevStr;
        }

        public static bool operator == (MyString firstStr, MyString secondStr)
        {
            bool flag = true;

            if (firstStr.value.Length == secondStr.value.Length)
            {
                for (int i = 0; i < firstStr.value.Length; i++)
                {
                    if (firstStr.value[i] != secondStr.value[i])
                    {
                        flag = false;
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }


        //TODO Переопределить Equals

        public static bool operator != (MyString firstStr, MyString secondStr)
        {
            bool flag = false;

            if (firstStr.value.Length == secondStr.value.Length)
            {
                for (int i = 0; i < firstStr.value.Length; i++)
                {
                    if (firstStr.value[i] != secondStr.value[i])
                    {
                        flag = true;
                        break;
                    }
                }
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public override bool Equals(Object obj)
        {
            bool flag = true;

            if (obj == null)
            {
                flag = false;
            }

            MyString ms = obj as MyString;

            if (this.value.Length == ms.value.Length)
            {
                for (int i = 0; i < this.value.Length; i++)
                {
                    if (this.value[i] != ms.value[i])
                    {
                        flag = false;
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public static MyString operator - (MyString prevStr, string subStr)
        {
            string valueStr = "";
            for (int i = 0; i < prevStr.value.Length; i++)
            {
                valueStr += prevStr.value[i];
            }

            if (valueStr.Contains(subStr))
            {
                int firstOccurrence = valueStr.IndexOf(subStr);
                valueStr = valueStr.Remove(firstOccurrence, firstOccurrence + subStr.Length);
            }
            prevStr.value = new char[valueStr.Length];
            for (int i = 0; i < valueStr.Length; i++)
            {
                prevStr.value[i] = valueStr[i];
            }

            return prevStr;
        }

        public static string ToString(MyString myString)
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < myString.value.Length; i++)
            {
                sb.Append(myString.value[i]);
            }
            string convertedStr = sb.ToString();
            return convertedStr;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            char[] ch = new char[5] { 'q', 'e', 'd', 'f', 'u'};
            MyString ms = new MyString("ffff");
            MyString ms2 = new MyString("ffff");
            MyString ms1 = new MyString("dafdaffar");
            MyString ms3 = new MyString(ch);
            MyString ns = new MyString();
            ms1 = ms1 - "daf";
            Console.WriteLine(MyString.ToString(ms1));
            ms1 = ms1 + "daf";
            Console.WriteLine(MyString.ToString(ms1));

            ns = ns + "aaa";
            Console.WriteLine(MyString.ToString(ns));

            Console.WriteLine(ms2 == ms);
            string str = MyString.ToString(ms2);
            Console.WriteLine(str);
            Console.WriteLine(MyString.ToString(ms3));

            Console.WriteLine(ms3.Equals(ms));
            Console.WriteLine(ms.Equals(ms2));


        }
    }
}
