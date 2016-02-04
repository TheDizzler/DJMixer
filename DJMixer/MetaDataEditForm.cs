using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HundredMilesSoftware.UltraID3Lib;
using TagLib;

namespace DJMixer {
	public partial class MetaDataEditForm : Form {

		//private UltraID3 metaData;
		private File metaFile;

		private bool initialized = false;

		public MetaDataEditForm() {
			InitializeComponent();
		}


		public void initialize(Song song) {

			if (song.usingTagLib) {

				metaFile = song.tagFile;

				this.Text = song.ToString();
				textBox_Title.Text = metaFile.Tag.Title;
				textBox_Artist.Text = metaFile.Tag.FirstPerformer;
				textBox_Genre.Text = metaFile.Tag.Genres[0];
				foreach (String genre in metaFile.Tag.Genres)
					textBox_Genre.Text += "; " + genre;
				textBox_Album.Text = metaFile.Tag.Album;
				textBox_Year.Text = "" + metaFile.Tag.Year;
				textBox_Comments.Text = metaFile.Tag.Comment;

				button_SaveChanges.Enabled = true;

			//} else if (song.usingUltraID3) {

				//metaData = song.metaData;

				//this.Text = song.ToString();
				//textBox_Title.Text = metaData.Title;
				//textBox_Artist.Text = metaData.Artist;
				//textBox_Genre.Text = metaData.Genre;
				//textBox_Album.Text = metaData.Album;
				//textBox_Year.Text = "" + metaData.Year;
				//textBox_Comments.Text = metaData.Comments;

				//button_SaveChanges.Enabled = true;
				//initialized = true;
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
				Console.WriteLine("Could not parse year");
			}
			metaFile.Save();


			//} else if (song.usingUltraID3) {
			//	metaData.Title = textBox_Title.Text;
			//	metaData.Artist = textBox_Artist.Text;
			//	try {
			//		metaData.Genre = textBox_Genre.Text;
			//	} catch (Exception ex) {
			//		Console.WriteLine(ex.Message);
			//		Console.WriteLine(ex.GetType().ToString());
			//		Console.WriteLine(ex.HResult);
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
				Console.WriteLine(ex.Message);
				//textBox_Year.Text = original;
				textBox_Year.Undo();
				textBox_Year.BackColor = Color.Crimson;
				return;
			}

			textBox_Year.BackColor = Color.White;
		}
	}
}
