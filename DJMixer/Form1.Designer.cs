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
			this.buttonPlay = new System.Windows.Forms.Button();
			this.button_Stop = new System.Windows.Forms.Button();
			this.button_PlayRight = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.button_StopRightPlayer = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonPlay
			// 
			this.buttonPlay.Location = new System.Drawing.Point(37, 441);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(75, 23);
			this.buttonPlay.TabIndex = 0;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.UseVisualStyleBackColor = true;
			this.buttonPlay.Click += new System.EventHandler(this.button_PlayLeft_Click);
			// 
			// button_Stop
			// 
			this.button_Stop.Cursor = System.Windows.Forms.Cursors.Default;
			this.button_Stop.Location = new System.Drawing.Point(153, 441);
			this.button_Stop.Name = "button_Stop";
			this.button_Stop.Size = new System.Drawing.Size(75, 23);
			this.button_Stop.TabIndex = 3;
			this.button_Stop.Text = "Stop";
			this.button_Stop.UseVisualStyleBackColor = true;
			this.button_Stop.Click += new System.EventHandler(this.button_StopLeftPlayer_Click);
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
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.progressBar1);
			this.groupBox1.Controls.Add(this.buttonPlay);
			this.groupBox1.Controls.Add(this.button_Stop);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(380, 470);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(7, 368);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(367, 42);
			this.progressBar1.TabIndex = 4;
			this.progressBar1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.progressBar_click);
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
			this.groupBox2.Location = new System.Drawing.Point(426, 13);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(369, 470);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(37, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(40, 156);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "label2";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(807, 495);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonPlay;
		private System.Windows.Forms.Button button_Stop;
		private System.Windows.Forms.Button button_PlayRight;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button_StopRightPlayer;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

