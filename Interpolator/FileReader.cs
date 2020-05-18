using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpolator
{
	static class FileReader
	{
		/// <summary>
		/// Method for reading data from a file.
		/// </summary>
		public static List<double> GetData(string path)
		{
			// All lines from file in array.
			string[] rawInput = null;
			try
			{
				rawInput = File.ReadAllLines(path);
				if (rawInput == null)
				{
					throw new Exception("Format error.\nOpen the " + path + " file and enter the data in it in the format:\nx1 y1\nx2 y2\n...");
				}
				if (rawInput.Length == 0)
				{
					throw new Exception("Format error.\nOpen the " + path + " file and enter the data in it in the format:\nx1 y1\nx2 y2\n...");
				}
			}
			catch(Exception ex)
			{
				var result = MessageBox.Show(ex.Message, "Error while reading file.", MessageBoxButtons.RetryCancel);
				// Check for what the user has decided: try again or close.
				if (result == DialogResult.Cancel)
				{
					Application.Exit();
					Environment.Exit(1);
					return null;
				}
				return null;
			}
			List<double> output = new List<double>();
			// Temporary var. Used for proper splitting
			string[] splitTemp;
			int rawInputLength = rawInput.Length;
			for(int i =0; i < rawInputLength; i++)
			{
				splitTemp = rawInput[i].Split();
				output.Add(Convert.ToDouble(splitTemp[0]));
				output.Add(Convert.ToDouble(splitTemp[1]));
			}
			return output;
		}

	}
}
