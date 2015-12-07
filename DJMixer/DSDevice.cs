using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace DJMixer {
	class DSDevice {


		private DirectSoundDeviceInfo device;

		public DSDevice(DirectSoundDeviceInfo device) {
			this.device = device;
		}


		public override String ToString() {

			return device.Description;
		}

		internal Guid getGUID() {
			
			return device.Guid;
		}
	}
}
