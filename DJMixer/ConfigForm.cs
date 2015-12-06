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
		public void getSoundDevices() {

			for (int i = 0; i < WaveOut.DeviceCount; ++i) {
				Console.WriteLine(WaveOut.GetCapabilities(i).ProductName);
				comboBox_SoundDeviceSelect.Items.Add(WaveOut.GetCapabilities(i).ProductName);

			}

			comboBox_SoundDeviceSelect.SelectedItem = comboBox_SoundDeviceSelect.Items[0];
		}


		public int getDeviceNumber() {

			return comboBox_SoundDeviceSelect.SelectedIndex;
		}


		public void getDirectSoundDevices() {

			foreach (DirectSoundDeviceInfo device in DirectSoundOut.Devices) {

				comboBox_SoundDeviceSelect.Items.Add(device.Description);
            }
		}

		public Guid getDeviceGUID() {

			foreach (DirectSoundDeviceInfo device in DirectSoundOut.Devices) {
				return device.Guid;
			}

			return Guid.Empty;
		}



		private void comboBox_SoundDeviceSelect_SelectedIndexChanged(Object sender, EventArgs e) {

			//setDirectSoundDevice();
		}

		private void listBox_SoundDevices_SelectedIndexChanged(Object sender, EventArgs e) {

		}
	}
}
