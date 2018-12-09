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
    public class UnitTest_PlayerStats_WithNoData : UIBaseTestClass
    {
        [Test]
        public void TestPlayerStats_NoData()
        {

            Application app = base.Application;
            Window window = app.GetWindow(SearchCriteria.ByAutomationId("StartScreen"), InitializeOption.WithCache);
            Add_AchievementData();
            window.WaitWhileBusy();
            //click the stats button
            Button statsBtn = window.Get<Button>(SearchCriteria.ByAutomationId("button4"));
            window.WaitWhileBusy();
            statsBtn.Click();
            window.WaitWhileBusy();
            //get stats window
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
            xmlUtils.CreateXMLfile();
        }
    }
}
