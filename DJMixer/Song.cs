using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HundredMilesSoftware.UltraID3Lib;
using TagLib;

namespace DJMixer {
	public class Song {

		public String filepath;
		/// <summary>
		/// Stripped file name
		/// </summary>
		private String filename;

		public TagLib.File tagFile;

		//public UltraID3 metaData;
		//public bool usingUltraID3 = false;
		public bool usingTagLib = false;

		//private String songname;
		//private String artist;
		//private String album;
		//private short? year;
		//private String genre;


		public Song() {
		}

		//public Song(String file) {

		//	filepath = file;

		//	int startpos = filepath.LastIndexOf("\\");
		//	if (startpos == -1)
		//		startpos = filepath.LastIndexOf("/");
		//	if (startpos == -1)
		//		startpos = 0;

		//	filename = filepath.Substring(startpos + 1, filepath.Length - startpos - 5);

		//	usingTagLib = false;
		//}

		public bool initialize(String file) {
			filepath = file;

			int startpos = filepath.LastIndexOf("\\");
			if (startpos == -1)
				startpos = filepath.LastIndexOf("/");
			if (startpos == -1)
				startpos = 0;

			filename = filepath.Substring(startpos + 1, filepath.Length - startpos - 5);

			//metaData = new UltraID3();
			//try {
			//	metaData.Read(filepath);
			//} catch (Exception ex) {
			//	Console.WriteLine("Source: " + ex.Source);
			//	Console.WriteLine("BaseException: " + ex.GetBaseException());
			//	Console.WriteLine(filepath + ": " + ex.Message);

			//	usingUltraID3 = false;
			//	return false;
			//}

			try {
				tagFile = File.Create(filepath);
			} catch (Exception ex) {
				Console.WriteLine(filepath + " invalid");
			}
			usingTagLib = true;

			return true;
		}


		public bool matches(String keyword) {

			//if (usingUltraID3) {
			//	try {
			//		return metaData.Album.ToLower().Contains(keyword) || metaData.Artist.ToLower().Contains(keyword)
			//			|| metaData.Comments.ToLower().Contains(keyword) || metaData.FileName.ToLower().Contains(keyword)
			//			|| metaData.Genre.ToLower().Contains(keyword);
			//	} catch (Exception ex) {

			//		Console.WriteLine(ex.Message);
			//	}
			//}

			return false;

		}


		public override String ToString() {

			//Console.WriteLine(filename);
			//Console.WriteLine(tagFile.Tag.FirstPerformer.Length);
			//Console.WriteLine(tagFile.Tag.Title.Length);


			if (!usingTagLib || tagFile.Tag.FirstPerformer == null
				|| (tagFile.Tag.FirstPerformer.Length + tagFile.Tag.Title.Length == 0)) {
				return filename;
			} else
				return tagFile.Tag.FirstPerformer + " - " + tagFile.Tag.Title;
		}

		//if (usingUltraID3) {
		//	//if (metaData.Artist.Length + metaData.Title.Length == 0)
		//	//	return filename;
		//	return metaData.Artist + " - " + metaData.Title;
		//}
	}
}

