using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BotWars;

namespace BotWars
{
	class MapViewer : MainViewer
	{
		public MapViewer() : base()
		{
			curframe = 0;
		}

		private void SetSpace(int MouseX, int MouseY)
		{
			if (MouseX < 0 || MouseX >= Width || MouseY < 0 || MouseY >= Height || board == null)
				return;

			int rows = board.GetUpperBound(1) + 1;
			int cols = board.GetUpperBound(0) + 1;

			int boardleft = (int)((this.Width / 2) - (cols / 2.0 * gridsize) + (xoffset * gridsize));
			int boardtop = (int)((this.Height / 2) - (rows / 2.0 * gridsize) + (yoffset * gridsize));

			int xloc = MouseX - boardleft;
			int yloc = MouseY - boardtop;
			int maxx = gridsize * cols;
			int maxy = gridsize * rows;

			if (xloc >= 0 && xloc < maxx && yloc >= 0 && yloc < maxy) // Clicked in a valid area
			{
				int spacex = xloc / gridsize;
				int spacey = yloc / gridsize;
				Space tempspace = board[spacex, spacey];
				if (tempspace == null || tempspace.Name != curspace.Name)
				{
					board[spacex, spacey] = curspace.MakeClone();
				}
				Invalidate();
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				SetSpace(e.X, e.Y);
			}
			base.OnMouseMove(e);
		}
	}
}
