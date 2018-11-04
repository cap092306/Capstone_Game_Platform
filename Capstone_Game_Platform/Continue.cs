using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Capstone_Game_Platform
{
    public partial class Continue : Form
    {
        public Continue()
        {
            InitializeComponent();
            LoadPlayerLevelHistory();
        }

        private void LoadPlayerLevelHistory()
        {
            XMLUtils xmlUtils = new XMLUtils()
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            DataSet ds = xmlUtils.ReadXMLfile();
            DataTable dt = ds.Tables[(int)SaveGameHelper.XMLTbls.player_history];
            DataTable lvlsCompleted = new DataTable();
            var rows = dt.AsEnumerable()
                .Where(
                    i =>
                    i.Field<string>("player_ID") == StartScreen.PlayerID.ToString() &&
                    !String.IsNullOrWhiteSpace(i.Field<string>("completed").ToString()))
                .OrderBy(x => x.Field<string>("level_ID"))
                .DefaultIfEmpty();

            foreach (var row in rows) { lvlsCompleted.ImportRow(row); }
            if (lvlsCompleted != null) { DisplayLevels(lvlsCompleted); }
           
            DataRow lastPlayed = dt.AsEnumerable()
                .Where(
                    a =>
                    a.Field<string>("player_ID") == StartScreen.PlayerID.ToString() &&
                    a.Field<string>("last_played") == dt.AsEnumerable()
                        .Where(
                            i => 
                            !String.IsNullOrWhiteSpace(i.Field<string>("last_played").ToString()))
                        .Max(x => x.Field<DateTime>("last_played")).ToString())
                .SingleOrDefault();

            DisplayLastLevel(lastPlayed);
        }

        private void DisplayLevels(DataTable dt)
        {
            string TargetBtnName = "btnLvl";
            Button TargetBtn;

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TargetBtnName += dr.Field<string>("level_id").ToString();
                    TargetBtn = (Button)this.Controls[TargetBtnName];
                    TargetBtn.Enabled = true;
                    TargetBtn.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void DisplayLastLevel(DataRow dr)
        {
            string TargetBtnName = "btnLvl" + dr.Field<string>("level_ID").ToString();
            Button TargetBtn = (Button)this.Controls[TargetBtnName];
            TargetBtn.Enabled = true;
            TargetBtn.ForeColor = System.Drawing.Color.Yellow;
        }

        private void btnLvl1_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Dispose();
        }

        private void btnLvl2_Click(object sender, EventArgs e)
        {
            Form Form2 = new Form2();
            Form2.Show();
            this.Dispose();
        }

        private void btnLvl3_Click(object sender, EventArgs e)
        {
            Form Form3 = new Form3();
            Form3.Show();
            this.Dispose();
        }
    }
}
