namespace DJMixer {
	partial class SongSearchForm {
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
			this.button_Search = new System.Windows.Forms.Button();
			this.searchKeyword = new System.Windows.Forms.RichTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox_Title = new System.Windows.Forms.CheckBox();
			this.checkBox_Artist = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox_Comments = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_Search
			// 
			this.button_Search.Location = new System.Drawing.Point(313, 85);
			this.button_Search.Name = "button_Search";
			this.button_Search.Size = new System.Drawing.Size(75, 23);
			this.button_Search.TabIndex = 0;
			this.button_Search.Text = "Search";
			this.button_Search.UseVisualStyleBackColor = true;
			this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
			// 
			// searchKeyword
			// 
			this.searchKeyword.Location = new System.Drawing.Point(138, 41);
			this.searchKeyword.Name = "searchKeyword";
			this.searchKeyword.Size = new System.Drawing.Size(137, 33);
			this.searchKeyword.TabIndex = 2;
			this.searchKeyword.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox_Comments);
			this.groupBox1.Controls.Add(this.searchKeyword);
			this.groupBox1.Controls.Add(this.button_Search);
			this.groupBox1.Controls.Add(this.checkBox3);
			this.groupBox1.Controls.Add(this.checkBox_Artist);
			this.groupBox1.Controls.Add(this.checkBox_Title);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(404, 171);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// checkBox_Title
			// 
			this.checkBox_Title.AutoSize = true;
			this.checkBox_Title.Location = new System.Drawing.Point(6, 20);
			this.checkBox_Title.Name = "checkBox_Title";
			this.checkBox_Title.Size = new System.Drawing.Size(46, 17);
			this.checkBox_Title.TabIndex = 0;
			this.checkBox_Title.Text = "Title";
			this.checkBox_Title.UseVisualStyleBackColor = true;
			this.checkBox_Title.CheckedChanged += new System.EventHandler(this.checkBox_Title_CheckedChanged);
			// 
			// checkBox_Artist
			// 
			this.checkBox_Artist.AutoSize = true;
			this.checkBox_Artist.Location = new System.Drawing.Point(6, 43);
			this.checkBox_Artist.Name = "checkBox_Artist";
			this.checkBox_Artist.Size = new System.Drawing.Size(49, 17);
			this.checkBox_Artist.TabIndex = 1;
			this.checkBox_Artist.Text = "Artist";
			this.checkBox_Artist.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(6, 66);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(55, 17);
			this.checkBox3.TabIndex = 2;
			this.checkBox3.Text = "Genre";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox_Comments
			// 
			this.checkBox_Comments.AutoSize = true;
			this.checkBox_Comments.Location = new System.Drawing.Point(6, 89);
			this.checkBox_Comments.Name = "checkBox_Comments";
			this.checkBox_Comments.Size = new System.Drawing.Size(75, 17);
			this.checkBox_Comments.TabIndex = 3;
			this.checkBox_Comments.Text = "Comments";
			this.checkBox_Comments.UseVisualStyleBackColor = true;
			// 
			// SongSearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 201);
			this.Controls.Add(this.groupBox1);
			this.Name = "SongSearchForm";
			this.Text = "SongSearchForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button_Search;
		private System.Windows.Forms.RichTextBox searchKeyword;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox_Comments;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox_Artist;
		private System.Windows.Forms.CheckBox checkBox_Title;
	}
}