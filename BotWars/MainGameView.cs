using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace BotWars
{
   class MainGameView: Form
   {
      // Data members
      private GameData gdata;

      // GUI Control memebers
		private MainMenu TopMenu;
		private MenuItem FileMenu, FileQuit;
      private BoardControl boardcontrol;
		private ProgramControl programcontrol;

      public MainGameView(GameData ingdata)
      {
			Text = "BotWars";
         Width = 1020;
         Height = 760;
         gdata = ingdata;

			FileQuit = new MenuItem("&Quit", new EventHandler(OnFileQuit));
			FileMenu = new MenuItem("&File", new MenuItem[] { FileQuit });

			TopMenu = new MainMenu();
			TopMenu.MenuItems.AddRange(new MenuItem[] { FileMenu });
			this.Menu = TopMenu;

         boardcontrol = new BoardControl(gdata);
			boardcontrol.PlayerList = gdata.Players;
			boardcontrol.Size = new Size(610, 720);
         boardcontrol.Location = new Point(205, 5);
			boardcontrol.Selectable = false;
			boardcontrol.Anchor |= AnchorStyles.Right | AnchorStyles.Bottom;
         Controls.Add(boardcontrol);

			programcontrol = new ProgramControl();
			programcontrol.Size = new Size(200, 500);
			programcontrol.Location = new Point(820, 5);
			programcontrol.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
			programcontrol.ProgrammingDone += new EventHandler(NextPlayer);
			Controls.Add(programcontrol);

         CenterToScreen();
      }

		protected void OnFileQuit(object sender, EventArgs args)
		{
			DialogResult res = MessageBox.Show("Are you sure you want to quit?", "Quit BotWars?", MessageBoxButtons.YesNo);

			if (res == DialogResult.Yes)
			{
				gdata.GameOver = true;
				this.Close();
			}
		}

      protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
      {
         gdata.GameOver = true;
      }

		public void NextPlayer(object sender, EventArgs args)
		{
			gdata.CurrentPlayer += 1;
			Player player = gdata.GetPlayer(gdata.CurrentPlayer);
			programcontrol.ProgrammingPlayer = player;
		}
   }
}
