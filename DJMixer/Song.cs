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
				Console.WriteLine(ex.Message);
				usingTagLib = false;
				return false;
			}
			usingTagLib = true;

			return true;
		}


		public bool matchesAll(String keyword) {

			if (usingTagLib) {
				try {
					return matchesArtist(keyword) || matchesAlbum(keyword)
						|| matchesInComment(keyword) || matchesFilename(keyword)
						|| matchesGenre(keyword);
				} catch (Exception ex) {

					Console.WriteLine(filename + " has a problem");
				}
			}

			return false;

		}

		private Boolean matchesFilename(String keyword) {

			if (String.IsNullOrEmpty(filename))
				return false;
			return filename.ToLower().Contains(keyword);
		}

		private Boolean matchesInComment(String keyword) {

			if (String.IsNullOrEmpty(tagFile.Tag.Comment))
				return false;
			return tagFile.Tag.Comment.ToLower().Contains(keyword);
		}

		private Boolean matchesAlbum(String keyword) {

			if (String.IsNullOrEmpty(tagFile.Tag.Album))
				return false;
			return tagFile.Tag.Album.ToLower().Contains(keyword);
		}

		private Boolean matchesArtist(String keyword) {
			
			foreach (String artist in tagFile.Tag.Performers)
				if (artist.ToLower().Contains(keyword))
					return true;

			return false;
		}


		private Boolean matchesGenre(String keyword) {

			foreach (String genre in tagFile.Tag.Genres) {
				if (genre.ToLower().Contains(keyword))
					return true;
			}
			
			return false;
		}

		public override String ToString() {

			//Console.WriteLine(filename);
			//Console.WriteLine(tagFile.Tag.FirstPerformer.Length);
			//Console.WriteLine(tagFile.Tag.Title.Length);


			if (!usingTagLib || String.IsNullOrWhiteSpace(tagFile.Tag.FirstPerformer)
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

