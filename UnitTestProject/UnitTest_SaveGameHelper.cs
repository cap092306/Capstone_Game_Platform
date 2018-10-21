using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone_Game_Platform;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest_SaveGameHelper
    {
        [TestMethod]
        public void SaveLevel_TestMethod()
        {
            SaveGameHelper saveGameHelper = new SaveGameHelper();
            saveGameHelper.Level_ID = 1;
            saveGameHelper.Player_ID = 1;
            saveGameHelper.Life_Count = 1;
            saveGameHelper.Level_Score = 200;
            saveGameHelper.Level_Time = 1000;
            saveGameHelper.Special_Count = 1;
            saveGameHelper.Monster_Count = 0;
            saveGameHelper.Level_Attempts = 1;
            saveGameHelper.SaveLevel();
        }

        [TestMethod]
        public void SaveAchievement_TestMethod()
        {
            SaveGameHelper saveGameHelper = new SaveGameHelper();
            saveGameHelper.Level_ID = 1;
            saveGameHelper.Player_ID = 1;
            saveGameHelper.Player_Achievement = SaveGameHelper.Achievement.Star_Light;
            saveGameHelper.Achievement_Data = (200 / 10).ToString();
            saveGameHelper.SaveAchievement();
        }


    }

}
