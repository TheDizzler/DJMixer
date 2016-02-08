using System;
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
using System.Diagnostics;

namespace DJMixer {
	public partial class Player : BasicPlayer {


		private Song nextSong;
		private Song songRightClicked;
		private SamplePlayer samplePlayer;

		private MetaDataEditForm editForm;

		public Player() {
			InitializeComponent();

			//nextSong = new Song(@"D:\mp3z\JPop\Tsunku\Sub-Groups\Guardians 4\Shugo Chara Party - Party Time.mp3");

			threadGUIUpdater = new Thread(new ThreadStart(updateDisplay));
			threadGUIUpdater.IsBackground = true;
			threadGUIUpdater.Name = this.Name + " GUI Update Thread";

		}


		public void sampleDone() {

			Debug.WriteLine("Sample Done");
			playSong();
			startGUIThread();
		}


		private void button_Play_Click(Object sender, EventArgs e) {

			if (deviceOut.PlaybackState == PlaybackState.Playing) {

				deviceOut.Pause();
				label_SongTitle.Text += " (Paused)";

			} else if (deviceOut.PlaybackState == PlaybackState.Paused || changedDevice) {

				deviceOut.Play();
				label_SongTitle.Text = currentSong.ToString();
				changedDevice = false;

			} else {

				playSong();

				//startGUIThread();
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

				if (fileReader != null)
					fileReader.Dispose();
				fileReader = new Mp3FileReader(currentSong.filepath);

			} catch (Exception) {
				MessageBox.Show("Error reading " + currentSong + ".\n" +
					"File does not exist or cannot be read.");
				if (fileReader != null)
					fileReader.Dispose();
				loadNextSong(null, null);
				return;
			}

			startGUIThread();

			waveChannel = new WaveChannel32(fileReader, absoluteVolume * mixedVolume, panSlider.Pan);
			waveChannel.PadWithZeroes = false;

			SampleChannel sampleChannel = new SampleChannel(waveChannel);
			sampleChannel.PreVolumeMeter += onPreVolumeMeter;
			volumeDelegate = (vol) => sampleChannel.Volume = vol;
			volumeDelegate(absoluteVolume * mixedVolume);
			
			//Debug.WriteLine("absoluteVolume: " + absoluteVolume + " mixedVolume: " + mixedVolume);
			//Debug.WriteLine("absoluteVolume * mixedVolume = " + absoluteVolume * mixedVolume);

			postVolumeMeter = new MeteringSampleProvider(sampleChannel);
			postVolumeMeter.StreamVolume += onPostVolumeMeter;


			deviceOut.Init(postVolumeMeter);
			deviceOut.Play();

			label_EndTime.Text = String.Format("{0:00}:{1:00}",
						(int)fileReader.TotalTime.TotalMinutes,
						fileReader.TotalTime.Seconds);




			label_SongTitle.Text = currentSong.ToString();
		}


		protected override void setGUIText(String text) {

			if (timer.InvokeRequired) {
				timer.Invoke(new SetTextCallback(setGUIText), new object[] { text });
			} else {
				timer.Text = text;
				progressBar.Value = (int)(fileReader.CurrentTime.TotalSeconds / fileReader.TotalTime.TotalSeconds * 100);
			}

		}

		internal void addSongs(List<Song> selectedSongs) {
			
			songList.Items.AddRange(selectedSongs.ToArray());
		}

		protected override void button_Stop_Click(Object sender, EventArgs e) {

			if (deviceOut.PlaybackState != PlaybackState.Stopped)
				manuallyStopped = true;

			if (stop()) {
				label_SongTitle.Text = currentSong.ToString() + " (Stopped)";
				fileReader.CurrentTime += fileReader.CurrentTime.Negate();
			}
		}


		protected override void loadNextSong(object sender, StoppedEventArgs e) {

			Debug.WriteLine("Load next song");
			if (manuallyStopped) {  // this prevents next song from loading when stop button is pressed
				Debug.WriteLine("Manual stop");
				manuallyStopped = false;
				return;
			}

			nextSong = getNextSong();

			if (samplePlayer.ready())
				samplePlayer.playSample();
			else
				playSong();
		}


		Song getNextSong() {

			Debug.WriteLine("Get next song");
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

			if (samplePlayer.isPlaying())
				return;

			if (songList.Items.Count < nextSongIndex + 2) {
				MessageBox.Show("No more queued songs ");
				return;
			}

			if (deviceOut.PlaybackState == PlaybackState.Playing) {

				stop();
				Thread.Sleep(50); // sometimes the playback glitches if there is no pause.

			} else

				sampleDone();

		}


		private void songList_MouseDoubleClick(Object sender, MouseEventArgs e) {


			nextSongIndex = songList.SelectedIndex - 1;

			if (!stop()) {
				//Debug.WriteLine("stopped?");
				loadNextSong(null, null);
			}

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

			loadMp3Files(loadMP3Dialog.FileNames);
		}


		private void songList_DragDrop(Object sender, DragEventArgs e) {

			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				loadMp3Files(files);
			}
		}


		private void loadMp3Files(String[] files) {

			foreach (string file in files) {
				String fileType = file.Substring(file.LastIndexOf(".") + 1);
				if (fileType == "mp3") {
					Song song = new Song();
					if (!song.initialize(file))
						MessageBox.Show(" Could not read ID3 metadata in " + file);

					songList.Items.Add(song);

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
							if (!song.initialize(file))
								MessageBox.Show(" Could not read ID3 metadata in " + file);
							songList.Items.Add(song);
						}
					}
				}

			}
		}


		void onPreVolumeMeter(object sender, StreamVolumeEventArgs e) {

			waveformPainterL.AddMax(e.MaxSampleValues[0]);
			waveformPainterR.AddMax(e.MaxSampleValues[1]);
		}

		void onPostVolumeMeter(object sender, StreamVolumeEventArgs e) {

			volumeMeterL.Amplitude = e.MaxSampleValues[0];
			volumeMeterR.Amplitude = e.MaxSampleValues[1];

		}


		private void startGUIThread() {

			if (!threadGUIUpdater.IsAlive && fileReader != null) {
				Debug.WriteLine("Starting Thread");
				threadGUIUpdater.Start();
			}

		}

		public void setSampler(SamplePlayer smplPlyr) {

			samplePlayer = smplPlyr;
		}

		private void button_ResetList_Click(Object sender, EventArgs e) {

			songList.Items.Clear();

		}



		private void songList_DragEnter(Object sender, DragEventArgs e) {

			// Check if the Dataformat of the data can be accepted
			// (we only accept file drops from Explorer, etc.)
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy; // Okay
			else
				e.Effect = DragDropEffects.None; // Unknown data, ignore it
		}

		private void removeFromListToolStripMenuItem_Click(Object sender, EventArgs e) {

			songList.Items.Remove(songRightClicked);

			if (songRightClicked == currentSong)
				--nextSongIndex;

			songRightClicked = null;
		}

		private void mouseClickListBox(Object sender, MouseEventArgs e) {

			int index = songList.IndexFromPoint(e.Location);

			if (index <= -1)
				return;

			songList.SelectedIndex = index;
			if (e.Button == MouseButtons.Right)
				songRightClicked = (Song)songList.Items[index];
			else if (e.Button == MouseButtons.Left) {

				Label label = new Label();
				label.Location = e.Location;
				label.Text = "Test";

			}
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


		private void label_SongTitle_DoubleClick(Object sender, EventArgs e) {

			songRightClicked = currentSong;
			editID3Tag(sender, e);
		}
	}
}
