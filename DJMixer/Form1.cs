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

		float masterMixFader = 50;


		public Form1() {
			InitializeComponent();

			config = new ConfigForm(this);

			initSoundDevices();

			leftPlayer.setSampler(leftSamplePlayer);
			leftSamplePlayer.setPlayer(leftPlayer);

			rightPlayer.setSampler(rightSamplePlayer);
			rightSamplePlayer.setPlayer(rightPlayer);
		}


		public void initSoundDevices() {


			switch (config.getDeviceOut()) {
				case DEVICEID.DIRECTSOUND:
					Console.WriteLine("Initing direct sound");
					leftPlayer.setGUID(config.getDeviceGUID());
					rightPlayer.setGUID(config.getDeviceGUID());
					leftSamplePlayer.setGUID(config.getDeviceGUID());
					rightSamplePlayer.setGUID(config.getDeviceGUID());
					break;
				case DEVICEID.WAVEOUT:
					Console.WriteLine("Initing WAVE out");
					leftPlayer.setWaveOut(config.getWaveOutDeviceNumber());
					rightPlayer.setWaveOut(config.getWaveOutDeviceNumber());
					leftSamplePlayer.setWaveOut(config.getWaveOutDeviceNumber());
					rightSamplePlayer.setWaveOut(config.getWaveOutDeviceNumber());
					break;
				case DEVICEID.NONESELECTED:
					config.Show();
					MessageBox.Show("No Output device found");
					break;
			}
		}


		private void onFormClosing(Object sender, FormClosingEventArgs e) {

			leftPlayer.prepareForClose();
			rightPlayer.prepareForClose();
			leftSamplePlayer.prepareForClose();
			rightSamplePlayer.prepareForClose();

			switch (MessageBox.Show("Are you sure?", "Exit?", MessageBoxButtons.YesNo)) {

				case DialogResult.No:
					e.Cancel = true;
					leftPlayer.cancelClose();
					rightPlayer.cancelClose();
					leftSamplePlayer.cancelClose();
					rightSamplePlayer.cancelClose();
					break;
				case DialogResult.Yes:
					leftPlayer.shutdown();
					rightPlayer.shutdown();
					leftSamplePlayer.shutdown();
					rightSamplePlayer.shutdown();
					break;
			}
		}


		private void trackBar_CrossFader_Scroll(Object sender, EventArgs e) {

			if ((Control.ModifierKeys & Keys.Alt) != 0)
				trackBar_CrossFader.Value = 50;

			masterMixFader = (float)trackBar_CrossFader.Value / 100;
			leftPlayer.setMixedVolume(1 - masterMixFader);
			rightPlayer.setMixedVolume(masterMixFader);

		}

		private void configToolStripMenuItem1_Click(Object sender, EventArgs e) {

			config.Show();
		}

		private void searchToolStripMenuItem_Click(Object sender, EventArgs e) {

			SongSearchForm searchForm = new SongSearchForm();
			searchForm.Show();
		}
	}
}
