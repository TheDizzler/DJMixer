using System;

namespace DJMixer {
	partial class ConfigForm {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
			this.comboBox_SoundDeviceSelect = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton_DS = new System.Windows.Forms.RadioButton();
			this.radioButton_WaveOut = new System.Windows.Forms.RadioButton();
			this.radioButton_WASAPI = new System.Windows.Forms.RadioButton();
			this.radioButton_ASIO = new System.Windows.Forms.RadioButton();
			this.groupBox_OutputDrivers = new System.Windows.Forms.GroupBox();
			this.groupBox_OutputDrivers.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBox_SoundDeviceSelect
			// 
			this.comboBox_SoundDeviceSelect.FormattingEnabled = true;
			this.comboBox_SoundDeviceSelect.Location = new System.Drawing.Point(12, 44);
			this.comboBox_SoundDeviceSelect.Name = "comboBox_SoundDeviceSelect";
			this.comboBox_SoundDeviceSelect.Size = new System.Drawing.Size(220, 21);
			this.comboBox_SoundDeviceSelect.TabIndex = 4;
			this.comboBox_SoundDeviceSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox_SoundDeviceSelect_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Select Audio Out Device";
			// 
			// radioButton_DS
			// 
			this.radioButton_DS.AutoSize = true;
			this.radioButton_DS.Location = new System.Drawing.Point(17, 19);
			this.radioButton_DS.Name = "radioButton_DS";
			this.radioButton_DS.Size = new System.Drawing.Size(84, 17);
			this.radioButton_DS.TabIndex = 6;
			this.radioButton_DS.Text = "DirectSound";
			this.radioButton_DS.UseVisualStyleBackColor = true;
			this.radioButton_DS.CheckedChanged += new System.EventHandler(this.radioButton_DS_CheckedChanged);
			// 
			// radioButton_WaveOut
			// 
			this.radioButton_WaveOut.AutoSize = true;
			this.radioButton_WaveOut.Checked = true;
			this.radioButton_WaveOut.Location = new System.Drawing.Point(17, 43);
			this.radioButton_WaveOut.Name = "radioButton_WaveOut";
			this.radioButton_WaveOut.Size = new System.Drawing.Size(71, 17);
			this.radioButton_WaveOut.TabIndex = 7;
			this.radioButton_WaveOut.TabStop = true;
			this.radioButton_WaveOut.Text = "WaveOut";
			this.radioButton_WaveOut.UseVisualStyleBackColor = true;
			this.radioButton_WaveOut.CheckedChanged += new System.EventHandler(this.radioButton_WaveOut_CheckedChanged);
			// 
			// radioButton_WASAPI
			// 
			this.radioButton_WASAPI.AutoSize = true;
			this.radioButton_WASAPI.Enabled = false;
			this.radioButton_WASAPI.Location = new System.Drawing.Point(17, 67);
			this.radioButton_WASAPI.Name = "radioButton_WASAPI";
			this.radioButton_WASAPI.Size = new System.Drawing.Size(67, 17);
			this.radioButton_WASAPI.TabIndex = 8;
			this.radioButton_WASAPI.Text = "WASAPI";
			this.radioButton_WASAPI.UseVisualStyleBackColor = true;
			// 
			// radioButton_ASIO
			// 
			this.radioButton_ASIO.AutoSize = true;
			this.radioButton_ASIO.Enabled = false;
			this.radioButton_ASIO.Location = new System.Drawing.Point(17, 90);
			this.radioButton_ASIO.Name = "radioButton_ASIO";
			this.radioButton_ASIO.Size = new System.Drawing.Size(50, 17);
			this.radioButton_ASIO.TabIndex = 9;
			this.radioButton_ASIO.Text = "ASIO";
			this.radioButton_ASIO.UseVisualStyleBackColor = true;
			// 
			// groupBox_OutputDrivers
			// 
			this.groupBox_OutputDrivers.Controls.Add(this.radioButton_DS);
			this.groupBox_OutputDrivers.Controls.Add(this.radioButton_ASIO);
			this.groupBox_OutputDrivers.Controls.Add(this.radioButton_WaveOut);
			this.groupBox_OutputDrivers.Controls.Add(this.radioButton_WASAPI);
			this.groupBox_OutputDrivers.Location = new System.Drawing.Point(12, 71);
			this.groupBox_OutputDrivers.Name = "groupBox_OutputDrivers";
			this.groupBox_OutputDrivers.Size = new System.Drawing.Size(186, 128);
			this.groupBox_OutputDrivers.TabIndex = 10;
			this.groupBox_OutputDrivers.TabStop = false;
			this.groupBox_OutputDrivers.Text = "Output Drivers";
			// 
			// ConfigForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(240, 207);
			this.Controls.Add(this.groupBox_OutputDrivers);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox_SoundDeviceSelect);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(256, 246);
			this.MinimumSize = new System.Drawing.Size(256, 246);
			this.Name = "ConfigForm";
			this.Text = "Config";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
			this.groupBox_OutputDrivers.ResumeLayout(false);
			this.groupBox_OutputDrivers.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox_SoundDeviceSelect;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButton_DS;
		private System.Windows.Forms.RadioButton radioButton_WaveOut;
		private System.Windows.Forms.RadioButton radioButton_WASAPI;
		private System.Windows.Forms.RadioButton radioButton_ASIO;
		private System.Windows.Forms.GroupBox groupBox_OutputDrivers;
	}
}