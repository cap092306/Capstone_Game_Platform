using System;
using System.Windows.Forms;

namespace Capstone_Game_Platform
{
    public partial class LevelComplete3 : Form
    {
        public LevelComplete3()
        {
            InitializeComponent();
        }

        private void LevelComplete_Load(object sender, EventArgs e)
        {
             label3.Text = Form3.score.ToString();
			 label7.Text = Form3.time;
        }

        private void Button3_Click(object sender, EventArgs e)
        { 
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveGameHelper saveGameHelper = new SaveGameHelper
            {
                Level_ID = 3,
                Player_ID = StartScreen.PlayerID,
                Level_Score = Form3.score,
                Special_Count = 1, //wind + 
                Monster_Count = 3, //lightbolt kills
                Level_Time = int.Parse(Form3.time), // time to complete level in seconds
                Level_Attempts = 1 // how many attempts before completing level
            };
            saveGameHelper.SaveLevel();

            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Star_Light;
            saveGameHelper.Achievement_Data = Form3.score / 10;
            saveGameHelper.SaveAchievement();
            label4.Visible = true;
        }
    }
}
