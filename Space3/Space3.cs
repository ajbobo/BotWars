using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BotWars
{
   public class Space3 : Space
   {
		public Space3():base()
		{
			Pit = true;
		}

      public override string Name
      {
         get { return "Space3"; }
      }

		public override Phase ActivePhase
		{
			get { return Phase.Conveyors; }
		}

      public override void Draw2D(Graphics g, int frame)
      {
         g.FillRectangle(Brushes.Green, 0, 0, 64, 64);
         if (frame > 0 && Animating)
         {
            int pos = (64 / (int)Values.FramesPerSecond) * frame;
            g.DrawLine(Pens.Black, pos, 0, 0, pos); // Draw a diagonal line
         }
      }
   }
}
