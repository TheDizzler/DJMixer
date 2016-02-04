namespace DJMixer {
	partial class SearchResultForm {
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
			this.listBox_SearchResults = new System.Windows.Forms.ListBox();
			this.button_Select = new System.Windows.Forms.Button();
			this.label_NumResults = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox_SearchResults
			// 
			this.listBox_SearchResults.FormattingEnabled = true;
			this.listBox_SearchResults.Location = new System.Drawing.Point(12, 40);
			this.listBox_SearchResults.Name = "listBox_SearchResults";
			this.listBox_SearchResults.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBox_SearchResults.Size = new System.Drawing.Size(259, 199);
			this.listBox_SearchResults.TabIndex = 0;
			// 
			// button_Select
			// 
			this.button_Select.Location = new System.Drawing.Point(189, 246);
			this.button_Select.Name = "button_Select";
			this.button_Select.Size = new System.Drawing.Size(75, 23);
			this.button_Select.TabIndex = 1;
			this.button_Select.Text = "Select Songs";
			this.button_Select.UseVisualStyleBackColor = true;
			this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
			// 
			// label_NumResults
			// 
			this.label_NumResults.AutoSize = true;
			this.label_NumResults.Location = new System.Drawing.Point(13, 13);
			this.label_NumResults.Name = "label_NumResults";
			this.label_NumResults.Size = new System.Drawing.Size(90, 13);
			this.label_NumResults.TabIndex = 2;
			this.label_NumResults.Text = "0 Matches Found";
			// 
			// SearchResultForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 362);
			this.Controls.Add(this.label_NumResults);
			this.Controls.Add(this.button_Select);
			this.Controls.Add(this.listBox_SearchResults);
			this.Name = "SearchResultForm";
			this.Text = "SearchForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox_SearchResults;
		private System.Windows.Forms.Button button_Select;
		private System.Windows.Forms.Label label_NumResults;
	}
}