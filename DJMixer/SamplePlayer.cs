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


		int songsUntilNextSample = 1;

		private Player mainPlayer;


		public SamplePlayer() {
			InitializeComponent();

			songsUntilNextSample = (int)songsBetweenSamples.Value;
		}


		public void setPlayer(Player plyr) {

			mainPlayer = plyr;
		}



		public void playSample() {


			playSong();

		}


		private void button_LoadSamples_Click(Object sender, EventArgs e) {

			loadMP3Dialog.FileName = null;
			loadMP3Dialog.ShowDialog(this);
		}


		private void loadMP3Dialog_FileOk(Object sender, CancelEventArgs e) {

			//List<Song> songs = new List<Song>();

			foreach (String file in loadMP3Dialog.FileNames) {

				String fileType = file.Substring(file.LastIndexOf(".") + 1);
				if (fileType == "mp3") {
					Song song = new Song();
					if (song.initialize(file))
						sampleList.Items.Add(song);
					else
						MessageBox.Show(file + " does not appear to be a valid mp3 file");

				} else if (fileType == "m3u") {

					StreamReader m3u = File.OpenText(file);
					String line;
					while ((line = m3u.ReadLine()) != null) {

						if (line.StartsWith("#EXTINF:")) {

							String filepath = m3u.ReadLine();
							if (filepath.Substring(1, 1) != ":") {
								filepath = file.Substring(0, file.LastIndexOf("\\") + 1) + filepath;
							}
							Song song = new Song();
							if (song.initialize(file))
								sampleList.Items.Add(song);
							else
								MessageBox.Show(file + " does not appear to be a valid mp3 file");

						}
					}
				}
			}

			//sampleList.Items.AddRange(songs.ToArray());
			getNextSample();
		}


		private void button_Play_Click(Object sender, EventArgs e) {


			if (mainPlayer.isPlaying()) {
				songsUntilNextSample = 0;
				setGUIText("Sample playing next");
				return;
			}

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
					mainPlayer.sampleDone();
					return;
				}

				fileReader = new Mp3FileReader(currentSong.filepath);

			} catch (Exception) {
				MessageBox.Show("Error reading " + currentSong,
					"File does not exist or cannot be read.");
				getNextSample();
				mainPlayer.sampleDone();
				return;
			}

			waveChannel = new WaveChannel32(fileReader, absoluteVolume * mixedVolume, panSlider.Pan);
			waveChannel.PadWithZeroes = false;

			volumeDelegate = (vol) => waveChannel.Volume = vol;
			volumeDelegate(absoluteVolume * mixedVolume);

			deviceOut.Init(waveChannel);
			deviceOut.Play();

			setGUIText("Playing Sample");

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
			if (songsUntilNextSample > 1)
				setGUIText(songsUntilNextSample + " songs until sample");
			else
				setGUIText("Sample playing next");
			mainPlayer.sampleDone();
		}


		private void sampleList_SelectedIndexChanged(Object sender, EventArgs e) {

			nextSongIndex = sampleList.SelectedIndex;
		}


		public Boolean ready() {

			if (radioButton_On.Checked && songsUntilNextSample-- <= 1) {
				songsUntilNextSample = (int)songsBetweenSamples.Value;
				return true;
			}

			if (radioButton_Off.Checked)
				setGUIText("Samples Disabled");
			else {
				if (songsUntilNextSample > 1)
					setGUIText(songsUntilNextSample + " songs until sample");
				else
					setGUIText("Sample playing next");
			}

			return false;
		}

		private void songsBetweenSamples_ValueChanged(Object sender, EventArgs e) {

			if ((int)songsBetweenSamples.Value > songsUntilNextSample)
				++songsUntilNextSample;
			else
				--songsUntilNextSample;

			if (radioButton_On.Checked)
				if (songsUntilNextSample > 1)
					setGUIText(songsUntilNextSample + " songs until sample");
				else
					setGUIText("Sample playing next");
		}


		protected override void setGUIText(String text) {

			if (label_SongTitle.InvokeRequired) {
				label_SongTitle.Invoke(new SetTextCallback(setGUIText), new object[] { text });
			} else {
				label_SongTitle.Text = text;
			}

		}

		private void radioButton_On_CheckedChanged(Object sender, EventArgs e) {

			if (radioButton_On.Checked) {
				songsUntilNextSample = (int)songsBetweenSamples.Value;
				if (songsUntilNextSample > 1)
					setGUIText(songsUntilNextSample + " songs until sample");
				else
					setGUIText("Sample playing next");
			}
		}


		private void radioButton_Off_CheckedChanged(Object sender, EventArgs e) {

			if (radioButton_Off.Checked)
				setGUIText("Samples Disabled");

		}

		private void button_ResetList_Click(Object sender, EventArgs e) {

			sampleList.Items.Clear();

		}

		private void sampleList_DropDown(Object sender, EventArgs e) {

			if (sampleList.Items.Count <= 0)
				button_LoadSamples_Click(null, null);
		}
	}
}
