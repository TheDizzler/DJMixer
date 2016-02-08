using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DJMixer {

	enum Keyword { Title, Artist, Genre, Year, Comments };


	public partial class SongSearchForm : Form {

		Size defaultSize = new Size(new Point(444, 173));
		Size fullSize = new Size(new Point(444, 410));

		private String keyword;
		private Stopwatch timer;
		private Thread threadGUIUpdater;

		private Thread threadSearch;

		private MetaDataEditForm editForm;
		private Song songRightClicked;


		private int songsFound = 0;



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

				listBox_SearchResults.Items.Clear();
				songsFound = 0;

				if (timer == null)
					timer = new Stopwatch();
				else
					timer.Reset();

				timer.Start();

				searchKeyword.Text = searchKeyword.Text.Trim(' ');
				keyword = searchKeyword.Text.ToLower();

				threadGUIUpdater = new Thread(new ThreadStart(updateDisplay));
				threadGUIUpdater.IsBackground = true;
				threadGUIUpdater.Name = this.Name + " GUI Update Thread";

				threadSearch = new Thread(new ThreadStart(searchProc));
				threadSearch.IsBackground = true;
				threadSearch.Name = "Search Thread";

				threadGUIUpdater.Start();
				threadSearch.Start();


				progressBar_Searching.Value = 100;

			}
		}


		private List<String> searchForFiles(String directory) {

			List<String> files = new List<String>();

			foreach (String subDir in Directory.GetDirectories(directory)) {

				try {

					files.AddRange(Directory.GetFiles(subDir, "*.mp3"));
					files.AddRange(searchForFiles(subDir));
					//Console.WriteLine(subDir + " Ok");

				} catch (UnauthorizedAccessException ex) {

					//Console.WriteLine(subDir + " NOT cool!!!!");
				}
			}

			return files;

		}

		private void getResults(List<String> allFiles) {

			//List<Song> results = new List<Song>();

			//searchKeyword.Text = searchKeyword.Text.Trim(' ');

			//String keyword = searchKeyword.Text.ToLower();


			foreach (String file in allFiles) {

				Song song = new Song();
				if (song.initialize(file) && song.matchesAll(keyword)) {

					//results.Add(song);
					addToListBox(song);
					//listBox_SearchResults.Items.Add(song);
					//this.Size = fullSize;
				}
			}
		}



		private void searchFieldChanged(Object sender, EventArgs e) {

			if (String.IsNullOrWhiteSpace(searchKeyword.Text))
				searchKeyword.BackColor = Color.White;
		}


		private void searchProc() {

			getResults(searchForFiles(folderBrowserDialog.SelectedPath));

			timer.Stop();
			//label_NumResults.Text = listBox_SearchResults.Items.Count + " Matches Found";
			//label_Timer.Text = "in " + timer.Elapsed.Seconds + " seconds";

			Console.WriteLine(Thread.CurrentThread.Name + " terminated");
		}

		/// <summary>
		/// GUI update thread proc
		/// </summary>
		protected void updateDisplay() {

			while (timer.IsRunning) {

				setGUIText();

			}

			setGUIText();

			Console.WriteLine(Thread.CurrentThread.Name + " Thread terminated");
		}

		/// <summary>
		/// This delegate enables asynchronous calls for setting
		/// the text property on a TextBox control.
		/// </summary>
		protected delegate void SetTextCallback();

		private delegate void SetListCallback(Song song);


		protected virtual void setGUIText() {

			if (label_NumResults.InvokeRequired) {
				SetTextCallback d = new SetTextCallback(setGUIText);
				label_NumResults.Invoke(d, new object[] {  });
			} else {
				label_NumResults.Text = listBox_SearchResults.Items.Count + " Matches Found";
				label_Timer.Text = "in " + timer.Elapsed.TotalSeconds + " seconds";
				progressBar_Searching.Value = 100;
			}

		}


		private void addToListBox(Song song) {

			if (listBox_SearchResults.InvokeRequired) {
				listBox_SearchResults.Invoke(new SetListCallback(addToListBox), new object[] { song });
			} else {
				listBox_SearchResults.Items.Add(song);
				this.Size = fullSize;
			}
		}

		private void button_Select_Click(Object sender, EventArgs e) {

		}


		private void mouseClickListBox(Object sender, MouseEventArgs e) {

			int index = listBox_SearchResults.IndexFromPoint(e.Location);

			if (index <= -1)
				return;

			if (e.Button == MouseButtons.Right)
				songRightClicked = (Song)listBox_SearchResults.Items[index];

			//Console.WriteLine(index);
			//Console.WriteLine(songRightClicked);
		}

		private void editID3Tag(Object sender, EventArgs e) {

			if (songRightClicked != null) {
				if (editForm == null)
					editForm = new MetaDataEditForm();
				editForm.initialize(songRightClicked);
				editForm.Show();

				songRightClicked = null;
			}
		}
	}
}
