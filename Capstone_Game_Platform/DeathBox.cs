using System;
using System.Windows.Forms;

namespace Capstone_Game_Platform
{
    public partial class DeathBox : Form
    {
        public DeathBox()
        {
            InitializeComponent();
        }
        //updating this file to make sure i am current
        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            Close();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SaveGameHelper saveGameHelper = new SaveGameHelper
            {
                Level_ID = 1,
                Player_ID = StartScreen.PlayerID,
                Level_Score = Form1.score,
                Special_Count = 0, //wind + 
                Monster_Count = Form1.boltScore, //lightbolt kills
                Level_Time = int.Parse(Form1.time), // time to complete level in seconds
                Level_Attempts = StartScreen.LevelTryCounter, // how many attempts before completing level
                Char_Points = Form1.score
            };
            saveGameHelper.SaveLevel();

            if (Form1.deathByBlackHole)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Black_Hole;
                saveGameHelper.Achievement_Data = 1;
                saveGameHelper.SaveAchievement();
            }
            else if (Form1.deathByBolt)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Electrocuted;
                saveGameHelper.Achievement_Data = 1;
                saveGameHelper.SaveAchievement();
            }

            StartScreen.char_level = saveGameHelper.Char_Level;
            label4.Visible = true;
        }
    }
}
