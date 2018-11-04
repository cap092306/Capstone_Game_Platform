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
            DataTable dt = ds.Tables[(int)SaveGameHelper.XMLTbls.player_achievement];
            DataTable results = dt.AsEnumerable()
                .Where(i => i.Field<String>("player_ID") == StartScreen.PlayerID.ToString())
                .OrderBy(i => i.Field<String>("achievement_ID"))
                .CopyToDataTable();

            results.TableName = "Player Achievements";
            results.Columns.RemoveAt(0); // player_id
            results.Columns.RemoveAt(0); //achievement_id
            results.Columns["achievement_name"].SetOrdinal(0);
            results.Columns["achievement_desc"].SetOrdinal(1);
            results.Columns["achievement_data"].SetOrdinal(2);
            results.Columns["achievement_date"].SetOrdinal(3);
            
            dataGridView2.DataSource = results;
            dataGridView1.Columns[0].HeaderText = "Achievement";
            dataGridView1.Columns[1].HeaderText = "Details";
            dataGridView1.Columns[2].HeaderText = "Status";
            dataGridView1.Columns[3].HeaderText = "Date Achieved";

            dataGridView2.Show();
            dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }
    }
}
