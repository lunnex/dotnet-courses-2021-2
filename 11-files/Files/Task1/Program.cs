using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    class Program
    {
        public static void ProcessFile(string path)
        {
            List<int?> list = new List<int?>();
            using (StreamReader streamReader = new StreamReader(path))
            {
                while(true)
                {

                    string readed = streamReader.ReadLine();

                    if (readed != null)
                    {
                        int.TryParse(readed, out int value);
                        list.Add(value * value);
                        Console.WriteLine("added " + value * value);
                    }
                    else
                    {
                        break;
                    }

                    
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                for(int i = 0; i < list.Count; i++)
                {
                    streamWriter.WriteLine(list[i]);
                }
            }

        }

        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            string pathFile = dirInfo.Parent.Parent.Parent.GetFiles("disp*")[0].ToString();
            ProcessFile(pathFile);
        }
    }
}