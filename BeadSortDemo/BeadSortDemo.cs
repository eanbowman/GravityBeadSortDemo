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
		public int sizeToSort = 1000000;
		public BeadSortDemo()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Console.SetOut(new TextBoxWriter(textBox1));
			Console.WriteLine("Gravity / Bead Sort Demo");
			int[] data = RandomList();
			Console.WriteLine(sizeToSort);
			//int[] data = { 586, 25, 58964, 8547, 119, 0, 78596 };

			sizeToSort = data.Length - 1;
			Console.Write("Unsorted beads:");
			textBox1.Refresh();
			ShowBeads(data);
			BeadSort(ref data);
			Console.Write("Sorted beads:");
			textBox1.Refresh();
			ShowBeads(data);
			Console.WriteLine("---");
			Console.WriteLine("Beads are sorted!");
			textBox1.Refresh();
		}

		private void ShowBeads(int[] data)
		{
			for (int i = 0; i <= sizeToSort; i++)
			{
				Console.Write(data[i]);
				Console.Write(" ");
			}
			Console.WriteLine();
			textBox1.Refresh();
		}

		private int[] RandomList()
		{
			int[] randomizedList = new int[sizeToSort];
			int i;
			Console.WriteLine("Randomizing list of " + sizeToSort + " integers");
			Random rnd = new Random();
			for (i = 0; i < sizeToSort; i++)
			{
				randomizedList[i] = rnd.Next(0, byte.MaxValue);
				Console.Write(randomizedList[i]);
				Console.Write(" ");
			}
			Console.WriteLine("");
			textBox1.Refresh();
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
	}
}
