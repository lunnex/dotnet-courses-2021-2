using System;

namespace Task2
{
    public interface ISeries
    {
        double GetCurrent();
        void Reset();
        bool MoveNext();
    }

    class GeometricProgression : ISeries 
    {
        double start, q;
        int index;

        public GeometricProgression(double start, double q)
        {
            this.start = start;
            this.q = q;
        }

        public double GetCurrent()
        {
            return start * Math.Pow(q, index -1);
        }

        public bool MoveNext()
        {
            index++;
            return true;
        }

        public void Reset()
        {
            index = 1;
        }


    }


    class Program
    {
        public static void PrintSeries(ISeries series, int i)
        {
            for (int j = 0; j < i; j++)
            {
                series.MoveNext();
                Console.WriteLine(series.GetCurrent());
            }
        }

        static void Main(string[] args)
        {
            GeometricProgression gp = new GeometricProgression(2, 2);
            PrintSeries(gp, 6);
        }
    }
}
