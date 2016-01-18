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
			this.comboBox_SoundDeviceSelect = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
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
			// ConfigForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(288, 339);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox_SoundDeviceSelect);
			this.Name = "ConfigForm";
			this.Text = "Config";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onFormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox_SoundDeviceSelect;
		private System.Windows.Forms.Label label1;
	}
}