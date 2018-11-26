using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTestProject")]
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
            int count = dt.AsEnumerable()
                .Where(i => i.Field<string>("player_ID") == StartScreen.PlayerID.ToString())
                .Count();

            if (count > 0)
            {
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
                
            } else {
                DataGridViewColumn msgCol = new DataGridViewColumn(new DataGridViewTextBoxCell());
                dataGridView1.Columns.Add(msgCol);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[0].Cells[0].Value = "No player history data to view. Go save the Sun!";
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void LoadPlayerAchievements()
        {
            DataTable dt = ds.Tables[(int)SaveGameHelper.XMLTbls.player_achievement];
            int count = dt.AsEnumerable()
                .Where(i => i.Field<string>("player_ID") == StartScreen.PlayerID.ToString()
                    && i.Field<string>("achievement_data") != "0")
                .Count();

            if (count > 0)
            {
                DataTable player = dt.AsEnumerable()
                    .Where(i => i.Field<string>("player_ID") == StartScreen.PlayerID.ToString()
                    && i.Field<string>("achievement_data") != "0")
                    .CopyToDataTable();
                dt = ds.Tables[(int)SaveGameHelper.XMLTbls.achievement];
                var result = from dt1 in player.AsEnumerable()
                             join dt2 in dt.AsEnumerable() on (string)dt1["achievement_ID"]
                             equals (string)dt2["achievement_ID"]
                             select new
                             {
                                 achievement_ID = (string)dt1["achievement_ID"],
                                 achievement_data = (string)dt1["achievement_data"],
                                 achievement_date = (string)dt1["achievement_date"],
                                 achievement_name = (string)dt2["achievement_name"],
                                 achievement_desc = (string)dt2["achievement_desc"],
                                 badge = (string)dt2["badge"],
                                 number = (string)dt2["number"]
                             };

                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                dataGridView2.Columns.Add(imageCol);

                DataGridViewColumn descCol = new DataGridViewColumn(new DataGridViewTextBoxCell());
                dataGridView2.Columns.Add(descCol);
                DataGridViewColumn playerCol = new DataGridViewColumn(new DataGridViewTextBoxCell());
                dataGridView2.Columns.Add(playerCol);

                for (int j = 0; j < result.Count(); j++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[j].Cells[0].Value = 
                        Properties.Resources.ResourceManager.GetObject(result.ElementAt(j).badge.ToString());
                    dataGridView2.Rows[j].Cells[1].Value = 
                        string.Format("{0} - {1}", result.ElementAt(j).achievement_name, result.ElementAt(j).achievement_desc);
                    if (result.ElementAt(j).achievement_date.ToString() == string.Empty)
                    {
                        int.TryParse(result.ElementAt(j).number, out int badgeValue);
                        int.TryParse(result.ElementAt(j).achievement_data, out int playerData);
                        dataGridView2.Rows[j].Cells[2].Value = string.Format("You have {0} of {1}.", playerData, badgeValue);
                    }
                    else
                    {
                        dataGridView2.Rows[j].Cells[2].Value = string.Format("You achieved this goal on {0}.", result.ElementAt(j).achievement_date.ToString());
                    }

                }
            } else {
                DataGridViewColumn msgCol = new DataGridViewColumn(new DataGridViewTextBoxCell());
                dataGridView2.Columns.Add(msgCol);
                dataGridView2.Rows.Add();
                dataGridView2.Rows[0].Cells[0].Value = "No player achievement data to view. Go save the Sun!";
            }

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}