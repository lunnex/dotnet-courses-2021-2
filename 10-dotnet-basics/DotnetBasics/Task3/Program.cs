using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
	
	class Program
    {
		public static void Main(string[] args)
		{
			TwoDPoint point1 = new TwoDPoint(1, 10);
			TwoDPoint point2 = new TwoDPoint(1, 10);

			TwoDPointWithHash point3 = new TwoDPointWithHash(1, 10);
			TwoDPointWithHash point4 = new TwoDPointWithHash(10, 1);

			TwoDPointWithHash point5 = new TwoDPointWithHash(1, 1);
			TwoDPointWithHash point6 = new TwoDPointWithHash(10, 10);

			object object1 = (object)point1;
			object object2 = (object)point2;

			Console.WriteLine(point3.GetHashCode());
			Console.WriteLine(point4.GetHashCode());
			Console.WriteLine(point5.GetHashCode());
			Console.WriteLine(point6.GetHashCode());

			Console.WriteLine(point1.Equals(point2));
			Console.WriteLine(point1 == point2);

			Console.WriteLine(object1.Equals(object2));
			Console.WriteLine(object1 == object2); 
		}
	}
}
