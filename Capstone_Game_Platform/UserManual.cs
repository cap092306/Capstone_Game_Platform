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

            Uri uriPath = new Uri("file:///" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.HELPName.ToString()),UriKind.Absolute);
            webBrowser1.Url = uriPath;
            
            webBrowser1.Refresh();
        }
    }
}
