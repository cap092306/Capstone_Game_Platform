using System;
using System.Collections.Generic;
using System.Media;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Game_Platform
{
	public partial class Form4 : Form
	{
		public List<Panel> listPanel = new List<Panel>();
		public int Index;
		public Form4()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (Index < listPanel.Count - 1)
			{
				listPanel[++Index].Show();
				
			}
			if (Index == 6)
			{
				button2.Hide();
				button1.Show();			
			}
		}

		private void Form4_Load(object sender, EventArgs e)
		{
			listPanel.Add(panel1);
			listPanel.Add(panel2);
			listPanel.Add(panel3);
			listPanel.Add(panel4);
			listPanel.Add(panel5);
			listPanel.Add(panel6);
			listPanel.Add(panel7);
			panel1.Show();
			panel2.Hide();
			panel3.Hide();
			panel4.Hide();
			panel5.Hide();
			panel6.Hide();
			panel7.Hide();
			button1.Hide();

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Form Form1 = new Form1();
			Form1.Show();
			this.Close();
		}
	}
}
