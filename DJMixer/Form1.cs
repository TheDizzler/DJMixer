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
using NAudio.Gui;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;


namespace DJMixer {



	public partial class Form1 : Form {

		ConfigForm config;



		WaveOut waveOutRightPlayer;
		Mp3FileReader rightAudioFileReader;


		

		public Form1() {
			InitializeComponent();

			config = new ConfigForm(this);
			//config.getSoundDevices();
			config.getDirectSoundDevices();

			initSoundDevices();




		}


		private void initSoundDevices() {


			
			leftPlayer.setGUID(config.getDeviceGUID());




			waveOutRightPlayer = new WaveOut();
			waveOutRightPlayer.DeviceNumber = config.getDeviceNumber();
		}



		private void button_StopRightPlayer_Click(Object sender, EventArgs e) {


			if (waveOutRightPlayer != null) {
				waveOutRightPlayer.Stop();
			}
		}









		private void button_PlayRight_Click(Object sender, EventArgs e) {

			rightAudioFileReader = new Mp3FileReader(@"D:\mp3z\JPop\Tsunku\Sub-Groups\Guardians 4\Shugo Chara Party - Party Time.mp3");

			waveOutRightPlayer.Init(rightAudioFileReader);
			waveOutRightPlayer.Play();

		}





		private void onFormClosing(Object sender, FormClosingEventArgs e) {
			leftPlayer.prepareForClose();

			switch (MessageBox.Show("Are you sure?", "Exit?", MessageBoxButtons.YesNo)) {

				case DialogResult.No:
					e.Cancel = true;
					leftPlayer.cancelClose();
					break;
				case DialogResult.Yes:
					leftPlayer.stop();
					button_StopRightPlayer_Click(null, e);
					break;
			}
		}

		private void trackBar_CrossFader_Scroll(Object sender, EventArgs e) {

		}

		private void configToolStripMenuItem1_Click(Object sender, EventArgs e) {

			//this.Hide();
			config.Show();
		}
	}
}
