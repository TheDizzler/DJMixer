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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongSearchForm));
			this.button_search = new System.Windows.Forms.Button();
			this.searchKeyword = new System.Windows.Forms.RichTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar_Searching = new System.Windows.Forms.ProgressBar();
			this.label_Timer = new System.Windows.Forms.Label();
			this.label_NumResults = new System.Windows.Forms.Label();
			this.checkBox_Comments = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox_Artist = new System.Windows.Forms.CheckBox();
			this.checkBox_Title = new System.Windows.Forms.CheckBox();
			this.button_SendToLeftPlayer = new System.Windows.Forms.Button();
			this.listBox_SearchResults = new System.Windows.Forms.ListBox();
			this.rightClickMenu_PlayList = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editID3DataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.button_SendToRightPlayer = new System.Windows.Forms.Button();
			this.button_cancelSearch = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.rightClickMenu_PlayList.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_search
			// 
			this.button_search.Location = new System.Drawing.Point(313, 85);
			this.button_search.Name = "button_search";
			this.button_search.Size = new System.Drawing.Size(75, 23);
			this.button_search.TabIndex = 0;
			this.button_search.Text = "Search";
			this.button_search.UseVisualStyleBackColor = true;
			this.button_search.Click += new System.EventHandler(this.button_Search_Click);
			// 
			// searchKeyword
			// 
			this.searchKeyword.Location = new System.Drawing.Point(90, 41);
			this.searchKeyword.Name = "searchKeyword";
			this.searchKeyword.Size = new System.Drawing.Size(137, 29);
			this.searchKeyword.TabIndex = 2;
			this.searchKeyword.Text = "";
			this.searchKeyword.TextChanged += new System.EventHandler(this.searchFieldChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button_cancelSearch);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.progressBar_Searching);
			this.groupBox1.Controls.Add(this.label_Timer);
			this.groupBox1.Controls.Add(this.label_NumResults);
			this.groupBox1.Controls.Add(this.checkBox_Comments);
			this.groupBox1.Controls.Add(this.searchKeyword);
			this.groupBox1.Controls.Add(this.button_search);
			this.groupBox1.Controls.Add(this.checkBox3);
			this.groupBox1.Controls.Add(this.checkBox_Artist);
			this.groupBox1.Controls.Add(this.checkBox_Title);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(404, 119);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(90, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Keyword:";
			// 
			// progressBar_Searching
			// 
			this.progressBar_Searching.Location = new System.Drawing.Point(299, 25);
			this.progressBar_Searching.Name = "progressBar_Searching";
			this.progressBar_Searching.Size = new System.Drawing.Size(100, 23);
			this.progressBar_Searching.TabIndex = 8;
			// 
			// label_Timer
			// 
			this.label_Timer.Location = new System.Drawing.Point(164, 95);
			this.label_Timer.Name = "label_Timer";
			this.label_Timer.Size = new System.Drawing.Size(143, 13);
			this.label_Timer.TabIndex = 7;
			this.label_Timer.Text = "in 0 seconds";
			this.label_Timer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label_Timer.Visible = false;
			// 
			// label_NumResults
			// 
			this.label_NumResults.Location = new System.Drawing.Point(161, 77);
			this.label_NumResults.Name = "label_NumResults";
			this.label_NumResults.Size = new System.Drawing.Size(146, 13);
			this.label_NumResults.TabIndex = 6;
			this.label_NumResults.Text = "0 Matches Found";
			this.label_NumResults.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label_NumResults.Visible = false;
			// 
			// checkBox_Comments
			// 
			this.checkBox_Comments.AutoSize = true;
			this.checkBox_Comments.Enabled = false;
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
			this.checkBox3.Enabled = false;
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
			this.checkBox_Artist.Enabled = false;
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
			this.checkBox_Title.Enabled = false;
			this.checkBox_Title.Location = new System.Drawing.Point(6, 20);
			this.checkBox_Title.Name = "checkBox_Title";
			this.checkBox_Title.Size = new System.Drawing.Size(46, 17);
			this.checkBox_Title.TabIndex = 0;
			this.checkBox_Title.Text = "Title";
			this.checkBox_Title.UseVisualStyleBackColor = true;
			this.checkBox_Title.CheckedChanged += new System.EventHandler(this.checkBox_Title_CheckedChanged);
			// 
			// button_SendToLeftPlayer
			// 
			this.button_SendToLeftPlayer.Location = new System.Drawing.Point(12, 342);
			this.button_SendToLeftPlayer.Name = "button_SendToLeftPlayer";
			this.button_SendToLeftPlayer.Size = new System.Drawing.Size(117, 23);
			this.button_SendToLeftPlayer.TabIndex = 5;
			this.button_SendToLeftPlayer.Text = "Send to Left Player";
			this.button_SendToLeftPlayer.UseVisualStyleBackColor = true;
			this.button_SendToLeftPlayer.Click += new System.EventHandler(this.button_SendToLeftPlayer_Click);
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
			this.listBox_SearchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.songList_MouseDoubleClick);
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
			this.editID3DataToolStripMenuItem.Click += new System.EventHandler(this.editID3Tag);
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.Description = "Chose a directory to search";
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// button_SendToRightPlayer
			// 
			this.button_SendToRightPlayer.Location = new System.Drawing.Point(299, 342);
			this.button_SendToRightPlayer.Name = "button_SendToRightPlayer";
			this.button_SendToRightPlayer.Size = new System.Drawing.Size(117, 23);
			this.button_SendToRightPlayer.TabIndex = 6;
			this.button_SendToRightPlayer.Text = "Send To Right Player";
			this.button_SendToRightPlayer.UseVisualStyleBackColor = true;
			this.button_SendToRightPlayer.Click += new System.EventHandler(this.button_SendToRightPlayer_Click);
			// 
			// button_cancelSearch
			// 
			this.button_cancelSearch.Location = new System.Drawing.Point(313, 56);
			this.button_cancelSearch.Name = "button_cancelSearch";
			this.button_cancelSearch.Size = new System.Drawing.Size(75, 23);
			this.button_cancelSearch.TabIndex = 10;
			this.button_cancelSearch.Text = "Cancel";
			this.button_cancelSearch.UseVisualStyleBackColor = true;
			this.button_cancelSearch.Visible = false;
			this.button_cancelSearch.Click += new System.EventHandler(this.button_cancelSearch_Click);
			// 
			// SongSearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 371);
			this.Controls.Add(this.button_SendToRightPlayer);
			this.Controls.Add(this.button_SendToLeftPlayer);
			this.Controls.Add(this.listBox_SearchResults);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(444, 410);
			this.MinimumSize = new System.Drawing.Size(444, 173);
			this.Name = "SongSearchForm";
			this.Text = "SongSearchForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.rightClickMenu_PlayList.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button_search;
		private System.Windows.Forms.RichTextBox searchKeyword;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox_Comments;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox_Artist;
		private System.Windows.Forms.CheckBox checkBox_Title;
		private System.Windows.Forms.Label label_NumResults;
		private System.Windows.Forms.Button button_SendToLeftPlayer;
		private System.Windows.Forms.ListBox listBox_SearchResults;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Label label_Timer;
		private System.Windows.Forms.ContextMenuStrip rightClickMenu_PlayList;
		private System.Windows.Forms.ToolStripMenuItem editID3DataToolStripMenuItem;
		private System.Windows.Forms.ProgressBar progressBar_Searching;
		private System.Windows.Forms.Button button_SendToRightPlayer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_cancelSearch;
	}
}