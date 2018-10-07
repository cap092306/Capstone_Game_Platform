using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace Capstone_Game_Platform
{
    public partial class Form1 : Form
    {
        bool moveLeft = false; // used to control player moving left
        bool moveRight = false; // used to control player moving right
        bool blnJump = false; // used to check if player is blnJump or not
        bool blnHasKey = false; // used to determine if the player possesses the key
        int jumpSpd = 10; // jump speed integer
        int force = 8; // jump force
        int score = 0; // resets the score to 0 upon entering a level
        int playSpeed = 18; //play speed integer used to control the speed of the game
        int backLeft = 8; // sets backgound speed
        SoundPlayer CoinSound = new SoundPlayer(Resource1.qubodup_CoinCollect);

        public Form1()
        {
            InitializeComponent();
        }
        private void mainGameTimer(object sender, EventArgs e)
        {
            // linking the jumpSpd integer with the player picture boxes to location
            player.Top += jumpSpd;
            // refresh the player picture box consistently
            player.Refresh();
            // if blnJump is true and force is less than 0
            // then change blnJump to false
            if (blnJump && force < 0)
            {
                blnJump = false;
            }
            // if blnJump is true
            // then change jump speed to -12
            // reduce force by 1
            if (blnJump)
            {
                jumpSpd = -12;
                force -= 1;
            }
            else
            {
                // else change the jump speed to 12
                jumpSpd = 12;
            }
            // if go left is true and players left is greater than 100 pixels
            // only then move player towards left of the
            if (moveLeft && player.Left > 50)
            {
                player.Left -= playSpeed;
            }
            // by doing the if statement above, the player picture will stop on the forms left
            // if go right boolean is true
            // player left plus players width plus 100 is less then the forms width
            // then we move the player towards the right by adding to the players left
            if (moveRight && player.Left + (player.Width + 100) < this.ClientSize.Width)
            {
                player.Left += playSpeed;
            }
            // by doing the if statement above, the player picture will stop on the forms right
            // if go right is true and the background picture left is greater 1352
            // then we move the background picture towards the left
            if (moveRight && background.Left > -1353)
            {
                background.Left -= backLeft;
                // the for loop below is checking to see the platforms and coins in the level
                // when they are found it will move them towards the left
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin" || x is PictureBox && x.Tag == "door" || x is
                    PictureBox && x.Tag == "key")
                    {
                        x.Left -= backLeft;
                    }
                }
            }
            // if go left is true and the background pictures left is less than 2
            // then we move the background picture towards the right
            if (moveLeft && background.Left < 2)
            {
                background.Left += backLeft;
                // below the is the for loop thats checking to see the platforms and coins in the level
                // when they are found in the level it will move them all towards the right with the background
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform" || x is PictureBox && x.Tag == "coin" || x is PictureBox && x.Tag == "door" || x is
                    PictureBox && x.Tag == "key")
                    {
                        x.Left += backLeft;
                      
                    }
                }
            }
            // below if the for loop thats checking for all of the controls in this form
            foreach (Control x in this.Controls)
            {
                // is X is a picture box and it has a tag of platform
                if (x is PictureBox && x.Tag == "platform")
                {
                    // then we are checking if the player is colliding with the platform
                    // and blnJump is set to false
                    if (player.Bounds.IntersectsWith(x.Bounds) && !blnJump)
                    {
                        // then we do the following
                        force = 8; // set the force to 8
                        player.Top = x.Top - player.Height; // also we place the player on top of the picture box
                        jumpSpd = 0; // set the jump speed to 0
                    }
                }
                // if the picture box found has a tag of coin
                if (x is PictureBox && x.Tag == "coin")
                {
                    // now if the player collides with the coin picture box
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        CoinSound.Play();
                        this.Controls.Remove(x); // then we are going to remove the coin image
                        score++; // add 1 to the score
                    }
                }
            }
            // if the player collides with the door and has key boolean is true
            if (player.Bounds.IntersectsWith(door.Bounds) && blnHasKey)
            {
                // then we change the image of the door to open
                //The line below gave me an error so i commented it out until i can figure out what was wrong with it.
                //door.Image = Properties.Resources.door_open;
                // and we stop the timer
                gameTimer.Stop();
                MessageBox.Show("You Completed the level!!"); // show the message box
            }
            // if the player collides with the key picture box
            if (player.Bounds.IntersectsWith(key.Bounds))
            {
                // then we remove the key from the game
                this.Controls.Remove(key);
                // change the has key boolean to true
                blnHasKey = true;
            }
            // this is where the player dies
            // if the player goes below the forms height then we will end the game
            if (player.Top + player.Height > this.ClientSize.Height + 60)
            {
                gameTimer.Stop(); // stop the timer
                MessageBox.Show("You Died, the moon is laughing!!!"); // show the message box
                this.Close();
            }
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            //if the player pressed the left key AND the player is inside the panel
            // then we set the car left boolean to true
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            // if player pressed the right key and the player left plus player width is less then the panel1 width
            if (e.KeyCode == Keys.Right)
            {
                // then we set the player right to true
                moveRight = true;
            }
            //if the player pressed the space key and blnJump boolean is false
            if (e.KeyCode == Keys.Space && !blnJump)
            {
                // then we set blnJump to true
                blnJump = true;
            }
        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            // if the LEFT key is up we set the car left to false
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            // if the RIGHT key is up we set the car right to false
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            //when the keys are released we check if blnJump is true
            // if so we need to set it back to false so the player can jump again
            if (blnJump)
            {
                blnJump = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }
    }
}
