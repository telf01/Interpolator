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
	public partial class ChartForm : Form
	{
		public List<(double X, double Y)> Data { get; set; }
		public List<(double X, double Y)> InterpolatedData { get; set; }
		public ChartForm()
		{
			InitializeComponent();
		}

		private void ChartForm_Load(object sender, EventArgs e)
		{
			chart1.Series[0].MarkerSize = 10;
			int dataLength = InterpolatedData.Count();
			for (int i = 0; i < dataLength; i++)
			{
				chart1.Series[1].Points.AddXY(InterpolatedData[i].X, InterpolatedData[i].Y);
				Application.DoEvents();
			}
			dataLength = Data.Count();
			for (int i = 0; i < dataLength; i++)
			{
				chart1.Series[0].Points.AddXY(Data[i].X, Data[i].Y);
				Application.DoEvents();
			}
			
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
			chart1.DrawToBitmap(bmp, new Rectangle(0, 0, chart1.Width, chart1.Height));
			bmp.Save(textBox1.Text);
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if(textBox1.Text == "")
			{
				SaveButton.Enabled = false;
			}
			else
			{
				SaveButton.Enabled = true;
			}
		}
	}
}
