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

            DataSet ds = xmlUtils.ReadXMLfile();
            DataTable dt = ds.Tables[(int)SaveGameHelper.XMLTbls.player_history];
            DataTable lvlsCompleted = new DataTable();
            var rows = (from lc in dt.AsEnumerable()
                        where lc.Field<string>("player_ID") == StartScreen.PlayerID.ToString() &&
                           !String.IsNullOrWhiteSpace(lc.Field<string>("completed").ToString())
                        orderby lc.Field<string>("level_ID")
                        select lc).DefaultIfEmpty();

            foreach (var row in rows) { lvlsCompleted.ImportRow(row); }
            Assert.IsNotNull(lvlsCompleted);
            Assert.AreEqual(1, lvlsCompleted.Rows.Count, $"Expects 1 history record.");
            Assert.IsTrue(!String.IsNullOrWhiteSpace(lvlsCompleted.Rows[0].Field<string>("last_played")));
        }

        [TestMethod]
        public void SaveAchievement_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            xmlUtils.DeleteXMLfile();

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

            saveGameHelper.Player_Achievement = SaveGameHelper.Achievements.Star_Power;
            saveGameHelper.Achievement_Data = 1;
            saveGameHelper.SaveAchievement();

            DataSet ds = xmlUtils.ReadXMLfile();
            DataTable dt = ds.Tables[(int)SaveGameHelper.XMLTbls.player_achievement];
            DataTable badges = new DataTable();
            var rows = (from lc in dt.AsEnumerable()
                        where lc.Field<string>("player_ID") == StartScreen.PlayerID.ToString() &&
                           !String.IsNullOrWhiteSpace(lc.Field<string>("achievement_date").ToString())
                        orderby lc.Field<string>("level_ID")
                        select lc).DefaultIfEmpty();

            foreach (var row in rows) { badges.ImportRow(row); }
            Assert.IsNotNull(badges);
            Assert.AreEqual(1, badges.Rows.Count, $"Expects 1 achievement record. Created new XML file and added 1 achievement."); //should come back with 1 row
            Assert.IsTrue(!String.IsNullOrWhiteSpace(badges.Rows[0].Field<string>("achievement_data")));
        }


    }

}
