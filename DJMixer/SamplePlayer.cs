using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DJMixer {
	public partial class SamplePlayer : BasicPlayer {
		public SamplePlayer() {
			InitializeComponent();

			
		}

		private void radioButton_Auto_CheckedChanged(Object sender, EventArgs e) {

			
		}

		private void button_LoadSamples_Click(Object sender, EventArgs e) {

			loadMP3Dialog.FileName = null;
			loadMP3Dialog.ShowDialog(this);
		}


		private void loadMP3Dialog_FileOk(Object sender, CancelEventArgs e) {

			List<Song> songs = new List<Song>();

			foreach (String file in loadMP3Dialog.FileNames) {

				String fileType = file.Substring(file.LastIndexOf(".") + 1);
				if (fileType == "mp3")
					songs.Add(new Song(file));
				else if (fileType == "m3u") {

					StreamReader m3u = File.OpenText(file);
					String line;
					while ((line = m3u.ReadLine()) != null) {

						if (line.StartsWith("#EXTINF:")) {

							String filepath = m3u.ReadLine();
							if (filepath.Substring(1, 1) != ":") {
								filepath = file.Substring(0, file.LastIndexOf("\\") + 1) + filepath;
							}
							songs.Add(new Song(filepath));
						}
					}
				}
			}

			sampleList.Items.AddRange(songs.ToArray());
			
		}
	}
}
