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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button_Load_Mp3 = new System.Windows.Forms.Button();
			this.waveformPainterR = new NAudio.Gui.WaveformPainter();
			this.volumeMeterR = new NAudio.Gui.VolumeMeter();
			this.waveformPainterL = new NAudio.Gui.WaveformPainter();
			this.volumeMeterL = new NAudio.Gui.VolumeMeter();
			this.panSlider1 = new NAudio.Gui.PanSlider();
			this.trackBar_Volume = new System.Windows.Forms.TrackBar();
			this.label_SongTitle = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.buttonPlay = new System.Windows.Forms.Button();
			this.button_Stop = new System.Windows.Forms.Button();
			this.loadMP3Dialog = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button_Load_Mp3);
			this.groupBox1.Controls.Add(this.waveformPainterR);
			this.groupBox1.Controls.Add(this.volumeMeterR);
			this.groupBox1.Controls.Add(this.waveformPainterL);
			this.groupBox1.Controls.Add(this.volumeMeterL);
			this.groupBox1.Controls.Add(this.panSlider1);
			this.groupBox1.Controls.Add(this.trackBar_Volume);
			this.groupBox1.Controls.Add(this.label_SongTitle);
			this.groupBox1.Controls.Add(this.timer);
			this.groupBox1.Controls.Add(this.progressBar1);
			this.groupBox1.Controls.Add(this.buttonPlay);
			this.groupBox1.Controls.Add(this.button_Stop);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(380, 470);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "DynamoPlayer";
			// 
			// button_Load_Mp3
			// 
			this.button_Load_Mp3.Location = new System.Drawing.Point(299, 441);
			this.button_Load_Mp3.Name = "button_Load_Mp3";
			this.button_Load_Mp3.Size = new System.Drawing.Size(75, 23);
			this.button_Load_Mp3.TabIndex = 14;
			this.button_Load_Mp3.Text = "Load MP3";
			this.button_Load_Mp3.UseVisualStyleBackColor = true;
			this.button_Load_Mp3.Click += new System.EventHandler(this.button_Load_Mp3_Click);
			// 
			// waveformPainterR
			// 
			this.waveformPainterR.BackColor = System.Drawing.SystemColors.Window;
			this.waveformPainterR.Location = new System.Drawing.Point(225, 19);
			this.waveformPainterR.Name = "waveformPainterR";
			this.waveformPainterR.Size = new System.Drawing.Size(75, 23);
			this.waveformPainterR.TabIndex = 13;
			this.waveformPainterR.Text = "waveformPainterR";
			// 
			// volumeMeterR
			// 
			this.volumeMeterR.Amplitude = 0F;
			this.volumeMeterR.Location = new System.Drawing.Point(52, 50);
			this.volumeMeterR.MaxDb = 6F;
			this.volumeMeterR.MinDb = -60F;
			this.volumeMeterR.Name = "volumeMeterR";
			this.volumeMeterR.Size = new System.Drawing.Size(39, 160);
			this.volumeMeterR.TabIndex = 12;
			this.volumeMeterR.Text = "volumeMeterR";
			// 
			// waveformPainterL
			// 
			this.waveformPainterL.BackColor = System.Drawing.SystemColors.Window;
			this.waveformPainterL.Location = new System.Drawing.Point(225, 50);
			this.waveformPainterL.Name = "waveformPainterL";
			this.waveformPainterL.Size = new System.Drawing.Size(75, 23);
			this.waveformPainterL.TabIndex = 11;
			this.waveformPainterL.Text = "waveformPainterL";
			// 
			// volumeMeterL
			// 
			this.volumeMeterL.Amplitude = 0F;
			this.volumeMeterL.Location = new System.Drawing.Point(7, 50);
			this.volumeMeterL.MaxDb = 6F;
			this.volumeMeterL.MinDb = -60F;
			this.volumeMeterL.Name = "volumeMeterL";
			this.volumeMeterL.Size = new System.Drawing.Size(39, 160);
			this.volumeMeterL.TabIndex = 10;
			this.volumeMeterL.Text = "volumeMeterL";
			// 
			// panSlider1
			// 
			this.panSlider1.Location = new System.Drawing.Point(122, 231);
			this.panSlider1.Name = "panSlider1";
			this.panSlider1.Pan = 0F;
			this.panSlider1.Size = new System.Drawing.Size(141, 51);
			this.panSlider1.TabIndex = 9;
			// 
			// trackBar_Volume
			// 
			this.trackBar_Volume.LargeChange = 10;
			this.trackBar_Volume.Location = new System.Drawing.Point(329, 125);
			this.trackBar_Volume.Maximum = 100;
			this.trackBar_Volume.Name = "trackBar_Volume";
			this.trackBar_Volume.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar_Volume.Size = new System.Drawing.Size(45, 157);
			this.trackBar_Volume.TabIndex = 8;
			this.trackBar_Volume.TickFrequency = 10;
			this.trackBar_Volume.Value = 75;
			this.trackBar_Volume.Scroll += new System.EventHandler(this.trackBar_Volume_Scroll);
			// 
			// label_SongTitle
			// 
			this.label_SongTitle.AutoEllipsis = true;
			this.label_SongTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_SongTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label_SongTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label_SongTitle.Location = new System.Drawing.Point(11, 295);
			this.label_SongTitle.Name = "label_SongTitle";
			this.label_SongTitle.Size = new System.Drawing.Size(363, 39);
			this.label_SongTitle.TabIndex = 6;
			this.label_SongTitle.Text = "Song Title";
			this.label_SongTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer
			// 
			this.timer.AutoSize = true;
			this.timer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.timer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timer.Location = new System.Drawing.Point(147, 334);
			this.timer.Name = "timer";
			this.timer.Size = new System.Drawing.Size(84, 33);
			this.timer.TabIndex = 5;
			this.timer.Text = "00:00";
			this.timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(7, 368);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(367, 42);
			this.progressBar1.TabIndex = 4;
			this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
			// 
			// buttonPlay
			// 
			this.buttonPlay.Location = new System.Drawing.Point(37, 441);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(75, 23);
			this.buttonPlay.TabIndex = 0;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.UseVisualStyleBackColor = true;
			this.buttonPlay.Click += new System.EventHandler(this.button_Play_Click);
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
			this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
			// 
			// loadMP3Dialog
			// 
			this.loadMP3Dialog.FileName = "loadMP3Dialog";
			this.loadMP3Dialog.Filter = "MP3 files | *.mp3";
			this.loadMP3Dialog.FileOk += new System.ComponentModel.CancelEventHandler(this.loadMP3Dialog_FileOk);
			// 
			// Player
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Name = "Player";
			this.Size = new System.Drawing.Size(392, 483);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private NAudio.Gui.WaveformPainter waveformPainterR;
		private NAudio.Gui.VolumeMeter volumeMeterR;
		private NAudio.Gui.WaveformPainter waveformPainterL;
		private NAudio.Gui.VolumeMeter volumeMeterL;
		private NAudio.Gui.PanSlider panSlider1;
		private System.Windows.Forms.TrackBar trackBar_Volume;
		private System.Windows.Forms.Label label_SongTitle;
		private System.Windows.Forms.Label timer;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button buttonPlay;
		private System.Windows.Forms.Button button_Stop;
		private System.Windows.Forms.Button button_Load_Mp3;
		private System.Windows.Forms.OpenFileDialog loadMP3Dialog;
	}
}
