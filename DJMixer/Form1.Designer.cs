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
			this.components = new System.ComponentModel.Container();
			this.trackBar_CrossFader = new System.Windows.Forms.TrackBar();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip_FaderReset = new System.Windows.Forms.ToolTip(this.components);
			this.leftSamplePlayer = new DJMixer.SamplePlayer();
			this.rightPlayer = new DJMixer.Player();
			this.leftPlayer = new DJMixer.Player();
			this.rightSamplePlayer = new DJMixer.SamplePlayer();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_CrossFader)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// trackBar_CrossFader
			// 
			this.trackBar_CrossFader.Location = new System.Drawing.Point(392, 483);
			this.trackBar_CrossFader.Maximum = 100;
			this.trackBar_CrossFader.Name = "trackBar_CrossFader";
			this.trackBar_CrossFader.Size = new System.Drawing.Size(407, 45);
			this.trackBar_CrossFader.TabIndex = 8;
			this.trackBar_CrossFader.TickFrequency = 5;
			this.toolTip_FaderReset.SetToolTip(this.trackBar_CrossFader, "Alt-Click to center fader");
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
			this.menuStrip1.Size = new System.Drawing.Size(1224, 24);
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
			// leftSamplePlayer
			// 
			this.leftSamplePlayer.Location = new System.Drawing.Point(12, 45);
			this.leftSamplePlayer.Name = "leftSamplePlayer";
			this.leftSamplePlayer.Size = new System.Drawing.Size(203, 409);
			this.leftSamplePlayer.TabIndex = 12;
			// 
			// rightPlayer
			// 
			this.rightPlayer.Location = new System.Drawing.Point(610, 45);
			this.rightPlayer.Name = "rightPlayer";
			this.rightPlayer.Size = new System.Drawing.Size(392, 432);
			this.rightPlayer.TabIndex = 11;
			// 
			// leftPlayer
			// 
			this.leftPlayer.Location = new System.Drawing.Point(212, 45);
			this.leftPlayer.Name = "leftPlayer";
			this.leftPlayer.Size = new System.Drawing.Size(392, 432);
			this.leftPlayer.TabIndex = 10;
			// 
			// rightSamplePlayer
			// 
			this.rightSamplePlayer.Location = new System.Drawing.Point(1008, 45);
			this.rightSamplePlayer.Name = "rightSamplePlayer";
			this.rightSamplePlayer.Size = new System.Drawing.Size(201, 432);
			this.rightSamplePlayer.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(568, 531);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "50% / 50%";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(389, 529);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "100% Left";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(763, 529);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "100% Right";
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1224, 556);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rightSamplePlayer);
			this.Controls.Add(this.leftSamplePlayer);
			this.Controls.Add(this.rightPlayer);
			this.Controls.Add(this.leftPlayer);
			this.Controls.Add(this.trackBar_CrossFader);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "DJ Blaster";
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
		private SamplePlayer leftSamplePlayer;
		private System.Windows.Forms.ToolTip toolTip_FaderReset;
		private SamplePlayer rightSamplePlayer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}

