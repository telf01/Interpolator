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
			}
			dataLength = Data.Count();
			for (int i = 0; i < dataLength; i++)
			{
				chart1.Series[0].Points.AddXY(Data[i].X, Data[i].Y);
			}
			
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{

		}
	}
}
