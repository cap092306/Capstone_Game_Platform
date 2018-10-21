using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System.IO;


namespace Capstone_Game_Platform
{
    public partial class PlayerStats : Form
    {
        private XMLUtils xmlUtils;
        private DataSet ds;
        private const int player_history = 3;
        private const int player_achievement = 4;
        public PlayerStats()
        {
            InitializeComponent();
        }

        private void PlayerStats_Load(object sender, EventArgs e)
        {
            xmlUtils = new XMLUtils()
            {
                Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cloud9Data.xml")
            };
            ds = xmlUtils.ReadXMLfile();
        }

        private void LoadPlayerHistory()
        {
            DataTable dt = ds.Tables[player_history];
            DataTable stats = dt.AsEnumerable()
                .Where(i => i.Field<String>("player_ID") == StartScreen.PlayerID.ToString())
                .OrderByDescending(i => i.Field<String>("level_ID"))
                .CopyToDataTable();
            
            
        }
    }
}
