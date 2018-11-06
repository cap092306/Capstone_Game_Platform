using System;
using System.Media;
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
        public static int PlayerID = 1;// gives us the ability to allow for more than player

        private void Button1_Click(object sender, EventArgs e)
        {
            Form Form4 = new Form4();
            Form4.Show();
            Theme.Stop();
            
            //this.Dispose();
        }
        
        private void StartScreen_Load(object sender, EventArgs e)
        {
            Theme.PlayLooping();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form cont = new ContinueGame();
            cont.Show();
            Theme.Stop();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form Help = new UserManual();
            Help.Show();
            Theme.Stop();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form Stats = new PlayerStats();
            Stats.Show();
            Theme.Stop();
        }
    }
}
