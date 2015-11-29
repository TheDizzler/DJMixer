using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimDX.DirectSound;

namespace DJMixer {
	class SoundDevice : DeviceInformation {

		override public String ToString() {

			return "DriverGuid: " + DriverGuid + ". Model Name: " + ModuleName + ". " + Description;

		}
	}
}
