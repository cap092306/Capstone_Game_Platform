using System;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest_Level_1_Lost_Quit : UIBaseTestClass
    {
        [Test]
        public void TestMethod1()
        {
            Application app = base.Application;

            Window window = app.GetWindow(SearchCriteria.ByAutomationId("StartScreen"), InitializeOption.WithCache);
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
            
            AttachedKeyboard keyboard = game.Keyboard;
            keyboard.HoldKey(KeyboardInput.SpecialKeys.RIGHT);  //die by black hole
            //keyboard.LeaveKey(KeyboardInput.SpecialKeys.RIGHT);

            Window lost = app.GetWindow(SearchCriteria.ByAutomationId("DeathBox"), InitializeOption.WithCache);
            keyboard.LeaveKey(KeyboardInput.SpecialKeys.RIGHT);
            lost.WaitWhileBusy();
            children1 = lost.GetMultiple(SearchCriteria.All); //35

            Button saveBtn = (Button)children1[4];
            saveBtn.Click();
            lost.WaitWhileBusy();

            Button quitBtn = (Button)children1[5];
            quitBtn.Click();
            
            app.Close();
            app.Dispose();
        }
    }
}
