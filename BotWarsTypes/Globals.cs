using System;
using System.Collections.Generic;
using System.Text;

namespace BotWars
{
   // Any globally-accessible stuff that doesn't fit in another file

	public enum Direction
	{
		North = 0,
		East = 1,
		South = 2,
		West = 3
	}

	public enum Values
	{
		RegistersPerTurn = 5,
		CardsPerHand = 10,
		FramesPerSecond = 30
	}

	public enum Phase
	{
		All = 0,
		MovePlayers,
		Conveyors,
		Pushers,
		Fire,
		LaserFire
	}

	public struct MovementStep
	{
		public Direction Direction;
		public Space Space;
	}
}