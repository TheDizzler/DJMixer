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


		DirectSoundOut directSoundOut;
		Mp3FileReader fileReader;
		Thread threadGUIUpdater;

		private Action<float> setVolumeDelegate;


		public Player() {
			InitializeComponent();

			
		}

		public void setGUID(Guid guid) {

			directSoundOut = new DirectSoundOut(guid); // config.getDeviceGUID()
		}



		private void button_Play_Click(Object sender, EventArgs e) {

			if (directSoundOut.PlaybackState == PlaybackState.Playing) {

				directSoundOut.Pause();


			} else if (directSoundOut.PlaybackState == PlaybackState.Paused) {
				directSoundOut.Play();

			} else {
				fileReader = new Mp3FileReader(@"D:/mp3z/JPop/Tsunku/Canary Club/05. [H!PBR] Canary Club - SWEET & TOUGHNESS.mp3");

				SampleChannel sampleChannel = new SampleChannel(fileReader);
				sampleChannel.PreVolumeMeter += onPreVolumeMeter;
				this.setVolumeDelegate = (vol) => sampleChannel.Volume = vol;
				MeteringSampleProvider postVolumeMeter = new MeteringSampleProvider(sampleChannel);
				postVolumeMeter.StreamVolume += onPostVolumeMeter;


				directSoundOut.Init(postVolumeMeter);
				directSoundOut.Play();

				threadGUIUpdater = new Thread(new ThreadStart(updateDisplay));
				threadGUIUpdater.IsBackground = true;
				threadGUIUpdater.Name = "Player GUI Update Thread";
				threadGUIUpdater.Start();


				setVolumeDelegate((float)trackBar_Volume.Value / 100);
			}

			label2.Text = directSoundOut.PlaybackState.ToString();

		}


		private void button_Stop_Click(Object sender, EventArgs e) {

			stop();

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

			if (fileReader != null) {
				//float xPos = trackBar_Volume.PointToClient(Cursor.Position).X;
				//int width = trackBar_Volume.Bounds.Width;
				//float xPercent = xPos / progressBar1.Bounds.Width;

				//waveOutLeftPlayer.Volume = (float)trackBar_Volume.Value / 100;
				setVolumeDelegate((float)trackBar_Volume.Value / 100);

			}
		}



		/// Thread proc.
		private void updateDisplay() {

			while (fileReader.CurrentTime <= fileReader.TotalTime &&
				 directSoundOut.PlaybackState != PlaybackState.Stopped) {

				//int minsInt = leftAudioFileReader.CurrentTime.Minutes;

				//String mins;
				//if (minsInt < 10)
				//	mins = "0" + minsInt;
				//else
				//	mins = minsInt.ToString();

				//int secsInt = leftAudioFileReader.CurrentTime.Seconds;
				//String secs;
				//if (secsInt < 10)
				//	secs = "0" + secsInt;
				//else
				//	secs = secsInt.ToString();


				//setText(mins + ":" + secs +
				//	" %" + (int)(leftAudioFileReader.CurrentTime.TotalSeconds
				//	/ leftAudioFileReader.TotalTime.TotalSeconds * 100));

				setText(String.Format("{0:00}:{1:00}",
					(int)fileReader.CurrentTime.TotalMinutes,
					fileReader.CurrentTime.Seconds));


			}
			Console.WriteLine("Thread terminated");
		}

		// This delegate enables asynchronous calls for setting
		// the text property on a TextBox control.
		delegate void SetTextCallback(String text);

		private void setText(String text) {

			if (timer.InvokeRequired) {
				SetTextCallback d = new SetTextCallback(setText);
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

			if (directSoundOut != null) {
				directSoundOut.Stop();
				label2.Text = directSoundOut.PlaybackState.ToString();
			}
		}
	}
}
