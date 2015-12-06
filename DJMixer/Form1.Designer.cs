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
			this.button_PlayRight = new System.Windows.Forms.Button();
			this.button_StopRightPlayer = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.trackBar_CrossFader = new System.Windows.Forms.TrackBar();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.leftPlayer = new DJMixer.Player();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_CrossFader)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_PlayRight
			// 
			this.button_PlayRight.Location = new System.Drawing.Point(85, 426);
			this.button_PlayRight.Name = "button_PlayRight";
			this.button_PlayRight.Size = new System.Drawing.Size(75, 23);
			this.button_PlayRight.TabIndex = 4;
			this.button_PlayRight.Text = "Play";
			this.button_PlayRight.UseVisualStyleBackColor = true;
			this.button_PlayRight.Click += new System.EventHandler(this.button_PlayRight_Click);
			// 
			// button_StopRightPlayer
			// 
			this.button_StopRightPlayer.Location = new System.Drawing.Point(198, 426);
			this.button_StopRightPlayer.Name = "button_StopRightPlayer";
			this.button_StopRightPlayer.Size = new System.Drawing.Size(75, 23);
			this.button_StopRightPlayer.TabIndex = 6;
			this.button_StopRightPlayer.Text = "Stop";
			this.button_StopRightPlayer.UseVisualStyleBackColor = true;
			this.button_StopRightPlayer.Click += new System.EventHandler(this.button_StopRightPlayer_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button_PlayRight);
			this.groupBox2.Controls.Add(this.button_StopRightPlayer);
			this.groupBox2.Location = new System.Drawing.Point(425, 45);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(369, 470);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(806, 623);
			this.Controls.Add(this.leftPlayer);
			this.Controls.Add(this.trackBar_CrossFader);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar_CrossFader)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button_PlayRight;
		private System.Windows.Forms.Button button_StopRightPlayer;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TrackBar trackBar_CrossFader;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem1;
		private Player leftPlayer;
	}
}

