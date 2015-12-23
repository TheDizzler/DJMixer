using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJMixer {
	public class Song {

		public String filepath;
		/// <summary>
		/// Stripped file name
		/// </summary>
		private String songname;


		public Song(String file) {

			filepath = file;

			int startpos = filepath.LastIndexOf("\\");
			if (startpos == -1)
				startpos = filepath.LastIndexOf("/");
			if (startpos == -1)
				startpos = 0;

			songname = filepath.Substring(startpos + 1, filepath.Length - startpos - 5);
		}


		public String DisplayMember {

			get { return songname; }
		}

		public override String ToString() {

			return songname;
		}
	}
}
