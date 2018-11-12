﻿namespace Capstone_Game_Platform
{
    partial class ContinueGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContinueGame));
            this.btnLvl1 = new System.Windows.Forms.Button();
            this.btnLvl2 = new System.Windows.Forms.Button();
            this.btnLvl3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLvl1
            // 
            this.btnLvl1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLvl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLvl1.ForeColor = System.Drawing.Color.White;
            this.btnLvl1.Location = new System.Drawing.Point(56, 47);
            this.btnLvl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLvl1.Name = "btnLvl1";
            this.btnLvl1.Size = new System.Drawing.Size(107, 32);
            this.btnLvl1.TabIndex = 0;
            this.btnLvl1.Text = "Level 1";
            this.btnLvl1.UseVisualStyleBackColor = true;
            this.btnLvl1.Click += new System.EventHandler(this.BtnLvl1_Click);
            // 
            // btnLvl2
            // 
            this.btnLvl2.Enabled = false;
            this.btnLvl2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLvl2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLvl2.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLvl2.Location = new System.Drawing.Point(56, 99);
            this.btnLvl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLvl2.Name = "btnLvl2";
            this.btnLvl2.Size = new System.Drawing.Size(107, 32);
            this.btnLvl2.TabIndex = 1;
            this.btnLvl2.Text = "Level 2";
            this.btnLvl2.UseVisualStyleBackColor = true;
            this.btnLvl2.Click += new System.EventHandler(this.BtnLvl2_Click);
            // 
            // btnLvl3
            // 
            this.btnLvl3.Enabled = false;
            this.btnLvl3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLvl3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLvl3.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLvl3.Location = new System.Drawing.Point(56, 148);
            this.btnLvl3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLvl3.Name = "btnLvl3";
            this.btnLvl3.Size = new System.Drawing.Size(107, 32);
            this.btnLvl3.TabIndex = 2;
            this.btnLvl3.Text = "Level 3";
            this.btnLvl3.UseVisualStyleBackColor = true;
            this.btnLvl3.Click += new System.EventHandler(this.BtnLvl3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select a Level to Play";
            // 
            // ContinueGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(225, 190);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLvl3);
            this.Controls.Add(this.btnLvl2);
            this.Controls.Add(this.btnLvl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ContinueGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Continue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLvl1;
        private System.Windows.Forms.Button btnLvl2;
        private System.Windows.Forms.Button btnLvl3;
        private System.Windows.Forms.Label label1;
    }
}