using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlimDX.DirectSound;

namespace DJMixer {
	public partial class ConfigForm : Form {

		public DeviceCollection deviceCollection;


		public ConfigForm() {
			InitializeComponent();
		}


		public void getSoundDevices() {

			deviceCollection = DirectSound.GetDevices();

			String[] deviceList = new String[deviceCollection.Count];
			//SoundDevice[] devices = new SoundDevice[deviceCollection.Count];

			int i = 0;
			foreach (DeviceInformation info in deviceCollection) {

				//devices[i] = new SoundDevice();
				//devices[i].Description = info.Description;
				//devices[i].DriverGuid = info.DriverGuid;
				//devices[i].ModuleName = info.ModuleName;

				deviceList[i] = info.Description;

				++i;


			}



			comboBox_SoundDeviceSelect.Items.AddRange(deviceList);
			comboBox_SoundDeviceSelect.SelectedItem = comboBox_SoundDeviceSelect.Items[0];
			//listBox_SoundDevices.Items.AddRange(devices);
		}


		private void setDirectSoundDevice() {

			//ds = new DirectSound(deviceCollection[comboBox_SoundDeviceSelect.SelectedIndex].DriverGuid);
			//ds.SetCooperativeLevel(this.Handle, CooperativeLevel.Priority);

		}

		private void comboBox_SoundDeviceSelect_SelectedIndexChanged(Object sender, EventArgs e) {

			setDirectSoundDevice();
		}

	}
}
