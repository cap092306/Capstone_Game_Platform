using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;


namespace Capstone_Game_Platform
{
    public partial class PlayerStats : Form
    {
        private XMLUtils xmlUtils;
        private DataSet ds;
       
        public PlayerStats()
        {
            InitializeComponent();
        }

        private void PlayerStats_Load(object sender, EventArgs e)
        {
            xmlUtils = new XMLUtils()
            {
                Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            ds = xmlUtils.ReadXMLfile();
            LoadPlayerHistory();
            LoadPlayerAchievements();
        }

        private void LoadPlayerHistory()
        {
            DataTable dt = ds.Tables[(int)SaveGameHelper.XMLTbls.player_history];
            DataTable stats = dt.AsEnumerable()
                .Where(i => i.Field<String>("player_ID") == StartScreen.PlayerID.ToString())
                .OrderBy(i => i.Field<String>("level_ID"))
                .CopyToDataTable();

            stats.TableName = "Player History";
            stats.Columns.RemoveAt(0); // player_id
            stats.Columns["level_ID"].SetOrdinal(0);
            stats.Columns["points"].SetOrdinal(1);
            stats.Columns["level_time"].SetOrdinal(2);
            stats.Columns["last_played"].SetOrdinal(3);
            stats.Columns["completed"].SetOrdinal(4);
            stats.Columns["level_attempts"].SetOrdinal(5);
            stats.Columns["monster_count"].SetOrdinal(6);
            stats.Columns["life_count"].SetOrdinal(7);
            stats.Columns["special_count"].SetOrdinal(8);

            dataGridView1.DataSource = stats;
            dataGridView1.Columns[0].HeaderText = "Level";
            dataGridView1.Columns[1].HeaderText = "Highest Score";
            dataGridView1.Columns[2].HeaderText = "Best Time";
            dataGridView1.Columns[3].HeaderText = "Last Played";
            dataGridView1.Columns[4].HeaderText = "Date First Completed";
            dataGridView1.Columns[5].HeaderText = "Lowest Number of Restarts to Complete Level";
            dataGridView1.Columns[6].HeaderText = "Highest Number of Lighting Bolts Defeated";
            dataGridView1.Columns[7].HeaderText = "Highest Number of Remaining Lives";
            dataGridView1.Columns[8].HeaderText = "Highest Number of Special Items Found";

            dataGridView1.Show();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void LoadPlayerAchievements()
        {
            //DataTable dt1 = ds.Tables[(int)SaveGameHelper.XMLTbls.achievement];
            //DataTable dt2 = ds.Tables[(int)SaveGameHelper.XMLTbls.player_achievement];
            //IEnumerable<DataRow> results = from d1 in dt1.AsEnumerable()
            //                               join d2 in dt2.AsEnumerable() on d1["achievement_ID"].ToString() equals d2["achievement_ID"].ToString()
            //                               where d2["player_ID"].ToString() == StartScreen.PlayerID.ToString()
            //                               select new DataRow
            //                               {
            //                                   achievement_ID = (int)d1["achievement_ID"],
            //                                   achievement_name = (string)d1["achievement_name"],
            //                                   achievement_desc = (string)d1["achievement_desc"],
            //                                   achievement_data = (string)d2["achievement_data"],
            //                                   achievement_date = (System.DateTime)d2["achievement_date"]
            //                               };
            //DataTable CombinedDataTable = results.CopyToDataTable<DataRow>();



            //CombinedDataTable.TableName = "Player Achievements";
            //CombinedDataTable.Columns.RemoveAt(0); // player_id

            //dataGridView2.DataSource = CombinedDataTable;

            //dataGridView2.Show();
            //dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }
    }
}
