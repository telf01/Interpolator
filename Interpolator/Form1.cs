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
			List<(double X, double Y)> data;
			do
			{
				data = FileWorker.GetData(inputTextBox.Text);
			} while (data == null);

			double last = data.OrderByDescending(a => a.X).First().X;
			double step = Convert.ToDouble(distanceTextBox.Text);
			List<(double X, double Y)> interpolatedPoints = new List<(double X, double Y)>();
			for (double t = data.OrderByDescending(a => a.X).Last().X; t <= last; t+=step)
			{
				var spline = new CubicSpline(data);
				var neighbours = spline.FindNeighbours(t);
				var x = spline.SystemOfEquationSolver(neighbours);
				double answer = spline.Solve(x, t);
				(double, double) formatedAnswer = (t, answer);
				interpolatedPoints.Add(formatedAnswer);
			}
			FileWorker.WriteData(interpolatedPoints, outputTextBox.Text);
			if (checkBox1.Checked)
			{
				ChartForm chartForm = new ChartForm();
				chartForm.Data = data;
				chartForm.InterpolatedData = interpolatedPoints;
				chartForm.Show();
			}
			else
			{
				MessageBox.Show("The calculations are completed.", "The calculations are completed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
