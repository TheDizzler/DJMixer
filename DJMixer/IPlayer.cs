using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DJMixer {
	public interface IPlayer {

		/// <summary>
		/// Must be called from main form after config form construction
		/// </summary>
		/// <param name="guid"></param>
		void setGUID(Guid guid);

		void setMixedVolume(float mixVol);

        void prepareForClose();
        bool stop();
		void cancelClose();
		bool isPlaying();
	}
}
