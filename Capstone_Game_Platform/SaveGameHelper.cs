using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Capstone_Game_Platform
{
    public class SaveGameHelper
    {
        public int Player_ID { get; set; }
        public string Player_Name { get; set; }
        public int Char_Level { get; set; }
        public int Char_Points { get; set; }
        public int Level_ID { get; set; }
        public int Life_Count { get; set; }
        public int Level_Score { get; set; }
        public int Level_Time { get; set; } //second count
        public int Monster_Count { get; set; } //monsters killed
        public int Special_Count { get; set; } // special items found
        public Achievement Player_Achievement { get; set; }
        public string Achievement_Data { get; set; }
        public DateTime Achievement_Date { get; set; }

        private XMLUtils xmlUtils;
        private DataSet ds;
        //tables in XML managed in this helper
        private const int player_history = 4;
        private const int player_achievement = 5;
        //achievements
        public enum Achievement : int { Defeat_Moon = 1, Star_Light = 2, light_speed = 3}




        public  SaveGameHelper(){
            LoadXMLUtils();
        }

        private void LoadXMLUtils()
        {
            xmlUtils = new XMLUtils()
            {
                Path = Path.Combine(Application.ExecutablePath, "Cloud9Data.xml")
            };
            ds = xmlUtils.ReadXMLfile();
        }

        public bool SaveLevel()
        {
            //player_history
            DataTable dt = ds.Tables[player_history];
            DataRow result = (from row in dt.AsEnumerable()
                              where row.Field<int>("level_ID") == this.Level_ID //level1
                                    && row.Field<int>("player_ID") == this.Player_ID //player1
                              select row).SingleOrDefault();

            result.ItemArray[2] = this.Life_Count; // finished level with this many lives left
            result.ItemArray[3] = this.Level_Score; // final score of the level
            result.ItemArray[4] = this.Level_Time; // how long it took to complete the level in seconds
            result.ItemArray[5] = this.Special_Count; // how many special items were found in the level-default is one if the player finished the level
            result.ItemArray[6] = this.Monster_Count; // how many bad guys were defeated
            result.ItemArray[7] = DateTime.Now.ToString(); //last played
            if (result.ItemArray[8].ToString() == String.Empty)
            {
                result.ItemArray[8] = DateTime.Now.ToString(); //completed the first time
            }
            ds.AcceptChanges();
            xmlUtils.UpdateXMLfile(ds);

            return true;
        }

        public bool SaveAchievement()
        {
            DataTable dt = ds.Tables[player_achievement];
            DataRow result = (from row in dt.AsEnumerable()
                              where row.Field<int>("player_ID") == this.Player_ID
                                    && row.Field<int>("achievement_ID") == (int)(Achievement)this.Player_Achievement
                      select row).SingleOrDefault();
            //add to star collection achievement
            if (this.Player_Achievement == Achievement.Star_Light)
            {
                int starCount = int.Parse(this.Achievement_Data.ToString()) + int.Parse(result.ItemArray[2].ToString());
                result.ItemArray[2] = starCount.ToString();
                if (starCount >= 1000 && result.ItemArray[3].ToString() == String.Empty)
                {
                    result.ItemArray[3] = DateTime.Now.ToString();
                }
            }
            //other achievements maybe true or false data types, or will be tested against the level data
            //thus they will have to be handled differently

            ds.AcceptChanges();
            xmlUtils.UpdateXMLfile(ds);
            return true;
        }
    }
}
