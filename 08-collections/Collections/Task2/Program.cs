using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    class DynamicArray<T> : IEnumerable<T> where T : new()
    {
        private T[] array;
        private DynamicArray<T> _dynamicArray;
        private int index;

        public DynamicArray()
        {
            array = new T[8];
            Length = 0;
        }

        public DynamicArray(int size)
        {
            array = new T[size];
            Length = 0;
        }

        public DynamicArray(T[] input)
        {
            array = new T[input.Length];
            Array.Copy(array, input, input.Length);
            Length = input.Length;
        }

        public DynamicArray(IEnumerable<T> enumerable)
        {
            int size = 0;
            IEnumerator enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                size++;
            }
            enumerator.Reset();

            array = new T[size];

            for (int i = 0; i < size; i++)
            {
                enumerator.MoveNext();
                array[i] = (T)enumerator.Current;
            }

        }

        public int Length { get; set; }

        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }

        public void Add(T input)
        {

            if (Capacity == Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
            array[Length] = input;
            Length++;
        }

        public void AddRange(T[] input)
        {
            int length = Length;
            if (Capacity < Length + input.Length)
            {
                Array.Resize(ref array, Length + input.Length);
            }
            for (int i = length; i < length + input.Length; i++)
            {

                array[i] = input[i - Length];
            }
            Length += input.Length;
        }

        public bool Remove(T input)
        {
            int index = Array.IndexOf(array, input);
            if (index == -1)
            {
                return false;
            }
            for (int i = (int)index; i < Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            Length -= 1;
            return true;
        }

        public void Insert(T input, int index)
        {


            if (index > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Capacity == Length)
            {
                Array.Resize(ref array, Capacity + 1);
            }


            for (int i = Length; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = input;
            Length++;
        }

        public T this[int i]
        {
            get
            {
                if (i > Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return array[i];
            }

            set
            {
                if (i > Length)
                {
                    throw new IndexOutOfRangeException();
                }
                array[i] = value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                MoveNext();
                yield return array[index];
            }
            Reset();
        }

        public void Reset()
        {
            index = -1;
        }

        public bool MoveNext()
        {
            if (array[index])
            index++;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            DynamicArray<int> dymamicArray = new DynamicArray<int>(list);

            foreach(int i in dymamicArray)
            {
                Console.WriteLine(i);
            }

        }
    }
}

