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
		public List<double> Data { get; set; }
		public ChartForm()
		{
			InitializeComponent();
		}

		private void ChartForm_Load(object sender, EventArgs e)
		{
			int dataLength = Data.Count();
			for (int i = 0; i < dataLength; i++)
			{
				chart1.Series[0].Points.AddXY(Data[i], Data[++i]);
			}
		}
	}
}
