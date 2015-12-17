namespace DJMixer {
	partial class Player {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.loadMP3Dialog = new System.Windows.Forms.OpenFileDialog();
			this.button_Stop = new System.Windows.Forms.Button();
			this.buttonPlay = new System.Windows.Forms.Button();
			this.volumeMeterL = new NAudio.Gui.VolumeMeter();
			this.waveformPainterL = new NAudio.Gui.WaveformPainter();
			this.volumeMeterR = new NAudio.Gui.VolumeMeter();
			this.waveformPainterR = new NAudio.Gui.WaveformPainter();
			this.button_Load_Mp3 = new System.Windows.Forms.Button();
			this.songList = new System.Windows.Forms.CheckedListBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.button_Next = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).BeginInit();
			this.SuspendLayout();
			// 
			// trackBar_Volume
			// 
			this.trackBar_Volume.Location = new System.Drawing.Point(328, 3);
			this.trackBar_Volume.Size = new System.Drawing.Size(45, 218);
			// 
			// label_SongTitle
			// 
			this.label_SongTitle.Location = new System.Drawing.Point(11, 260);
			this.label_SongTitle.Size = new System.Drawing.Size(361, 39);
			// 
			// timer
			// 
			this.timer.Location = new System.Drawing.Point(144, 299);
			// 
			// panSlider1
			// 
			this.panSlider1.Location = new System.Drawing.Point(238, 227);
			// 
			// loadMP3Dialog
			// 
			this.loadMP3Dialog.FileName = "loadMP3Dialog";
			this.loadMP3Dialog.Filter = "MP3 files | *.mp3| Playlists | *.m3u";
			this.loadMP3Dialog.Multiselect = true;
			this.loadMP3Dialog.SupportMultiDottedExtensions = true;
			this.loadMP3Dialog.FileOk += new System.ComponentModel.CancelEventHandler(this.loadMP3Dialog_FileOk);
			// 
			// button_Stop
			// 
			this.button_Stop.Cursor = System.Windows.Forms.Cursors.Default;
			this.button_Stop.Location = new System.Drawing.Point(202, 398);
			this.button_Stop.Name = "button_Stop";
			this.button_Stop.Size = new System.Drawing.Size(75, 23);
			this.button_Stop.TabIndex = 3;
			this.button_Stop.Text = "Stop";
			this.button_Stop.UseVisualStyleBackColor = true;
			this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
			// 
			// buttonPlay
			// 
			this.buttonPlay.Location = new System.Drawing.Point(86, 398);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(75, 23);
			this.buttonPlay.TabIndex = 0;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.UseVisualStyleBackColor = true;
			this.buttonPlay.Click += new System.EventHandler(this.button_Play_Click);
			// 
			// volumeMeterL
			// 
			this.volumeMeterL.Amplitude = 0F;
			this.volumeMeterL.Location = new System.Drawing.Point(238, 61);
			this.volumeMeterL.MaxDb = 0F;
			this.volumeMeterL.MinDb = -48F;
			this.volumeMeterL.Name = "volumeMeterL";
			this.volumeMeterL.Size = new System.Drawing.Size(39, 160);
			this.volumeMeterL.TabIndex = 10;
			this.volumeMeterL.Text = "volumeMeterL";
			// 
			// waveformPainterL
			// 
			this.waveformPainterL.BackColor = System.Drawing.SystemColors.Window;
			this.waveformPainterL.Location = new System.Drawing.Point(238, 32);
			this.waveformPainterL.Name = "waveformPainterL";
			this.waveformPainterL.Size = new System.Drawing.Size(84, 23);
			this.waveformPainterL.TabIndex = 11;
			this.waveformPainterL.Text = "waveformPainterL";
			// 
			// volumeMeterR
			// 
			this.volumeMeterR.Amplitude = 0F;
			this.volumeMeterR.Location = new System.Drawing.Point(283, 61);
			this.volumeMeterR.MaxDb = 0F;
			this.volumeMeterR.MinDb = -48F;
			this.volumeMeterR.Name = "volumeMeterR";
			this.volumeMeterR.Size = new System.Drawing.Size(39, 160);
			this.volumeMeterR.TabIndex = 12;
			this.volumeMeterR.Text = "volumeMeterR";
			// 
			// waveformPainterR
			// 
			this.waveformPainterR.BackColor = System.Drawing.SystemColors.Window;
			this.waveformPainterR.Location = new System.Drawing.Point(237, 3);
			this.waveformPainterR.Name = "waveformPainterR";
			this.waveformPainterR.Size = new System.Drawing.Size(84, 23);
			this.waveformPainterR.TabIndex = 13;
			this.waveformPainterR.Text = "waveformPainterR";
			// 
			// button_Load_Mp3
			// 
			this.button_Load_Mp3.Location = new System.Drawing.Point(11, 309);
			this.button_Load_Mp3.Name = "button_Load_Mp3";
			this.button_Load_Mp3.Size = new System.Drawing.Size(75, 23);
			this.button_Load_Mp3.TabIndex = 14;
			this.button_Load_Mp3.Text = "Load MP3";
			this.button_Load_Mp3.UseVisualStyleBackColor = true;
			this.button_Load_Mp3.Click += new System.EventHandler(this.button_Load_Mp3_Click);
			// 
			// songList
			// 
			this.songList.FormattingEnabled = true;
			this.songList.IntegralHeight = false;
			this.songList.Location = new System.Drawing.Point(11, 3);
			this.songList.Name = "songList";
			this.songList.Size = new System.Drawing.Size(221, 254);
			this.songList.TabIndex = 15;
			this.songList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.songList_MouseDoubleClick);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(11, 338);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(362, 54);
			this.progressBar.TabIndex = 16;
			this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
			// 
			// button_Next
			// 
			this.button_Next.Location = new System.Drawing.Point(283, 398);
			this.button_Next.Name = "button_Next";
			this.button_Next.Size = new System.Drawing.Size(75, 23);
			this.button_Next.TabIndex = 17;
			this.button_Next.Text = "Next";
			this.button_Next.UseVisualStyleBackColor = true;
			this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
			// 
			// Player
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button_Next);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.buttonPlay);
			this.Controls.Add(this.button_Stop);
			this.Controls.Add(this.volumeMeterR);
			this.Controls.Add(this.songList);
			this.Controls.Add(this.volumeMeterL);
			this.Controls.Add(this.button_Load_Mp3);
			this.Controls.Add(this.waveformPainterR);
			this.Controls.Add(this.waveformPainterL);
			this.Name = "Player";
			this.Size = new System.Drawing.Size(380, 429);
			this.Controls.SetChildIndex(this.panSlider1, 0);
			this.Controls.SetChildIndex(this.waveformPainterL, 0);
			this.Controls.SetChildIndex(this.waveformPainterR, 0);
			this.Controls.SetChildIndex(this.button_Load_Mp3, 0);
			this.Controls.SetChildIndex(this.volumeMeterL, 0);
			this.Controls.SetChildIndex(this.songList, 0);
			this.Controls.SetChildIndex(this.volumeMeterR, 0);
			this.Controls.SetChildIndex(this.button_Stop, 0);
			this.Controls.SetChildIndex(this.buttonPlay, 0);
			this.Controls.SetChildIndex(this.progressBar, 0);
			this.Controls.SetChildIndex(this.timer, 0);
			this.Controls.SetChildIndex(this.label_SongTitle, 0);
			this.Controls.SetChildIndex(this.trackBar_Volume, 0);
			this.Controls.SetChildIndex(this.button_Next, 0);
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.OpenFileDialog loadMP3Dialog;
		private System.Windows.Forms.Button button_Stop;
		private System.Windows.Forms.Button buttonPlay;
		private NAudio.Gui.VolumeMeter volumeMeterL;
		private NAudio.Gui.WaveformPainter waveformPainterL;
		private NAudio.Gui.VolumeMeter volumeMeterR;
		private NAudio.Gui.WaveformPainter waveformPainterR;
		private System.Windows.Forms.Button button_Load_Mp3;
		private System.Windows.Forms.CheckedListBox songList;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button button_Next;
	}
}