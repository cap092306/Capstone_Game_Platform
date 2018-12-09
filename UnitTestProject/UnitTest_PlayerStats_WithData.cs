using System;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.Factory;
using Capstone_Game_Platform;
using System.IO;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest_PlayerStats_WithData : UIBaseTestClass
    {
       
        [Test]
        public void TestPlayerStats_WithData()
        {
            Application app = base.Application;

            Window window = app.GetWindow(SearchCriteria.ByAutomationId("StartScreen"), InitializeOption.WithCache);
            window.WaitWhileBusy();
            // add stats data
            Add_AchievementData();
            window.WaitWhileBusy();
            //click the stats button
            Button statsBtn = window.Get<Button>(SearchCriteria.ByAutomationId("button4"));
            window.WaitWhileBusy();
            statsBtn.Click();
            window.WaitWhileBusy();
            // set stats window
            Window playerStats = app.GetWindow(SearchCriteria.ByAutomationId("PlayerStats"), InitializeOption.WithCache);
            playerStats.WaitWhileBusy();
            playerStats.Close();
            window.Close();
            app.Close();
            app.Dispose();
        }

        private void Add_AchievementData()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            xmlUtils.DeleteXMLfile();

            SaveGameHelper saveGameHelper = new SaveGameHelper
            {
                Level_ID = 1,
                Player_ID = 1,
                Level_Score = 250,
                Special_Count = 1, //wind + 
                Monster_Count = 1, //lightbolt kills
                Level_Time = 1000, // time to complete level in seconds
                Level_Attempts = 1, // how many attempts before completing level
                Char_Points = 2050
            };
            saveGameHelper.SaveLevel();

            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Star_Light;
            saveGameHelper.Achievement_Data = 25000 / 10;
            saveGameHelper.SaveAchievement();
        }
    }
}
