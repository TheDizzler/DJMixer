using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DJMixer {
	public partial class SearchResultForm : Form {

		public SearchResultForm() {
			InitializeComponent();
		}


		public void loadResults(List<Song> results) {


			//foreach (Song result in results) {

				listBox_SearchResults.Items.AddRange(results.ToArray());

			label_NumResults.Text = results.Count + " Matches Found";
			//}

		}

		private void button_Select_Click(Object sender, EventArgs e) {



		}
	}
}
