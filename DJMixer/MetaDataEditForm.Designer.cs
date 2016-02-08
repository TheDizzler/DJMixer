namespace DJMixer {
	partial class MetaDataEditForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetaDataEditForm));
			this.button_SaveChanges = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_Title = new System.Windows.Forms.RichTextBox();
			this.textBox_Artist = new System.Windows.Forms.RichTextBox();
			this.textBox_Album = new System.Windows.Forms.RichTextBox();
			this.textBox_Genre = new System.Windows.Forms.RichTextBox();
			this.textBox_Year = new System.Windows.Forms.RichTextBox();
			this.textBox_Comments = new System.Windows.Forms.RichTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button_SaveChanges
			// 
			this.button_SaveChanges.Location = new System.Drawing.Point(211, 296);
			this.button_SaveChanges.Name = "button_SaveChanges";
			this.button_SaveChanges.Size = new System.Drawing.Size(75, 23);
			this.button_SaveChanges.TabIndex = 0;
			this.button_SaveChanges.Text = "Save Changes";
			this.button_SaveChanges.UseVisualStyleBackColor = true;
			this.button_SaveChanges.Click += new System.EventHandler(this.button_SaveChanges_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.Location = new System.Drawing.Point(295, 296);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 1;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Title";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Artist";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Album";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(163, 122);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Genre";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 122);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Year";
			// 
			// textBox_Title
			// 
			this.textBox_Title.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_Title.Location = new System.Drawing.Point(56, 12);
			this.textBox_Title.Multiline = false;
			this.textBox_Title.Name = "textBox_Title";
			this.textBox_Title.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.textBox_Title.Size = new System.Drawing.Size(314, 29);
			this.textBox_Title.TabIndex = 2;
			this.textBox_Title.Text = "";
			// 
			// textBox_Artist
			// 
			this.textBox_Artist.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_Artist.Location = new System.Drawing.Point(56, 47);
			this.textBox_Artist.Multiline = false;
			this.textBox_Artist.Name = "textBox_Artist";
			this.textBox_Artist.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.textBox_Artist.Size = new System.Drawing.Size(314, 29);
			this.textBox_Artist.TabIndex = 8;
			this.textBox_Artist.Text = "";
			// 
			// textBox_Album
			// 
			this.textBox_Album.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_Album.Location = new System.Drawing.Point(56, 82);
			this.textBox_Album.Multiline = false;
			this.textBox_Album.Name = "textBox_Album";
			this.textBox_Album.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.textBox_Album.Size = new System.Drawing.Size(314, 29);
			this.textBox_Album.TabIndex = 9;
			this.textBox_Album.Text = "";
			// 
			// textBox_Genre
			// 
			this.textBox_Genre.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_Genre.Location = new System.Drawing.Point(208, 117);
			this.textBox_Genre.Multiline = false;
			this.textBox_Genre.Name = "textBox_Genre";
			this.textBox_Genre.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.textBox_Genre.Size = new System.Drawing.Size(162, 29);
			this.textBox_Genre.TabIndex = 10;
			this.textBox_Genre.Text = "";
			// 
			// textBox_Year
			// 
			this.textBox_Year.BackColor = System.Drawing.SystemColors.Window;
			this.textBox_Year.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_Year.Location = new System.Drawing.Point(56, 117);
			this.textBox_Year.MaxLength = 4;
			this.textBox_Year.Multiline = false;
			this.textBox_Year.Name = "textBox_Year";
			this.textBox_Year.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.textBox_Year.Size = new System.Drawing.Size(92, 29);
			this.textBox_Year.TabIndex = 11;
			this.textBox_Year.Text = "";
			this.textBox_Year.TextChanged += new System.EventHandler(this.yearValidate);
			// 
			// textBox_Comments
			// 
			this.textBox_Comments.Location = new System.Drawing.Point(15, 162);
			this.textBox_Comments.Name = "textBox_Comments";
			this.textBox_Comments.Size = new System.Drawing.Size(355, 118);
			this.textBox_Comments.TabIndex = 12;
			this.textBox_Comments.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 146);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Comments";
			// 
			// MetaDataEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 331);
			this.ControlBox = false;
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox_Comments);
			this.Controls.Add(this.textBox_Year);
			this.Controls.Add(this.textBox_Genre);
			this.Controls.Add(this.textBox_Album);
			this.Controls.Add(this.textBox_Artist);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_Title);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_SaveChanges);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(400, 370);
			this.MinimumSize = new System.Drawing.Size(400, 370);
			this.Name = "MetaDataEditForm";
			this.ShowIcon = false;
			this.Text = "Edit MP3 MetaData";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_SaveChanges;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox textBox_Title;
		private System.Windows.Forms.RichTextBox textBox_Artist;
		private System.Windows.Forms.RichTextBox textBox_Album;
		private System.Windows.Forms.RichTextBox textBox_Genre;
		private System.Windows.Forms.RichTextBox textBox_Year;
		private System.Windows.Forms.RichTextBox textBox_Comments;
		private System.Windows.Forms.Label label6;
	}
}