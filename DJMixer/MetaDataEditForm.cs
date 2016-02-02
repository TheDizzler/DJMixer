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

namespace DJMixer {
	public partial class MetaDataEditForm : Form {

		private UltraID3 metaData;

		private bool initialized = false;

		public MetaDataEditForm() {
			InitializeComponent();
		}


		public void initialize(Song song) {

			metaData = song.metaData;

			this.Text = song.ToString();
			textBox_Title.Text = metaData.Title;
			textBox_Artist.Text = metaData.Artist;
			textBox_Genre.Text = metaData.Genre;
			textBox_Album.Text = metaData.Album;
			textBox_Year.Text = "" + metaData.Year;
			textBox_Comments.Text = metaData.Comments;


			initialized = true;
		}


		private void button_SaveChanges_Click(Object sender, EventArgs e) {

			metaData.Title = textBox_Title.Text;
			metaData.Artist = textBox_Artist.Text;
			try {
				metaData.Genre = textBox_Genre.Text;
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.GetType().ToString());
				Console.WriteLine(ex.HResult);
			}
			metaData.Album = textBox_Album.Text;
			try {
				metaData.Year = short.Parse(textBox_Year.Text);
			} catch (Exception ex) {
				metaData.Year = null;
			}
			metaData.Write();
			this.Hide();
			initialized = false;
		}


		private void button_Cancel_Click(Object sender, EventArgs e) {


			this.Hide();
			//metaData = null;

			initialized = false;
		}

		private void formShown(Object sender, EventArgs e) {

			if (!initialized)
				this.Hide();
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
