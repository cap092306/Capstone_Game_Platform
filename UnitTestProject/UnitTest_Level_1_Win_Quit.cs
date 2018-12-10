using System;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.Factory;
using Capstone_Game_Platform;
using System.IO;
using Button = TestStack.White.UIItems.Button;
using System.Windows.Forms;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest_Level_1_Win_Quit : UIBaseTestClass
    {
        [Test]
        public void TestMethod1()
        {
            TestStack.White.Application app = base.Application;
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
            Window game = app.GetWindow(SearchCriteria.ByAutomationId("Form1"), InitializeOption.NoCache);
            game.Focus();

            UIItemCollection items = game.Items;
            items[24].Focus();

            SendKeys.Send("{SPACE}");




            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RIGHT);//winElem14.SendKeys(Keys.Right);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RIGHT);//winElem14.SendKeys(Keys.Right);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RIGHT);//winElem14.SendKeys(Keys.Right);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RIGHT);//winElem14.SendKeys(Keys.Right);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RIGHT);//winElem14.SendKeys(Keys.Right);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RIGHT);//winElem14.SendKeys(Keys.Right);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RIGHT);//winElem14.SendKeys(Keys.Right);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);//winElem14.SendKeys(Keys.Left);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);//winElem14.SendKeys(Keys.Left);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);//winElem14.SendKeys(Keys.Left);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);//winElem14.SendKeys(Keys.Left);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);//winElem14.SendKeys(Keys.Left);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);//winElem14.SendKeys(Keys.Left);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);//winElem14.SendKeys(Keys.Left);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);//winElem14.SendKeys(Keys.Left);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RIGHT);//winElem14.SendKeys(Keys.Right);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);//winElem14.SendKeys(Keys.Left);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);//winElem14.SendKeys(Keys.Left);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);//winElem14.SendKeys(Keys.Space);
            //input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.LEFT);//winElem14.SendKeys(Keys.Left);


            Window win = app.GetWindow(SearchCriteria.ByAutomationId("LevelComplete"), InitializeOption.WithCache);
            
            win.WaitWhileBusy();
            children1 = win.GetMultiple(SearchCriteria.All); //35

            Button saveBtn = (Button)children1[4];
            saveBtn.Click();
            win.WaitWhileBusy();

            Button quitBtn = (Button)children1[5];
            quitBtn.Click();
            
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
