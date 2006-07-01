using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BotWars
{
	class CurrentSpace : UserControl
	{
		Space curspace;

		public CurrentSpace()
		{
			SetStyle(
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.UserPaint |
				ControlStyles.OptimizedDoubleBuffer |
				ControlStyles.UserMouse, true);
		}

		public Space CurSpace
		{
			set { curspace = value; }
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			if (curspace != null)
			{
				Rectangle src = new Rectangle(3, 3, Width - 6, Height - 6);
				Rectangle dest = new Rectangle(0, 0, 64, 64);
				g.SetClip(src);
				GraphicsContainer gc = g.BeginContainer(src, dest, GraphicsUnit.Pixel);
				curspace.Draw2D(g, 0);
				g.EndContainer(gc);
				g.ResetClip();
			}

			g.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
		}
	}
}
