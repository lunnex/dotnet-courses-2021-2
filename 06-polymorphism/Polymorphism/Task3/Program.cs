using System;
using System.Collections.Generic;

namespace Task3
{
    public interface ISeries
    {
        double GetCurrent();
        bool MoveNext();
        void Reset();
    }

    public interface IIndexable
    {
        double this[int index] { get; }
    }

    interface IIndexableSeries : ISeries, IIndexable
    {

    }

    class ArithmeticProgression: IIndexableSeries
    {
        double start, step;
        int currentIndex;
        public List<double> listOfValues = new List<double>();

        public ArithmeticProgression(double start, double step)
        {
            this.start = start;
            this.step = step;
            this.currentIndex = 1;
            
        }

        public double GetCurrent()
        {
            listOfValues.Add( start + step * currentIndex);
            return start + step * currentIndex;
        }

        public bool MoveNext()
        {
            currentIndex++;
            return true;
        }

        public void Reset()
        {
            listOfValues.Clear();
            currentIndex = 1;
        }

        public double this[int index]
		{
			get { return listOfValues[index]; }
		}
    }

    class List : IIndexableSeries
    {
        private double[] series;
        private int currentIndex;

        public List(double[] series)
        {
            this.series = series;
            currentIndex = 0;
        }

        public double GetCurrent()
        {
            return series[currentIndex];
        }

        public bool MoveNext()
        {
            currentIndex = currentIndex < series.Length - 1 ? currentIndex + 1 : 0;
            return true;
        }

        public void Reset()
        {
            currentIndex = 0;
        }

        public double this[int index]
		{
			get { return series[index]; }
		}
    }

    class Program
    {
        public static void PrintSeries(ISeries series, int i)
        {
            for (int j = 0; j < i; j++)
            {
                
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }
        }

        public static void PrintIndexable(IIndexableSeries series, int i)
        {
            
            for (int j = 0; j < i; j++)
            {
                series.MoveNext();
                Console.WriteLine(series.GetCurrent());
            }
        }

        static void Main(string[] args)
        {
            ArithmeticProgression ap = new ArithmeticProgression(1, 1);
            PrintSeries(ap, 6);
            //ap.Reset();

            Console.WriteLine();

            double[] doubleSeries = new double[6];
            int counter = 0;
            while (counter < 6)
            {
                doubleSeries[counter] = ap[counter];
                
                counter++;
            }
            List list = new List(doubleSeries);

            PrintIndexable(list, 6);
        }
    }
}
