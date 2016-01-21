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
using NAudio.Wave;

namespace DJMixer {
	public partial class SamplePlayer : BasicPlayer {


		public bool on = true;

		private Player player;


		public SamplePlayer() {
			InitializeComponent();


		}


		public void playSample() {

			playSong();

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

		private void button_Play_Click(Object sender, EventArgs e) {

			//Console.WriteLine("button_Play_Click()");
			if (deviceOut.PlaybackState == PlaybackState.Playing) {

				deviceOut.Pause();
				label_SongTitle.Text += " (Paused)";

			} else if (deviceOut.PlaybackState == PlaybackState.Paused || changedDevice) {

				deviceOut.Play();
				label_SongTitle.Text = currentSong.ToString();
				changedDevice = false;

			} else {

				playSong();
			}
		}


		protected override void playSong() {

			if (currentSong == null)
				getNextSample();

			try {

				if (currentSong == null) {
					Console.WriteLine("No samples to play");
					player.sampleDone();
					return;
				}

				fileReader = new Mp3FileReader(currentSong.filepath);

			} catch (Exception) {
				MessageBox.Show("Error reading " + currentSong,
					"File does not exist or cannot be read.");
				getNextSample();
				player.sampleDone();
				return;
			}

			waveChannel = new WaveChannel32(fileReader, absoluteVolume * mixedVolume, panSlider.Pan);
			waveChannel.PadWithZeroes = false;

			volumeDelegate = (vol) => waveChannel.Volume = vol;
			volumeDelegate(absoluteVolume * mixedVolume);

			deviceOut.Init(waveChannel);
			deviceOut.Play();

		}


		private void getNextSample() {

			if (sampleList.Items.Count < 1) {
				Console.WriteLine("No samples loaded");
				return;
			}

			if (nextSongIndex >= sampleList.Items.Count || nextSongIndex < 0)
				nextSongIndex = 0;

			currentSong = (Song)sampleList.Items[nextSongIndex];
			sampleList.SelectedIndex = nextSongIndex;
			++nextSongIndex;
		}


		protected override void loadNextSong(object sender, StoppedEventArgs e) {

			getNextSample();
			player.sampleDone();
		}


		private void sampleList_SelectedIndexChanged(Object sender, EventArgs e) {

			nextSongIndex = sampleList.SelectedIndex;
		}


		public void setPlayer(Player plyr) {

			player = plyr;
		}
	}
}
