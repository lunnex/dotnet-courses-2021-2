using System;

namespace Task1
{
    class DynamicArray<T> where T : new()
    {
        private T[] array;
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
    }

    class AuxiliaryClass
    {

    }

    class AuxiliaryClass1 : AuxiliaryClass
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<AuxiliaryClass> dArr = new DynamicArray<AuxiliaryClass>();
            AuxiliaryClass[] clArr = new AuxiliaryClass[7] { new AuxiliaryClass(), new AuxiliaryClass(), new AuxiliaryClass(), new AuxiliaryClass(), new AuxiliaryClass(), new AuxiliaryClass(), new AuxiliaryClass() };
            AuxiliaryClass1 cl = new AuxiliaryClass1();
            AuxiliaryClass1 cl1 = new AuxiliaryClass1();
            AuxiliaryClass1 cl2 = new AuxiliaryClass1();
            AuxiliaryClass1 cl3 = new AuxiliaryClass1();
            dArr.AddRange(clArr);
            dArr.Insert(cl, 0);
            Console.WriteLine(dArr[0]);
            dArr.Insert(cl1, 3);
            Console.WriteLine(dArr[3]);
            dArr.Insert(cl2, dArr.Length);
            Console.WriteLine(dArr[dArr.Length - 1]);
            dArr.Remove(cl1);
            Console.WriteLine(dArr[3]);
            //dArr.Remove(cl3);
        }
    }
}
