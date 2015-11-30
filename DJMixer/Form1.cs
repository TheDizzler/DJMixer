using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using SlimDX.DirectSound;
using SlimDX.Multimedia;
//using SlimDX.XAudio2;

namespace DJMixer {
	public partial class Form1 : Form {

		ConfigForm config;

		//BackgroundWorker rightPlayerWorker;
		//BackgroundWorker leftPlayerWorker;

		IWavePlayer waveOutLeftPlayer;
		IWavePlayer waveOutRightPlayer;
		Mp3FileReader leftAudioFileReader;
		Mp3FileReader rightAudioFileReader;

		public Thread threadLeftPlayer;
		//bool leftPlayerPlaying = false;

		public Form1() {
			InitializeComponent();

			config = new ConfigForm();
			config.getSoundDevices();

			initSoundDevices();


			

		}

		private void initSoundDevices() {

			waveOutLeftPlayer = new WaveOut();
			waveOutRightPlayer = new WaveOut();

		}


		private void button_StopLeftPlayer_Click(Object sender, EventArgs e) {

			if (waveOutLeftPlayer != null) {
				waveOutLeftPlayer.Stop();
				label2.Text = waveOutLeftPlayer.PlaybackState.ToString();
			}

		}

		private void button_StopRightPlayer_Click(Object sender, EventArgs e) {


			if (waveOutRightPlayer != null) {
				waveOutRightPlayer.Stop();
			}
		}


		private void button_PlayLeft_Click(Object sender, EventArgs e) {

			if (waveOutLeftPlayer.PlaybackState == PlaybackState.Playing) {

				waveOutLeftPlayer.Pause();


			} else if (waveOutLeftPlayer.PlaybackState == PlaybackState.Paused) {
				waveOutLeftPlayer.Play();

			} else {
				leftAudioFileReader = new Mp3FileReader(@"D:/mp3z/JPop/Tsunku/Canary Club/05. [H!PBR] Canary Club - SWEET & TOUGHNESS.mp3");
				waveOutLeftPlayer.Init(leftAudioFileReader);
				waveOutLeftPlayer.Play();

				threadLeftPlayer = new Thread(new ThreadStart(updateDisplays));
				threadLeftPlayer.IsBackground = true;
				threadLeftPlayer.Start();

				

			}
			label2.Text = waveOutLeftPlayer.PlaybackState.ToString();
		}


		private void button_PlayRight_Click(Object sender, EventArgs e) {

			rightAudioFileReader = new Mp3FileReader(@"D:\mp3z\JPop\Tsunku\Sub-Groups\Guardians 4\Shugo Chara Party - Party Time.mp3");

			waveOutRightPlayer.Init(rightAudioFileReader);
			waveOutRightPlayer.Play();

		}





		private void progressBar_click(Object sender, MouseEventArgs e) {

			//waveOutLeftPlayer.PlaybackState.
		}



		private void updateDisplays() {

			while (leftAudioFileReader.CurrentTime <= leftAudioFileReader.TotalTime &&
				 waveOutLeftPlayer.PlaybackState != PlaybackState.Stopped) {
				setText(leftAudioFileReader.CurrentTime.Minutes + ":" +
					leftAudioFileReader.CurrentTime.Seconds +
					" %" + ((int)leftAudioFileReader.CurrentTime.TotalSeconds / leftAudioFileReader.TotalTime.TotalSeconds));

			}
		}

		private void playerWorker_ProgressChanged(Object sender, ProgressChangedEventArgs e) {

			progressBar1.Value = e.ProgressPercentage;
			label1.Text = e.ProgressPercentage.ToString();
		}

		// This delegate enables asynchronous calls for setting
		// the text property on a TextBox control.
		delegate void SetTextCallback(String text);

		private void setText(String text) {

			if (label1.InvokeRequired) {
				SetTextCallback d = new SetTextCallback(setText);
				Invoke(d, new object[] { text });
			} else {
				label1.Text = text;
				progressBar1.Value = (int)(leftAudioFileReader.CurrentTime.TotalSeconds / leftAudioFileReader.TotalTime.TotalSeconds * 100);
			}

		}
	}
}
