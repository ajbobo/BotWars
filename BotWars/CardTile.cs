using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace BotWars
{
	class CardTile : UserControl
	{
		private MovementCard card;

		public CardTile(MovementCard incard)
		{
			Width = 36;
			Height = 50;
			card = incard;

			SetStyle(
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.UserPaint |
				ControlStyles.OptimizedDoubleBuffer, true);
		}

		public MovementCard Card
		{
			get { return card; }
			set { card = value; }
		}

		public bool HasCard
		{
			get { if (card != null) return true; else return false; }
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (HasCard)
			{
				DragDropEffects effects = DoDragDrop(card, DragDropEffects.Move);

				if (effects != DragDropEffects.None) // Something happened
				{
					Card = null;
					Invalidate();
				}
			}
		}

		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			if (!HasCard)
			{
				if (drgevent.Data.GetDataPresent("BotWars.MovementCard"))
				{
					Graphics g = CreateGraphics();
					MovementCard mycard = (MovementCard)drgevent.Data.GetData("BotWars.MovementCard");
					mycard.Draw(g, true);
					drgevent.Effect = DragDropEffects.Move;
				}
			}
		}

		protected override void OnDragLeave(EventArgs e)
		{
			Invalidate();
		}

		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if (drgevent.Data.GetDataPresent("BotWars.MovementCard"))
			{
				MovementCard mycard = (MovementCard)drgevent.Data.GetData("BotWars.MovementCard");
				Card = mycard;
				drgevent.Effect = DragDropEffects.Move;
				Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if (card != null)
			{
				card.Draw(g, false);
			}
			g.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
		}
	}
}