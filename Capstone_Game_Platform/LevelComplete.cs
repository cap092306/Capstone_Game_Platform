using System;
using System.Windows.Forms;

namespace Capstone_Game_Platform
{
    public partial class LevelComplete : Form
    {
        private int star = 10;
        private int minute = 60;
        private int achieved = 1;
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
            StartScreen.LevelTryCounter = 0;
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
                Monster_Count = Form1.boltScore, //lightbolt kills
                Level_Time = int.Parse(Form1.time), // time to complete level in seconds
                Level_Attempts = StartScreen.LevelTryCounter, // how many attempts before completing level
                Char_Points = Form1.score
            };
            saveGameHelper.SaveLevel();

            if (Form1.score == 0)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Skipper;
                saveGameHelper.Achievement_Data = achieved;
                saveGameHelper.SaveAchievement();
            } else {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Star_Light;
                saveGameHelper.Achievement_Data = Form1.score / star;
                saveGameHelper.SaveAchievement();
            }
            
            if (int.Parse(Form1.time) <= minute)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Light_Speed_1;
                saveGameHelper.Achievement_Data = int.Parse(Form1.time);
                saveGameHelper.SaveAchievement();
            }

            if (Form1.boltScore > 0)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Kills_1;
                saveGameHelper.Achievement_Data = Form1.boltScore;
                saveGameHelper.SaveAchievement();
            }

            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Portal_1;
            saveGameHelper.Achievement_Data = achieved;
            saveGameHelper.SaveAchievement();
            StartScreen.char_level = saveGameHelper.Char_Level;
            label4.Visible = true;
        }
    }
}
