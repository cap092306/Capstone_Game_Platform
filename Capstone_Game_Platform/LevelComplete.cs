using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Game_Platform
{
    public partial class LevelComplete : Form
    {
        public LevelComplete()
        {
            InitializeComponent();
        }

        private void LevelComplete_Load(object sender, EventArgs e)
        {
            label3.Text = Form1.score.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveGameHelper saveGameHelper = new SaveGameHelper();
            saveGameHelper.Level_ID = 1;
            saveGameHelper.Player_ID = 1;
            saveGameHelper.Level_Score = Form1.score;
            saveGameHelper.SaveLevel();
            saveGameHelper.Player_Achievement = SaveGameHelper.Achievement.Star_Light;
            saveGameHelper.Achievement_Data = (Form1.score / 10).ToString();
            saveGameHelper.SaveAchievement();
            this.label4.Visible = true;
        }
    }
}
