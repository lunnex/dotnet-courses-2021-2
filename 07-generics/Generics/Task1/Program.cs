using System;

namespace Task1
{
    class DynamicArray<T> where T : new()
    {
        public T[] array;
        public DynamicArray()
        {
            array = new T[8];
        }

        public DynamicArray(int size)
        {
            array = new T[size];
        }

        public DynamicArray(T[] input)
        {
            array = new T[input.Length];
            Array.Copy(array, input, input.Length);
        }

        public int Length()
        {
            int countOfNotNulls = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[countOfNotNulls] == null)
                {
                    break;
                }
                countOfNotNulls++;
            }
            return countOfNotNulls;
        }

        public int Capacity()
        {
            return array.Length;
        }

        public void Add(T input)
        {
            
            if (this.Capacity() == this.Length())
            {
                 Array.Resize(ref array, array.Length * 2);
            }
            this.array[this.Length()] = input;
        }

        public void AddRange(T[] input)
        {
            int length = this.Length();
            if (this.Capacity() < this.Length() + input.Length)
            {
                Array.Resize(ref array, this.Length() + input.Length);
            }
            for (int i = length; i < length + input.Length; i++)
            {

                array[i] = input[i - this.Length()];
            }
        }

        public bool Remove (T input) 
        {
            bool flag = false;
            int? index = Array.IndexOf(array, input);
            if (index == null)
            {
                flag = false;
            }
            else
            {
                for (int i = (int)index; i < this.Length()-1; i++)
                {
                    array[i] = array[i + 1];
                    Array.Resize(ref array, this.Length()-1);
                    flag = true;
                }
            }
            return flag;
        }

        public void Insert(T input, int index)
        {


            if (index > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Capacity() == this.Length())
            {
                Array.Resize(ref array, this.Capacity() + 1);
            }


            for (int i = this.Length(); i > index; i--)
            {
                array[i] = array[i-1];
            }
            array[index] = input;
        }

        public T this[int i]
        {
            get
            {
                return array[i];
            }

            set
            {
                this[i] = value;
            }
        }
    }

    class AuxiliaryClass
    {
        public virtual void print()
        {
            Console.WriteLine("ddddd");
        }
    }

    class AuxiliaryClass1 : AuxiliaryClass
    {
        public override void Print()
        {
            Console.WriteLine("aaaa");
        }
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
            dArr.Insert(cl2, dArr.Length());
            Console.WriteLine(dArr[dArr.Length()-1]);
            dArr.Remove(cl1);
            Console.WriteLine(dArr[3]);
            //dArr.Remove(cl3);
        }
    }
}
