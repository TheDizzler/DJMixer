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

		protected DirectSoundOut directSoundOut;
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
		protected int currentSongIndex = -1;

		/// <summary>
		/// A flag to denote when the audio output device has changed.
		/// </summary>
		protected Boolean changedDevice = false;


		public BasicPlayer() {
			InitializeComponent();


		}

		/// <summary>
		/// Called from main form after config form construction
		/// </summary>
		/// <param name="guid"></param>
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
			//directSoundOut.PlaybackStopped += loadNextSong;


		}



		protected virtual void playSong() {

		}


		protected virtual void loadNextSong(object sender, StoppedEventArgs e) {
			playSong();
		}


		protected void trackBar_Volume_Scroll(Object sender, EventArgs e) {

			absoluteVolume = (float)trackBar_Volume.Value / 100;

			if (fileReader != null)
				volumeDelegate(absoluteVolume * mixedVolume);
		}


		/// <summary>
		/// GUI update thread proc
		/// </summary>
		protected void updateDisplay() {

			while (fileReader.CurrentTime <= fileReader.TotalTime &&
				 directSoundOut.PlaybackState != PlaybackState.Stopped) {

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
				Invoke(d, new object[] { text });
			} else {
				timer.Text = text;
				//progressBar1.Value = (int)(fileReader.CurrentTime.TotalSeconds / fileReader.TotalTime.TotalSeconds * 100);
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


		public bool stop() {

			if (directSoundOut != null && directSoundOut.PlaybackState != PlaybackState.Stopped) {

				directSoundOut.Stop();
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
