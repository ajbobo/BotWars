using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BotWars
{
	public delegate void ActivatedSpaceHandler(Space space);

	public class MainViewer : UserControl
	{
		public event ActivatedSpaceHandler OnActivatedSpace;
		protected Space[,] board;
		protected Space curspace, activespace;
      protected int  mousex, mousey;
		protected float xoffset, yoffset;
		protected int gridsize;
		protected bool hasmouse, dragging;
		protected int curframe;
		protected bool selectable;
		protected List<Player> playerlist;

      public MainViewer()
      {
         board = null;
			curspace = null;
			activespace = null;
         xoffset = 0;
         yoffset = 0;
			gridsize = 64;
			hasmouse = false;
			dragging = false;
         SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
				ControlStyles.UserMouse, true);
         BackColor = Color.SlateGray;
         MenuItem resetview = new MenuItem("&Reset View", ResetView);
         this.ContextMenu = new ContextMenu(new MenuItem[] {resetview});
			OnActivatedSpace += new ActivatedSpaceHandler(SetActiveSpace);
			selectable = true;
			playerlist = new List<Player>();
      }

		private void SetActiveSpace(Space space)
		{
			activespace = space;
		}

		public Space CurSpace
		{
			set { curspace = value; }
		}

		public int CurFrame
		{
			set { curframe = value; }
			get { return curframe; }
		}

		public bool Selectable
		{
			get { return selectable; }
			set { selectable = value; }
		}

		public List<Player> PlayerList
		{
			get { return playerlist; }
			set { playerlist = value; }
		}

		public void SetBoard(Space[,] inBoard)
		{
			board = inBoard;
			Invalidate();
		}
		
		public void InitializeView()
		{
			gridsize = 64;

			OnActivatedSpace(null);
			ResetView(this, new EventArgs());
		}

      private void ResetView(object src, EventArgs e)
      {
         xoffset = 0;
         yoffset = 0;

         Invalidate();
      }

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Invalidate();
		}
		
      protected override void OnMouseDown(MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Middle)
         {
            mousex = e.X;
            mousey = e.Y;
         }
			dragging = false;
      }

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !dragging) // Select the space they clicked on
			{
				int MouseX = e.X;
				int MouseY = e.Y;

				if (!selectable || MouseX < 0 || MouseX >= Width || MouseY < 0 || MouseY >= Height || board == null)
					return;

				int rows = board.GetUpperBound(1) + 1;
				int cols = board.GetUpperBound(0) + 1;

				int boardleft = (int)((this.Width / 2) - (cols / 2.0 * gridsize) + (xoffset * gridsize));
				int boardtop = (int)((this.Height / 2) - (rows / 2.0 * gridsize) + (yoffset * gridsize));

				int xloc = MouseX - boardleft;
				int yloc = MouseY - boardtop;
				int maxx = gridsize * cols;
				int maxy = gridsize * rows;

				Space tempspace = null;
				if (xloc >= 0 && xloc < maxx && yloc >= 0 && yloc < maxy) // Clicked in a valid area
				{
					int spacex = xloc / gridsize;
					int spacey = yloc / gridsize;
					tempspace = board[spacex, spacey];
				}
				OnActivatedSpace(tempspace);
				Invalidate();
			}
		}

      protected override void OnMouseMove(MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Middle) // What if the user doesn't have a middle button? - FINISH MEv
         {
				if (board == null) // Don't do anything if there's no board yet
					return;

            // Make sure the view isn't pulled too far off of the screen - FINISH ME

				// The X and Y offsets are stored as a percentage of a gridsize
            float diffx = (float)(mousex - e.X) / (float)gridsize;
            float diffy = (float)(mousey - e.Y) / (float)gridsize;
            xoffset -= diffx;
            yoffset -= diffy;
            mousex = e.X;
            mousey = e.Y;

            Invalidate();
         }
			dragging = true;
      }

		protected override void OnMouseEnter(EventArgs e)
		{
			hasmouse = true;
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			hasmouse = false;
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			// These controls aren't quite as elegant as I'd like, but they'll do for now
			// There's some weirdness here - the main Form seems to have focus too much
			// User has to click on the Viewer in order to scroll in or out
			if (hasmouse)
			{
				//Console.Write("GridSize: " + gridsize);
				int amt = e.Delta / 120;
				gridsize += amt * 5;
				if (gridsize < 10)
					gridsize = 10;
				else if (gridsize > 120)
					gridsize = 120;
				//Console.WriteLine(" -> " + gridsize);
				Invalidate();
			}
		}

      protected override void OnPaint(PaintEventArgs e)
      {
         Graphics g = e.Graphics;
					
			// Go through each space in the board and draw it
			if (board != null)
			{
				Rectangle highlight = new Rectangle(0,0,0,0);
				bool needhighlight = false;
				int rows = board.GetUpperBound(1);
				int cols = board.GetUpperBound(0);
				int boardleft = (int)((this.Width / 2) - ((cols + 1) / 2.0 * gridsize) + (xoffset * gridsize));
				int boardtop = (int)((this.Height / 2) - ((rows + 1) / 2.0 * gridsize) + (yoffset * gridsize));
				for (int x = 0; x <= cols; x++)
				{
					int locx = boardleft + x * gridsize;
					for (int y = 0; y <= rows; y++)
					{
						int locy = boardtop + y * gridsize;
						Rectangle src = new Rectangle(locx , locy , gridsize, gridsize);
						Rectangle dest = new Rectangle(0, 0, 64, 64);

						// Draw the white border around each space - willonly be seen if the space is null
						g.DrawRectangle(Pens.WhiteSmoke, locx, locy, gridsize - 1, gridsize - 1);

						// Set up the clipped drawing area with new coordinates for the space
						GraphicsContainer gc = g.BeginContainer(src, dest, GraphicsUnit.Pixel);
						g.SetClip(dest);
						if (board[x, y] != null)
						{
							// Record the space's current draw location
							board[x, y].DrawX = locx;
							board[x, y].DrawY = locy;

							// Draw the space
							board[x, y].Draw2D(g, curframe);

							// Draw walls if they exist
							if (board[x, y].IsWall(Direction.North)) DrawWall(g, Direction.North);
							if (board[x, y].IsWall(Direction.South)) DrawWall(g, Direction.South);
							if (board[x, y].IsWall(Direction.East)) DrawWall(g, Direction.East);
							if (board[x, y].IsWall(Direction.West)) DrawWall(g, Direction.West);

						}
						g.ResetClip();
						g.EndContainer(gc);

						// Highlight the active space
						if (activespace != null && board[x, y] == activespace)
						{
							highlight = src;
							needhighlight = true;
						}
					}
				}
				if (needhighlight)
					g.DrawRectangle(new Pen(Color.Yellow, 3), highlight.Left, highlight.Top, gridsize - 1, gridsize - 1);
			}
			// Draw each player
			int xloc = 0;
			float rot = 0;
			foreach (Player curplayer in playerlist)
			{
				int currot = (int)curplayer.FacingDirection * 90;
				rot = currot;
				Space playerspace = curplayer.CurSpace;
				// Calculate where the player should be drawn
				int playerx = playerspace.DrawX;
				int playery = playerspace.DrawY;
				int timedone = (int)(1000 * (curframe / (float)Values.FramesPerSecond));
				if (timedone > 0 && curplayer.StepList.Count > 0) // Make sure the player is moving
				{
					int steplen = 1000 / curplayer.StepList.Count; // Number of milliseconds in each step
					int steptime = timedone % steplen; // Milliseconds finished in the current step
					int stepnum = timedone / steplen; // Step number that is currently being drawn
					bool lastframe = false; // Set to true if this is the last frame of a player's step
					//Console.WriteLine("player: {3} steplen: {0} steptime: {1} stepnum: {2}", steplen, steptime, stepnum, curplayer.Name);
					if (steptime == 0) // Deal with the last frame of movement nicely
					{
						stepnum--;
						steptime = steplen;
						lastframe = true;
					}
					float steppercent = (float)steptime / (float)steplen;
					if (stepnum < curplayer.StepList.Count)
					{
						MovementStep curstep = curplayer.StepList[stepnum];
						Space targetspace = curstep.Space;
						int targetrot = (int)curstep.Direction * 90;
						// Deal with North<->West rotations
						if (targetrot == 0 && currot == 270) // West turning North
							targetrot = 360;
						else if (targetrot == 270 && currot == 0) // North turning West
							currot = 360;
						playerx += (int)((targetspace.DrawX - playerspace.DrawX) * steppercent);
						playery += (int)((targetspace.DrawY - playerspace.DrawY) * steppercent);
						rot += (int)((targetrot - currot) * steppercent);
					}
					if (lastframe)
						curplayer.StepComplete();
				}
				Rectangle src = new Rectangle(playerx, playery, gridsize, gridsize);
				Rectangle dest = new Rectangle(0, 0, 64, 64);
				GraphicsContainer gc = g.BeginContainer(src, dest, GraphicsUnit.Pixel);
				g.TranslateTransform(32, 32);
				g.RotateTransform(rot);
				g.TranslateTransform(-32, -32);
				g.DrawImage(curplayer.PlayerImage, 0, 0);
				g.EndContainer(gc);
				xloc += gridsize;
			}
         // Draw a border around the entire board
         g.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
      }

		private void DrawWall(Graphics g, Direction dir)
		{
			// This function is here in case I decide to have a more complicated wall-drawing routine
			switch (dir)
			{
			case Direction.North: g.FillRectangle(Brushes.Brown, 0, 0, 64, 3); break;
			case Direction.South: g.FillRectangle(Brushes.Brown, 0, 61, 64, 3); break;
			case Direction.East: g.FillRectangle(Brushes.Brown, 61, 0, 3, 64); break;
			case Direction.West: g.FillRectangle(Brushes.Brown, 0, 0, 3, 64); break;
			}
		}
	}
}
