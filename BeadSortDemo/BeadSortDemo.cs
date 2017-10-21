using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeadSortDemo
{
	public partial class BeadSortDemo : Form
	{
		public BeadSortDemo()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Console.SetOut(new TextBoxWriter(textBox1));
			textBox1.AppendText("Gravity / Bead Sort Demo");
			textBox1.AppendText(Environment.NewLine);
			textBox1.Refresh();
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			RunSort(10); // by default sort 10
		}

		private void RunSort(int howMany)
		{
			int[] data = RandomList(howMany);
			textBox1.AppendText(howMany.ToString() + " beads");
			textBox1.AppendText(Environment.NewLine);
			textBox1.Refresh();

			howMany = data.Length - 1;
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText("Unsorted beads:");
			textBox1.AppendText(Environment.NewLine);

			ShowBeads(data);
			
			BeadSort(ref data);
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText("Sorted beads:");
			textBox1.AppendText(Environment.NewLine);

			ShowBeads(data);
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText("---");
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText("Beads are sorted!");
			textBox1.AppendText(Environment.NewLine);

		}

		private void ShowBeads(int[] data)
		{
			string output = "[";
			for (int i = 0; i < data.Length; i++)
			{
				output += (data[i]);
				if (i+1 != data.Length)
				{
					output += (", ");
				}
			}
			textBox1.AppendText(output + "]");
			textBox1.Refresh();
		}

		private int[] RandomList(int listSize)
		{
			int[] randomizedList = new int[listSize];
			int i;
			Random rnd = new Random();
			
			for (i = 0; i < listSize; i++)
			{
				randomizedList[i] = rnd.Next(0, 65535);
			}

			return randomizedList;
		}

		public static void BeadSort(ref int[] data)
		{
			int i, j, max, sum;
			byte[] beads;

			for (i = 1, max = data[0]; i < data.Length; ++i)
				if (data[i] > max)
					max = data[i];

			beads = new byte[max * data.Length];

			for (i = 0; i < data.Length; ++i)
				for (j = 0; j < data[i]; ++j)
					beads[i * max + j] = 1;

			for (j = 0; j < max; ++j)
			{
				for (sum = i = 0; i < data.Length; ++i)
				{
					sum += beads[i * max + j];
					beads[i * max + j] = 0;
				}

				for (i = data.Length - sum; i < data.Length; ++i)
					beads[i * max + j] = 1;
			}

			for (i = 0; i < data.Length; ++i)
			{
				for (j = 0; j < max && Convert.ToBoolean(beads[i * max + j]); ++j) ;
				data[i] = j;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			RunSort((int) numericUpDown1.Value);
		}
	}
}
