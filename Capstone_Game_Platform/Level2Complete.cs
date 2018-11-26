using System;
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
			label5.Text = Form2.time;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
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
                Monster_Count = 2, //lightbolt kills
                Level_Time = int.Parse(Form2.time), // time to complete level in seconds
                Level_Attempts = 1 // how many attempts before completing level
            };
            saveGameHelper.SaveLevel();

            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Star_Light;
            saveGameHelper.Achievement_Data = (Form2.score / 10);
            saveGameHelper.SaveAchievement();
            label4.Visible = true;
        }
    }
}
