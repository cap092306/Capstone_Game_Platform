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

        private XMLUtils xmlUtils;
        private DataSet ds;
        //tables in XML managed in this helper

        public enum XMLTbls : int {player = 0, achievement = 1, level = 2, player_history = 3, player_achievement = 4}
        //achievements
        public enum Achievement : int { Defeat_Moon = 1, Star_Light = 2, light_speed = 3}

        public  SaveGameHelper(){
            LoadXMLUtils();
        }

        private void LoadXMLUtils()
        {
            xmlUtils = new XMLUtils()
            {
                Path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            ds = xmlUtils.ReadXMLfile();
        }

        public bool SaveLevel()
        {
            //player_history
            DataTable dt = ds.Tables[(int)XMLTbls.player_history];
            DataRow result = (from row in dt.AsEnumerable()
                              where row.Field<string>("player_ID") == Player_ID.ToString() //player1
                                    && row.Field<string>("level_ID") == Level_ID.ToString() //level1
                              select row).SingleOrDefault();
            // save best stats
            int.TryParse(result.ItemArray[2].ToString(), out int life_count);
            if (Life_Count > life_count)
            {
                result.ItemArray[2] = Life_Count.ToString(); // finished level with this many lives left
            }

            int.TryParse(result.ItemArray[3].ToString(), out int level_score);
            if (Level_Score > level_score)
            {
                result.ItemArray[3] = Level_Score.ToString(); // final score of the level
            }

            int.TryParse(result.ItemArray[4].ToString(), out int level_time);
            if (Level_Time < level_time)
            { 
                result.ItemArray[4] = Level_Time.ToString(); // how long it took to complete the level in seconds
            }

            int.TryParse(result.ItemArray[5].ToString(), out int special_count);
            if (Special_Count > special_count)
            {
                result.ItemArray[5] = Special_Count.ToString(); // how many special items were found in the level-default is one if the player finished the level
            }

            int.TryParse(result.ItemArray[6].ToString(), out int monster_count);
            if (Monster_Count > monster_count)
            {
                result.ItemArray[6] = Monster_Count.ToString(); // how many bad guys were defeated
            }

            result.ItemArray[7] = DateTime.Now.ToString(); //last played

            if (result.ItemArray[8].ToString() == String.Empty)
            {
                result.ItemArray[8] = DateTime.Now.ToString(); //completed the first time
            }

            int.TryParse(result.ItemArray[9].ToString(), out int level_attempts);
            if (Monster_Count < level_attempts)
            {
                result.ItemArray[9] = Level_Attempts.ToString(); // how many times the level has been played
            }
            ds.AcceptChanges();
            xmlUtils.UpdateXMLfile(ds);

            return true;
        }

        public bool SaveAchievement()
        {
            DataTable dt = ds.Tables[(int)XMLTbls.player_achievement];
            DataRow result = (from row in dt.AsEnumerable()
                              where row.Field<string>("player_ID") == Player_ID.ToString()
                                    && row.Field<string>("achievement_ID") == ((int)Player_Achievement).ToString()
                      select row).SingleOrDefault();
            //add to star collection achievement
            int intAchievementData = 0;
            if (Player_Achievement == Achievement.Star_Light)
            {
                int.TryParse(Achievement_Data.ToString(), out intAchievementData);
                int.TryParse(result.ItemArray[2].ToString(), out int starCount);
                // if we add a second level of star collection add logic to handle it here
                result.ItemArray[2] = (intAchievementData + starCount).ToString();
                if ((intAchievementData + starCount) >= 1000 && result.ItemArray[3].ToString() == String.Empty)
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
