using System;
using System.Windows.Forms;

namespace Capstone_Game_Platform
{
    public partial class Level2Complete : Form
    {
        private int star = 10;
        private int minute = 60;
        private int achieved = 1;
        public Level2Complete()
        {
            InitializeComponent();
        }

        private void Level2Complete_Load(object sender, EventArgs e)
        {
            label3.Text = Form2.score.ToString();
			label5.Text = Form2.time;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            StartScreen.LevelTryCounter = 0;
            Form3 Form3 = new Form3();
            Form3.Show();
            Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveGameHelper saveGameHelper = new SaveGameHelper
            {
                Level_ID = 2,
                Player_ID = StartScreen.PlayerID,
                Level_Score = Form2.score,
                Special_Count = 1, //wind + 
                Monster_Count = Form2.boltScore, //lightbolt kills
                Level_Time = int.Parse(Form2.time), // time to complete level in seconds
                Level_Attempts = StartScreen.LevelTryCounter, // how many attempts before completing level
                Char_Points = Form1.score
            };
            saveGameHelper.SaveLevel();

            if (Form2.score == 0)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Skipper;
                saveGameHelper.Achievement_Data = achieved;
                saveGameHelper.SaveAchievement();
            }
            else
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Star_Light;
                saveGameHelper.Achievement_Data = Form2.score / star;
                saveGameHelper.SaveAchievement();
            }

            if (int.Parse(Form2.time) <= minute)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Light_Speed_2;
                saveGameHelper.Achievement_Data = int.Parse(Form2.time);
                saveGameHelper.SaveAchievement();
            }

            if (Form2.boltScore > 0)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Kills_2;
                saveGameHelper.Achievement_Data = Form3.boltScore;
                saveGameHelper.SaveAchievement();
            }

            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Portal_2;
            saveGameHelper.Achievement_Data = achieved;
            saveGameHelper.SaveAchievement();
            StartScreen.char_level = saveGameHelper.Char_Level;
            label4.Visible = true;
        }
    }
}
