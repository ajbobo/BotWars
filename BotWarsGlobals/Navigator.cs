using System;
using System.Collections.Generic;
using System.Text;

namespace BotWars
{
	public class Navigator
	{
		private Space[,] board;

		public Navigator(Space[,] inboard)
		{
			board = inboard;
		}

		public bool MovePlayerFromString(Player player, string movestr)
		{
			//Console.WriteLine("{0} is moving from string", player.Name);
			// For each character in the movement string, create a MovementStep for the player
			// Valid characters = (F)orward, (B)ackward, (R)ight, (L)eft, (W)ait
			// Invalid characters will be ignored
			player.StepList.Clear();
			player.CurStep = 0;
			Space startspace = player.CurSpace;
			Space tempspace = player.CurSpace;
			Direction tempdir = player.FacingDirection;
			foreach (char command in movestr)
			{
				int ModX = 0, ModY = 0, ModRot = 0;
				switch (command)
				{
				case 'F':
					switch (tempdir)
					{
					case Direction.North: ModY = -1; break;
					case Direction.South: ModY = 1; break;
					case Direction.East: ModX = 1; break;
					case Direction.West: ModX = -1; break;
					}
					break;
				case 'B':
					switch (tempdir)
					{
					case Direction.North: ModY = 1; break;
					case Direction.South: ModY = -1; break;
					case Direction.East: ModX = -1; break;
					case Direction.West: ModX = 1; break;
					}
					break;
				case 'R':
					ModRot = 1; 
					break;
				case 'L':
					ModRot = -1;
					break;
				case 'W':
					break;
				}
				Space targetspace;
				int NewX = tempspace.BoardX + ModX;
				int NewY = tempspace.BoardY + ModY;
				// Check for walls, other players, edge of board etc - FINISH ME
				if (NewX < 0 || NewX > board.GetUpperBound(0) || 
					 NewY < 0 || NewY > board.GetUpperBound(1)) // Check for edge of board
					targetspace = tempspace; // Don't move off the current space
				else
					targetspace = board[NewX, NewY];
				if (targetspace == null) // Make sure there is a space where the player wants to go
					targetspace = tempspace;
				if (targetspace.CurPlayer != null && targetspace.CurPlayer != player) // Check if there is another player in the space
				{
					if (!MovePlayerInDirection(targetspace.CurPlayer, tempdir)) // The player couldn't move
						targetspace = tempspace;
				}
				Direction targetdir = (Direction)(((int)tempdir + ModRot) % 4);
				// Insert the player's new step
				MovementStep step = new MovementStep();
				step.Direction = targetdir;
				step.Space = targetspace;
				player.StepList.Add(step);
				// Update the temp variables for the player's next step
				tempspace = targetspace;
				tempdir = targetdir;
			}
			// If the player has not moved, return false
			if (tempspace == startspace)
				return false;
			// If the player has moved, return true
			return true;
		}

		public bool MovePlayerInDirection(Player player, Direction movedir)
		{
			//Console.WriteLine("{0} is being pushed {1}", player.Name, movedir);
			// Push the player in the specified direction, do not change it's rotation
			Space startspace = player.CurSpace;
			Space tempspace = player.CurSpace;
			Space targetspace;
			int ModX = 0, ModY = 0;
			switch (movedir)
			{
			case Direction.North: ModY = -1; break;
			case Direction.South: ModY = 1; break;
			case Direction.East: ModX = 1; break;
			case Direction.West: ModX = -1; break;
			}
			int NewX = tempspace.BoardX + ModX;
			int NewY = tempspace.BoardY + ModY;
			// Check for walls, other players, edge of board etc - FINISH ME
			if (NewX < 0 || NewX > board.GetUpperBound(0) ||
				 NewY < 0 || NewY > board.GetUpperBound(1)) // Check for edge of board
				targetspace = tempspace; // Don't move off the current space
			else
				targetspace = board[NewX, NewY];
			if (targetspace == null) // Make sure there is a space where the player wants to go
				targetspace = tempspace;
			// Insert the player's new step
			MovementStep step = new MovementStep();
			step.Direction = player.FacingDirection;
			step.Space = targetspace;
			player.StepList.Add(step);
			// Update the temp variables for the player's next step
			tempspace = targetspace;
			// If the player has not moved, return false
			if (tempspace == startspace)
				return false;
			// If the player has moved, return true
			return true;
		}
	}
}
