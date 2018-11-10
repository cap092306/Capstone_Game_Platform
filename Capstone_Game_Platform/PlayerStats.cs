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
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            ds = xmlUtils.ReadXMLfile();
            LoadPlayerHistory();
            LoadPlayerAchievements();
        }

        private void LoadPlayerHistory()
        {
            DataTable dt = ds.Tables[(int)SaveGameHelper.XMLTbls.player_history];
            DataTable stats = dt.AsEnumerable()
                .Where(i => i.Field<string>("player_ID") == StartScreen.PlayerID.ToString())
                .OrderBy(i => i.Field<string>("level_ID"))
                .CopyToDataTable();

            stats.TableName = "Player History";
            stats.Columns.RemoveAt(0); // player_idstats.Columns["level_ID"].SetOrdinal(0);
            stats.Columns["level_ID"].SetOrdinal(0);
            stats.Columns["level_ID"].ColumnName = "Level";
            stats.Columns["points"].SetOrdinal(1);
            stats.Columns["points"].ColumnName = "Highest Score";
            stats.Columns["level_time"].SetOrdinal(2);
            stats.Columns["level_time"].ColumnName = "Best Time";
            stats.Columns["last_played"].SetOrdinal(3);
            stats.Columns["last_played"].ColumnName = "Last Played";
            stats.Columns["completed"].SetOrdinal(4);
            stats.Columns["completed"].ColumnName = "Date First Completed";
            stats.Columns["level_attempts"].SetOrdinal(5);
            stats.Columns["level_attempts"].ColumnName = "Lowest Number of Restarts to Complete Level";
            stats.Columns["monster_count"].SetOrdinal(6);
            stats.Columns["monster_count"].ColumnName = "Highest Number of Lighting Bolts Defeated";
            stats.Columns["life_count"].SetOrdinal(7);
            stats.Columns["life_count"].ColumnName = "Highest Number of Remaining Lives";
            stats.Columns["special_count"].SetOrdinal(8);
            stats.Columns["special_count"].ColumnName = "Highest Number of Special Items Found";

            LinqPivot lp = new LinqPivot();
            stats = lp.Pivot(stats, stats.Columns["Level"], "Level Stats");

            dataGridView1.DataSource = stats;
            dataGridView1.Show();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void LoadPlayerAchievements()
        {
            DataTable dt = ds.Tables[(int)SaveGameHelper.XMLTbls.player_achievement];
            DataTable results = dt.AsEnumerable()
                .Where(i => i.Field<string>("player_ID") == StartScreen.PlayerID.ToString())
                .OrderBy(i => i.Field<string>("achievement_ID"))
                .CopyToDataTable();

            DataTable achieve = ds.Tables[(int)SaveGameHelper.XMLTbls.achievement];

            DataTable result = new DataTable();





            //dataGridView2.DataSource = results;


            //dataGridView2.Show();
            //dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }
    }
}
