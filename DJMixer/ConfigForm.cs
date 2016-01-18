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
	public partial class ConfigForm : Form {


		Form1 deck;


		public ConfigForm(Form1 dck) {
			InitializeComponent();

			deck = dck;
		}


		/// <summary>
		///  If less latency is required (it shouldn't?), can use ASIO drivers instead of WaveOut
		/// </summary>
		//public void getSoundDevices() {

		//	for (int i = 0; i < WaveOut.DeviceCount; ++i) {
		//		Console.WriteLine(WaveOut.GetCapabilities(i).ProductName);
		//		comboBox_SoundDeviceSelect.Items.Add(WaveOut.GetCapabilities(i).ProductName);

		//	}

		//	comboBox_SoundDeviceSelect.SelectedItem = comboBox_SoundDeviceSelect.Items[0];
		//}


		//public int getDeviceNumber() {

		//	return comboBox_SoundDeviceSelect.SelectedIndex;
		//}

		/// <summary>
		///  If less latency is required (it shouldn't?), can use ASIO drivers instead of WaveOut
		/// </summary>
		public void getDirectSoundDevices() {

			foreach (DirectSoundDeviceInfo device in DirectSoundOut.Devices) {

				DSDevice d = new DSDevice(device);
				comboBox_SoundDeviceSelect.Items.Add(d);

			}


			comboBox_SoundDeviceSelect.SelectedItem = comboBox_SoundDeviceSelect.Items[0];
		}

		public Guid getDeviceGUID() {

			return ((DSDevice)comboBox_SoundDeviceSelect.SelectedItem).getGUID();
		}


		private void comboBox_SoundDeviceSelect_SelectedIndexChanged(Object sender, EventArgs e) {

			deck.initSoundDevices();

		}

		private void onFormClosing(Object sender, FormClosingEventArgs e) {

			e.Cancel = true;
			this.Hide();
		}

	}
}
