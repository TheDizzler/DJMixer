namespace DJMixer {
	partial class SamplePlayer {
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
			this.button_LoadSamples = new System.Windows.Forms.Button();
			this.sampleList = new System.Windows.Forms.ComboBox();
			this.radioButton_On = new System.Windows.Forms.RadioButton();
			this.radioButton_Off = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.loadMP3Dialog = new System.Windows.Forms.OpenFileDialog();
			this.button_Play = new System.Windows.Forms.Button();
			this.songsBetweenSamples = new System.Windows.Forms.NumericUpDown();
			this.label_ForCounter = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.songsBetweenSamples)).BeginInit();
			this.SuspendLayout();
			// 
			// trackBar_Volume
			// 
			this.trackBar_Volume.Location = new System.Drawing.Point(147, 4);
			this.trackBar_Volume.Size = new System.Drawing.Size(45, 122);
			// 
			// label_SongTitle
			// 
			this.label_SongTitle.Enabled = false;
			this.label_SongTitle.Location = new System.Drawing.Point(8, 218);
			this.label_SongTitle.Size = new System.Drawing.Size(184, 35);
			// 
			// timer
			// 
			this.timer.Location = new System.Drawing.Point(117, 298);
			// 
			// panSlider
			// 
			this.panSlider.Location = new System.Drawing.Point(5, 298);
			this.panSlider.Size = new System.Drawing.Size(103, 30);
			// 
			// button_ResetList
			// 
			this.button_ResetList.Location = new System.Drawing.Point(61, 188);
			this.button_ResetList.Click += new System.EventHandler(this.button_ResetList_Click);
			// 
			// button_LoadSamples
			// 
			this.button_LoadSamples.Location = new System.Drawing.Point(8, 159);
			this.button_LoadSamples.Name = "button_LoadSamples";
			this.button_LoadSamples.Size = new System.Drawing.Size(75, 23);
			this.button_LoadSamples.TabIndex = 1;
			this.button_LoadSamples.Text = "Load Samples";
			this.button_LoadSamples.UseVisualStyleBackColor = true;
			this.button_LoadSamples.Click += new System.EventHandler(this.button_LoadSamples_Click);
			// 
			// sampleList
			// 
			this.sampleList.Location = new System.Drawing.Point(8, 132);
			this.sampleList.Name = "sampleList";
			this.sampleList.Size = new System.Drawing.Size(184, 21);
			this.sampleList.TabIndex = 13;
			this.sampleList.DropDown += new System.EventHandler(this.sampleList_DropDown);
			this.sampleList.SelectedIndexChanged += new System.EventHandler(this.sampleList_SelectedIndexChanged);
			// 
			// radioButton_On
			// 
			this.radioButton_On.AutoSize = true;
			this.radioButton_On.Checked = true;
			this.radioButton_On.Location = new System.Drawing.Point(6, 19);
			this.radioButton_On.Name = "radioButton_On";
			this.radioButton_On.Size = new System.Drawing.Size(39, 17);
			this.radioButton_On.TabIndex = 14;
			this.radioButton_On.TabStop = true;
			this.radioButton_On.Text = "On";
			this.radioButton_On.UseVisualStyleBackColor = true;
			this.radioButton_On.CheckedChanged += new System.EventHandler(this.radioButton_On_CheckedChanged);
			// 
			// radioButton_Off
			// 
			this.radioButton_Off.AutoSize = true;
			this.radioButton_Off.Location = new System.Drawing.Point(6, 42);
			this.radioButton_Off.Name = "radioButton_Off";
			this.radioButton_Off.Size = new System.Drawing.Size(39, 17);
			this.radioButton_Off.TabIndex = 15;
			this.radioButton_Off.Text = "Off";
			this.radioButton_Off.UseVisualStyleBackColor = true;
			this.radioButton_Off.CheckedChanged += new System.EventHandler(this.radioButton_Off_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Enabled = false;
			this.radioButton3.Location = new System.Drawing.Point(6, 69);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(70, 17);
			this.radioButton3.TabIndex = 16;
			this.radioButton3.Text = "TheOther";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton_On);
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton_Off);
			this.groupBox1.Location = new System.Drawing.Point(8, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(105, 99);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Samples";
			// 
			// loadMP3Dialog
			// 
			this.loadMP3Dialog.FileName = "loadMP3Dialog";
			this.loadMP3Dialog.Filter = "MP3 files |*.m3u;*.mp3";
			this.loadMP3Dialog.Multiselect = true;
			this.loadMP3Dialog.SupportMultiDottedExtensions = true;
			this.loadMP3Dialog.FileOk += new System.ComponentModel.CancelEventHandler(this.loadMP3Dialog_FileOk);
			// 
			// button_Play
			// 
			this.button_Play.Location = new System.Drawing.Point(117, 159);
			this.button_Play.Name = "button_Play";
			this.button_Play.Size = new System.Drawing.Size(75, 23);
			this.button_Play.TabIndex = 18;
			this.button_Play.Text = "Play";
			this.button_Play.UseVisualStyleBackColor = true;
			this.button_Play.Click += new System.EventHandler(this.button_Play_Click);
			// 
			// songsBetweenSamples
			// 
			this.songsBetweenSamples.Location = new System.Drawing.Point(98, 263);
			this.songsBetweenSamples.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.songsBetweenSamples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.songsBetweenSamples.Name = "songsBetweenSamples";
			this.songsBetweenSamples.Size = new System.Drawing.Size(38, 20);
			this.songsBetweenSamples.TabIndex = 20;
			this.songsBetweenSamples.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.songsBetweenSamples.ValueChanged += new System.EventHandler(this.songsBetweenSamples_ValueChanged);
			// 
			// label_ForCounter
			// 
			this.label_ForCounter.Location = new System.Drawing.Point(5, 263);
			this.label_ForCounter.Name = "label_ForCounter";
			this.label_ForCounter.Size = new System.Drawing.Size(87, 32);
			this.label_ForCounter.TabIndex = 21;
			this.label_ForCounter.Text = "Songs Between Samples:";
			this.label_ForCounter.UseMnemonic = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 113);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "Next Sample:";
			// 
			// SamplePlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label_ForCounter);
			this.Controls.Add(this.songsBetweenSamples);
			this.Controls.Add(this.button_Play);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.sampleList);
			this.Controls.Add(this.button_LoadSamples);
			this.Name = "SamplePlayer";
			this.Size = new System.Drawing.Size(201, 374);
			this.Controls.SetChildIndex(this.button_ResetList, 0);
			this.Controls.SetChildIndex(this.button_LoadSamples, 0);
			this.Controls.SetChildIndex(this.trackBar_Volume, 0);
			this.Controls.SetChildIndex(this.timer, 0);
			this.Controls.SetChildIndex(this.label_SongTitle, 0);
			this.Controls.SetChildIndex(this.panSlider, 0);
			this.Controls.SetChildIndex(this.sampleList, 0);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.button_Play, 0);
			this.Controls.SetChildIndex(this.songsBetweenSamples, 0);
			this.Controls.SetChildIndex(this.label_ForCounter, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.songsBetweenSamples)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button_LoadSamples;
		private System.Windows.Forms.ComboBox sampleList;
		private System.Windows.Forms.RadioButton radioButton_On;
		private System.Windows.Forms.RadioButton radioButton_Off;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.OpenFileDialog loadMP3Dialog;
		private System.Windows.Forms.Button button_Play;
		private System.Windows.Forms.NumericUpDown songsBetweenSamples;
		private System.Windows.Forms.Label label_ForCounter;
		private System.Windows.Forms.Label label1;
	}
}
