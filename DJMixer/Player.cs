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

namespace DJMixer {
	public partial class Player : UserControl {


		private DirectSoundOut directSoundOut;
		private Mp3FileReader fileReader;
		private Thread threadGUIUpdater;

		/// <summary>
		/// Internal volume, i.e. actual volume when crossfader is 100% towards this player
		/// This volume can only be changed from the player itself.
		/// </summary>
		private float absoluteVolume = .75f;
		/// <summary>
		/// Percent of volume to play.
		/// </summary>
		private float mixedVolume = .50f;
		private Action<float> volumeDelegate;

		private Song currentSong;
		/// <summary>
		/// Stripped file name
		/// </summary>
		//private String songname;

		private MeteringSampleProvider postVolumeMeter;

		private Boolean changedDevice = false;
		private Boolean manuallyStopped = false;


		public Player() {
			InitializeComponent();

			//currentSong = new Song(@"D:\mp3z\JPop\Tsunku\Sub-Groups\Guardians 4\Shugo Chara Party - Party Time.mp3");
		}

		public void setGUID(Guid guid) {

			if (directSoundOut != null && fileReader != null) {

				if (directSoundOut.PlaybackState == PlaybackState.Playing) {

					directSoundOut.Stop();
					directSoundOut = new DirectSoundOut(guid);
					directSoundOut.Init(postVolumeMeter);
					directSoundOut.Play();
					changedDevice = false;

				} else {

					directSoundOut = new DirectSoundOut(guid);
					directSoundOut.Init(postVolumeMeter);
					if (directSoundOut.PlaybackState == PlaybackState.Paused)
						changedDevice = true;

				}
			} else {
				directSoundOut = new DirectSoundOut(guid);
				changedDevice = false;
			}
			directSoundOut.PlaybackStopped += loadNextSong;
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

				loadSong();
			}



		}

		private void loadSong() {
			try {
				if (currentSong == null) {

					currentSong = (Song)songList.CheckedItems[0];
					songList.SetItemChecked(songList.CheckedIndices[0], false);
                }

				fileReader = new Mp3FileReader(currentSong.filepath);

			} catch (Exception) {
				MessageBox.Show("Error reading " + currentSong,
					"File does not exist or cannot be read.");
				return;
			}

			SampleChannel sampleChannel = new SampleChannel(fileReader);
			sampleChannel.PreVolumeMeter += onPreVolumeMeter;
			this.volumeDelegate = (vol) => sampleChannel.Volume = vol;
			postVolumeMeter = new MeteringSampleProvider(sampleChannel);
			postVolumeMeter.StreamVolume += onPostVolumeMeter;

			
			directSoundOut.Init(postVolumeMeter);
			directSoundOut.Play();

			threadGUIUpdater = new Thread(new ThreadStart(updateDisplay));
			threadGUIUpdater.IsBackground = true;
			threadGUIUpdater.Name = "Player GUI Update Thread";
			threadGUIUpdater.Start();


			volumeDelegate(absoluteVolume * mixedVolume);

			label_SongTitle.Text = currentSong.ToString();
		}


		private void button_Stop_Click(Object sender, EventArgs e) {

			manuallyStopped = true;
			stop();

		}


		void loadNextSong(object sender, StoppedEventArgs e) {

			if (manuallyStopped) {
				manuallyStopped = false;// do nothing for now
				return;
			}

			currentSong = (Song)songList.CheckedItems[0];
			songList.SetItemChecked(songList.CheckedIndices[0], false);
			loadSong();
        }


		void onPreVolumeMeter(object sender, StreamVolumeEventArgs e) {
			// we know it is stereo
			waveformPainterL.AddMax(e.MaxSampleValues[0]);
			waveformPainterR.AddMax(e.MaxSampleValues[1]);
		}

		void onPostVolumeMeter(object sender, StreamVolumeEventArgs e) {
			// we know it is stereo
			volumeMeterL.Amplitude = e.MaxSampleValues[0];
			volumeMeterR.Amplitude = e.MaxSampleValues[1];

		}


		private void progressBar1_Click(Object sender, EventArgs e) {

			if (fileReader != null) {
				float xPos = progressBar1.PointToClient(Cursor.Position).X;
				int width = progressBar1.Bounds.Width;
				float xPercent = xPos / progressBar1.Bounds.Width;

				fileReader.Position = (long)(xPercent * fileReader.Length);

			}
		}


		private void trackBar_Volume_Scroll(Object sender, EventArgs e) {

			absoluteVolume = (float)trackBar_Volume.Value / 100;

			if (fileReader != null)
				volumeDelegate(absoluteVolume * mixedVolume);

		}


		public void setMixedVolume(float mixVol) {

			mixedVolume = mixVol;

			if (fileReader != null)
				volumeDelegate(absoluteVolume * mixedVolume);
		}


		/// <summary>
		/// GUI update thread proc
		/// </summary>
		private void updateDisplay() {

			while (fileReader.CurrentTime <= fileReader.TotalTime &&
				 directSoundOut.PlaybackState != PlaybackState.Stopped) {

				setGUIText(String.Format("{0:00}:{1:00}",
					(int)fileReader.CurrentTime.TotalMinutes,
					fileReader.CurrentTime.Seconds));

			}

			setGUIText(String.Format("{0:00}:{1:00}", 0, 0));
			Console.WriteLine("Thread terminated");
		}




		/// <summary>
		/// This delegate enables asynchronous calls for setting
		/// the text property on a TextBox control.
		/// </summary>
		delegate void SetTextCallback(String text);


		private void setGUIText(String text) {

			if (timer.InvokeRequired) {
				SetTextCallback d = new SetTextCallback(setGUIText);
				Invoke(d, new object[] { text });
			} else {
				timer.Text = text;
				progressBar1.Value = (int)(fileReader.CurrentTime.TotalSeconds / fileReader.TotalTime.TotalSeconds * 100);
			}

		}


		public void prepareForClose() {

			if (threadGUIUpdater != null && threadGUIUpdater.IsAlive)
				threadGUIUpdater.Suspend(); // necessary to interrupt this thread as MessageBox blocks UI threads

		}


		public void cancelClose() {

			if (threadGUIUpdater != null && threadGUIUpdater.IsAlive)
				threadGUIUpdater.Resume();
		}


		public void stop() {

			if (directSoundOut != null && directSoundOut.PlaybackState != PlaybackState.Stopped) {

				directSoundOut.Stop();
				label_SongTitle.Text = currentSong.ToString() + " (Stopped)";
			}
		}

		private void button_Load_Mp3_Click(Object sender, EventArgs e) {

			loadMP3Dialog.ShowDialog(this);

		}


		private void loadMP3Dialog_FileOk(Object sender, CancelEventArgs e) {

			//mp3File = loadMP3Dialog.FileName;
			int i = 0;
			Song[] songs = new Song[loadMP3Dialog.FileNames.Length];

			foreach (String file in loadMP3Dialog.FileNames) {

				songs[i++] = new Song(file);
			}

			songList.Items.AddRange(songs);

			
        }
	}
}
