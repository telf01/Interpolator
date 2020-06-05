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

		public Matrix<double> CalculateSplines()
		{
			int pointCount = Data.Count();
			List<double>[] splineMatrix = new List<double>[pointCount * 3];
			List<double> answerMatrix = new List<double>();
			int k = 0;

			for(int i = 0; i < pointCount - 1; i++)
			{
				splineMatrix[k] = new List<double>();

				splineMatrix[k].Add(1);
				splineMatrix[k].Add(Data[i].X - Data[i].X);
				splineMatrix[k].Add(Math.Pow(Data[i].X - Data[i].X, 2));
				splineMatrix[k].Add(Math.Pow(Data[i].X - Data[i].X, 3));
				
				answerMatrix.Add(Data[i].Y);

				k++;
				splineMatrix[k] = new List<double>();

				splineMatrix[k].Add(1);
				splineMatrix[k].Add(Data[i + 1].X - Data[i].X);
				splineMatrix[k].Add(Math.Pow(Data[i + 1].X - Data[i].X, 2));
				splineMatrix[k].Add(Math.Pow(Data[i + 1].X - Data[i].X, 3));

				answerMatrix.Add(Data[i + 1].Y);

				k++;
			}

			return null;
		}

		public double Solve(Vector<double> vector, double t)
		{
			double answer = vector[0] + vector[1] * t + vector[2] * Math.Pow(t, 2) + vector[3] * Math.Pow(t, 3);
			return answer;
		}
	}
}
