using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BotWars
{
	class WallButton : Button
	{
		private Direction dir;
		private bool Open;

		public WallButton(Direction indir)
			: base()
		{
			dir = indir;
			BackColor = Color.Green;
		}

		public Direction Dir
		{
			get { return dir; }
		}

		public bool IsWall
		{
			get { return !Open; }
			set
			{
				Open = !value;
				if (Open)
					BackColor = Color.Green;
				else
					BackColor = Color.Red;
			}
		}
	}

	class RegisterButton : Button
	{
		private int register;
		private bool active;

		public RegisterButton(int Register)
			: base()
		{
			register = Register;
			BackColor = Color.Green;
		}

		public int Register
		{
			get { return register; }
		}

		public bool IsActive
		{
			get { return active; }
			set
			{
				active = value;
				if (active)
					BackColor = Color.Green;
				else
					BackColor = Color.Red;
			}
		}
	}

	class SpaceParameters : GroupBox
	{
		private Space curspace;

		private CheckBox Pit;
		private Label WallLabel;
		private WallButton WallNorth, WallEast, WallSouth, WallWest;
		private Label RegisterLabel;
		private RegisterButton[] RegButtons;
		private CheckBox Entry;

		public SpaceParameters()
			: base()
		{
			Text = "Space Parameters";
			curspace = null;

			Pit = new CheckBox();
			Pit.Text = "Is Pit";
			Pit.Location = new Point(5, 15);
			Pit.Checked = false;
			Pit.Click += new EventHandler(OnPitChecked);
			Pit.Parent = this;

			WallLabel = new Label();
			WallLabel.Text = "Walls";
			WallLabel.Location = new Point(33, 76);
			WallLabel.Size = new Size(35,15);
			WallLabel.Parent = this; 
			
			WallNorth = new WallButton(Direction.North);
			WallNorth.Location = new Point(25,40);
			WallNorth.Size = new Size(45, 20);
			WallNorth.Click += new EventHandler(OnWallButton);
			WallNorth.Parent = this;

			WallSouth = new WallButton(Direction.South);
			WallSouth.Location = new Point(25, 105);
			WallSouth.Size = new Size(45, 20);
			WallSouth.Click += new EventHandler(OnWallButton);
			WallSouth.Parent = this;

			WallEast = new WallButton(Direction.East);
			WallEast.Location = new Point(70, 60);
			WallEast.Size = new Size(20, 45);
			WallEast.Click += new EventHandler(OnWallButton);
			WallEast.Parent = this;

			WallWest = new WallButton(Direction.West);
			WallWest.Location = new Point(5, 60);
			WallWest.Size = new Size(20, 45);
			WallWest.Click += new EventHandler(OnWallButton);
			WallWest.Parent = this;

			RegisterLabel = new Label();
			RegisterLabel.Text = "Registers";
			RegisterLabel.Location = new Point(10, 130);
			RegisterLabel.Size = new Size(75, 15);
			RegisterLabel.Parent = this;

			RegButtons = new RegisterButton[5];
			for (int reg = 0; reg < 5; reg++)
			{
				RegButtons[reg] = new RegisterButton(reg + 1);
				RegButtons[reg].Location = new Point(5 + reg * 16,150);
				RegButtons[reg].Size = new Size(15, 15);
				RegButtons[reg].Click += new EventHandler(OnRegisterButton);
				RegButtons[reg].Parent = this;
			}

			Entry = new CheckBox();
			Entry.Text = "Is Entry Point";
			Entry.Location = new Point(5, 170);
			Entry.Checked = false;
			Entry.Click += new EventHandler(OnEntryChecked);
			Entry.Parent = this;
		}

		public void MakeActiveSpace(Space space)
		{
			curspace = space;
			UpdateControls();
		}

		private void UpdateControls()
		{
			// Set the controls to display the options for the currently active space
			if (curspace != null)
			{
				Pit.Checked = curspace.IsPit;
				WallNorth.IsWall = curspace.IsWall(Direction.North);
				WallSouth.IsWall = curspace.IsWall(Direction.South);
				WallEast.IsWall = curspace.IsWall(Direction.East);
				WallWest.IsWall = curspace.IsWall(Direction.West);
				for (int reg = 0; reg < 5; reg++)
					RegButtons[reg].IsActive = curspace.IsRegisterActive(reg + 1);
				Entry.Checked = curspace.IsEntry;
			}
			else
			{
				Pit.Checked = false;
				WallNorth.IsWall = false;
				WallSouth.IsWall = false;
				WallEast.IsWall = false;
				WallWest.IsWall = false;
				for (int reg = 0; reg < 5; reg++)
					RegButtons[reg].IsActive = true;
				Entry.Checked = false;
			}

			Invalidate();
		}

		private void OnPitChecked(object src, EventArgs e)
		{
			curspace.IsPit = Pit.Checked;
		}

		private void OnWallButton(object src, EventArgs e)
		{
			if (curspace == null)
				return;

			WallButton button = (WallButton)src;
			Direction dir = button.Dir;

			bool iswall = curspace.IsWall(dir);

			button.IsWall = !iswall;
			curspace.SetWall(dir, !iswall);
		}

		private void OnRegisterButton(object src, EventArgs e)
		{
			if (curspace == null)
				return;

			RegisterButton button = (RegisterButton)src;
			int reg = button.Register;
			bool active = curspace.IsRegisterActive(reg);

			button.IsActive = !active;
			curspace.SetRegisterActive(reg, !active);
		}

		private void OnEntryChecked(object src, EventArgs e)
		{
			curspace.IsEntry = Entry.Checked;
		}
	}
}
