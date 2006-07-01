using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BotWars
{
   public class TestSpace : Space
   {
		public TestSpace()
		{
		}

      public override string Name
      {
         get { return "TestSpace"; }
      }

		public override Phase ActivePhase
		{
			get { return Phase.Pushers; }
		}

      public override void Draw2D(Graphics g, int frame)
      {
         g.FillRectangle(Brushes.Red, 0, 0, 64, 64);
         if (frame > 0 && Animating)
         {
            int ypos = (64 / (int)Values.FramesPerSecond) * frame;
            g.DrawLine(Pens.Black, 0, ypos, 63, ypos); // Draw a vertical line
         }
      }
   }
}
