using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BotWars
{
   public class Space
   {
		// Member variables
		protected bool Pit;
		protected bool Entry;
		protected bool[] Wall;
		protected bool[] Register;
		protected bool animating;
		protected Player curplayer;
		protected Point curdrawpoint;
		protected Point curboardpoint;

		public Space()
		{
			Pit = false;
			Entry = false;

			Wall = new bool[4];
			for (int x = 0; x < 4; x++)
				Wall[x] = false;

			Register = new bool[5];
			for (int x = 0; x < 5; x++)
				Register[x] = true;

			curplayer = null;
			curdrawpoint = new Point(0, 0);
			curboardpoint = new Point(0, 0);
		}

		public virtual string Name
      {
         get { return "Space"; }
      }

		public virtual bool IsPit
		{
			get { return Pit; }
			set { Pit = value; }
		}

		public virtual bool IsEntry
		{
			get { return Entry; }
			set { Entry = value; }
		}

		public virtual bool IsWall(Direction dir)
		{
			return Wall[(int)dir];
		}

		public virtual void SetWall(Direction dir, bool iswall)
		{
			Wall[(int)dir] = iswall;
		}

		public virtual bool IsRegisterActive(int register)
		{
			return Register[register - 1];
		}

		public virtual void SetRegisterActive(int register, bool active)
		{
			Register[register - 1] = active;
		}

		public virtual Phase ActivePhase
		{
			get { return Phase.All; }
		}

		public virtual void Activate()
		{
			// Default space does nothing
		}

		public bool Animating
		{
			get { return animating; }
			set { animating = value; }
		}

		public Player CurPlayer
		{
			get { return curplayer; }
			set { curplayer = value; }
		}

		public int DrawX
		{
			get { return curdrawpoint.X; }
			set { curdrawpoint.X = value; }
		}

		public int DrawY
		{
			get { return curdrawpoint.Y; }
			set { curdrawpoint.Y = value; }
		}

		public int BoardX
		{
			get { return curboardpoint.X; }
			set { curboardpoint.X = value; }
		}

		public int BoardY
		{
			get { return curboardpoint.Y; }
			set { curboardpoint.Y = value; }
		}

      public virtual void Draw2D(Graphics g, int frame)
      {
         g.FillRectangle(Brushes.Blue, 0, 0, 64, 64);
         if (frame > 0 && Animating)
         {
            int xpos = (64 / (int)Values.FramesPerSecond) * frame;
            g.DrawLine(Pens.Black, xpos, 0, xpos, 63); // Draw a vertical line
         }
      }

      public Space MakeClone()
      {
			// Create the clone
         Space res = (Space)MemberwiseClone();

			// Update any variables that were not cloned correctly
			res.Wall = new bool[4];
			for (int x = 0; x < 4; x++)
				res.Wall[x] = false;

			res.Register = new bool[5];
			for (int x = 0; x < 5; x++)
				res.Register[x] = true;

			return res;
      }
	}
}
