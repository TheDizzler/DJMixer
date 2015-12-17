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
	public partial class Player : BasicPlayer {


		//private DirectSoundOut directSoundOut;
		//private Mp3FileReader fileReader;
		//private Thread threadGUIUpdater;

		///// <summary>
		///// Internal volume, i.e. actual volume when crossfader is 100% towards this player
		///// This volume can only be changed from the player itself.
		///// </summary>
		//private float absoluteVolume = .75f;
		///// <summary>
		///// Percent of volume to play.
		///// </summary>
		//private float mixedVolume = .50f;
		//private Action<float> volumeDelegate;

		//private Song currentSong;
		///// <summary>
		///// Stripped file name
		///// </summary>
		////private String songname;

		//private MeteringSampleProvider postVolumeMeter;

		//private Boolean changedDevice = false;
		private Boolean manuallyStopped = false;


		public Player() {
			InitializeComponent();

			currentSong = new Song(@"D:\mp3z\JPop\Tsunku\Sub-Groups\Guardians 4\Shugo Chara Party - Party Time.mp3");
		}

		//public void setGUID(Guid guid) {

		//	if (directSoundOut != null && fileReader != null) {

		//		if (directSoundOut.PlaybackState == PlaybackState.Playing) {

		//			directSoundOut.Stop();
		//			directSoundOut = new DirectSoundOut(guid);
		//			directSoundOut.Init(postVolumeMeter);
		//			directSoundOut.Play();
		//			changedDevice = false;

		//		} else {

		//			directSoundOut = new DirectSoundOut(guid);
		//			directSoundOut.Init(postVolumeMeter);
		//			if (directSoundOut.PlaybackState == PlaybackState.Paused)
		//				changedDevice = true;

		//		}
		//	} else {
		//		directSoundOut = new DirectSoundOut(guid);
		//		changedDevice = false;
		//	}
		//	directSoundOut.PlaybackStopped += loadNextSong;
		//}



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

		protected override void loadSong() {
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


		protected override void button_Stop_Click(Object sender, EventArgs e) {

			manuallyStopped = true;
			if (stop())
				label_SongTitle.Text = currentSong.ToString() + " (Stopped)";
		}


		protected override void loadNextSong(object sender, StoppedEventArgs e) {

			if (manuallyStopped) {
				manuallyStopped = false;// do nothing for now
				return;
			}


			currentSong = getNextSong();
			songList.SetItemChecked(songList.CheckedIndices[0], false);
			loadSong();
		}


		Song getNextSong() {

			Song next = (Song)songList.CheckedItems[0];


			return next; 
		}


		void onPreVolumeMeter(object sender, StreamVolumeEventArgs e) {
			
			waveformPainterL.AddMax(e.MaxSampleValues[0]);
			waveformPainterR.AddMax(e.MaxSampleValues[1]);
		}

		void onPostVolumeMeter(object sender, StreamVolumeEventArgs e) {
			
			volumeMeterL.Amplitude = e.MaxSampleValues[0];
			volumeMeterR.Amplitude = e.MaxSampleValues[1];

		}


		private void progressBar1_Click(Object sender, EventArgs e) {

			if (fileReader != null) {
				float xPos = progressBar.PointToClient(Cursor.Position).X;
				int width = progressBar.Bounds.Width;
				float xPercent = xPos / progressBar.Bounds.Width;

				fileReader.Position = (long)(xPercent * fileReader.Length);

			}
		}


		///// <summary>
		///// GUI update thread proc
		///// </summary>
		//protected override void updateDisplay() {

		//	while (fileReader.CurrentTime <= fileReader.TotalTime &&
		//		 directSoundOut.PlaybackState != PlaybackState.Stopped) {

		//		setGUIText(String.Format("{0:00}:{1:00}",
		//			(int)fileReader.CurrentTime.TotalMinutes,
		//			fileReader.CurrentTime.Seconds));

		//	}

		//	setGUIText(String.Format("{0:00}:{1:00}", 0, 0));
		//	Console.WriteLine(this.Name + "Thread terminated");
		//}




		/// <summary>
		/// This delegate enables asynchronous calls for setting
		/// the text property on a TextBox control.
		/// </summary>
		//delegate void SetTextCallback(String text);


		protected override void setGUIText(String text) {

			if (timer.InvokeRequired) {
				SetTextCallback d = new SetTextCallback(setGUIText);
				Invoke(d, new object[] { text });
			} else {
				timer.Text = text;
				progressBar.Value = (int)(fileReader.CurrentTime.TotalSeconds / fileReader.TotalTime.TotalSeconds * 100);
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
