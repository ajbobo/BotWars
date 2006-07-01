using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BotWars
{
   public class MovementCard : IDataObject
   {
      public virtual string Name
      {
         get { return "NoOp"; }
      }

      public virtual string MoveString
      {
         get { return ""; }
      }

		public virtual int Occurances
		{
			get { return 0; }
		}

		public MovementCard MakeClone()
		{
			// Create the clone
			MovementCard res = (MovementCard)MemberwiseClone();

			// Update any variables that were not cloned correctly
			// Currently aren't any

			return res;
		}

		public virtual void Draw(Graphics g, bool ghost)
		{
			// Draws in a 36x50 pixel box
			Color color;
			if (ghost)
				color = Color.FromArgb(64, 255, 0, 0);
			else
				color = Color.FromArgb(255, 0, 0);
			Pen pen = new Pen(color, 5);

			g.DrawLine(pen, 12, 19, 24, 31);
			g.DrawLine(pen, 12, 31, 24, 19); 
		}

		#region IDataObject Members (partially complete)

		public object GetData(Type format)
		{
			return this;
		}

		public object GetData(string format)
		{
			if (format == "BotWars.MovementCard")
				return this;
			return null;
		}

		public object GetData(string format, bool autoConvert)
		{
			if (format == "BotWars.MovementCard")
				return this;
			return null;
		}

		public bool GetDataPresent(Type format)
		{
			return format == typeof(MovementCard);
		}

		public bool GetDataPresent(string format)
		{
			return format == "BotWars.MovementCard";
		}

		public bool GetDataPresent(string format, bool autoConvert)
		{
			return format == "BotWars.MovementCard";
		}

		public string[] GetFormats()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public string[] GetFormats(bool autoConvert)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void SetData(object data)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void SetData(Type format, object data)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void SetData(string format, object data)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void SetData(string format, bool autoConvert, object data)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion
	}
}
