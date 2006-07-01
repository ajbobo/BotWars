using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using BotWars;

namespace BotWars
{
	class BoardControl : MainViewer
	{
		private GameData gdata;

		public BoardControl(GameData ingdata)
			: base()
		{
			gdata = ingdata;
			board = gdata.Board;
			gdata.timer.Tick += new EventHandler(NextFrame);
		}

		void NextFrame(object src, EventArgs e)
		{
			curframe = gdata.Frame;
			Invalidate();
		}
	}
}
