using System;
using System.Linq;
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
        public int Level_Attempts { get; set; } // how many times the level has been played
        public Achievement Player_Achievement { get; set; }
        public string Achievement_Data { get; set; }
        public DateTime Achievement_Date { get; set; }

        private XMLUtils xmlUtils;
        private DataSet ds;
        //tables in XML managed in this helper
        private const int player_history = 3;
        private const int player_achievement = 4;
        //achievements
        public enum Achievement : int { Defeat_Moon = 1, Star_Light = 2, light_speed = 3}

        public  SaveGameHelper(){
            LoadXMLUtils();
        }

        private void LoadXMLUtils()
        {
            xmlUtils = new XMLUtils()
            {
                Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cloud9Data.xml")
            };
            ds = xmlUtils.ReadXMLfile();
        }

        public bool SaveLevel()
        {
            //player_history
            DataTable dt = ds.Tables[player_history];
            DataRow result = (from row in dt.AsEnumerable()
                              where row.Field<string>("player_ID") == this.Player_ID.ToString() //player1
                                    && row.Field<string>("level_ID") == this.Level_ID.ToString() //level1
                              select row).SingleOrDefault();
            // save best stats
            int life_count = int.Parse(result.ItemArray[2].ToString() ?? "0");
            if (this.Life_Count > life_count)
            {
                result.ItemArray[2] = this.Life_Count.ToString(); // finished level with this many lives left
            }

            int level_score = int.Parse(result.ItemArray[3].ToString() ?? "0");
            if (this.Level_Score > level_score)
            {
                result.ItemArray[3] = this.Level_Score.ToString(); // final score of the level
            }

            int level_time = int.Parse(result.ItemArray[4].ToString() ?? "0");
            if (this.Level_Time > level_time)
            { 
                result.ItemArray[4] = this.Level_Time.ToString(); // how long it took to complete the level in seconds
            }

            int special_count = int.Parse(result.ItemArray[5].ToString() ?? "0");
            if (this.Special_Count > special_count)
            {
                result.ItemArray[5] = this.Special_Count.ToString(); // how many special items were found in the level-default is one if the player finished the level
            }

            int monster_count = int.Parse(result.ItemArray[6].ToString() ?? "0");
            if (this.Monster_Count > monster_count)
            {
                result.ItemArray[6] = this.Monster_Count.ToString(); // how many bad guys were defeated
            }

            result.ItemArray[7] = DateTime.Now.ToString(); //last played

            if (result.ItemArray[8].ToString() == String.Empty)
            {
                result.ItemArray[8] = DateTime.Now.ToString(); //completed the first time
            }

            int level_attempts = int.Parse(result.ItemArray[9].ToString() ?? "0");
            if (this.Monster_Count < level_attempts)
            {
                result.ItemArray[9] = this.Level_Attempts.ToString(); // how many times the level has been played
            }
            ds.AcceptChanges();
            xmlUtils.UpdateXMLfile(ds);

            return true;
        }

        public bool SaveAchievement()
        {
            DataTable dt = ds.Tables[player_achievement];
            DataRow result = (from row in dt.AsEnumerable()
                              where row.Field<string>("player_ID") == this.Player_ID.ToString()
                                    && row.Field<string>("achievement_ID") == ((int)(Achievement)this.Player_Achievement).ToString()
                      select row).SingleOrDefault();
            //add to star collection achievement
            if (Player_Achievement == Achievement.Star_Light)
            {
                int starCount = int.Parse(this.Achievement_Data.ToString() ?? "0") + int.Parse(result.ItemArray[2].ToString() ?? "0");
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
