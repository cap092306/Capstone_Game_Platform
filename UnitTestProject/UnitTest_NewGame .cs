using System;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.Factory;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest_NewGame : UIBaseTestClass
    {
        [Test]
        public void TestMethod1()
        {
            Application app = base.Application;

            Window window = app.GetWindow(SearchCriteria.ByAutomationId("StartScreen"), InitializeOption.WithCache);

            window.WaitWhileBusy();
            //click the cont button
            Button newBtn = window.Get<Button>(SearchCriteria.ByAutomationId("button1"));
            window.WaitWhileBusy();
            newBtn.Click();
            window.WaitWhileBusy();
            
            // get story window
            Window story = app.GetWindow(SearchCriteria.ByAutomationId("Form4"), InitializeOption.WithCache);
            IUIItem[] children1 = story.GetMultiple(SearchCriteria.All);
            story.WaitWhileBusy();
            Button nextBtn = (Button)children1[1];
            nextBtn.Click();
            nextBtn.Click();
            nextBtn.Click();
            nextBtn.Click();
            nextBtn.Click();
            nextBtn.Click();
            story.ReloadIfCached();
            children1 = story.GetMultiple(SearchCriteria.All);
            Button beginBtn = (Button)children1[7];
            beginBtn.Click();

            // get game window
            Window game = app.GetWindow(SearchCriteria.ByAutomationId("Form1"), InitializeOption.WithCache);

            game.Close();
            app.Close();
            app.Dispose();
        }


    }
}