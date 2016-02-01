using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HundredMilesSoftware.UltraID3Lib;

namespace DJMixer {
	public class Song {

		public String filepath;
		/// <summary>
		/// Stripped file name
		/// </summary>
		private String filename;

		public UltraID3 metaData;
		//private String songname;
		//private String artist;
		//private String album;
		//private short? year;
		//private String genre;


		public Song(String file) {

			filepath = file;

			int startpos = filepath.LastIndexOf("\\");
			if (startpos == -1)
				startpos = filepath.LastIndexOf("/");
			if (startpos == -1)
				startpos = 0;

			filename = filepath.Substring(startpos + 1, filepath.Length - startpos - 5);

			metaData = new UltraID3();
			metaData.Read(filepath);
			//artist = metaData.Artist;
			//songname = metaData.Title;
			//album = metaData.Album;
			//genre = metaData.Genre;
			//year = metaData.Year;
		}


		//public String DisplayMember
		//{

		//	get { return metaData.GetTag(Id3TagFamily.FileStartTag).Title.Value; }
		//}

		public override String ToString() {

			return metaData.Artist + " - " + metaData.Title;
		}
	}
}
