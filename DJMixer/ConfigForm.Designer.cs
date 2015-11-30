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
			this.listBox_SoundDevices = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// comboBox_SoundDeviceSelect
			// 
			this.comboBox_SoundDeviceSelect.FormattingEnabled = true;
			this.comboBox_SoundDeviceSelect.Location = new System.Drawing.Point(412, 300);
			this.comboBox_SoundDeviceSelect.Name = "comboBox_SoundDeviceSelect";
			this.comboBox_SoundDeviceSelect.Size = new System.Drawing.Size(220, 21);
			this.comboBox_SoundDeviceSelect.TabIndex = 4;
			// 
			// listBox_SoundDevices
			// 
			this.listBox_SoundDevices.FormattingEnabled = true;
			this.listBox_SoundDevices.Location = new System.Drawing.Point(412, 29);
			this.listBox_SoundDevices.Name = "listBox_SoundDevices";
			this.listBox_SoundDevices.Size = new System.Drawing.Size(220, 251);
			this.listBox_SoundDevices.TabIndex = 3;
			// 
			// ConfigForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 448);
			this.Controls.Add(this.comboBox_SoundDeviceSelect);
			this.Controls.Add(this.listBox_SoundDevices);
			this.Name = "ConfigForm";
			this.Text = "ConfigForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox_SoundDeviceSelect;
		private System.Windows.Forms.ListBox listBox_SoundDevices;
	}
}