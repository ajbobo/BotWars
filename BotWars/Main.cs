using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace BotWars
{
	public class BotWarsMain
   {
		[STAThreadAttribute]
      public static void Main()
      {
			Application.EnableVisualStyles();
         GameData gdata = new GameData();
         GameSetup setup = new GameSetup(gdata);

         setup.ShowDialog();

         if (setup.DialogResult == DialogResult.OK)
         {
            Console.WriteLine("The game should start");
            Console.WriteLine("Players:");
            for (int x = 0; x < gdata.NumPlayers; x++)
               Console.WriteLine('\t' + gdata.GetPlayer(x).Name);
            Console.WriteLine("Cards:");
            for (int x = 0; x < gdata.NumCards; x++)
            {               
               MovementCard card = gdata.GetCard(x);
               Console.WriteLine('\t' + card.Name + " -> " + card.MoveString);
            }
            Console.WriteLine("Spaces:");
            for (int x = 0; x < gdata.NumSpaces; x++)
            {
               Space space = gdata.GetSpace(x);
               Console.WriteLine('\t' + space.Name + " Phase: " + space.ActivePhase) ;
            }
            Console.WriteLine("Modifications:");
            for (int x = 0; x < gdata.NumModifications; x++)
            {
               Modification mod = gdata.GetModification(x);
               Console.WriteLine('\t' + mod.Name);
            }

            CreateBoard(gdata);
				CreateDeck(gdata);
            RunGameLoop(gdata);
         }
         else
         {
            Console.WriteLine("The game should be over");
         }
      }

      private static void CreateBoard(GameData gdata)
      {
			bool done = false;
			while (!done)
			{
				// Load the board
				gdata.Board = XMLControl.LoadXMLFile(gdata.Board, gdata.SpaceList);

				// Build the list of entry points
				Space[,] board = gdata.Board;
				for (int row = 0; row < gdata.BoardRows; row++)
				{
					for (int col = 0; col < gdata.BoardCols; col++)
					{
						Space curspace = board[col, row];
						if (curspace == null)
							continue;
						if (curspace.IsEntry)
							gdata.AddEntry(curspace);
					}
				}
				Console.WriteLine("Entry Points {0}", gdata.NumEntries);
				if (gdata.NumEntries < gdata.NumPlayers)
					MessageBox.Show("This map does not have enough entry points for the current players", "Invalid Map");
				else
					done = true;
			}
			// Put each player on a random entry point
			Random rand = new Random();
			foreach (Player curplayer in gdata.Players)
			{
				done = false;
				while (!done)
				{
					int numentry = rand.Next(0, gdata.NumEntries); // 0 <= numentry < NumEntries
					Space curentry = gdata.GetEntry(numentry);
					if (curentry.CurPlayer == null)
					{
						curentry.CurPlayer = curplayer;
						curplayer.CurSpace = curentry;
						done = true;
						Console.WriteLine(curplayer.Name + " is on entry #" + numentry);
					}
				}
			}
      }

		private static void CreateDeck(GameData gdata)
		{
			gdata.CreateDeck();
			gdata.ShuffleDeck();
		}

		private static void DealCards(GameData gdata)
		{
			gdata.CollectUsedCards();
			gdata.DealCards();
		}

		private static void ProgramCards(GameData gdata, MainGameView view)
		{
			view.NextPlayer(null, EventArgs.Empty);

			// Wait until all players have programmed or the program is closed
			while (gdata.CurrentPlayer != -1 && !gdata.GameOver) 
			{
				Application.DoEvents();
				Thread.Sleep(2);
			}
		}

		private static void MovePlayers(GameData gdata, int curregister)
		{
			// Move the players based on the way they programmed their registers
			// Player movement should be based on a Priority value on the cards - FINISH ME
			if (gdata.CurrentPlayer == -1) // No more players to move
				return;

			Player curplayer = gdata.GetPlayer(gdata.CurrentPlayer);
			MovementCard card = curplayer.GetCardFromProgram(curregister - 1);
			Console.WriteLine("Moving " + curplayer.Name + " : " + card.MoveString);
			// Set the player's MovementSteps according to the card
			gdata.Navigator.MovePlayerFromString(curplayer, card.MoveString);
			gdata.CurrentPlayer++;
		}

		private static void StopSpaceAnimation(GameData gdata)
		{
			for (int x = 0; x < gdata.BoardCols; x++)
			{
				for (int y = 0; y < gdata.BoardRows; y++)
				{
					Space curspace = gdata.BoardSpace(x, y);
					if (curspace == null)
						continue;
					curspace.Animating = false;
				}
			}
		}

		private static void ActivateSpaces(GameData gdata, int regnum, Phase curphase)
		{
			for (int x = 0; x < gdata.BoardCols; x++)
			{
				for (int y = 0; y < gdata.BoardRows; y++)
				{
					Space curspace = gdata.BoardSpace(x, y);
					if (curspace == null)
						continue;

					bool rightphase = (curspace.ActivePhase == Phase.All || curspace.ActivePhase == curphase);
					if (curspace.IsRegisterActive(regnum) && rightphase)
					{
						curspace.Activate();
						curspace.Animating = true;
					}
				}
			}
		}

		private static void LaserFire(GameData gdata)
		{
			// Resolve laser fire
		}

		private static void EndGameSequence()
		{
			// Check to see that there is a winner (or tie)
			// Announce the winner here
		}

		private static void RunGameLoop(GameData gdata)
      {
         MainGameView view = new MainGameView(gdata);

         view.Show();

			while (!gdata.GameOver)
			{
				DealCards(gdata);
				ProgramCards(gdata,view);
				int regcnt = 1;

				while (regcnt <= (int)Values.RegistersPerTurn && !gdata.GameOver)
				{
					Console.WriteLine("Starting Register {0}",regcnt);
					Phase curphase = Phase.MovePlayers;

					gdata.CurrentPlayer = 0;
					while (curphase <= Phase.LaserFire && !gdata.GameOver)
					{
						Console.WriteLine("Starting Phase {0}",curphase);
						StopSpaceAnimation(gdata);

						gdata.Animating = true;
						switch (curphase)
						{
						case Phase.MovePlayers:		MovePlayers(gdata, regcnt); break;
						case Phase.Conveyors:
						case Phase.Pushers:
						case Phase.Fire:				ActivateSpaces(gdata, regcnt, curphase); break;
						case Phase.LaserFire:		LaserFire(gdata); break;
						}

						while (gdata.Animating && !gdata.GameOver)
						{
							Application.DoEvents();
							Thread.Sleep(2);
						}

						if (gdata.GameOver)
						{
							EndGameSequence();
						}
						else if (gdata.CurrentPlayer == -1) // Only advance the phase if all of the players are done
						{
							curphase++;
						}
					}

					regcnt++;
				}
			}

         view.Close();
      }
   }
}