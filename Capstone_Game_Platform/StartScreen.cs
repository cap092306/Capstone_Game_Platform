using System;
using System.Media;
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
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }
        SoundPlayer Theme = new SoundPlayer(Resource1.looperman_l_1804190_0133365_trippy_psychedelic_8_bit_sample_meltdown);

        private void button1_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            Theme.Stop();
            
            //this.Dispose();
        }
        
        private void StartScreen_Load(object sender, EventArgs e)
        {
            Theme.PlayLooping();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
