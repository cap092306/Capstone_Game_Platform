﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Game_Platform
{
    public partial class Level2Complete : Form
    {
        public Level2Complete()
        {
            InitializeComponent();
        }

        private void Level2Complete_Load(object sender, EventArgs e)
        {
            label3.Text = Form2.score.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
