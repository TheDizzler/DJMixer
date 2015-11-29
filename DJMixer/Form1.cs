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
using SlimDX.DirectSound;
using SlimDX.Multimedia;
//using SlimDX.XAudio2;

namespace DJMixer {
	public partial class Form1 : Form {

		/// <summary>
		///  Audio output stream.
		/// </summary>
		//XAudio2 device;


		public DeviceCollection deviceCollection;

		public DirectSound ds;


		public Form1() {
			InitializeComponent();

			getSoundDevices();

			//device = new XAudio2();

			setDirectSoundDevice();


		}

		private void setDirectSoundDevice() {

			ds = new DirectSound(deviceCollection[comboBox_SoundDeviceSelect.SelectedIndex].DriverGuid);
			ds.SetCooperativeLevel(this.Handle, CooperativeLevel.Priority);

		}



		private void buttonPlay_Click(Object sender, EventArgs e) {

			WaveFormatExtensible format = new WaveFormatExtensible();
			format.BitsPerSample = 16;
			format.BlockAlignment = 4;
			format.Channels = 2;
			format.FormatTag = WaveFormatTag.MpegLayer3;
			format.SamplesPerSecond = 44100;
			format.AverageBytesPerSecond = format.SamplesPerSecond * format.BlockAlignment;

			SoundBufferDescription desc = new SoundBufferDescription();
			desc.Format = format;
			desc.Flags = SlimDX.DirectSound.BufferFlags.GlobalFocus;
			desc.SizeInBytes = 8 * format.AverageBytesPerSecond;

			PrimarySoundBuffer pBuffer = new PrimarySoundBuffer(ds, desc);


			SoundBufferDescription desc2 = new SoundBufferDescription();
			desc2.Format = format;
			desc2.Flags = BufferFlags.GlobalFocus | BufferFlags.ControlPositionNotify | BufferFlags.GetCurrentPosition2;
			desc2.SizeInBytes = 8 * format.AverageBytesPerSecond;

			SecondarySoundBuffer sBuffer = new SecondarySoundBuffer(ds, desc2);


			NotificationPosition[] notifications = new NotificationPosition[2];
			notifications[0].Offset = desc2.SizeInBytes / 2 + 1;
			notifications[1].Offset = desc2.SizeInBytes - 1;


			notifications[0].Event = new AutoResetEvent(false);
			notifications[1].Event = new AutoResetEvent(false);
			sBuffer.SetNotificationPositions(notifications);

			byte[] bytes1 = new byte[desc2.SizeInBytes / 2];
			byte[] bytes2 = new byte[desc2.SizeInBytes];

			Stream stream = File.Open("D:/mp3z/JPop/Tsunku/Canary Club/05. [H!PBR] Canary Club - SWEET & TOUGHNESS.mp3", FileMode.Open);

			Thread fillBuffer = new Thread(() => {
				int readNumber = 1;
				int bytesRead;

				bytesRead = stream.Read(bytes2, 0, desc2.SizeInBytes);
				sBuffer.Write<byte>(bytes2, 0, LockFlags.None);
				sBuffer.Play(0, PlayFlags.Looping);
				while (true) {
					if (bytesRead == 0) { break; }
					notifications[0].Event.WaitOne();
					bytesRead = stream.Read(bytes1, 0, bytes1.Length);
					sBuffer.Write<byte>(bytes1, 0, LockFlags.None);

					if (bytesRead == 0) { break; }
					notifications[1].Event.WaitOne();
					bytesRead = stream.Read(bytes1, 0, bytes1.Length);
					sBuffer.Write<byte>(bytes1, desc2.SizeInBytes / 2, LockFlags.None);
				}
				stream.Close();
				stream.Dispose();
			});
			fillBuffer.Start();

			//MasteringVoice mv = new MasteringVoice(device);

			//System.IO.FileStream file = System.IO.File.OpenRead("D:/mp3z/JPop/Tsunku/Canary Club/05. [H!PBR] Canary Club - SWEET & TOUGHNESS.mp3");




			//WaveStream stream = new WaveStream(;

			//file.Close();

			//AudioBuffer buffer = new AudioBuffer();
			//buffer.AudioData = stream;
			//buffer.AudioBytes = (int) stream.Length;
			//buffer.Flags = SlimDX.XAudio2.BufferFlags.EndOfStream; // plays until end of stream

			//SourceVoice sourceVoice = new SourceVoice(device, stream.Format);
			//sourceVoice.SubmitSourceBuffer(buffer);
			//sourceVoice.Start();


		}

		private void getSoundDevices() {

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

		private void comboBox_SoundDeviceSelect_SelectedIndexChanged(Object sender, EventArgs e) {

			setDirectSoundDevice();
		}

		private void button_Stop_Click(Object sender, EventArgs e) {

		}
	}
}
