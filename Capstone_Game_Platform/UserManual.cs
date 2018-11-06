using System;
using System.Windows.Forms;
using System.IO;

namespace Capstone_Game_Platform
{
    public partial class UserManual : Form
    {

        public UserManual()
        {
            InitializeComponent();
            webBrowser1.Url = new Uri("file:///" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.HELPName.ToString()));
        }  
    }
}
