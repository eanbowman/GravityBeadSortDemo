using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeadSortDemo
{
	public class TextBoxWriter : TextWriter
	{
		TextBox _output = null;

		public TextBoxWriter(TextBox output)
		{
			_output = output;
		}

		public override void Write(char value)
		{
			base.Write(value);
			_output.AppendText(value.ToString());
		}

		public override Encoding Encoding
		{
			get { return System.Text.Encoding.UTF8; }
		}
	}
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BeadSortDemo());
		}
	}
}
