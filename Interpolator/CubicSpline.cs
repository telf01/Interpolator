using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Globalization;
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

		public Vector<double> CreateBaseMatrix()
		{
			int dataCount = Data.Count(); 
			double[,] matrix = new double[(dataCount - 1) * 4, (dataCount - 1) * 4];
			double[] answers = new double[(dataCount - 1) * 4];
			int pointerPosition = 0;
			int j = 0;
			for (int i = 0; i < (dataCount - 1); i++)
			{
				matrix[j, pointerPosition] = 1;
				j++;
				matrix[j, pointerPosition] = 1;
				matrix[j, ++pointerPosition] = Data[i + 1].X - Data[i].X;
				matrix[j, ++pointerPosition] = Math.Pow((Data[i + 1].X - Data[i].X), 2);
				matrix[j, ++pointerPosition] = Math.Pow((Data[i + 1].X - Data[i].X), 3);
				pointerPosition++;
				j++;
			}

			j = 0;
			for(int i = 0; i < (dataCount - 1); i++)
			{
				answers[j] = Data[i].Y;
				j++;
				answers[j] = Data[i + 1].Y;
				j++;
			}

			return null;
		}
	}
}
