using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BotWars
{
   public class TurnRight : MovementCard
   {
      public override string Name
      {
         get { return "TurnRight"; }
      }

      public override string MoveString
      {
         get { return "R"; }
      }

		public override int Occurances
		{
			get { return 5; }
		}

		public override void Draw(Graphics g, bool ghost)
		{
			// Draws in a 36x50 pixel box
			Color color;
			if (ghost)
				color = Color.FromArgb(64, 0, 0, 255);
			else
				color = Color.FromArgb(0, 0, 255);
			Pen pen = new Pen(color, 5);

			g.DrawLine(pen, 5, 25, 31, 25);
			g.DrawLine(pen, 25, 19, 31, 25);
			g.DrawLine(pen, 25, 31, 31, 25);
		}
   }
}
