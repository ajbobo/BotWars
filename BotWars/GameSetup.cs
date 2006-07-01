using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Drawing;

namespace BotWars
{
   public partial class GameSetup : Form
   {
      private GameData gdata;

      public GameSetup(GameData ingdata)
      {
         gdata = ingdata;
         InitializeComponent();
      }

      private void GameSetup_Load(object sender, EventArgs e)
      {
         // Load Movement Cards
         DirectoryInfo curdir = new DirectoryInfo("Cards");
         CardsTable.Rows.Clear();
         if (curdir.Exists)
         {
            foreach (FileInfo curfile in curdir.GetFiles("*.dll"))
            {
               DataRow newrow = CardsTable.NewRow();
               string filename = curfile.Name.Substring(0, curfile.Name.Length - 4);
               newrow["FileName"] = filename;
               newrow["Import"] = true;
               CardsTable.Rows.Add(newrow);
            }
         }
         else
         {
            MessageBox.Show("Unable to find Cards directory","Error loading Movement Cards.");
         }
         // Load Spaces
         curdir = new DirectoryInfo("Spaces");
         SpacesTable.Rows.Clear();
         if (curdir.Exists)
         {
            foreach (FileInfo curfile in curdir.GetFiles("*.dll"))
            {
               DataRow newrow = SpacesTable.NewRow();
               string filename = curfile.Name.Substring(0, curfile.Name.Length - 4);
               newrow["FileName"] = filename;
               newrow["Import"] = true;
               SpacesTable.Rows.Add(newrow);
            }
         }
         else
         {
            MessageBox.Show("Unable to find Spaces directory", "Error loading Spaces.");
         }
         // Load Modifications
         curdir = new DirectoryInfo("Modifications");
         ModsTable.Rows.Clear();
         if (curdir.Exists)
         {
            foreach (FileInfo curfile in curdir.GetFiles("*.dll"))
            {
               DataRow newrow = ModsTable.NewRow();
               string filename = curfile.Name.Substring(0, curfile.Name.Length - 4);
               newrow["FileName"] = filename;
               newrow["Import"] = true;
               ModsTable.Rows.Add(newrow);
            }
         }
         else
         {
            MessageBox.Show("Unable to find Modifications directory", "Error loading Modifications.");
         }
			// Load PlayerImages
			curdir = new DirectoryInfo("PlayerImages");
			PlayerImage.Items.Clear();
			if (curdir.Exists)
			{
				foreach (FileInfo curfile in curdir.GetFiles("*.bmp"))
				{
					string filename = curfile.Name.Substring(0, curfile.Name.Length - 4);
					PlayerImage.Items.Add(filename);
				}
			}
			else
			{
				MessageBox.Show("Unable to find PlayerImages directory", "Error loading PlayerImages.");
			}
      }

      private void NumPlayers_TextChanged(object sender, EventArgs e)
      {
         int numplayers = 0;
         try
         {
            numplayers = int.Parse(NumPlayers.Text);
         }
         catch (Exception ex) { string temp = ex.ToString(); }
         int numrows = PlayersTable.Rows.Count;

         if (numplayers > numrows) // Add players
         {
            for (int x = numrows + 1; x <= numplayers; x++)
            {
               DataRow PlayerRow = PlayersTable.NewRow();
               PlayerRow["Name"] = "Player_" + x;
					PlayerRow["Image"] = PlayerImage.Items[0]; 
					PlayersTable.Rows.Add(PlayerRow);
            }
         }
         else if (numplayers < numrows) // Remove rows
         {
            for (int x = 0; x < numrows - numplayers; x++)
               PlayersTable.Rows.RemoveAt(PlayersTable.Rows.Count - 1);
         }
      }

      private void OK_Click(object sender, EventArgs e)
      {
         try
         {
            LoadPlayers();
            LoadCards();
            LoadSpaces();
            LoadMods();
         }
         catch (Exception ex)
         {
            string dummy = ex.Message;
            return;
         }
         DialogResult = DialogResult.OK;
      }

      private void Cancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
      }

      private void LoadPlayers()
      {
         // Add players to gdata
         if (PlayersTable.Rows.Count == 0)
         {
            MessageBox.Show("You need at least one player.", "Not enough players.");
            throw new Exception();
         }
         for (int x = 0; x < PlayersTable.Rows.Count; x++)
         {
            Player player = new Player();
            player.Name = (string)PlayersTable.Rows[x][0];
				player.PlayerImage = LoadPlayerImage((string)PlayersTable.Rows[x][1]);
            gdata.AddPlayer(player);
         }
      }

		private Image LoadPlayerImage(string filename)
		{
			Bitmap playerimage = null;
			try
			{
				// Find a way to only load the needed images once each - FINISH ME 
				playerimage = new Bitmap("PlayerImages\\" + filename + ".bmp");
				playerimage.MakeTransparent(Color.FromArgb(255,0,255));
			}
			catch (Exception ex)
			{
				string dummy = ex.Message;
				MessageBox.Show("Unable to load player image: " + filename, "Error loading playerimage");
			}
			return playerimage;
		}

      private void LoadCards()
      {
         // For each card file selected, add an instance of its Card to gdata
         for (int x = 0; x < CardsTable.Rows.Count; x++)
         {
            if ((bool)CardsTable.Rows[x].ItemArray[1])
            {
               string filename = (string)CardsTable.Rows[x][0];
               string path = "Cards/" + filename + ".dll";
               string classname = "BotWars." + filename;
               try
               {
                  Assembly assem = Assembly.LoadFrom(path);
                  MovementCard card = (MovementCard)assem.CreateInstance(classname);
                  gdata.AddCard(card);
               }
               catch (Exception ex)
               {
                  string dummy = ex.Message;
                  MessageBox.Show(
                     "Unable to load movement card from: " + filename + ".dll",
                     "Error Loading Movement Card"
                  );
               }
            }
         }
      }

      private void LoadSpaces()
      {
         // Add the default Space to gdata
         gdata.AddSpace(new Space());
         // For each space file selected, add an instance of its Space to gdata
         for (int x = 0; x < SpacesTable.Rows.Count; x++)
         {
            if ((bool)SpacesTable.Rows[x].ItemArray[1])
            {
               string filename = (string)SpacesTable.Rows[x][0];
               string path = "Spaces/" + filename + ".dll";
               string classname = "BotWars." + filename;
               try
               {
                  Assembly assem = Assembly.LoadFrom(path);
                  Space space = (Space)assem.CreateInstance(classname);
                  gdata.AddSpace(space);
               }
               catch (Exception ex)
               {
                  string dummy = ex.Message;
                  MessageBox.Show(
                     "Unable to load space from: " + filename + ".dll",
                     "Error Loading Space"
                  );
               }
            }
         }
      }

      private void LoadMods()
      {
         // For each modification file selected, add an instance of its Modification to gdata
         for (int x = 0; x < ModsTable.Rows.Count; x++)
         {
            if ((bool)ModsTable.Rows[x].ItemArray[1])
            {
               string filename = (string)ModsTable.Rows[x][0];
               string path = "Modifications/" + filename + ".dll";
               string classname = "BotWars." + filename;
               try
               {
                  Assembly assem = Assembly.LoadFrom(path);
                  Modification mod = (Modification)assem.CreateInstance(classname);
                  gdata.AddModification(mod);
               }
               catch (Exception ex)
               {
                  string dummy = ex.Message;
                  MessageBox.Show(
                     "Unable to load modification from: " + filename + ".dll",
                     "Error Loading Modification"
                  );
               }
            }
         }
      }
   }
}