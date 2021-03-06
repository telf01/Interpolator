﻿using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpolator
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void inputTextBox_TextChanged(object sender, EventArgs e)
		{
			if(inputTextBox.Text == "")
			{
				button1.Enabled = false;
			}
			else
			{
				button1.Enabled = true;
			}
		}

		private void outputTextBox_TextChanged(object sender, EventArgs e)
		{
			if (outputTextBox.Text == "")
			{
				button1.Enabled = false;
			}
			else
			{
				button1.Enabled = true;
			}
		}

		private void distanceTextBox_TextChanged(object sender, EventArgs e)
		{
			if (distanceTextBox.Text == "")
			{
				button1.Enabled = false;
			}
			else
			{
				button1.Enabled = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = "Reading data from file...";
			toolStripProgressBar1.Value = 20;
			Application.DoEvents();

			List<(double X, double Y)> data;
			do
			{
				data = FileWorker.GetData(inputTextBox.Text);
			} while (data == null);
			toolStripStatusLabel1.Text = "Spline calculating...";
			toolStripProgressBar1.Value = 40;
			Application.DoEvents();

			double last = data.OrderByDescending(a => a.X).First().X;
			double step = Convert.ToDouble(distanceTextBox.Text);
			List<(double X, double Y)> interpolatedPoints = new List<(double X, double Y)>();

			var spline = new CubicSpline(data);
			var system = spline.CreateBaseMatrix();
			var answers = spline.CalculateSystem(system);
			Application.DoEvents();

			for (double t = data.OrderByDescending(a => a.X).Last().X; t <= last; t += step)
			{
				int currentSplineNumber = spline.FindCurentSpline(t);
				int j = currentSplineNumber * 4;
				double currentY = answers[j - 4] + answers[j - 3] * (t - data[currentSplineNumber - 1].X) + answers[j - 2] * Math.Pow((t - data[currentSplineNumber - 1].X), 2) + answers[j - 1] * Math.Pow((t - data[currentSplineNumber - 1].X), 3);
				interpolatedPoints.Add((t, currentY));
			}

			toolStripStatusLabel1.Text = "Writing data to file...";
			toolStripProgressBar1.Value = 60;
			Application.DoEvents();

			FileWorker.WriteData(interpolatedPoints, outputTextBox.Text);

			toolStripStatusLabel1.Text = "Drawing graph....";
			toolStripProgressBar1.Value = 80;
			Application.DoEvents();

			if (checkBox1.Checked)
			{
				ChartForm chartForm = new ChartForm();
				chartForm.Data = data;
				chartForm.InterpolatedData = interpolatedPoints;
				chartForm.Show();
			}
			toolStripStatusLabel1.Text = "Completed!";
			toolStripProgressBar1.Value = 100;
		}
	}
}
