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
			this.radioButton_Auto = new System.Windows.Forms.RadioButton();
			this.radioButton_Manual = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.loadMP3Dialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// trackBar_Volume
			// 
			this.trackBar_Volume.Location = new System.Drawing.Point(187, 16);
			this.trackBar_Volume.Size = new System.Drawing.Size(45, 87);
			// 
			// label_SongTitle
			// 
			this.label_SongTitle.Enabled = false;
			this.label_SongTitle.Location = new System.Drawing.Point(212, 120);
			// 
			// timer
			// 
			this.timer.Location = new System.Drawing.Point(148, 214);
			// 
			// panSlider
			// 
			this.panSlider.Location = new System.Drawing.Point(159, 158);
			// 
			// button_LoadSamples
			// 
			this.button_LoadSamples.Location = new System.Drawing.Point(23, 196);
			this.button_LoadSamples.Name = "button_LoadSamples";
			this.button_LoadSamples.Size = new System.Drawing.Size(75, 23);
			this.button_LoadSamples.TabIndex = 1;
			this.button_LoadSamples.Text = "Load Samples";
			this.button_LoadSamples.UseVisualStyleBackColor = true;
			this.button_LoadSamples.Click += new System.EventHandler(this.button_LoadSamples_Click);
			// 
			// sampleList
			// 
			this.sampleList.Location = new System.Drawing.Point(8, 109);
			this.sampleList.Name = "sampleList";
			this.sampleList.Size = new System.Drawing.Size(184, 21);
			this.sampleList.TabIndex = 13;
			// 
			// radioButton_Auto
			// 
			this.radioButton_Auto.AutoSize = true;
			this.radioButton_Auto.Location = new System.Drawing.Point(6, 19);
			this.radioButton_Auto.Name = "radioButton_Auto";
			this.radioButton_Auto.Size = new System.Drawing.Size(47, 17);
			this.radioButton_Auto.TabIndex = 14;
			this.radioButton_Auto.TabStop = true;
			this.radioButton_Auto.Text = "Auto";
			this.radioButton_Auto.UseVisualStyleBackColor = true;
			// 
			// radioButton_Manual
			// 
			this.radioButton_Manual.AutoSize = true;
			this.radioButton_Manual.Location = new System.Drawing.Point(6, 42);
			this.radioButton_Manual.Name = "radioButton_Manual";
			this.radioButton_Manual.Size = new System.Drawing.Size(60, 17);
			this.radioButton_Manual.TabIndex = 15;
			this.radioButton_Manual.TabStop = true;
			this.radioButton_Manual.Text = "Manual";
			this.radioButton_Manual.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(6, 69);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(85, 17);
			this.radioButton3.TabIndex = 16;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "radioButton3";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton_Auto);
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton_Manual);
			this.groupBox1.Location = new System.Drawing.Point(8, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(134, 99);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// loadMP3Dialog
			// 
			this.loadMP3Dialog.FileName = "loadMP3Dialog";
			this.loadMP3Dialog.Filter = "MP3 files | *.mp3 ; *.m3u";
			this.loadMP3Dialog.Multiselect = true;
			this.loadMP3Dialog.SupportMultiDottedExtensions = true;
			this.loadMP3Dialog.FileOk += new System.ComponentModel.CancelEventHandler(this.loadMP3Dialog_FileOk);
			// 
			// SamplePlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.sampleList);
			this.Controls.Add(this.button_LoadSamples);
			this.Name = "SamplePlayer";
			this.Size = new System.Drawing.Size(374, 275);
			this.Controls.SetChildIndex(this.button_LoadSamples, 0);
			this.Controls.SetChildIndex(this.trackBar_Volume, 0);
			this.Controls.SetChildIndex(this.timer, 0);
			this.Controls.SetChildIndex(this.label_SongTitle, 0);
			this.Controls.SetChildIndex(this.panSlider, 0);
			this.Controls.SetChildIndex(this.sampleList, 0);
			this.Controls.SetChildIndex(this.groupBox1, 0);
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button_LoadSamples;
		private System.Windows.Forms.ComboBox sampleList;
		private System.Windows.Forms.RadioButton radioButton_Auto;
		private System.Windows.Forms.RadioButton radioButton_Manual;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.OpenFileDialog loadMP3Dialog;
	}
}
