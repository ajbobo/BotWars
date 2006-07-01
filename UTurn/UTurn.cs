using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BotWars
{
   public class UTurn : MovementCard
   {
      public override string Name
      {
         get { return "UTurn"; }
      }

      public override string MoveString
      {
         get { return "RR"; }
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
				color = Color.FromArgb(64, 128, 0, 255);
			else
				color = Color.FromArgb(128, 0, 255);
			Pen pen = new Pen(color, 5);

			g.DrawLine(pen, 8, 45, 8, 15);
			g.DrawLine(pen, 8, 15, 28, 15);
			g.DrawLine(pen, 28, 15, 28, 45);
		}
   }
}
