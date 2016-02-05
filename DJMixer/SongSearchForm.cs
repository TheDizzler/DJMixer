using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DJMixer {

	enum Keyword { Title, Artist, Genre, Year, Comments };


	public partial class SongSearchForm : Form {

		Size defaultSize = new Size(new Point(444, 173));
		Size fullSize = new Size(new Point(444, 410));


		public SongSearchForm() {
			InitializeComponent();

			this.Size = defaultSize;
		}


		private void checkBox_Title_CheckedChanged(Object sender, EventArgs e) {

		}


		private void button_Search_Click(Object sender, EventArgs e) {


			//SearchResultForm resultForm = new SearchResultForm();

			if (String.IsNullOrWhiteSpace(searchKeyword.Text)) {
				searchKeyword.BackColor = Color.Red;
				return;
			}

			DialogResult result = folderBrowserDialog.ShowDialog(this);

			if (result == DialogResult.OK) {

				Stopwatch timer = new Stopwatch();
				timer.Start();
				List<Song> results = getResults(Directory.GetFiles(folderBrowserDialog.SelectedPath,
					"*.mp3", SearchOption.AllDirectories));
				timer.Stop();

				//if (results.Count > 0) {

				//	this.Size = fullSize;
				//	listBox_SearchResults.Items.AddRange(results.ToArray());

				//} else {

				//	this.Size = defaultSize;
				//}

				label_NumResults.Text = results.Count + " Matches Found";
				label_Timer.Text = "in " + timer.Elapsed.Seconds + " seconds";
			}
			//resultForm.loadResults(getResults(Directory.GetFiles(@"D:\mp3z", "*.mp3", SearchOption.AllDirectories)));

			//resultForm.Show();

		}


		private List<Song> getResults(String[] allFiles) {

			List<Song> results = new List<Song>();

			searchKeyword.Text = searchKeyword.Text.Trim(' ');

			String keyword = searchKeyword.Text.ToLower();


			foreach (String file in allFiles) {

				Song song = new Song();
				if (song.initialize(file) && song.matchesAll(keyword)) {

					results.Add(song);
					listBox_SearchResults.Items.Add(song);
					this.Size = fullSize;
				}
			}


			return results;
		}

		private void searchFieldChanged(Object sender, EventArgs e) {

			if (String.IsNullOrWhiteSpace(searchKeyword.Text))
				searchKeyword.BackColor = Color.White;
		}

		private void button_Select_Click(Object sender, EventArgs e) {

		}
	}
}
