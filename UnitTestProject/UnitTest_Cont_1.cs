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
    public class UnitTest_Cont_1 : UIBaseTestClass
    {
        [Test]
        public void TestMethod1()
        {
            Application app = base.Application;

            Window window = app.GetWindow(SearchCriteria.ByAutomationId("StartScreen"), InitializeOption.WithCache);

            window.WaitWhileBusy();
            //click the cont button
            Button contBtn = window.Get<Button>(SearchCriteria.ByAutomationId("button2"));
            window.WaitWhileBusy();
            contBtn.Click();
            window.WaitWhileBusy();
            // get cont window
            Window cont = app.GetWindow(SearchCriteria.ByAutomationId("ContinueGame"), InitializeOption.WithCache);
            cont.WaitWhileBusy();

            IUIItem[] children1 = cont.GetMultiple(SearchCriteria.All);
            //get lvl 1 button
            Button lvl1Btn = (Button)children1[1];
            lvl1Btn.Click();
            // get game window
            Window game = app.GetWindow(SearchCriteria.ByAutomationId("Form1"), InitializeOption.WithCache);
            game.Close();
            app.Close();
            app.Dispose();
        }


    }
}
