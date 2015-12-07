using System;

namespace DJMixer
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
			this.trackBar_CrossFader = new System.Windows.Forms.TrackBar();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.leftPlayer = new DJMixer.Player();
			this.rightPlayer = new DJMixer.Player();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_CrossFader)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// trackBar_CrossFader
			// 
			this.trackBar_CrossFader.Location = new System.Drawing.Point(269, 527);
			this.trackBar_CrossFader.Maximum = 100;
			this.trackBar_CrossFader.Name = "trackBar_CrossFader";
			this.trackBar_CrossFader.Size = new System.Drawing.Size(270, 45);
			this.trackBar_CrossFader.TabIndex = 8;
			this.trackBar_CrossFader.TickFrequency = 5;
			this.trackBar_CrossFader.Value = 50;
			this.trackBar_CrossFader.Scroll += new System.EventHandler(this.trackBar_CrossFader_Scroll);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(806, 24);
			this.menuStrip1.TabIndex = 9;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// configToolStripMenuItem
			// 
			this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem1});
			this.configToolStripMenuItem.Name = "configToolStripMenuItem";
			this.configToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.configToolStripMenuItem.Text = "Tools";
			// 
			// configToolStripMenuItem1
			// 
			this.configToolStripMenuItem1.Name = "configToolStripMenuItem1";
			this.configToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
			this.configToolStripMenuItem1.Text = "Config";
			this.configToolStripMenuItem1.Click += new System.EventHandler(this.configToolStripMenuItem1_Click);
			// 
			// leftPlayer
			// 
			this.leftPlayer.Location = new System.Drawing.Point(12, 45);
			this.leftPlayer.Name = "leftPlayer";
			this.leftPlayer.Size = new System.Drawing.Size(392, 483);
			this.leftPlayer.TabIndex = 10;
			// 
			// rightPlayer
			// 
			this.rightPlayer.Location = new System.Drawing.Point(410, 45);
			this.rightPlayer.Name = "rightPlayer";
			this.rightPlayer.Size = new System.Drawing.Size(392, 483);
			this.rightPlayer.TabIndex = 11;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(806, 623);
			this.Controls.Add(this.rightPlayer);
			this.Controls.Add(this.leftPlayer);
			this.Controls.Add(this.trackBar_CrossFader);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.trackBar_CrossFader)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion
		private System.Windows.Forms.TrackBar trackBar_CrossFader;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem1;
		private Player leftPlayer;
		private Player rightPlayer;
	}
}

