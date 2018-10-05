namespace Capstone_Game_Platform
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.background = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.door = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.coin = new System.Windows.Forms.PictureBox();
            this.key = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.door)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.key)).BeginInit();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(100, 50);
            this.background.TabIndex = 0;
            this.background.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "platform";
            // 
            // door
            // 
            this.door.Location = new System.Drawing.Point(0, 151);
            this.door.Name = "door";
            this.door.Size = new System.Drawing.Size(100, 50);
            this.door.TabIndex = 2;
            this.door.TabStop = false;
            this.door.Tag = "door";
            // 
            // player
            // 
            this.player.Location = new System.Drawing.Point(0, 221);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(100, 50);
            this.player.TabIndex = 3;
            this.player.TabStop = false;
            // 
            // coin
            // 
            this.coin.Location = new System.Drawing.Point(0, 293);
            this.coin.Name = "coin";
            this.coin.Size = new System.Drawing.Size(100, 50);
            this.coin.TabIndex = 4;
            this.coin.TabStop = false;
            this.coin.Tag = "coin";
            // 
            // key
            // 
            this.key.Location = new System.Drawing.Point(126, 0);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(100, 50);
            this.key.TabIndex = 5;
            this.key.TabStop = false;
            this.key.Tag = "key";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.maingameTimer);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(598, 481);
            this.Controls.Add(this.key);
            this.Controls.Add(this.coin);
            this.Controls.Add(this.player);
            this.Controls.Add(this.door);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.background);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.door)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.key)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox door;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox coin;
        private System.Windows.Forms.PictureBox key;
        private System.Windows.Forms.Timer gameTimer;
    }
}

