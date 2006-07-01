using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BotWars
{
   public class ForwardOne : MovementCard
   {
      public override string Name
      {
         get { return "ForwardOne"; }
      }

      public override string MoveString
      {
         get { return "F"; }
      }

		public override int Occurances
		{
			get { return 5; }
		}

		public override void Draw(Graphics g, bool ghost)
		{
			// Draws in a 72x100 pixel box
			Color color;
			if (ghost)
				color = Color.FromArgb(64, 0, 255, 0);
			else
				color = Color.FromArgb(0, 255, 0);
			Pen pen = new Pen(color, 5);

			g.DrawLine(pen, 18, 12, 18, 38);
			g.DrawLine(pen, 18, 12, 12, 18);
			g.DrawLine(pen, 18, 12, 24, 18);
		}
   }
}
