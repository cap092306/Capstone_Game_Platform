﻿using System;
using System.IO;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.Factory;
using Capstone_Game_Platform;
using TestStack.White.WindowsAPI;
using TestStack.White.InputDevices;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest_Level_3_Win_Quit : UIBaseTestClass
    {
        [Test]
        public void TestMethod1()
        {
            Application app = base.Application;
            Window window = app.GetWindow(SearchCriteria.ByAutomationId("StartScreen"), InitializeOption.WithCache);
            Add_Level_Data();
            window.WaitWhileBusy();
            //click the cont button
            Button contBtn = window.Get<Button>(SearchCriteria.ByAutomationId("button2"));
            contBtn.Click();

            // get cont window
            Window cont = app.GetWindow(SearchCriteria.ByAutomationId("ContinueGame"), InitializeOption.WithCache);
            cont.WaitWhileBusy();

            IUIItem[] children1 = cont.GetMultiple(SearchCriteria.All);
            //get lvl 3 button
            Button lvl3Btn = (Button)children1[3];
            lvl3Btn.Click();
            // get game window
            Window game = app.GetWindow(SearchCriteria.ByAutomationId("Form3"), InitializeOption.WithCache);
            UIItemCollection items = game.Items;
                        
            
            // put stuff here to win




           
            Window win = app.GetWindow(SearchCriteria.ByAutomationId("LevelComplete3"), InitializeOption.WithCache);
            win.WaitWhileBusy();
            children1 = win.GetMultiple(SearchCriteria.All); //4-save 5-quit

            Button saveBtn = (Button)children1[4];
            saveBtn.Click();
            win.WaitWhileBusy();

            Button quitBtn = (Button)children1[5];
            quitBtn.Click();

            app.Close();
            app.Dispose();
        }

        private void Add_Level_Data()
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

            saveGameHelper = new SaveGameHelper
            {
                Level_ID = 2,
                Player_ID = 1,
                Level_Score = 250,
                Special_Count = 1, //wind + 
                Monster_Count = 1, //lightbolt kills
                Level_Time = 1000, // time to complete level in seconds
                Level_Attempts = 1, // how many attempts before completing level
                Char_Points = 2050
            };
            saveGameHelper.SaveLevel();
        }
    }
}
