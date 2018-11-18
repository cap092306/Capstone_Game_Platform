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
        public void Pivot_TestMethod()
        {
            XMLUtils xmlUtils = new XMLUtils
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            DataSet ds = xmlUtils.ReadXMLfile();
            DataTable dt = ds.Tables[(int)SaveGameHelper.XMLTbls.player_history];
            LinqPivot linqPivot = new LinqPivot();
            DataTable stats = linqPivot.Pivot(dt, dt.Columns["level_ID"], "Level Stats");

            Assert.AreEqual(4, stats.Columns.Count);
        }
    }
}
