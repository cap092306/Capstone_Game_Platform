using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Capstone_Game_Platform
{
    public partial class ContinueGame : Form
    {
        public ContinueGame()
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

            int count = dt.AsEnumerable()
                .Where(i => i.Field<string>("player_ID") == StartScreen.PlayerID.ToString() 
                      && !string.IsNullOrWhiteSpace(i.Field<string>("completed").ToString()))
                .Count();

            if (count > 0)
            {
                DataTable lvlsCompleted = (from lc in dt.AsEnumerable()
                    where lc.Field<string>("player_ID") == StartScreen.PlayerID.ToString() 
                        && !string.IsNullOrWhiteSpace(lc.Field<string>("completed").ToString())
                    orderby lc.Field<string>("level_ID")
                    select lc).CopyToDataTable();

                DisplayLevels(lvlsCompleted);

                string maxPlayerLvl = lvlsCompleted.AsEnumerable()
                    .OrderByDescending(j => j.Field<string>("level_ID"))
                    .First().Field<string>("level_ID").ToString();

                string maxLvl = ds.Tables[(int)SaveGameHelper.XMLTbls.level].AsEnumerable()
                    .OrderByDescending(k => k.Field<string>("level_ID"))
                    .First().Field<string>("level_ID").ToString();
                
                if (maxPlayerLvl != maxLvl)
                {
                    int.TryParse(maxPlayerLvl, out int retVal);
                    retVal += 1;
                    DisplayNextLevel(retVal.ToString());
                }
            }

            count = dt.AsEnumerable()
                .Where(i => i.Field<string>("player_ID") == StartScreen.PlayerID.ToString() 
                    && i.Field<string>("last_played") == dt.AsEnumerable()
                        .OrderByDescending(t => t.Field<string>("last_played"))
                        .First().Field<string>("last_played").ToString())
                .Count();

            if(count > 0)
            {
                DataRow lastPlayed = (from lp in dt.AsEnumerable()
                    where lp.Field<string>("player_ID") == StartScreen.PlayerID.ToString() &&
                        lp.Field<string>("last_played") == dt.AsEnumerable()
                            .OrderByDescending(t => t.Field<string>("last_played"))
                            .First().Field<string>("last_played").ToString()
                    select lp).SingleOrDefault();

                DisplayLastLevel(lastPlayed);
            }
        }

        private void DisplayLevels(DataTable dt)
        {
            string TargetBtnName = "btnLvl";
            Button TargetBtn;

            if (dt != null && dt.Columns.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TargetBtnName += dr.Field<string>("level_id").ToString();
                    TargetBtn = (Button)Controls[TargetBtnName];
                    TargetBtn.Enabled = true;
                    TargetBtn.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void DisplayNextLevel(string lvl)
        {
            if (!string.IsNullOrWhiteSpace(lvl))
            {
                string TargetBtnName = "btnLvl" + lvl;
                Button TargetBtn = (Button)Controls[TargetBtnName];
                TargetBtn.Enabled = true;
                TargetBtn.ForeColor = System.Drawing.Color.White;
            }
        }

        private void DisplayLastLevel(DataRow dr)
        {
            if (dr != null)
            {
                string TargetBtnName = "btnLvl" + dr.Field<string>("level_ID").ToString();
                Button TargetBtn = (Button)Controls[TargetBtnName];
                TargetBtn.Enabled = true;
                TargetBtn.ForeColor = System.Drawing.Color.Yellow;
            }
        }

        private void BtnLvl1_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            Dispose();
        }

        private void BtnLvl2_Click(object sender, EventArgs e)
        {
            Form Form2 = new Form2();
            Form2.Show();
            Dispose();
        }

        private void BtnLvl3_Click(object sender, EventArgs e)
        {
            Form Form3 = new Form3();
            Form3.Show();
            Dispose();
        }
    }
}
