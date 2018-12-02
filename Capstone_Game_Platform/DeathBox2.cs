using System;
using System.Windows.Forms;

namespace Capstone_Game_Platform
{
    public partial class DeathBox2 : Form
    {
        private int achieved = 1;
        public DeathBox2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
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
                Level_ID = 2,
                Player_ID = StartScreen.PlayerID,
                Level_Score = Form1.score,
                Special_Count = 0, //wind + 
                Monster_Count = Form2.boltScore, //lightbolt kills
                Level_Time = int.Parse(Form2.time), // time to complete level in seconds
                Level_Attempts = StartScreen.LevelTryCounter, // how many attempts before completing level
                Char_Points = Form2.score
            };
            saveGameHelper.SaveLevel();

            if (Form2.deathByBlackHole)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Black_Hole;
                saveGameHelper.Achievement_Data = achieved;
                saveGameHelper.SaveAchievement();
            }
            else if (Form2.deathByBolt)
            {
                saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Electrocuted;
                saveGameHelper.Achievement_Data = achieved;
                saveGameHelper.SaveAchievement();
            }

            StartScreen.char_level = saveGameHelper.Char_Level;
            label4.Visible = true;
        }
    }
}
