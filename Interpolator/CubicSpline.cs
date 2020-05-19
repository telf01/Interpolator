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

		public double Solve(Vector<double> vector, double t)
		{
			double answer = vector[0] + vector[1] * t + vector[2] * Math.Pow(t, 2) + vector[3] * Math.Pow(t, 3);
			return answer;
		}
	}
}
