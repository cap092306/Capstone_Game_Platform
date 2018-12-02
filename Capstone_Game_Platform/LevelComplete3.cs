using System;
using System.Windows.Forms;

namespace Capstone_Game_Platform
{
    public partial class LevelComplete3 : Form
    {
        private int star = 10;
        private int minute = 60;
        private int achieved = 1;
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
                Monster_Count = Form3.boltScore + 1, //lightbolt kills + Moon
                Level_Time = int.Parse(Form3.time), // time to complete level in seconds
                Level_Attempts = StartScreen.LevelTryCounter, // how many attempts before completing level
                Char_Points = Form3.score
            };
            saveGameHelper.SaveLevel();

            if (Form1.score == 0)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Skipper;
                saveGameHelper.Achievement_Data = achieved;
                saveGameHelper.SaveAchievement();
            }
            else
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Star_Light;
                saveGameHelper.Achievement_Data = Form1.score / star;
                saveGameHelper.SaveAchievement();
            }

            if (int.Parse(Form1.time) <= minute)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Light_Speed_3;
                saveGameHelper.Achievement_Data = int.Parse(Form1.time);
                saveGameHelper.SaveAchievement();
            }

            if(Form3.boltScore > 0)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Kills_3;
                saveGameHelper.Achievement_Data = Form3.boltScore;
                saveGameHelper.SaveAchievement();
            }

            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Defeat_Moon;
            saveGameHelper.Achievement_Data = achieved;
            saveGameHelper.SaveAchievement();

            StartScreen.char_level = saveGameHelper.Char_Level;
            StartScreen.LevelTryCounter = 0;
            label4.Visible = true;
        }
    }
}
