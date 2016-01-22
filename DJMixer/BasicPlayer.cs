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
using NAudio.Gui;

namespace DJMixer {
	/// <summary>
	/// A basic player UserControl. Has no visual elements and should only be used
	/// as a base class for other players.
	/// </summary>
	public partial class BasicPlayer : UserControl, IPlayer {


		protected DEVICEID deviceOutID;

		protected IWavePlayer deviceOut;

		//private WaveOut waveOut;
		//private DirectSoundOut directSoundOut;

		protected Mp3FileReader fileReader;
		protected Thread threadGUIUpdater;

		protected WaveChannel32 waveChannel;
		protected MeteringSampleProvider postVolumeMeter;
		protected Action<float> volumeDelegate;

		/// <summary>
		/// Internal volume, i.e. actual volume when crossfader is 100% towards this player
		/// This volume can only be changed from the player itself.
		/// </summary>
		protected float absoluteVolume = .75f;
		/// <summary>
		/// Percent of volume to play.
		/// </summary>
		protected float mixedVolume = .50f;

		protected Song currentSong;
		//protected int currentSongIndex = -1;
		protected int nextSongIndex = -1;

		/// <summary>
		/// A flag to denote when the audio output device has changed.
		/// </summary>
		protected Boolean changedDevice = false;

		protected Boolean runUpdateThread = true;

		protected Boolean manuallyStopped = false;



		public BasicPlayer() {
			InitializeComponent();


		}

		/// <summary>
		/// Called from main form when selecting Direct Sound device.
		/// </summary>
		/// <param name="guid"></param>
		public void setGUID(Guid guid) {

			deviceOutID = DEVICEID.DIRECTSOUND;

			DirectSoundOut directSoundOut;

			if (deviceOut != null) {

				deviceOut.PlaybackStopped -= loadNextSong;
				if (deviceOut.PlaybackState == PlaybackState.Playing) {
					
					deviceOut.Pause();
					directSoundOut = new DirectSoundOut(guid);
					if (postVolumeMeter != null)
						directSoundOut.Init(postVolumeMeter);
					directSoundOut.Play();
					changedDevice = false;
					
				} else {

					directSoundOut = new DirectSoundOut(guid);
					if (postVolumeMeter != null)
						directSoundOut.Init(postVolumeMeter);
					if (deviceOut.PlaybackState == PlaybackState.Paused)
						changedDevice = true;
					
				}
				deviceOut.Dispose();
			} else {
				directSoundOut = new DirectSoundOut(guid);
				changedDevice = false;

			}

			directSoundOut.PlaybackStopped += loadNextSong;

			deviceOut = directSoundOut;
		}

		/// <summary>
		/// Called from main form when selecting Wave Out device.
		/// </summary>
		/// <param name="waveOutDeviceNumber"></param>
		public void setWaveOut(int waveOutDeviceNumber) {

			deviceOutID = DEVICEID.WAVEOUT;
			WaveOut waveOut;


			if (deviceOut != null) {

				deviceOut.PlaybackStopped -= loadNextSong;
				if (deviceOut.PlaybackState == PlaybackState.Playing) {
					Console.WriteLine("wave out playing");
					deviceOut.Pause();
					waveOut = new WaveOut();
					waveOut.DeviceNumber = waveOutDeviceNumber;
					if (postVolumeMeter != null)
						waveOut.Init(postVolumeMeter);
					waveOut.Play();
					changedDevice = false;
					
				} else {
					Console.WriteLine("wave out NOT playing");
					waveOut = new WaveOut();
					waveOut.DeviceNumber = waveOutDeviceNumber;
					if (postVolumeMeter != null)
						waveOut.Init(postVolumeMeter);
					if (deviceOut.PlaybackState == PlaybackState.Paused)
						changedDevice = true;
					
				}
				
				deviceOut.Dispose();
			} else {
				//Console.WriteLine("device null");
				waveOut = new WaveOut();
				waveOut.DeviceNumber = waveOutDeviceNumber;
				changedDevice = false;
			}

			waveOut.PlaybackStopped += loadNextSong;

			deviceOut = waveOut;
		}


		protected virtual void playSong() {

		}


		public bool isPlaying() {

			return deviceOut.PlaybackState == PlaybackState.Playing;
		}


		protected virtual void loadNextSong(object sender, StoppedEventArgs e) {
			playSong();
		}


		protected void trackBar_Volume_Scroll(Object sender, EventArgs e) {

			absoluteVolume = (float)trackBar_Volume.Value / 100;

			if (fileReader != null)
				volumeDelegate(absoluteVolume * mixedVolume);

			//Console.WriteLine(absoluteVolume * mixedVolume);
		}


		/// <summary>
		/// GUI update thread proc
		/// </summary>
		protected void updateDisplay() {

			while (runUpdateThread) {
				
				setGUIText(String.Format("{0:00}:{1:00}",
					(int)fileReader.CurrentTime.TotalMinutes,
					fileReader.CurrentTime.Seconds));

			}

			setGUIText(String.Format("{0:00}:{1:00}", 0, 0));
			Console.WriteLine(this.Name + "Thread terminated");
		}

		/// <summary>
		/// This delegate enables asynchronous calls for setting
		/// the text property on a TextBox control.
		/// </summary>
		protected delegate void SetTextCallback(String text);


		protected virtual void setGUIText(String text) {

			if (timer.InvokeRequired) {
				SetTextCallback d = new SetTextCallback(setGUIText);
				timer.Invoke(d, new object[] { text });
			} else {
				timer.Text = text;
				//progressBar.Value = (int)(fileReader.CurrentTime.TotalSeconds / fileReader.TotalTime.TotalSeconds * 100);
			}

		}



		protected virtual void button_Stop_Click(Object sender, EventArgs e) {

			stop();

		}


		public void setMixedVolume(float mixVol) {

			mixedVolume = mixVol;

			if (fileReader != null)
				volumeDelegate(absoluteVolume * mixedVolume);
		}

		public void prepareForClose() {


			if (threadGUIUpdater != null && threadGUIUpdater.IsAlive)
				threadGUIUpdater.Suspend(); // necessary to interrupt this thread as MessageBox blocks UI threads

		}


		public void cancelClose() {

			if (threadGUIUpdater != null && threadGUIUpdater.IsAlive)
				threadGUIUpdater.Resume();
		}


		public void shutdown() {

			if (deviceOut != null) {
				deviceOut.PlaybackStopped -= loadNextSong;
				stop();
				deviceOut.Dispose();
			}

			cancelClose();

			runUpdateThread = false;

			if (threadGUIUpdater != null && threadGUIUpdater.IsAlive) {
				Console.WriteLine(threadGUIUpdater.Name + " starting close");

				//threadGUIUpdater.Join(1000);

				//while (threadGUIUpdater.IsAlive) {
				//	Thread.Sleep(500);
				//	Console.WriteLine(threadGUIUpdater.Name + " not dieing");
				//	threadGUIUpdater.Abort();
				//}
			}
		}


		public bool stop() {

			if (deviceOut != null && deviceOut.PlaybackState != PlaybackState.Stopped) {

				deviceOut.Stop();

				return true;
			}
			return false;
		}


		private void onPanChanged(Object sender, EventArgs e) {

			if ((Control.ModifierKeys & Keys.Alt) != 0)
				panSlider.Pan = 0;

			if (waveChannel != null)
				waveChannel.Pan = panSlider.Pan;



		}
	}
}
