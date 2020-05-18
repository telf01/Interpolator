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
				data = FileReader.GetData(inputTextBox.Text);
			} while (data == null);

			var spline = new CubicSpline(data);
			spline.FindNeighbours(16);

			ChartForm chartForm = new ChartForm();
			chartForm.Data = data;
			chartForm.Show();
		}
	}
}
