﻿using System;
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
    public partial class LevelComplete3 : Form
    {
        public LevelComplete3()
        {
            InitializeComponent();
        }

        private void LevelComplete_Load(object sender, EventArgs e)
        {
             label3.Text = Form1.score.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveGameHelper saveGameHelper = new SaveGameHelper();
            saveGameHelper.Level_ID = 3;
            saveGameHelper.Player_ID = StartScreen.PlayerID;
            saveGameHelper.Level_Score = Form3.score;
            saveGameHelper.Special_Count = 1; //wind + 
            saveGameHelper.Monster_Count = 0; //lightbolt kills
            saveGameHelper.Level_Time = 0; // time to complete level in seconds
            saveGameHelper.Level_Attempts = 1; // how many attempts before completing level
            saveGameHelper.SaveLevel();

            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Star_Light;
            saveGameHelper.Achievement_Data = (Form3.score / 10).ToString();
            saveGameHelper.SaveAchievement();
            this.Close();
        }
    }
}
