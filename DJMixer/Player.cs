﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.Threading;
using NAudio.Wave.SampleProviders;
using System.Collections;
using System.IO;

namespace DJMixer {
	public partial class Player : BasicPlayer {


		private Boolean manuallyStopped = false;
		private Song nextSong;

		public Player() {
			InitializeComponent();

			nextSong = new Song(@"D:\mp3z\JPop\Tsunku\Sub-Groups\Guardians 4\Shugo Chara Party - Party Time.mp3");

			threadGUIUpdater = new Thread(new ThreadStart(updateDisplay));
			threadGUIUpdater.IsBackground = true;
			threadGUIUpdater.Name = "Player GUI Update Thread";
			threadGUIUpdater.Start();


		}




		private void button_Play_Click(Object sender, EventArgs e) {

			if (directSoundOut.PlaybackState == PlaybackState.Playing) {

				directSoundOut.Pause();
				label_SongTitle.Text += " (Paused)";

			} else if (directSoundOut.PlaybackState == PlaybackState.Paused || changedDevice) {

				directSoundOut.Play();
				label_SongTitle.Text = currentSong.ToString();
				changedDevice = false;

			} else {

				playSong();
			}



		}

		protected override void playSong() {
			try {

				currentSong = nextSong;
				if (currentSong == null) {

					currentSong = getNextSong();
					if (currentSong == null) {
						MessageBox.Show("No songs to play.");
						return;
					}
				}

				fileReader = new Mp3FileReader(currentSong.filepath);

			} catch (Exception) {
				MessageBox.Show("Error reading " + currentSong,
					"File does not exist or cannot be read.");
				return;
			}

			waveChannel = new WaveChannel32(fileReader, absoluteVolume * mixedVolume, panSlider.Pan);
			waveChannel.PadWithZeroes = false;

			SampleChannel sampleChannel = new SampleChannel(waveChannel);
			sampleChannel.PreVolumeMeter += onPreVolumeMeter;
			volumeDelegate = (vol) => sampleChannel.Volume = vol;
			postVolumeMeter = new MeteringSampleProvider(sampleChannel);
			postVolumeMeter.StreamVolume += onPostVolumeMeter;


			directSoundOut.Init(postVolumeMeter);
			directSoundOut.Play();
			label_EndTime.Text = String.Format("{0:00}:{1:00}",
						(int)fileReader.TotalTime.TotalMinutes,
						fileReader.TotalTime.Seconds);

			//if (threadGUIUpdater != null)
			//	threadGUIUpdater.Abort();

			//threadGUIUpdater = new Thread(new ThreadStart(updateDisplay));
			//threadGUIUpdater.IsBackground = false;
			//threadGUIUpdater.Name = "Player GUI Update Thread";
			//threadGUIUpdater.Start();


			volumeDelegate(absoluteVolume * mixedVolume);

			label_SongTitle.Text = currentSong.ToString();
		}


		protected override void setGUIText(String text) {

			if (timer.InvokeRequired) {
				//SetTextCallback d = new SetTextCallback(setGUIText);
				Invoke(new SetTextCallback(setGUIText), text);
			} else {

				timer.Text = text;
				progressBar.Value = (int)(fileReader.CurrentTime.TotalSeconds / fileReader.TotalTime.TotalSeconds * 100);
			}

		}


		protected override void button_Stop_Click(Object sender, EventArgs e) {

			manuallyStopped = true;
			if (stop())
				label_SongTitle.Text = currentSong.ToString() + " (Stopped)";
		}


		protected override void loadNextSong(object sender, StoppedEventArgs e) {

			Console.WriteLine("Load next song");
			if (manuallyStopped) {  // this prevents next song from loading when stop button is pressed
				manuallyStopped = false;
				return;
			}


			nextSong = getNextSong();

			playSong();
		}


		Song getNextSong() {

			Console.WriteLine("Get next song");
			if (songList.Items.Count > 0 && songList.Items.Count > nextSongIndex + 1) {
				Song next = (Song)songList.Items[++nextSongIndex];
				return next;
			}

			return null;
		}


		private void progressBar_Click(Object sender, EventArgs e) {

			if (fileReader != null) {
				float xPos = progressBar.PointToClient(Cursor.Position).X;
				int width = progressBar.Bounds.Width;
				float xPercent = xPos / progressBar.Bounds.Width;

				fileReader.Position = (long)(xPercent * fileReader.Length);

			}
		}



		private void button_Next_Click(Object sender, EventArgs e) {

			if (songList.Items.Count < nextSongIndex+2) {
				MessageBox.Show("No more queued songs ");
				return;
			}

			if (directSoundOut.PlaybackState == PlaybackState.Playing) {
				stop();
				Thread.Sleep(50); // sometimes the playback glitches if there is no pause.
			}

			manuallyStopped = true;
			loadNextSong(sender, null);
		}


		private void songList_MouseDoubleClick(Object sender, MouseEventArgs e) {

			//currentSongIndex = songList.SelectedIndex - 1;
			nextSongIndex = songList.SelectedIndex - 1;
			stop();
			manuallyStopped = true;
			loadNextSong(sender, null);
		}


		private void button_SavePlaylist_Click(Object sender, EventArgs e) {

			if (songList.Items.Count == 0) {
				MessageBox.Show("Song list is empty");
				return;
			}

			savePlaylistDialog.FileName = null;
			savePlaylistDialog.ShowDialog(this);
		}


		private void savePlaylistDialog_FileOk(Object sender, CancelEventArgs e) {


			String file = savePlaylistDialog.FileName;

			if (file.LastIndexOf(".m3u") == -1 && file.LastIndexOf(".M3U") == -1) {

				file += ".m3u";
			}


			using (StreamWriter writer = new StreamWriter(file)) {

				writer.WriteLine("#EXTM3U");

				foreach (Song song in songList.Items) {

					writer.WriteLine("#EXTINF:###," + song.ToString());
					writer.WriteLine(song.filepath);

				}
			}
		}


		private void button_Load_Mp3_Click(Object sender, EventArgs e) {

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
							//Console.WriteLine(filepath);
							songs.Add(new Song(filepath));

						}


					}
				}
			}

			songList.Items.AddRange(songs.ToArray());

			for (int i = 0; i < songList.Items.Count; ++i) {
				songList.SetItemChecked(i, true);
			}
			//nextSongIndex = 0;
		}


		void onPreVolumeMeter(object sender, StreamVolumeEventArgs e) {

			waveformPainterL.AddMax(e.MaxSampleValues[0]);
			waveformPainterR.AddMax(e.MaxSampleValues[1]);
		}

		void onPostVolumeMeter(object sender, StreamVolumeEventArgs e) {

			volumeMeterL.Amplitude = e.MaxSampleValues[0];
			volumeMeterR.Amplitude = e.MaxSampleValues[1];

		}




	}
}
