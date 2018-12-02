using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone_Game_Platform;
using System.IO;
using System.Data;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest_SaveGameHelper
    {
        [TestMethod]
        public void SaveLevel_TestMethod()
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
                Char_Points = 250
            };
            saveGameHelper.SaveLevel();

            DataSet ds = xmlUtils.ReadXMLfile();
            DataRow rows = (from row in ds.Tables[(int)SaveGameHelper.XMLTbls.player_history].AsEnumerable()
                            where row.Field<string>("player_ID") == StartScreen.PlayerID.ToString() //player1
                                  && !String.IsNullOrWhiteSpace(row.Field<string>("completed").ToString())
                            select row).SingleOrDefault();

            Assert.IsNotNull(rows);
            Assert.IsTrue(!String.IsNullOrWhiteSpace(rows.Field<string>("last_played")));
        }

        [TestMethod]
        public void SaveAchievement_TestMethod()
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
                Char_Points = 250
            };
            saveGameHelper.SaveLevel();

            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Star_Light;
            saveGameHelper.Achievement_Data = 250 / 10;
            saveGameHelper.SaveAchievement();
         
            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Light_Speed_1;
            saveGameHelper.Achievement_Data = 1000;
            saveGameHelper.SaveAchievement();
           
            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Portal_1;
            saveGameHelper.Achievement_Data = 1;
            saveGameHelper.SaveAchievement();

            DataSet ds = xmlUtils.ReadXMLfile();
            DataTable dt = ds.Tables[(int)SaveGameHelper.XMLTbls.player_achievement];
            DataTable badges = new DataTable();


            int count = (from row in ds.Tables[(int)SaveGameHelper.XMLTbls.player_achievement].AsEnumerable()
                        where row.Field<string>("player_ID") == StartScreen.PlayerID.ToString() //player1
                              && !String.IsNullOrWhiteSpace(row.Field<string>("achievement_date").ToString())
                        select row).Count();

            Assert.IsNotNull(count);
            Assert.AreNotEqual(0,count);
        }
    }
}
