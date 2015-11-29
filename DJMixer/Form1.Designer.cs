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
			this.listBox_SoundDevices = new System.Windows.Forms.ListBox();
			this.comboBox_SoundDeviceSelect = new System.Windows.Forms.ComboBox();
			this.button_Stop = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonPlay
			// 
			this.buttonPlay.Location = new System.Drawing.Point(171, 385);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(75, 23);
			this.buttonPlay.TabIndex = 0;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.UseVisualStyleBackColor = true;
			this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
			// 
			// listBox_SoundDevices
			// 
			this.listBox_SoundDevices.FormattingEnabled = true;
			this.listBox_SoundDevices.Location = new System.Drawing.Point(575, 55);
			this.listBox_SoundDevices.Name = "listBox_SoundDevices";
			this.listBox_SoundDevices.Size = new System.Drawing.Size(220, 251);
			this.listBox_SoundDevices.TabIndex = 1;
			// 
			// comboBox_SoundDeviceSelect
			// 
			this.comboBox_SoundDeviceSelect.FormattingEnabled = true;
			this.comboBox_SoundDeviceSelect.Location = new System.Drawing.Point(575, 326);
			this.comboBox_SoundDeviceSelect.Name = "comboBox_SoundDeviceSelect";
			this.comboBox_SoundDeviceSelect.Size = new System.Drawing.Size(220, 21);
			this.comboBox_SoundDeviceSelect.TabIndex = 2;
			this.comboBox_SoundDeviceSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox_SoundDeviceSelect_SelectedIndexChanged);
			// 
			// button_Stop
			// 
			this.button_Stop.Cursor = System.Windows.Forms.Cursors.Default;
			this.button_Stop.Location = new System.Drawing.Point(253, 385);
			this.button_Stop.Name = "button_Stop";
			this.button_Stop.Size = new System.Drawing.Size(75, 23);
			this.button_Stop.TabIndex = 3;
			this.button_Stop.Text = "Stop";
			this.button_Stop.UseVisualStyleBackColor = true;
			this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(807, 495);
			this.Controls.Add(this.button_Stop);
			this.Controls.Add(this.comboBox_SoundDeviceSelect);
			this.Controls.Add(this.listBox_SoundDevices);
			this.Controls.Add(this.buttonPlay);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonPlay;
		private System.Windows.Forms.ListBox listBox_SoundDevices;
		private System.Windows.Forms.ComboBox comboBox_SoundDeviceSelect;
		private System.Windows.Forms.Button button_Stop;
	}
}

