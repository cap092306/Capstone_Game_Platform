using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone_Game_Platform;
using System.IO;
using System.Data;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest_LinqPivot
    {
        [TestMethod]
        public void LinqPivot_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            DataSet ds = xmlUtils.ReadXMLfile();

            LinqPivot linqPivot = new LinqPivot();
            DataTable dt = linqPivot.Pivot(ds.Tables[(int)SaveGameHelper.XMLTbls.player_achievement],
                ds.Tables[(int)SaveGameHelper.XMLTbls.player_achievement].Columns[(int)SaveGameHelper.PlayerAchievementsTbl.achievement_ID],
                "Player Achievements");
            Assert.IsNotNull(dt);
        }
    }
}
