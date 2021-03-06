﻿using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.Drawing;
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

		/// <summary>
		/// Method that forms the basic system of linear equations.
		/// </summary>
		public (Matrix<double>, Vector<double>) CreateBaseMatrix()
		{
			int dataCount = Data.Count();
			double[,] matrix = new double[(dataCount - 1) * 2 + dataCount - 2 + dataCount -2 + 2, (dataCount - 1) * 2 + dataCount - 2 + dataCount - 2 + 2];
			double[] answers = new double[(dataCount - 1) * 2 + dataCount - 2 + dataCount - 2 + 2];
			int pointerPosition = 0;
			int j = 0;
			//Step 1.1. The spline goes through the nodal points.
			for (int i = 0; i < dataCount - 1; i++)
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
			//Step 2.1. Verification of identical derivatives in nodal points.
			pointerPosition = 0;
			for(int i = 1; i < dataCount - 1; i++)
			{
				matrix[j, ++pointerPosition] = 1;
				matrix[j, ++pointerPosition] = 2 * (Data[i].X - Data[i - 1].X);
				matrix[j, ++pointerPosition] = 3 * Math.Pow((Data[i].X - Data[i - 1].X), 2);
				matrix[j, pointerPosition + 2] = -1;
				pointerPosition++;
				j++;
			}
			//Step 2.2. Verification of identical second derivatives in nodal points.
			pointerPosition = 1;
			for(int i = 1; i < dataCount - 1; i++)
			{
				matrix[j, ++pointerPosition] = 2;
				matrix[j, ++pointerPosition] = 6 * (Data[i].X - Data[i - 1].X);
				matrix[j, pointerPosition + 3] = -2;
				pointerPosition += 2;
				j++;
			}
			//Step 3. The second derivatives are zero at the first and last points.
			matrix[j, 2] = 2;
			matrix[++j, dataCount * 3 - 2] = 2;
			matrix[j, dataCount * 3 - 1] = 6 * (Data[dataCount - 1].X - Data[dataCount - 2].X);
			//Step 1.2. Adding answers for step 1.
			j = 0;
			for(int i = 0; i < dataCount - 1; i++)
			{
				answers[j] = Data[i].Y;
				j++;
				answers[j] = Data[i + 1].Y;
				j++;
			}

			Matrix<double> mat = Matrix<double>.Build.DenseOfArray(matrix);
			Vector<double> ans = Vector<double>.Build.DenseOfArray(answers);
			(Matrix<double>, Vector<double>) ret = (mat, ans);

			return ret;
		}
		
		public Vector<double> CalculateSystem((Matrix<double>, Vector<double>) data)
		{
			var ret = data.Item1.Solve(data.Item2);
			return ret;
		}
		/// <summary>
		/// Method for finding the spline to which the point belongs.
		/// </summary>
		public int FindCurentSpline(double value)
		{
			int dataCount = Data.Count();
			int tempI = 0;
			for(int i = 1; i < dataCount; i++)
			{
				if(value >= Data[i - 1].X && value < Data[i].X)
				{
					return i;
				}
				tempI = i;
			}
			return tempI + 1;
		}
	}
}
