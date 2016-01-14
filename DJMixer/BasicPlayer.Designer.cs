namespace DJMixer {
	partial class BasicPlayer {
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
			this.trackBar_Volume = new System.Windows.Forms.TrackBar();
			this.label_SongTitle = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Label();
			this.panSlider = new NAudio.Gui.PanSlider();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).BeginInit();
			this.SuspendLayout();
			// 
			// trackBar_Volume
			// 
			this.trackBar_Volume.LargeChange = 10;
			this.trackBar_Volume.Location = new System.Drawing.Point(149, -2);
			this.trackBar_Volume.Maximum = 100;
			this.trackBar_Volume.Name = "trackBar_Volume";
			this.trackBar_Volume.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar_Volume.Size = new System.Drawing.Size(45, 157);
			this.trackBar_Volume.TabIndex = 9;
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
			this.label_SongTitle.Location = new System.Drawing.Point(3, 0);
			this.label_SongTitle.Name = "label_SongTitle";
			this.label_SongTitle.Size = new System.Drawing.Size(130, 35);
			this.label_SongTitle.TabIndex = 11;
			this.label_SongTitle.Text = "Song Title";
			this.label_SongTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer
			// 
			this.timer.AutoSize = true;
			this.timer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.timer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timer.Location = new System.Drawing.Point(3, 35);
			this.timer.Name = "timer";
			this.timer.Size = new System.Drawing.Size(84, 33);
			this.timer.TabIndex = 10;
			this.timer.Text = "00:00";
			this.timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panSlider
			// 
			this.panSlider.Location = new System.Drawing.Point(3, 71);
			this.panSlider.Name = "panSlider";
			this.panSlider.Pan = 0F;
			this.panSlider.Size = new System.Drawing.Size(135, 30);
			this.panSlider.TabIndex = 12;
			this.panSlider.PanChanged += new System.EventHandler(this.onPanChanged);
			// 
			// BasicPlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panSlider);
			this.Controls.Add(this.label_SongTitle);
			this.Controls.Add(this.timer);
			this.Controls.Add(this.trackBar_Volume);
			this.Name = "BasicPlayer";
			this.Size = new System.Drawing.Size(198, 178);
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.TrackBar trackBar_Volume;
		protected System.Windows.Forms.Label label_SongTitle;
		protected System.Windows.Forms.Label timer;
		protected NAudio.Gui.PanSlider panSlider;
	}
}
