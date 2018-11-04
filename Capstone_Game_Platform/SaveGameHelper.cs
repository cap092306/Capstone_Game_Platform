﻿using System;
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
        public Achievements Player_Achievement { get; set; }
        public int Achievement_Data { get; set; }

        private XMLUtils xmlUtils;
        private DataSet ds;
        //tables in XML managed in this helper

        public enum XMLTbls : int {player = 0, player_history = 1, player_achievement = 2, level = 3, achievement = 4}
        public enum PlayerHistoryTbl : int {player_ID = 0, level_ID = 1, life_count = 2, points = 3, level_time = 4,
            special_count = 5, monster_count = 6, last_played = 7, completed = 8, level_attempts = 9}
        public enum PlayerAchievementsTbl : int { player_ID = 0, achievement_ID = 1, achievement_name = 2,
            achievement_desc = 3, achievement_data = 4, achievement_date = 5}
        //achievements
        public enum Achievement_Counters : int { Stars = 1000, Lighting = 100}
        public enum Achievements : int {Defeat_Moon = 1, Star_Power = 2, Star_Light = 3, Light_Speed_1 = 4,
            Light_Speed_2 = 5, Light_Speed_3 = 6, Specials_1 = 7, Specials_2 = 8, Specials_3 = 9,
            Shocked = 10, Electrocuted = 11, Kills_1 = 12, Kills_2 = 13, Kills_3 = 14, Hopper = 15, Surfer = 16,
            Head = 17, Black_Hole = 18, Skipper = 19, Jump = 20, Sacrifice = 21, Rider = 22, Chaser = 23,
            Portal_1 = 24, Portal_2 = 25}

        public  SaveGameHelper(){
            LoadXMLUtils();
        }

        private void LoadXMLUtils()
        {
            xmlUtils = new XMLUtils()
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            ds = xmlUtils.ReadXMLfile();
            DataColumn[] keys;
            ds.Tables[(int)XMLTbls.player].TableName = "Player";
            keys = new DataColumn[1];
            keys[0] = ds.Tables[(int)XMLTbls.player].Columns["player_ID"];
            ds.Tables[(int)XMLTbls.player].PrimaryKey = keys;

            ds.Tables[(int)XMLTbls.level].TableName = "Levels";
            keys = new DataColumn[1];
            keys[0] = ds.Tables[(int)XMLTbls.level].Columns["level_ID"];
            ds.Tables[(int)XMLTbls.level].PrimaryKey = keys;

            ds.Tables[(int)XMLTbls.player_history].TableName = "PlayerHistory";
            keys = new DataColumn[2];
            keys[0] = ds.Tables[(int)XMLTbls.player_history].Columns["player_ID"];
            keys[1] = ds.Tables[(int)XMLTbls.player_history].Columns["level_ID"];
            ds.Tables[(int)XMLTbls.player_history].PrimaryKey = keys;

            DataColumn parentColumn;
            DataColumn childColumn;
            ForeignKeyConstraint foreignKeyConstraint;

            parentColumn = ds.Tables[(int)XMLTbls.player].Columns["player_ID"];
            childColumn = ds.Tables[(int)XMLTbls.player_history].Columns["player_ID"];
            foreignKeyConstraint = new ForeignKeyConstraint("PlayerHistoryFK", parentColumn, childColumn);
            foreignKeyConstraint.DeleteRule = Rule.None;
            ds.Tables[(int)XMLTbls.player_history].Constraints.Add(foreignKeyConstraint);

            parentColumn = ds.Tables[(int)XMLTbls.level].Columns["level_ID"];
            childColumn = ds.Tables[(int)XMLTbls.player_history].Columns["level_ID"];
            foreignKeyConstraint = new ForeignKeyConstraint("LevelHistoryFK", parentColumn, childColumn);
            foreignKeyConstraint.DeleteRule = Rule.None;
            ds.Tables[(int)XMLTbls.player_history].Constraints.Add(foreignKeyConstraint);

            ds.Tables[(int)XMLTbls.achievement].TableName = "Achievement";
            keys = new DataColumn[1];
            keys[0] = ds.Tables[(int)XMLTbls.achievement].Columns["achievement_ID"];
            ds.Tables[(int)XMLTbls.achievement].PrimaryKey = keys;

            ds.Tables[(int)XMLTbls.player_achievement].TableName = "PlayerAchievements";
            keys = new DataColumn[2];
            keys[0] = ds.Tables[(int)XMLTbls.player_achievement].Columns["player_ID"];
            keys[1] = ds.Tables[(int)XMLTbls.player_achievement].Columns["achievement_ID"];
            ds.Tables[(int)XMLTbls.player_achievement].PrimaryKey = keys;

            parentColumn = ds.Tables[(int)XMLTbls.player].Columns["player_ID"];
            childColumn = ds.Tables[(int)XMLTbls.player_achievement].Columns["player_ID"];
            foreignKeyConstraint = new ForeignKeyConstraint("PlayerAchieveFK", parentColumn, childColumn);
            foreignKeyConstraint.DeleteRule = Rule.None;
            ds.Tables[(int)XMLTbls.player_achievement].Constraints.Add(foreignKeyConstraint);

            parentColumn = ds.Tables[(int)XMLTbls.achievement].Columns["achievement_ID"];
            childColumn = ds.Tables[(int)XMLTbls.player_achievement].Columns["achievement_ID"];
            foreignKeyConstraint = new ForeignKeyConstraint("LevelAchieveFK", parentColumn, childColumn);
            foreignKeyConstraint.DeleteRule = Rule.None;
            ds.Tables[(int)XMLTbls.player_achievement].Constraints.Add(foreignKeyConstraint);

            ds.EnforceConstraints = true;
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
            int.TryParse(result.ItemArray[(int)PlayerHistoryTbl.life_count].ToString(), out int life_count);
            if (Life_Count > life_count)
            {
                result.ItemArray[(int)PlayerHistoryTbl.life_count] = Life_Count.ToString(); // finished level with this many lives left
            }

            int.TryParse(result.ItemArray[(int)PlayerHistoryTbl.points].ToString(), out int level_score);
            if (Level_Score > level_score)
            {
                result.ItemArray[(int)PlayerHistoryTbl.points] = Level_Score.ToString(); // final score of the level
            }

            int.TryParse(result.ItemArray[(int)PlayerHistoryTbl.level_time].ToString(), out int level_time);
            if (Level_Time < level_time)
            { 
                result.ItemArray[(int)PlayerHistoryTbl.level_time] = Level_Time; // how long it took to complete the level in seconds
            }

            int.TryParse(result.ItemArray[(int)PlayerHistoryTbl.special_count].ToString(), out int special_count);
            if (Special_Count > special_count)
            {
                result.ItemArray[(int)PlayerHistoryTbl.special_count] = Special_Count; // how many special items were found in the level-default is one if the player finished the level
            }

            int.TryParse(result.ItemArray[(int)PlayerHistoryTbl.monster_count].ToString(), out int monster_count);
            if (Monster_Count > monster_count)
            {
                result.ItemArray[(int)PlayerHistoryTbl.monster_count] = Monster_Count; // how many bad guys were defeated
            }

            result.ItemArray[(int)PlayerHistoryTbl.last_played] = DateTime.Now.ToString(); //last played

            if (result.ItemArray[(int)PlayerHistoryTbl.completed].ToString() == String.Empty)
            {
                result.ItemArray[(int)PlayerHistoryTbl.completed] = DateTime.Now.ToString(); //completed the first time
            }

            int.TryParse(result.ItemArray[(int)PlayerHistoryTbl.level_attempts].ToString(), out int level_attempts);
            if (Level_Attempts < level_attempts)
            {
                result.ItemArray[(int)PlayerHistoryTbl.level_attempts] = Level_Attempts.ToString(); // how many times the level has been played
            }

            result.AcceptChanges();
            dt.AcceptChanges();
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

            int.TryParse(result.ItemArray[(int)PlayerAchievementsTbl.achievement_data].ToString(), out int achievementCount);

            if (Player_Achievement == Achievements.Star_Light) // Star Collection is a counter
            {   // if we add a second level of star collection add logic to handle it here
                result.ItemArray[(int)PlayerAchievementsTbl.achievement_data] = (Achievement_Data + achievementCount).ToString();
                if ((Achievement_Data + achievementCount) >= (int)Achievement_Counters.Stars && result.ItemArray[(int)PlayerAchievementsTbl.achievement_date].ToString() == string.Empty)
                {
                    result.ItemArray[(int)PlayerAchievementsTbl.achievement_date] = DateTime.Now.ToString();
                }
            }

            if (Player_Achievement == Achievements.Electrocuted) // Death by Lighting is a counter
            {   // if we add a second level of star collection add logic to handle it here
                result.ItemArray[(int)PlayerAchievementsTbl.achievement_data] = (Achievement_Data + achievementCount).ToString();
                if ((Achievement_Data + achievementCount) >= (int)Achievement_Counters.Lighting && result.ItemArray[(int)PlayerAchievementsTbl.achievement_date].ToString() == string.Empty)
                {
                    result.ItemArray[(int)PlayerAchievementsTbl.achievement_date] = DateTime.Now.ToString();
                }
            }
            
            // All other achievements are true or false data types, save as 1, to change from default of 0
            if(result.ItemArray[(int)PlayerAchievementsTbl.achievement_date].ToString() == string.Empty)
            {
                result.ItemArray[(int)PlayerAchievementsTbl.achievement_data] = 1;
                result.ItemArray[(int)PlayerAchievementsTbl.achievement_date] = DateTime.Now.ToString(); // record date of first achievement 
            }

            ds.AcceptChanges();
            xmlUtils.UpdateXMLfile(ds);
            return true;
        }
    }
}
