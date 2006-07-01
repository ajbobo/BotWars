using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BotWars
{
   public class GameData
   {
      private List<Player> players;
      private List<MovementCard> cards;
      private List<Space> spaces;
      private List<Modification> mods;
		private List<Space> entries;
		private List<MovementCard> deck;
      private Space[,] board;
      private int rows, cols;
      private bool gameover;
      public Timer timer;
      private int frame;
		private int currentplayer;
		private Navigator navigator;

      public GameData()
      {
         System.Console.WriteLine("Created a new GameData");
         players = new List<Player>();
         cards = new List<MovementCard>();
         spaces = new List<Space>();
         mods = new List<Modification>();
			entries = new List<Space>();
			deck = new List<MovementCard>();
         gameover = false;
         rows = 0; cols = 0;
         timer = new Timer();
         timer.Interval = 1000 / (int)Values.FramesPerSecond; // # of frames per 1000 milliseconds
         timer.Tick += new EventHandler(OnTimer);
         frame = 0;
			currentplayer = -1;
      }

      public void AddPlayer(Player player)
      {
         players.Add(player);
      }

      public int NumPlayers
      {
         get { return players.Count; }
      }

      public Player GetPlayer(int player)
      {
			if (player >= players.Count || player < 0)
				return null;
         return players[player];
      }

		public List<Player> Players
		{
			get { return players; }
		}

      public void AddCard(MovementCard card)
      {
         cards.Add(card);
      }

      public int NumCards
      {
         get { return cards.Count; }
      }

      public MovementCard GetCard(int card)
      {
			if (card >= cards.Count || card < 0)
				return null;
         return cards[card];
      }

      public void AddSpace(Space space)
      {
         spaces.Add(space);
      }

      public int NumSpaces
      {
         get { return spaces.Count; }
      }

      public Space GetSpace(int space)
      {
			if (space >= spaces.Count || space < 0)
				return null;
         return spaces[space];
      }

		public List<Space> SpaceList
		{
			get { return spaces; }
		}

      public void AddModification(Modification mod)
      {
         mods.Add(mod);
      }

      public int NumModifications
      {
         get { return mods.Count; }
      }

      public Modification GetModification(int mod)
      {
			if (mod >= mods.Count || mod < 0)
				return null;
         return mods[mod];
      }

		public void AddEntry(Space space)
		{
			entries.Add(space);
		}

		public int NumEntries
		{
			get { return entries.Count; }
		}

		public Space GetEntry(int space)
		{
			return entries[space];
		}

      public bool GameOver
      {
         get { return gameover; }
         set { gameover = value; }
      }

		public Space[,] Board
		{
			get { return board; }
			set 
			{ 
				board = value; 
				rows = board.GetUpperBound(1) + 1; 
				cols = board.GetUpperBound(0) + 1;
				navigator = new Navigator(board);
			}
		}

		public int BoardRows
      {
         get { return rows; }
      }

      public int BoardCols
      {
         get { return cols; }
      }

		public Space BoardSpace(int x, int y)
		{
			return board[x, y];
		}

		public void CreateDeck()
		{
			MovementCard curcard;

			foreach (MovementCard mc in cards)
			{
				int numcards = mc.Occurances * NumPlayers;
				for (int x = 0; x < numcards; x++)
				{
					curcard = mc.MakeClone();
					deck.Add(curcard);
				}
			}
			int minsize = NumPlayers * 10;
			while (deck.Count < minsize)
			{
				deck.Add(new MovementCard()); // Pad the deck with basic cards
			}
			/*
			Console.WriteLine("Initial Deck:");
			foreach (MovementCard mc in deck)
				Console.WriteLine(mc.Name);
			*/
		}

		public void ShuffleDeck()
		{
			// Find a better algorithm for this - FINISH ME

			Random rand = new Random();

			int numcards = deck.Count;
			for (int y = 1; y <= 3; y++)
			{
				for (int x = 0; x < numcards; x++)
				{
					MovementCard mc = deck[x];
					deck.RemoveAt(x);
					int newposition = rand.Next(0, numcards);
					deck.Insert(newposition, mc);
				}
			}
			/*
			Console.WriteLine("Shuffled Deck:");
			foreach (MovementCard mc in deck)
				Console.WriteLine(mc.Name);
			*/
		}

		public void CollectUsedCards()
		{
			foreach (Player player in players)
			{
				// Collect cards from their hands
				for (int x = 0; x < (int)Values.CardsPerHand; x++)
				{
					MovementCard card = player.RemoveCardFromHand(x);
					if (card != null)
						deck.Add(card);
				}

				// Collect cards from their programs
				for (int x = 0; x < (int)Values.RegistersPerTurn; x++)
				{
					MovementCard card = player.RemoveCardFromProgram(x);
					if (card != null)
						deck.Add(card);
				}
			}
		}

		public void DealCards()
		{
			foreach (Player player in players)
			{
				int numcards = (int)Values.CardsPerHand - player.Damage; 
				for (int x = 0; x < numcards; x++)
				{
					MovementCard card = deck[0];
					deck.RemoveAt(0);
					player.AddCardToHand(card, x);
				}
			}
			/*
			foreach (Player player in players)
			{
				Console.WriteLine(player.Name + " was dealt:");
				for (int x = 0; x < (int)Values.CardsPerHand; x++)
				{
					MovementCard card = player.RemoveCardFromHand(x);
					Console.WriteLine(card.Name);
					player.AddCardToHand(card, x);
				}
			}
			*/
		}

		public int CurrentPlayer
		{
			get { return currentplayer; }
			set 
			{ 
				currentplayer = value; 
				if (currentplayer >= NumPlayers) 
					currentplayer = -1; 
			}
		}

		private void OnTimer(object src, EventArgs e)
      {
         frame++;
         if (frame >= (int)Values.FramesPerSecond)
         {
            timer.Stop();
            //frame = 0;
         }
      }

      public int Frame
      {
         get { return frame; }
      }

      public bool Animating
      {
         get { return timer.Enabled; }
         set
         {
				if (!timer.Enabled && value == true)
				{
					frame = 0;
					timer.Start();
				}
				if (timer.Enabled && value == false)
				{
					timer.Stop();
					frame = 0;
				}
         }
      }

		public Navigator Navigator
		{
			get { return navigator; }
		}
   }
}
