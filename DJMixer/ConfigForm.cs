using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;


namespace DJMixer {

	public enum DEVICEID {
		DIRECTSOUND,
		WAVEOUT,
		NONESELECTED
	};

	public partial class ConfigForm : Form {



		Form1 deck;

		bool wasDirectSound = false;
		bool populatingList = false;

		public ConfigForm(Form1 dck) {
			InitializeComponent();

			deck = dck;
		}

		private void radioButton_DS_CheckedChanged(Object sender, EventArgs e) {

			if (radioButton_DS.Checked) {
				getDirectSoundDevices();
				deck.initSoundDevices();
			}
		}

		private void radioButton_WaveOut_CheckedChanged(Object sender, EventArgs e) {

			if (radioButton_WaveOut.Checked) {
				getWaveOutDevices();
				deck.initSoundDevices();
			}
		}

		public DEVICEID getDeviceOut() {

			if (radioButton_DS.Checked) {
				getDirectSoundDevices();
				return DEVICEID.DIRECTSOUND;
			}
			if (radioButton_WaveOut.Checked) {
				getWaveOutDevices();
				return DEVICEID.WAVEOUT;
			}

			return DEVICEID.NONESELECTED;
		}


		/// <summary>
		///  If less latency is required (it shouldn't?), can use ASIO drivers instead of WaveOut
		/// </summary>
		public void getWaveOutDevices() {

			int selectedOut;
			if (comboBox_SoundDeviceSelect.Items.Count <= 0)
				selectedOut = 0;
			else
				selectedOut = comboBox_SoundDeviceSelect.SelectedIndex;

			comboBox_SoundDeviceSelect.Items.Clear();

			for (int i = 0; i < WaveOut.DeviceCount; ++i) {
				//Console.WriteLine(WaveOut.GetCapabilities(i).ProductName);
				WaveOutDevice wave = new WaveOutDevice(WaveOut.GetCapabilities(i));
				comboBox_SoundDeviceSelect.Items.Add(wave);

			}

			if (wasDirectSound && selectedOut > 0)
				--selectedOut;
			populatingList = true;
			comboBox_SoundDeviceSelect.SelectedItem = comboBox_SoundDeviceSelect.Items[selectedOut];
			wasDirectSound = false;
		}


		public int getWaveOutDeviceNumber() {

			return comboBox_SoundDeviceSelect.SelectedIndex;
		}


		/// <summary>
		///  If less latency is required (it shouldn't?), can use ASIO drivers instead of WaveOut
		/// </summary>
		public void getDirectSoundDevices() {

			int selectedOut;
			if (comboBox_SoundDeviceSelect.Items.Count <= 0)
				selectedOut = 0;
			else
				selectedOut = comboBox_SoundDeviceSelect.SelectedIndex;
			comboBox_SoundDeviceSelect.Items.Clear();

			foreach (DirectSoundDeviceInfo device in DirectSoundOut.Devices) {

				DSDevice d = new DSDevice(device);
				comboBox_SoundDeviceSelect.Items.Add(d);

			}

			if (!wasDirectSound)
				++selectedOut;
			populatingList = true;
			comboBox_SoundDeviceSelect.SelectedItem = comboBox_SoundDeviceSelect.Items[selectedOut];

			wasDirectSound = true;
		}

		public Guid getDeviceGUID() {

			return ((DSDevice)comboBox_SoundDeviceSelect.SelectedItem).getGUID();
		}


		private void comboBox_SoundDeviceSelect_SelectedIndexChanged(Object sender, EventArgs e) {

			if (!populatingList) {
				Console.WriteLine("Initing new sound device");
				deck.initSoundDevices();
			}
			populatingList = false;

		}

		private void onFormClosing(Object sender, FormClosingEventArgs e) {

			e.Cancel = true;
			this.Hide();
		}


	}
}
