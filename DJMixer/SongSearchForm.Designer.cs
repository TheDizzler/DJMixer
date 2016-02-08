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
			this.components = new System.ComponentModel.Container();
			this.button_Search = new System.Windows.Forms.Button();
			this.searchKeyword = new System.Windows.Forms.RichTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label_Timer = new System.Windows.Forms.Label();
			this.label_NumResults = new System.Windows.Forms.Label();
			this.checkBox_Comments = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox_Artist = new System.Windows.Forms.CheckBox();
			this.checkBox_Title = new System.Windows.Forms.CheckBox();
			this.button_Select = new System.Windows.Forms.Button();
			this.listBox_SearchResults = new System.Windows.Forms.ListBox();
			this.rightClickMenu_PlayList = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editID3DataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.progressBar_Searching = new System.Windows.Forms.ProgressBar();
			this.groupBox1.SuspendLayout();
			this.rightClickMenu_PlayList.SuspendLayout();
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
			this.searchKeyword.Location = new System.Drawing.Point(79, 20);
			this.searchKeyword.Name = "searchKeyword";
			this.searchKeyword.Size = new System.Drawing.Size(137, 29);
			this.searchKeyword.TabIndex = 2;
			this.searchKeyword.Text = "";
			this.searchKeyword.TextChanged += new System.EventHandler(this.searchFieldChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.progressBar_Searching);
			this.groupBox1.Controls.Add(this.label_Timer);
			this.groupBox1.Controls.Add(this.label_NumResults);
			this.groupBox1.Controls.Add(this.checkBox_Comments);
			this.groupBox1.Controls.Add(this.searchKeyword);
			this.groupBox1.Controls.Add(this.button_Search);
			this.groupBox1.Controls.Add(this.checkBox3);
			this.groupBox1.Controls.Add(this.checkBox_Artist);
			this.groupBox1.Controls.Add(this.checkBox_Title);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(404, 119);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// label_Timer
			// 
			this.label_Timer.Location = new System.Drawing.Point(164, 95);
			this.label_Timer.Name = "label_Timer";
			this.label_Timer.Size = new System.Drawing.Size(143, 13);
			this.label_Timer.TabIndex = 7;
			this.label_Timer.Text = "in 0 seconds";
			this.label_Timer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label_NumResults
			// 
			this.label_NumResults.Location = new System.Drawing.Point(161, 77);
			this.label_NumResults.Name = "label_NumResults";
			this.label_NumResults.Size = new System.Drawing.Size(146, 13);
			this.label_NumResults.TabIndex = 6;
			this.label_NumResults.Text = "0 Matches Found";
			this.label_NumResults.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			// button_Select
			// 
			this.button_Select.Location = new System.Drawing.Point(189, 343);
			this.button_Select.Name = "button_Select";
			this.button_Select.Size = new System.Drawing.Size(75, 23);
			this.button_Select.TabIndex = 5;
			this.button_Select.Text = "Select Songs";
			this.button_Select.UseVisualStyleBackColor = true;
			this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
			// 
			// listBox_SearchResults
			// 
			this.listBox_SearchResults.ContextMenuStrip = this.rightClickMenu_PlayList;
			this.listBox_SearchResults.FormattingEnabled = true;
			this.listBox_SearchResults.Location = new System.Drawing.Point(12, 137);
			this.listBox_SearchResults.Name = "listBox_SearchResults";
			this.listBox_SearchResults.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBox_SearchResults.Size = new System.Drawing.Size(404, 199);
			this.listBox_SearchResults.TabIndex = 4;
			this.listBox_SearchResults.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseClickListBox);
			// 
			// rightClickMenu_PlayList
			// 
			this.rightClickMenu_PlayList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editID3DataToolStripMenuItem});
			this.rightClickMenu_PlayList.Name = "rightClickMenu_PlayList";
			this.rightClickMenu_PlayList.Size = new System.Drawing.Size(142, 26);
			// 
			// editID3DataToolStripMenuItem
			// 
			this.editID3DataToolStripMenuItem.Name = "editID3DataToolStripMenuItem";
			this.editID3DataToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.editID3DataToolStripMenuItem.Text = "Edit ID3 Data";
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.Description = "Chose a directory to search";
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// progressBar_Searching
			// 
			this.progressBar_Searching.Location = new System.Drawing.Point(299, 25);
			this.progressBar_Searching.Name = "progressBar_Searching";
			this.progressBar_Searching.Size = new System.Drawing.Size(100, 23);
			this.progressBar_Searching.TabIndex = 8;
			// 
			// SongSearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 371);
			this.Controls.Add(this.button_Select);
			this.Controls.Add(this.listBox_SearchResults);
			this.Controls.Add(this.groupBox1);
			this.Name = "SongSearchForm";
			this.Text = "SongSearchForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.rightClickMenu_PlayList.ResumeLayout(false);
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
		private System.Windows.Forms.Label label_NumResults;
		private System.Windows.Forms.Button button_Select;
		private System.Windows.Forms.ListBox listBox_SearchResults;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Label label_Timer;
		private System.Windows.Forms.ContextMenuStrip rightClickMenu_PlayList;
		private System.Windows.Forms.ToolStripMenuItem editID3DataToolStripMenuItem;
		private System.Windows.Forms.ProgressBar progressBar_Searching;
	}
}