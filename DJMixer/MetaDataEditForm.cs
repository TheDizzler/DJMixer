using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HundredMilesSoftware.UltraID3Lib;
using Id3;
using Id3.Frames;
using TagLib;

namespace DJMixer {
	public partial class MetaDataEditForm : Form {

		public Id3Tag id3Tag;
		private File metaFile;

		//private bool initialized = false;

		public MetaDataEditForm() {
			InitializeComponent();
		}


		public void initialize(Song song) {



			if (song.usingTagLib) {

				metaFile = song.tagFile;

				this.Text = song.ToString();
				textBox_Title.Text = metaFile.Tag.Title;
				textBox_Artist.Text = metaFile.Tag.FirstPerformer;
				if (metaFile.Tag.Genres.Length > 0)
					textBox_Genre.Text = metaFile.Tag.Genres[0];
				foreach (String genre in metaFile.Tag.Genres)
					textBox_Genre.Text += "; " + genre;
				textBox_Album.Text = metaFile.Tag.Album;
				textBox_Year.Text = "" + metaFile.Tag.Year;
				textBox_Comments.Text = metaFile.Tag.Comment;

				button_SaveChanges.Enabled = true;

			} else if (song.usingId3Tag && !song.fileCorrupted) {

				id3Tag = song.id3Tag;

				this.Text = song.ToString();
				textBox_Title.Text = id3Tag.Title.Value;
				textBox_Artist.Text = id3Tag.Artists.Value;
				textBox_Genre.Text = id3Tag.Genre.Value;
				textBox_Album.Text = id3Tag.Album.Value;
				textBox_Year.Text = "" + id3Tag.Year.Value;
				foreach (CommentFrame comment in id3Tag.Comments)
					textBox_Comments.Text += comment.Comment + "\n";

				button_SaveChanges.Enabled = true;

			} else {
				//initialized = false;

				textBox_Title.Text = null;
				textBox_Artist.Text = null;
				textBox_Genre.Text = null;
				textBox_Album.Text = null;
				textBox_Year.Text = null;
				textBox_Comments.Text = null;

				button_SaveChanges.Enabled = false;
			}
		}


		private void button_SaveChanges_Click(Object sender, EventArgs e) {

			metaFile.Tag.Title = textBox_Title.Text;
			metaFile.Tag.Performers = new[] { textBox_Artist.Text };
			metaFile.Tag.Genres = textBox_Genre.Text.Split(';');
			metaFile.Tag.Album = textBox_Album.Text;
			try {
				metaFile.Tag.Year = uint.Parse(textBox_Year.Text);
			} catch (Exception ex) {
				//metaFile.Tag.Year = null;
				Debug.WriteLine("Could not parse year");
			}
			metaFile.Save();


			//} else if (song.usingUltraID3) {
			//	metaData.Title = textBox_Title.Text;
			//	metaData.Artist = textBox_Artist.Text;
			//	try {
			//		metaData.Genre = textBox_Genre.Text;
			//	} catch (Exception ex) {
			//		Debug.WriteLine(ex.Message);
			//		Debug.WriteLine(ex.GetType().ToString());
			//		Debug.WriteLine(ex.HResult);
			//	}
			//	metaData.Album = textBox_Album.Text;
			//	try {
			//		metaData.Year = short.Parse(textBox_Year.Text);
			//	} catch (Exception ex) {
			//		metaData.Year = null;
			//	}
			//	metaData.Write();





			this.Hide();
		}


		private void button_Cancel_Click(Object sender, EventArgs e) {

			this.Hide();
			//metaData = null;

			//initialized = false;
		}

		private void formShown(Object sender, EventArgs e) {

			//if (!initialized)
			//	this.Hide();
		}

		private void yearValidate(Object sender, EventArgs e) {

			String original = textBox_Year.Text;
			try {
				short.Parse(textBox_Year.Text);
			} catch (Exception ex) {
				Debug.WriteLine(ex.Message);
				//textBox_Year.Text = original;
				textBox_Year.Undo();
				textBox_Year.BackColor = Color.Crimson;
				return;
			}

			textBox_Year.BackColor = Color.White;
		}
	}
}
