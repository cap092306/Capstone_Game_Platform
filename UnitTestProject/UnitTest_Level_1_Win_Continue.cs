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
    public class UnitTest_Level_1_Win_Continue : UIBaseTestClass
    {
        [Test]
        public void TestMethod1()
        {
            Application app = base.Application;
            Window window = app.GetWindow(SearchCriteria.ByAutomationId("StartScreen"), InitializeOption.WithCache);
            Delete_LevelData();
            window.WaitWhileBusy();
            //click the cont button
            Button contBtn = window.Get<Button>(SearchCriteria.ByAutomationId("button2"));
            contBtn.Click();

            // get cont window
            Window cont = app.GetWindow(SearchCriteria.ByAutomationId("ContinueGame"), InitializeOption.WithCache);
            cont.WaitWhileBusy();

            IUIItem[] children1 = cont.GetMultiple(SearchCriteria.All);
            //get lvl 1 button
            Button lvl1Btn = (Button)children1[1];
            lvl1Btn.Click();
            // get game window
            Window game = app.GetWindow(SearchCriteria.ByAutomationId("Form1"), InitializeOption.WithCache);
            game.WaitWhileBusy(); //wait till lightening kills player

            //put in stuff here to win




            Window win = app.GetWindow(SearchCriteria.ByAutomationId("LevelComplete"), InitializeOption.WithCache);
            win.WaitWhileBusy();
            children1 = win.GetMultiple(SearchCriteria.All); //345

            Button saveBtn = (Button)children1[4];
            saveBtn.Click();
            win.WaitWhileBusy();

            contBtn = (Button)children1[3];
            contBtn.Click();

            game = app.GetWindow(SearchCriteria.ByAutomationId("Form1"), InitializeOption.WithCache);
            game.Close();


            app.Close();
            app.Dispose();
        }
        private void Delete_LevelData()
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