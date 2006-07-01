using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BotWars
{
   public class Player
   {
      private string name;
		private bool animating;
		private MovementCard[] hand;
		private MovementCard[] program;
		private int damage;
		private Image image;
		private Space curspace;
		private List<MovementStep> steplist;
		private int curstep = 0;
		private Direction facingdirection;

		public Player()
		{
			hand = new MovementCard[(int)Values.CardsPerHand];
			program = new MovementCard[(int)Values.RegistersPerTurn];
			damage = 0;
			curspace = null;
			steplist = new List<MovementStep>();
			facingdirection = Direction.North;
		}

      public string Name
      {
         get { return name; }
         set { name = value; }
      }

		public bool Animating
		{
			get { return animating; }
			set { animating = value; }
		}

		public int Damage
		{
			get { return damage; }
			set { damage += value; }
		}

		public Image PlayerImage
		{
			get { return image; }
			set { image = value; }
		}

		public Space CurSpace
		{
			get { return curspace; }
			set { curspace = value; }
		}

		public void AddCardToHand(MovementCard card, int index)
		{
			hand[index] = card;
		}

		public MovementCard RemoveCardFromHand(int index)
		{
			MovementCard card = hand[index];
			hand[index] = null;
			return card;
		}

		public void AddCardToProgram(MovementCard card, int index)
		{
			// Check to be sure the index does not already have a card
			program[index] = card;
		}

		public MovementCard GetCardFromProgram(int index)
		{
			MovementCard card = program[index];
			return card;
		}

		public MovementCard RemoveCardFromProgram(int index)
		{
			MovementCard card = program[index];
			program[index] = null;
			return card;
		}

		public List<MovementStep> StepList
		{
			get { return steplist; }
		}

		public int CurStep
		{
			get { return curstep; }
			set { curstep = value; }
		}

		public void StepComplete()
		{
			curspace.CurPlayer = null;
			MovementStep step = steplist[curstep];
			curspace = step.Space;
			curspace.CurPlayer = this;
			facingdirection = step.Direction;
			curstep++;
			if (curstep == steplist.Count)
			{
				//Console.WriteLine("{0} finshed steplist", Name);
				curstep = 0;
				steplist.Clear();
			}
		}

		public Direction FacingDirection
		{
			get { return facingdirection; }
			set { facingdirection = value; }
		}
   }
}
