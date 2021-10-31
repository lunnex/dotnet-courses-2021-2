using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
	class TwoDPointWithHash : TwoDPoint
	{
		public TwoDPointWithHash(int x, int y) : base(x, y)
		{ }

		public override int GetHashCode()
		{
			return HashCode.Combine(x, y);

		}
	}
}
