using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DJMixer {
	public partial class SongSearchForm : Form {

		Size defaultSize = new Size(new Point (444, 173));
		Size fullSize = new Size(new Point(444, 410));


		public SongSearchForm() {
			InitializeComponent();

			this.Size = defaultSize;
		}


		private void checkBox_Title_CheckedChanged(Object sender, EventArgs e) {

		}


		private void button_Search_Click(Object sender, EventArgs e) {


			SearchResultForm resultForm = new SearchResultForm();



			List<Song> results = getResults(Directory.GetFiles(@"D:\mp3z", "*.mp3", SearchOption.AllDirectories));
			if (results.Count > 0) {


				this.Size = fullSize;
				listBox_SearchResults.Items.AddRange(results.ToArray());
				label_NumResults.Text = results.Count + " Matches Found";

			} else {

				this.Size = defaultSize;
			}

			//resultForm.loadResults(getResults(Directory.GetFiles(@"D:\mp3z", "*.mp3", SearchOption.AllDirectories)));

			//resultForm.Show();

		}


		private List<Song> getResults(String[] allFiles) {

			List<Song> results = new List<Song>();

			foreach (String file in allFiles) {

				Song song = new Song();
				if (song.initialize(file) && song.matches(searchKeyword.Text.ToLower()))
						results.Add(song);
						
			}


			return results;
		}
	}
}
