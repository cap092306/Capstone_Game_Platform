namespace Capstone_Game_Platform
{
    partial class Continue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Continue));
            this.btnLvl1 = new System.Windows.Forms.Button();
            this.btnLvl2 = new System.Windows.Forms.Button();
            this.btnLvl3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLvl1
            // 
            this.btnLvl1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLvl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLvl1.ForeColor = System.Drawing.Color.White;
            this.btnLvl1.Location = new System.Drawing.Point(92, 32);
            this.btnLvl1.Name = "btnLvl1";
            this.btnLvl1.Size = new System.Drawing.Size(160, 49);
            this.btnLvl1.TabIndex = 0;
            this.btnLvl1.Text = "Level 1";
            this.btnLvl1.UseVisualStyleBackColor = true;
            this.btnLvl1.Click += new System.EventHandler(this.btnLvl1_Click);
            // 
            // btnLvl2
            // 
            this.btnLvl2.Enabled = false;
            this.btnLvl2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLvl2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLvl2.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLvl2.Location = new System.Drawing.Point(92, 112);
            this.btnLvl2.Name = "btnLvl2";
            this.btnLvl2.Size = new System.Drawing.Size(160, 49);
            this.btnLvl2.TabIndex = 1;
            this.btnLvl2.Text = "Level 2";
            this.btnLvl2.UseVisualStyleBackColor = true;
            this.btnLvl2.Click += new System.EventHandler(this.btnLvl2_Click);
            // 
            // btnLvl3
            // 
            this.btnLvl3.Enabled = false;
            this.btnLvl3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLvl3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLvl3.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLvl3.Location = new System.Drawing.Point(92, 187);
            this.btnLvl3.Name = "btnLvl3";
            this.btnLvl3.Size = new System.Drawing.Size(160, 49);
            this.btnLvl3.TabIndex = 2;
            this.btnLvl3.Text = "Level 3";
            this.btnLvl3.UseVisualStyleBackColor = true;
            this.btnLvl3.Click += new System.EventHandler(this.btnLvl3_Click);
            // 
            // Continue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(338, 264);
            this.Controls.Add(this.btnLvl3);
            this.Controls.Add(this.btnLvl2);
            this.Controls.Add(this.btnLvl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Continue";
            this.Text = "Continue";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLvl1;
        private System.Windows.Forms.Button btnLvl2;
        private System.Windows.Forms.Button btnLvl3;
    }
}