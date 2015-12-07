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
			config.getDirectSoundDevices();

			initSoundDevices();

		}


		public void initSoundDevices() {


			leftPlayer.setGUID(config.getDeviceGUID());
			rightPlayer.setGUID(config.getDeviceGUID());
		}



		private void onFormClosing(Object sender, FormClosingEventArgs e) {
			leftPlayer.prepareForClose();

			switch (MessageBox.Show("Are you sure?", "Exit?", MessageBoxButtons.YesNo)) {

				case DialogResult.No:
					e.Cancel = true;
					leftPlayer.cancelClose();
					rightPlayer.cancelClose();
					break;
				case DialogResult.Yes:
					leftPlayer.stop();
					rightPlayer.stop();
					break;
			}
		}


		private void trackBar_CrossFader_Scroll(Object sender, EventArgs e) {

			masterMixFader = (float)trackBar_CrossFader.Value / 100;
			leftPlayer.setMixedVolume(1 - masterMixFader);
			rightPlayer.setMixedVolume(masterMixFader);

		}

		private void configToolStripMenuItem1_Click(Object sender, EventArgs e) {

			config.Show();
		}
	}
}
