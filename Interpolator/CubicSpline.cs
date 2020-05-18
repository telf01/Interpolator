using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolator
{
	class CubicSpline
	{
		List<(double X, double Y)> Data { get; set; }
		public CubicSpline(List<(double X, double Y)> data)
		{
			Data = data;
		}

		/// <summary>
		/// Method for finding 4 nearest neighbors for x.
		/// </summary>
		public (double, double)[] FindNeighbours(double x)
		{
			var temp = Data.OrderBy(b => Math.Abs(x - b.X)).ToList();
			(double, double)[] output = new (double, double)[4];
			for(int i = 0; i < 4; i++)
			{
				output[i] = temp[i];
			}
			return output;
		}
	}
}
