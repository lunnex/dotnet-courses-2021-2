using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
	class TwoDPoint : Object
	{
		public readonly int x, y;

		public TwoDPoint(int x, int y)  //constructor
		{
			this.x = x;
			this.y = y;
		}

		public override bool Equals(Object obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// If parameter cannot be cast to Point return false.
			TwoDPoint p = obj as TwoDPoint;
			if ((Object)p == null)
			{
				return false;
			}

			// Return true if the fields match:
			return (x == p.x) && (y == p.y);
		}

		public bool Equals(TwoDPoint p)
		{
			// If parameter is null return false:
			if ((object)p == null)
			{
				return false;
			}

			// Return true if the fields match:
			return (x == p.x) && (y == p.y);
		}

		public static bool operator ==(TwoDPoint a, TwoDPoint b)
		{
			// If both are null, or both are same instance, return true.
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)a == null) || ((object)b == null))
			{
				return false;
			}

			// Return true if the fields match:
			return a.x == b.x && a.y == b.y;
		}

		public static bool operator !=(TwoDPoint a, TwoDPoint b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			return string.Format("x:{0} y:{1}", x, y);
		}
	}
	class Program
    {
		public class HashCodeDemo
		{
			public static void Demo(string[] args)
			{
				TwoDPoint point1 = new TwoDPoint(1, 10);
				TwoDPoint point2 = new TwoDPoint(1, 10);

				Console.WriteLine("Hash for point1: {0}\tHash for point2: {1}", point1.GetHashCode(), point2.GetHashCode());

				TwoDPointWithHash newPoint1 = new TwoDPointWithHash(1, 10);
				TwoDPointWithHash newPoint2 = new TwoDPointWithHash(1, 10);

				Console.WriteLine("Hash for point1: {0}\tHash for point2: {1}", newPoint1.GetHashCode(), newPoint2.GetHashCode());

				// уникальных точек будет 2, хотя координаты их одинаковы
				Console.WriteLine("TwoDPoint:");

				var twoDPointList = new List<TwoDPoint> { point1, point2 };
				var distinctTwoDPointList = twoDPointList.Distinct();
				foreach (var point in distinctTwoDPointList)
				{
					Console.WriteLine("Distinct point: {0}", point);
				}

				// одна уникальная точка
				Console.WriteLine("TwoDPointWithHash:");

				var twoDPointWithHashList = new List<TwoDPointWithHash> { newPoint1, newPoint2 };
				var distinctTwoDPointWithHashList = twoDPointWithHashList.Distinct();
				foreach (var point in distinctTwoDPointWithHashList)
				{
					Console.WriteLine("Distinct point: {0}", point);
				}
			}
		}

		class TwoDPointWithHash : TwoDPoint
		{
			public TwoDPointWithHash(int x, int y) : base(x, y)
			{ }

			public override int GetHashCode()
			{
				return HashCode.Combine(x, y); // ^ выполняет операцию логического исключающего XOR побитно

				// в чем тут проблема?
			}
		}

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
			Console.WriteLine(object1 == object2); // false !!!! почему?

			// в чем разница определений методов Equals и == ?
		}
	}
}
