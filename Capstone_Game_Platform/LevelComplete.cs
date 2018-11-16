using System;
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
			label5.Text = Form1.time;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveGameHelper saveGameHelper = new SaveGameHelper
            {
                Level_ID = 1,
                Player_ID = StartScreen.PlayerID,
                Level_Score = Form1.score,
                Special_Count = 1, //wind + 
                Monster_Count = 1, //lightbolt kills
                Level_Time = int.Parse(Form1.time), // time to complete level in seconds
                Level_Attempts = 1 // how many attempts before completing level
            };
            saveGameHelper.SaveLevel();

            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Star_Light;
            saveGameHelper.Achievement_Data = (Form1.score / 10);
            saveGameHelper.SaveAchievement();
            label4.Visible = true;
        }
    }
}
