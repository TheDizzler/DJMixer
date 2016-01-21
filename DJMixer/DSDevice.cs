using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace DJMixer {

	abstract class OutputDevice {

		public new abstract String ToString();
	}


	class DSDevice {

		private DirectSoundDeviceInfo device;

		public DSDevice(DirectSoundDeviceInfo device) {
			this.device = device;
		}


		public override String ToString() {

			return device.Description;
		}

		public Guid getGUID() {

			return device.Guid;
		}
	}


	class WaveOutDevice {


		private WaveOutCapabilities waveOutCapabilities;


		public WaveOutDevice(WaveOutCapabilities waveOutCapabilities) {
			this.waveOutCapabilities = waveOutCapabilities;
		}

		public override String ToString() {
			
			return waveOutCapabilities.ProductName;
		}

	}
}
