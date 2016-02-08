using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HundredMilesSoftware.UltraID3Lib;
using Id3;
using Id3.Frames;
using TagLib;

namespace DJMixer {
	public class Song {

		public String filepath;
		/// <summary>
		/// Stripped file name
		/// </summary>
		private String filename;

		public TagLib.File tagFile;
		public Id3Tag id3Tag;
		//public UltraID3 metaData;

		public bool usingId3Tag = false;
		public bool usingTagLib = false;
		public bool fileCorrupted = false;

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

				//TagLib.File.LocalFileAbstraction abstraction = new TagLib.File.LocalFileAbstraction(filepath);
				//TagLib.ReadStyle propertiesStyle = TagLib.ReadStyle.Average;
				//tagFile = new TagLib.Mpeg.AudioFile(abstraction, propertiesStyle);

				usingTagLib = true;
				return true;

			} catch (Exception ex) {
				Console.WriteLine(filepath + " invalid. Trying ID3.");
				//Console.WriteLine(ex.Message);
				usingTagLib = false;
			}


			//try {

			using (Mp3File mp3 = new Mp3File(filepath, Mp3Permissions.ReadWrite)) {

				id3Tag = mp3.GetTag(Id3TagFamily.FileStartTag);
				try {

					if (!String.IsNullOrWhiteSpace(id3Tag.Artists.Value)
						&& !String.IsNullOrWhiteSpace(id3Tag.Title.Value)) {

						usingId3Tag = true;
						return true;
					}

				} catch (Exception ex) {
					Console.WriteLine("Could not load ID3v2. Attempting v1");

				}

				try {

					id3Tag = mp3.GetTag(Id3TagFamily.FileEndTag);
					Console.WriteLine("trying v1");

					if (!String.IsNullOrWhiteSpace(id3Tag.Artists.Value)
						&& !String.IsNullOrWhiteSpace(id3Tag.Title.Value)) {

						usingId3Tag = true;
						return true;
					}

				} catch (Exception ex) {
					Console.WriteLine("Could not load v1!!!");
					fileCorrupted = true;
				}
			}



			//} catch (Exception ex) {
			//	Console.WriteLine(filepath + " invalid. Onoes :(");
			//	Console.WriteLine(ex.Message);
			//	usingId3Tag = false;
			//}

			//if (id3Tag != null) {
			//	usingId3Tag = true;
			//	return true;
			//}


			return false;
		}


		public bool matchesAll(String keyword) {


			try {
				return matchesArtist(keyword) || matchesAlbum(keyword)
					|| matchesInComment(keyword) || matchesFilename(keyword)
					|| matchesGenre(keyword);
			} catch (Exception ex) {

				Console.WriteLine(filename + ": " + ex.Message);
			}

			return false;

		}

		private Boolean matchesFilename(String keyword) {

			if (String.IsNullOrEmpty(filename))
				return false;

			return filename.ToLower().Contains(keyword);
		}

		private Boolean matchesInComment(String keyword) {

			if (usingId3Tag)
				foreach (CommentFrame comment in id3Tag.Comments)
					if (comment.Comment.ToLower().Contains(keyword))
						return true;


			if (usingTagLib) {
				if (String.IsNullOrEmpty(tagFile.Tag.Comment))
					return false;

				return tagFile.Tag.Comment.ToLower().Contains(keyword);
			}
			return false;
		}

		private Boolean matchesAlbum(String keyword) {

			if (usingId3Tag)
				return id3Tag.Album.Value.ToLower().Contains(keyword);

			if (usingTagLib) {
				if (String.IsNullOrEmpty(tagFile.Tag.Album))
					return false;
				return tagFile.Tag.Album.ToLower().Contains(keyword);
			}

			return false;
		}

		private Boolean matchesArtist(String keyword) {

			if (usingId3Tag)
				return id3Tag.Artists.Value.ToLower().Contains(keyword);

			if (usingTagLib) {
				foreach (String artist in tagFile.Tag.Performers)
					if (artist.ToLower().Contains(keyword))
						return true;
			}
			return false;
		}


		private Boolean matchesGenre(String keyword) {

			if (usingId3Tag)
				return id3Tag.Genre.Value.ToLower().Contains(keyword);

			if (usingTagLib) {
				foreach (String genre in tagFile.Tag.Genres) {
					if (genre.ToLower().Contains(keyword))
						return true;
				}
			}
			return false;

		}

		public override String ToString() {

			//Console.WriteLine(filename);
			//Console.WriteLine(tagFile.Tag.FirstPerformer.Length);
			//Console.WriteLine(tagFile.Tag.Title.Length);
			try {
				if (usingTagLib) {
					if ((String.IsNullOrWhiteSpace(tagFile.Tag.FirstPerformer)
							|| String.IsNullOrWhiteSpace(tagFile.Tag.Title))
						|| (tagFile.Tag.FirstPerformer.Length + tagFile.Tag.Title.Length == 0))
						return filename;
					return tagFile.Tag.FirstPerformer + " - " + tagFile.Tag.Title;
				}

				if (usingId3Tag) {
					if (String.IsNullOrWhiteSpace(id3Tag.Artists.Value)
						&& String.IsNullOrWhiteSpace(id3Tag.Title.Value))
						return filename;

					return id3Tag.Artists.Value + " - " + id3Tag.Title.Value;
				}
			} catch (Exception ex) {
				Console.WriteLine(filename + " is fuckered!!");
				Console.WriteLine(" Reason:" + ex);
				fileCorrupted = true;
			}

			if (fileCorrupted)
				return "FILE CORRUPTED - " + filename;

			return filename;

		}

		//if (usingUltraID3) {
		//	//if (metaData.Artist.Length + metaData.Title.Length == 0)
		//	//	return filename;
		//	return metaData.Artist + " - " + metaData.Title;
		//}
	}
}

