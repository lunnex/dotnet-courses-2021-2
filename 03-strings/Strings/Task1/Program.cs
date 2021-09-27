using System;

namespace Test1
{
    class Program
    {

        public static char[] RemovePunct(char[] chArr)
        {
            char[] charArrWithoutPunct = new char[chArr.Length];
            int counter = 0;
            foreach (char ch in chArr)
            {
                if (!char.IsPunctuation(ch))
                {
                    charArrWithoutPunct[counter] = ch;
                    counter++;
                }
            }
            return charArrWithoutPunct;
        }

        public static int SpaceCounter(char[] chArr)
        {
            int spaceCounter = 0;

            foreach (char ch in chArr)
            {
                if (ch == ' ')
                    spaceCounter++;
            }

            return spaceCounter;
        }
        static void Main(string[] args)
        {
            String str = Console.ReadLine();
            str = str.Trim();
            int quantityOfSpaces;
            char[] chars = str.ToCharArray();
            int wordLen = 0;
            double medLen = 0.0d;
            int counter = 0;

            chars = RemovePunct(chars);
            quantityOfSpaces = SpaceCounter(chars);
            String s = new String(chars);

            String[] strings = new String[quantityOfSpaces];
            strings = s.Split(" ");

            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = strings[i].Replace("\0", "");
            }

            foreach (String st in strings)
            {
                wordLen += st.Length;
            }

            Console.WriteLine((double)wordLen / (quantityOfSpaces + 1));


        }
    }
}
