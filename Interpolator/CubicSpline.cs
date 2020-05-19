using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

		public Vector<double> SystemOfEquationSolver((double X, double Y)[] neighbours)
		{

			var AE = Matrix<double>.Build.DenseOfArray(new double[,] {
	{ 3, 2, -1 },
	{ 2, -2, 4 },
	{ -1, 0.5, -1 }
			});
			var bE = Vector<double>.Build.Dense(new double[] { 1, -2, 0 });
			var xE = AE.Solve(bE);



			double[,] aData = new double[4, 4];
			for(int i = 0; i < 4; i++)
			{
				for(int k = 0; k < 4; k++)
				{
					aData[i, k] = Math.Pow(neighbours[i].X, k);
				}
			}
			var a = Matrix<double>.Build.DenseOfArray(aData);
			double[] bData = new double[4];
			for (int i = 0; i < 4; i++)
			{
				bData[i] = neighbours[i].Y;
			}
			var b = Vector<double>.Build.DenseOfArray(bData);
			var x = a.Solve(b);
			return x;
		}

	}
}
