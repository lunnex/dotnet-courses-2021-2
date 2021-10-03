using System;
using System.Diagnostics;
using System.Text;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer1 = new Stopwatch();
            Stopwatch timer2 = new Stopwatch();
            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 1000;

            timer1.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            timer1.Stop();

            timer2.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            timer2.Stop();

            Console.WriteLine("String: " + timer1.Elapsed.TotalMilliseconds);
            Console.WriteLine("StringBuilder: " + timer2.Elapsed.TotalMilliseconds);
        }
    }
}
