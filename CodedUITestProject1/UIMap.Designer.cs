﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 15.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace CodedUITestProject1
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public partial class UIMap
    {     
        /// <summary>
        /// Help
        /// </summary>
        public void Help()
        {
            #region Variable Declarations
            WinButton uIHelpButton = this.UICloud9MainMenuWindow.UIHelpWindow.UIHelpButton;
            WinButton uINextButton = this.UIUserManualWindow.UINextWindow.UINextButton;
            WinButton uIBackButton = this.UIUserManualWindow.UIBackWindow.UIBackButton;
            WinButton uICloseButton = this.UIUserManualWindow.UIUserManualTitleBar.UICloseButton;
            #endregion

            // Click 'Help' button
            Mouse.Click(uIHelpButton, new Point(43, 19));

            // Click 'Next' button
            Mouse.Click(uINextButton, new Point(36, 10));

            // Double-Click 'Next' button
            Mouse.DoubleClick(uINextButton, new Point(30, 16));

            // Click 'Next' button
            Mouse.Click(uINextButton, new Point(26, 17));

            // Click 'Next' button
            Mouse.Click(uINextButton, new Point(23, 17));

            // Click 'Next' button
            Mouse.Click(uINextButton, new Point(20, 17));

            // Double-Click 'Back' button
            Mouse.DoubleClick(uIBackButton, new Point(30, 18));

            // Double-Click 'Back' button
            Mouse.DoubleClick(uIBackButton, new Point(30, 17));

            // Click 'Back' button
            Mouse.Click(uIBackButton, new Point(27, 16));

            // Click 'Back' button
            Mouse.Click(uIBackButton, new Point(28, 16));

            // Click 'Close' button
            Mouse.Click(uICloseButton, new Point(22, 16));
        }
        
        /// <summary>
        /// PlayerStats_NoAchievements
        /// </summary>
        public void PlayerStats_NoAchievements()
        {
            #region Variable Declarations
            WinButton uIPlayerStatsButton = this.UICloud9MainMenuWindow.UIPlayerStatsWindow.UIPlayerStatsButton;
            WinButton uICloseButton = this.UIPlayerStatsWindow.UIPlayerStatsTitleBar.UICloseButton;
            #endregion

            // Click 'Player Stats' button
            Mouse.Click(uIPlayerStatsButton, new Point(35, 16));

            // Click 'Close' button
            Mouse.Click(uICloseButton, new Point(28, 19));
        }
        
        #region Properties
        public UICUserssonyaDocumentsWindow UICUserssonyaDocumentsWindow
        {
            get
            {
                if ((this.mUICUserssonyaDocumentsWindow == null))
                {
                    this.mUICUserssonyaDocumentsWindow = new UICUserssonyaDocumentsWindow();
                }
                return this.mUICUserssonyaDocumentsWindow;
            }
        }
        
        public UICloud9MainMenuWindow UICloud9MainMenuWindow
        {
            get
            {
                if ((this.mUICloud9MainMenuWindow == null))
                {
                    this.mUICloud9MainMenuWindow = new UICloud9MainMenuWindow();
                }
                return this.mUICloud9MainMenuWindow;
            }
        }
        
        public UIUserManualWindow UIUserManualWindow
        {
            get
            {
                if ((this.mUIUserManualWindow == null))
                {
                    this.mUIUserManualWindow = new UIUserManualWindow();
                }
                return this.mUIUserManualWindow;
            }
        }
        
        public UIPlayerStatsWindow1 UIPlayerStatsWindow
        {
            get
            {
                if ((this.mUIPlayerStatsWindow == null))
                {
                    this.mUIPlayerStatsWindow = new UIPlayerStatsWindow1();
                }
                return this.mUIPlayerStatsWindow;
            }
        }
        #endregion
        
        #region Fields
        private UICUserssonyaDocumentsWindow mUICUserssonyaDocumentsWindow;
        
        private UICloud9MainMenuWindow mUICloud9MainMenuWindow;
        
        private UIUserManualWindow mUIUserManualWindow;
        
        private UIPlayerStatsWindow1 mUIPlayerStatsWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UICUserssonyaDocumentsWindow : WinWindow
    {
        
        public UICUserssonyaDocumentsWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "C:\\Users\\sonya\\Documents\\GitHub\\Capstone_Game_Platform\\Capstone_Game_Platform\\bin" +
                "\\Debug";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "CabinetWClass";
            this.WindowTitles.Add("C:\\Users\\sonya\\Documents\\GitHub\\Capstone_Game_Platform\\Capstone_Game_Platform\\bin" +
                    "\\Debug");
            #endregion
        }
        
        #region Properties
        public UIItemWindow UIItemWindow
        {
            get
            {
                if ((this.mUIItemWindow == null))
                {
                    this.mUIItemWindow = new UIItemWindow(this);
                }
                return this.mUIItemWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIItemWindow mUIItemWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIItemWindow : WinWindow
    {
        
        public UIItemWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.AccessibleName] = "Items View";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "DirectUIHWND";
            this.WindowTitles.Add("C:\\Users\\sonya\\Documents\\GitHub\\Capstone_Game_Platform\\Capstone_Game_Platform\\bin" +
                    "\\Debug");
            #endregion
        }
        
        #region Properties
        public UICapstone_Game_PlatfoListItem UICapstone_Game_PlatfoListItem
        {
            get
            {
                if ((this.mUICapstone_Game_PlatfoListItem == null))
                {
                    this.mUICapstone_Game_PlatfoListItem = new UICapstone_Game_PlatfoListItem(this);
                }
                return this.mUICapstone_Game_PlatfoListItem;
            }
        }
        #endregion
        
        #region Fields
        private UICapstone_Game_PlatfoListItem mUICapstone_Game_PlatfoListItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UICapstone_Game_PlatfoListItem : WinListItem
    {
        
        public UICapstone_Game_PlatfoListItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinListItem.PropertyNames.Name] = "Capstone_Game_Platform.exe";
            this.WindowTitles.Add("C:\\Users\\sonya\\Documents\\GitHub\\Capstone_Game_Platform\\Capstone_Game_Platform\\bin" +
                    "\\Debug");
            #endregion
        }
        
        #region Properties
        public WinEdit UINameEdit
        {
            get
            {
                if ((this.mUINameEdit == null))
                {
                    this.mUINameEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUINameEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Name";
                    this.mUINameEdit.WindowTitles.Add("C:\\Users\\sonya\\Documents\\GitHub\\Capstone_Game_Platform\\Capstone_Game_Platform\\bin" +
                            "\\Debug");
                    #endregion
                }
                return this.mUINameEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUINameEdit;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UICloud9MainMenuWindow : WinWindow
    {
        
        public UICloud9MainMenuWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Cloud 9 - Main Menu";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Cloud 9 - Main Menu");
            #endregion
        }
        
        #region Properties
        public UIHelpWindow UIHelpWindow
        {
            get
            {
                if ((this.mUIHelpWindow == null))
                {
                    this.mUIHelpWindow = new UIHelpWindow(this);
                }
                return this.mUIHelpWindow;
            }
        }
        
        public UIPlayerStatsWindow UIPlayerStatsWindow
        {
            get
            {
                if ((this.mUIPlayerStatsWindow == null))
                {
                    this.mUIPlayerStatsWindow = new UIPlayerStatsWindow(this);
                }
                return this.mUIPlayerStatsWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIHelpWindow mUIHelpWindow;
        
        private UIPlayerStatsWindow mUIPlayerStatsWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIHelpWindow : WinWindow
    {
        
        public UIHelpWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "button3";
            this.WindowTitles.Add("Cloud 9 - Main Menu");
            #endregion
        }
        
        #region Properties
        public WinButton UIHelpButton
        {
            get
            {
                if ((this.mUIHelpButton == null))
                {
                    this.mUIHelpButton = new WinButton(this);
                    #region Search Criteria
                    this.mUIHelpButton.SearchProperties[WinButton.PropertyNames.Name] = "User Guide and Help Button";
                    this.mUIHelpButton.WindowTitles.Add("Cloud 9 - Main Menu");
                    #endregion
                }
                return this.mUIHelpButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIHelpButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIPlayerStatsWindow : WinWindow
    {
        
        public UIPlayerStatsWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "button4";
            this.WindowTitles.Add("Cloud 9 - Main Menu");
            #endregion
        }
        
        #region Properties
        public WinButton UIPlayerStatsButton
        {
            get
            {
                if ((this.mUIPlayerStatsButton == null))
                {
                    this.mUIPlayerStatsButton = new WinButton(this);
                    #region Search Criteria
                    this.mUIPlayerStatsButton.SearchProperties[WinButton.PropertyNames.Name] = "Player Stats Button";
                    this.mUIPlayerStatsButton.WindowTitles.Add("Cloud 9 - Main Menu");
                    #endregion
                }
                return this.mUIPlayerStatsButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIPlayerStatsButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIUserManualWindow : WinWindow
    {
        
        public UIUserManualWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "User Manual";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("User Manual");
            #endregion
        }
        
        #region Properties
        public UINextWindow UINextWindow
        {
            get
            {
                if ((this.mUINextWindow == null))
                {
                    this.mUINextWindow = new UINextWindow(this);
                }
                return this.mUINextWindow;
            }
        }
        
        public UIBackWindow UIBackWindow
        {
            get
            {
                if ((this.mUIBackWindow == null))
                {
                    this.mUIBackWindow = new UIBackWindow(this);
                }
                return this.mUIBackWindow;
            }
        }
        
        public UIUserManualTitleBar UIUserManualTitleBar
        {
            get
            {
                if ((this.mUIUserManualTitleBar == null))
                {
                    this.mUIUserManualTitleBar = new UIUserManualTitleBar(this);
                }
                return this.mUIUserManualTitleBar;
            }
        }
        #endregion
        
        #region Fields
        private UINextWindow mUINextWindow;
        
        private UIBackWindow mUIBackWindow;
        
        private UIUserManualTitleBar mUIUserManualTitleBar;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UINextWindow : WinWindow
    {
        
        public UINextWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnNext";
            this.WindowTitles.Add("User Manual");
            #endregion
        }
        
        #region Properties
        public WinButton UINextButton
        {
            get
            {
                if ((this.mUINextButton == null))
                {
                    this.mUINextButton = new WinButton(this);
                    #region Search Criteria
                    this.mUINextButton.SearchProperties[WinButton.PropertyNames.Name] = "Next";
                    this.mUINextButton.WindowTitles.Add("User Manual");
                    #endregion
                }
                return this.mUINextButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUINextButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIBackWindow : WinWindow
    {
        
        public UIBackWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnBack";
            this.WindowTitles.Add("User Manual");
            #endregion
        }
        
        #region Properties
        public WinButton UIBackButton
        {
            get
            {
                if ((this.mUIBackButton == null))
                {
                    this.mUIBackButton = new WinButton(this);
                    #region Search Criteria
                    this.mUIBackButton.SearchProperties[WinButton.PropertyNames.Name] = "Back";
                    this.mUIBackButton.WindowTitles.Add("User Manual");
                    #endregion
                }
                return this.mUIBackButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIBackButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIUserManualTitleBar : WinTitleBar
    {
        
        public UIUserManualTitleBar(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("User Manual");
            #endregion
        }
        
        #region Properties
        public WinButton UICloseButton
        {
            get
            {
                if ((this.mUICloseButton == null))
                {
                    this.mUICloseButton = new WinButton(this);
                    #region Search Criteria
                    this.mUICloseButton.SearchProperties[WinButton.PropertyNames.Name] = "Close";
                    this.mUICloseButton.WindowTitles.Add("User Manual");
                    #endregion
                }
                return this.mUICloseButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUICloseButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIPlayerStatsWindow1 : WinWindow
    {
        
        public UIPlayerStatsWindow1()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "PlayerStats";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("PlayerStats");
            #endregion
        }
        
        #region Properties
        public UIPlayerStatsTitleBar UIPlayerStatsTitleBar
        {
            get
            {
                if ((this.mUIPlayerStatsTitleBar == null))
                {
                    this.mUIPlayerStatsTitleBar = new UIPlayerStatsTitleBar(this);
                }
                return this.mUIPlayerStatsTitleBar;
            }
        }
        #endregion
        
        #region Fields
        private UIPlayerStatsTitleBar mUIPlayerStatsTitleBar;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIPlayerStatsTitleBar : WinTitleBar
    {
        
        public UIPlayerStatsTitleBar(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("PlayerStats");
            #endregion
        }
        
        #region Properties
        public WinButton UICloseButton
        {
            get
            {
                if ((this.mUICloseButton == null))
                {
                    this.mUICloseButton = new WinButton(this);
                    #region Search Criteria
                    this.mUICloseButton.SearchProperties[WinButton.PropertyNames.Name] = "Close";
                    this.mUICloseButton.WindowTitles.Add("PlayerStats");
                    #endregion
                }
                return this.mUICloseButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUICloseButton;
        #endregion
    }
}
