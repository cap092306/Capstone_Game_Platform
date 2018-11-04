using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            SaveGameHelper saveGameHelper = new SaveGameHelper();
            saveGameHelper.Level_ID = 2;
            saveGameHelper.Player_ID = StartScreen.PlayerID;
            saveGameHelper.Level_Score = Form2.score;
            saveGameHelper.Special_Count = 1; //wind + 
            saveGameHelper.Monster_Count = 0; //lightbolt kills
            saveGameHelper.Level_Time = 0; // time to complete level in seconds
            saveGameHelper.Level_Attempts = 1; // how many attempts before completing level
            saveGameHelper.SaveLevel();

            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Star_Light;
            saveGameHelper.Achievement_Data = (Form2.score / 10);
            saveGameHelper.SaveAchievement();
            label4.Visible = true;
        }
    }
}
