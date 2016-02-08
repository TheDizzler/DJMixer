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


		public Form1 mixer;


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
				label_NumResults.Visible = true;
				label_Timer.Visible = true;

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
					//Debug.WriteLine(subDir + " Ok");

				} catch (UnauthorizedAccessException ex) {

					//Debug.WriteLine(subDir + " is inaccessible.");
				}
			}

			return files;

		}

		private void getResults(List<String> allFiles) {

			foreach (String file in allFiles) {

				Song song = new Song();
				if (song.initialize(file) && song.matchesAll(keyword)) {

					addToListBox(song);

				}
			}
		}



		private void searchFieldChanged(Object sender, EventArgs e) {

			if (!String.IsNullOrWhiteSpace(searchKeyword.Text))
				searchKeyword.BackColor = Color.White;
		}


		private void searchProc() {

			getResults(searchForFiles(folderBrowserDialog.SelectedPath));

			timer.Stop();
			//label_NumResults.Text = listBox_SearchResults.Items.Count + " Matches Found";
			//label_Timer.Text = "in " + timer.Elapsed.Seconds + " seconds";

			Debug.WriteLine(Thread.CurrentThread.Name + " terminated");
		}

		/// <summary>
		/// GUI update thread proc
		/// </summary>
		protected void updateDisplay() {

			while (timer.IsRunning) {

				setGUIText();

			}

			setGUIText();

			Debug.WriteLine(Thread.CurrentThread.Name + " Thread terminated");
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


		private void mouseClickListBox(Object sender, MouseEventArgs e) {

			int index = listBox_SearchResults.IndexFromPoint(e.Location);

			if (index <= -1)
				return;

			if (e.Button == MouseButtons.Right)
				songRightClicked = (Song)listBox_SearchResults.Items[index];

			//Debug.WriteLine(index);
			//Debug.WriteLine(songRightClicked);
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

		private void button_SendToLeftPlayer_Click(Object sender, EventArgs e) {

			mixer.addToLeftPlayer(getList());
		}


		private List<Song> getList() {

			List<Song> list = new List<Song>();

			for (int i = 0; i < listBox_SearchResults.SelectedItems.Count; ++i) {

				list.Add((Song)listBox_SearchResults.SelectedItems[i]);
			}

			return list;
		}

		private void button_SendToRightPlayer_Click(Object sender, EventArgs e) {

			mixer.addToRightPlayer(getList());
		}
	}
}
