using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using static System.ArraySegment<T>;

namespace Task1
{
    class Program
    {
        static void RemoveEachSecondItem<T>(ICollection<T> l)
        {
            int i = 0;
            IEnumerator enumerator = l.GetEnumerator();
            enumerator.MoveNext();

            while (l.Count > 1)
            {
                enumerator = l.GetEnumerator();
                enumerator.MoveNext();
                while (l.Count >= i)
                {
                    if ((i % 2 == 0))
                    {
                        l.Remove((T)enumerator.Current);
                        enumerator = l.GetEnumerator();
                    }
                    i++;
                    enumerator.MoveNext();
                }
                i = 0;
            }
        }


        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            LinkedList<int> lList = new LinkedList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);

            lList.AddLast(5);
            lList.AddLast(6);
            lList.AddLast(7);
            lList.AddLast(8);
            lList.AddLast(9);

            RemoveEachSecondItem(list);
            RemoveEachSecondItem(lList);
            foreach (int t in list)
            {
                Console.WriteLine(t);
            }

            foreach (int t in lList)
            {
                Console.WriteLine(t);
            }
        }
    }
}
