using System;
using System.Media;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data;
using System.Linq;

namespace Capstone_Game_Platform
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
            XMLUtils xmlUtils = new XMLUtils()
            {
                FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Resources.XMLDBName.ToString())
            };
            ValidateXMLFile(xmlUtils);
            //to make game multiplayer we would have to add a screen to select the player or add a new player 
            // which would set the player id and then the set the char level using the Get Player info
            GetPlayerInfo(xmlUtils);
        }
        SoundPlayer Theme = new SoundPlayer(Resource1.looperman_l_1804190_0133365_trippy_psychedelic_8_bit_sample_meltdown);
        public static int PlayerID = 1;// gives us the ability to allow for more than one player
        public static int LevelTryCounter = 0; //player counter level tries
        public static int char_level = 1; //player char level
		public static int tickCount = 0;

        private void ValidateXMLFile(XMLUtils xmlUtils)
        {
            if (!xmlUtils.ValidateXmlFile())
            {
                xmlUtils.DeleteXMLfile();
                xmlUtils.CreateXMLfile();
            }
        }

        private void GetPlayerInfo(XMLUtils xmlUtils)
        {
            DataSet ds = xmlUtils.ReadXMLfile();
            DataTable dt = ds.Tables[(int)SaveGameHelper.XMLTbls.player];
            int count = dt.AsEnumerable()
                .Where(i => i.Field<string>("player_ID") == PlayerID.ToString())
                .Count();

            if (count > 0)
            {
                DataRow result = (from row in ds.Tables[(int)SaveGameHelper.XMLTbls.player].AsEnumerable()
                                  where row.Field<string>("player_ID") == PlayerID.ToString()
                                  select row).SingleOrDefault();

                int.TryParse(result.ItemArray[(int)SaveGameHelper.PlayerTbl.char_level].ToString(), out int char_lvl);
                char_level = char_lvl;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form Form4 = new Form4();
            Form4.Show();
            Theme.Stop();
        }
        
        private void StartScreen_Load(object sender, EventArgs e)
        {
            Theme.PlayLooping();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form cont = new ContinueGame();
            cont.Show();
            Theme.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Help = new UserManual();
            Help.Show();
            Theme.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form Stats = new PlayerStats();
            Stats.Show();
            Theme.Stop();
        }

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (tickCount < 26) {
			tickCount ++;
			label2.Location = new Point(label2.Location.X, label2.Location.Y - 10);
			label3.Location = new Point(label3.Location.X, label3.Location.Y - 10);
			label4.Location = new Point(label4.Location.X, label4.Location.Y - 10);
			label5.Location = new Point(label5.Location.X, label5.Location.Y - 10);
			label6.Location = new Point(label6.Location.X, label6.Location.Y - 10);
			pictureBox2.BringToFront();
			pictureBox6.BringToFront();
			pictureBox7.BringToFront();
			}
			else
			timer1.Stop();
			//timer2.Start();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			label2.Location = new Point(label2.Location.X + 10, label2.Location.Y);
			label3.Location = new Point(label3.Location.X + 10, label3.Location.Y);
			label4.Location = new Point(label4.Location.X + 10, label4.Location.Y);
			label5.Location = new Point(label5.Location.X + 10, label5.Location.Y);
			label6.Location = new Point(label6.Location.X + 10, label6.Location.Y);
		}
	}
}
