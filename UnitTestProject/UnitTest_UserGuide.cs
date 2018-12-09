using System;
using System.IO;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.Factory;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest_UserGuide : UIBaseTestClass
    {
        [Test]
        public void TestMethod1()
        {

            Application app = base.Application;
            
            Window window = app.GetWindow(SearchCriteria.ByAutomationId("StartScreen"), InitializeOption.WithCache);
            window.WaitWhileBusy();
            //click the help button
            Button helpBtn = window.Get<Button>(SearchCriteria.ByAutomationId("button3"));
            window.WaitWhileBusy();
            helpBtn.Click();
            window.WaitWhileBusy();

            //attached to new window
            Window userGuide = app.GetWindow(SearchCriteria.ByAutomationId("UserManual"), InitializeOption.WithCache);
           
            Button nextBtn = userGuide.Get<Button>(SearchCriteria.ByAutomationId("btnNext").AndIndex(0));
            Button backBtn = userGuide.Get<Button>(SearchCriteria.ByAutomationId("btnBack").AndIndex(1));

            userGuide.WaitWhileBusy();//front-cover
            nextBtn.Click(); 
            userGuide.WaitWhileBusy(); // pages 1-2
            nextBtn.Click();
            userGuide.WaitWhileBusy();// pages 3-4
            nextBtn.Click(); 
            userGuide.WaitWhileBusy();// pages 5-6
            nextBtn.Click(); 
            userGuide.WaitWhileBusy();// pages 7-8
            nextBtn.Click(); 
            userGuide.WaitWhileBusy();// 9-10
            nextBtn.Click(); 
            userGuide.WaitWhileBusy();// back cover - click back all the back
            backBtn.Click(); 
            userGuide.WaitWhileBusy();// 9-10;
            backBtn.Click(); 
            userGuide.WaitWhileBusy();// 7-8;
            backBtn.Click(); 
            userGuide.WaitWhileBusy();// 5-6;
            backBtn.Click(); 
            userGuide.WaitWhileBusy();// 3-4;
            backBtn.Click(); 
            userGuide.WaitWhileBusy();// 1-2;
            backBtn.Click(); 
            userGuide.WaitWhileBusy();// front-cover;

            userGuide.Close();
            window.Close();
            app.Close();
            app.Dispose();
        }
    }
}
