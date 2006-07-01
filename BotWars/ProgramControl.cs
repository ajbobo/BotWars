using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BotWars
{
	class ProgramControl : UserControl
	{
		private Button okbutton;
		private Timer countdown;
		private CardTile[] TopTiles;
		private CardTile[] BottomTiles;
		private Player player;
		private int timeleft, maxtime = 30; // The user should be able to enter maxtime - FINISH ME
		public event EventHandler ProgrammingDone;

		public ProgramControl()
		{
			int cardsperhand = (int)Values.CardsPerHand;
			int registersperturn = (int)Values.RegistersPerTurn;

			okbutton = new Button();
			okbutton.Text = "Done";
			okbutton.Size = new Size(100, 25);
			okbutton.Location = new Point(50, 245);
			okbutton.Parent = this;
			okbutton.Click += new EventHandler(OnOK);

			countdown = new Timer();
			countdown.Interval = 1000;
			countdown.Tick += new EventHandler(OnTick);

			timeleft = maxtime;

			// Initialize the two tile regions
			TopTiles = new CardTile[cardsperhand];
			BottomTiles = new CardTile[registersperturn];
			int halfhand = cardsperhand / 2;
			for (int x = 0; x < halfhand; x++)
			{
				TopTiles[x] = new CardTile(null);
				TopTiles[x].Location = new Point(5 + x * 36, 60);
				TopTiles[x].AllowDrop = true;
				TopTiles[x].Parent = this;
			}
			for (int x = halfhand; x < cardsperhand; x++)
			{
				TopTiles[x] = new CardTile(null);
				TopTiles[x].Location = new Point(5 + (x - halfhand) * 36, 110);
				TopTiles[x].AllowDrop = true;
				TopTiles[x].Parent = this;
			}
			for (int x = 0; x < registersperturn; x++)
			{
				BottomTiles[x] = new CardTile(null);
				BottomTiles[x].Location = new Point(5 + x * 36, 190);
				BottomTiles[x].AllowDrop = true;
				BottomTiles[x].Parent = this;
			}
		
			SetStyle(
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.UserPaint |
				ControlStyles.OptimizedDoubleBuffer, true);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			string text;
			if (player != null)
				text = player.Name + " Programming Cards";
			else
				text = "Waiting for next turn...";
			g.DrawString(text, Font, Brushes.Black, 5, 5);
			g.DrawString("Time Remaining: " + timeleft, Font, Brushes.Black, 5, 20);
			g.DrawString("Cards in Hand: ", Font, Brushes.Black, 5, 40);
			g.DrawString("Cards in Program: ", Font, Brushes.Black, 5, 170);
		}

		private void OnTick(object sender, EventArgs args)
		{
			timeleft--;
			if (timeleft == 0) // Out of time - close the dialog
				OnOK(this, EventArgs.Empty);
			Invalidate();
		}

		public Player ProgrammingPlayer
		{
			get { return player; }
			set
			{
				if (value != null && value != player) // Can't set the player to the current one
				{
					player = value;
					InitView();
					okbutton.Enabled = true;
				}
				else if (value == null)
				{
					player = null;
					okbutton.Enabled = false;
				}
			}
		}

		private void InitView()
		{
			for (int x = 0; x < (int)Values.CardsPerHand; x++)
			{
				TopTiles[x].Card = player.RemoveCardFromHand(x);
			}
			countdown.Start();
			Invalidate(true);
		}
		
		private void OnOK(object sender, EventArgs args)
		{
			// Put the unprogrammed cards back in the player's hand
			for (int x = 0; x < (int)Values.CardsPerHand; x++)
			{
				MovementCard card = TopTiles[x].Card;
				TopTiles[x].Card = null;
				player.AddCardToHand(card, x);
			}

			// Put the programmed cards in the player's program
			for (int x = 0; x < (int)Values.RegistersPerTurn; x++)
			{
				MovementCard card = BottomTiles[x].Card;
				BottomTiles[x].Card = null;

				// If the player didn't program all their registers, fill the rest with cards they were dealt
				int ptr = 0;
				while (card == null)
				{
					card = player.RemoveCardFromHand(ptr);
					ptr++;
				}
				player.AddCardToProgram(card, x);
			}

			countdown.Stop();
			timeleft = maxtime;
			Invalidate(true);
			ProgrammingDone(this, EventArgs.Empty);
		}
	}
}
