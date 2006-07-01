using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace BotWars
{
	class MapEditor : Form
	{
		[STAThreadAttribute]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new MapEditor());
		}

		// Variables needed for data
		private Space[,] Board;
		private List<Space> SpacesAvailable;

		// Variables needed for the GUI
		private MainMenu TopMenu;
		private MenuItem FileMenu, FileNew, FileOpen, FileImport, FileSave, FileQuit;
		private MenuItem EditMenu, EditResize;
		private ListBox SpaceList;
		private CurrentSpace CurSpace;
		private MapViewer Viewer;
		private SpaceParameters Params;

		public MapEditor()
		{
			LoadSpaces();
			InitializeForm();
		}

		private void InitializeForm()
		{
			Text = "BotWars Map Editor";
			Width = 1020;
			Height = 760;
			CenterToScreen();

			FileNew = new MenuItem("&New",new EventHandler(OnFileNew));
			FileOpen = new MenuItem("&Open", new EventHandler(OnFileOpen));
			FileImport = new MenuItem("&Import", new EventHandler(OnFileImport));
			FileSave = new MenuItem("&Save", new EventHandler(OnFileSave));
			FileQuit = new MenuItem("&Quit", new EventHandler(OnFileQuit));
			FileMenu = new MenuItem("&File", new MenuItem[] 
				{ FileNew, FileOpen, FileImport, FileSave, new MenuItem("-"), FileQuit });

			EditResize = new MenuItem("&Resize Map",new EventHandler(OnEditResize));
			EditMenu = new MenuItem("&Edit",new MenuItem[]
				{ EditResize});

			TopMenu = new MainMenu();
			TopMenu.MenuItems.AddRange(new MenuItem[]
				{ FileMenu, EditMenu} );
			this.Menu = TopMenu;
			
			CurSpace = new CurrentSpace();
			CurSpace.Size = new Size(74, 74);
			CurSpace.Location = new Point(43, 5);
			CurSpace.CurSpace = SpacesAvailable[0];
			CurSpace.Parent = this;

			SpaceList = new ListBox();
			SpaceList.Location = new Point(5, 85);
			SpaceList.Size = new Size(150, 620);
			SpaceList.Sorted = false;
			foreach (Space space in SpacesAvailable)
			{
				SpaceList.Items.Add(space.Name);
			}
			SpaceList.SelectedIndex = 0;
			SpaceList.SelectedIndexChanged += new EventHandler(SelectedSpace);
			SpaceList.Anchor |= AnchorStyles.Bottom;
			SpaceList.Parent = this;
			
			Viewer = new MapViewer();
			Viewer.Location = new Point(160, 5);
			Viewer.Size = new Size(700, 695);
			Viewer.CurSpace = SpacesAvailable[0];
			Viewer.Anchor |= AnchorStyles.Right | AnchorStyles.Bottom;
			Viewer.Parent = this;

			Params = new SpaceParameters();
			Params.Location = new Point(865, 0);
			Params.Size = new Size(145, 701);
			Params.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
			Params.Parent = this;
			Viewer.OnActivatedSpace += new ActivatedSpaceHandler(Params.MakeActiveSpace);
		}

		private void LoadSpaces()
		{
			SpacesAvailable = new List<Space>();
			// Add the default space to the list of available Spaces
			SpacesAvailable.Add(new Space());
			// Load Spaces from files
			DirectoryInfo carddir = new DirectoryInfo("Spaces");
			if (carddir.Exists)
			{
				foreach (FileInfo curfile in carddir.GetFiles("*.dll"))
				{
					string filename = curfile.Name.Substring(0, curfile.Name.Length - 4);
					string path = "Spaces/" + filename + ".dll";
					string classname = "BotWars." + filename;
					try
					{
						Assembly assem = Assembly.LoadFrom(path);
						Space space = (Space)assem.CreateInstance(classname);
						SpacesAvailable.Add(space);
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
			else
			{
				MessageBox.Show("Unable to find Spaces directory", "Error loading Spaces.");
			}
		}

		private void SelectedSpace(object src, EventArgs e)
		{
			int index = SpaceList.SelectedIndex;
			CurSpace.CurSpace = SpacesAvailable[index];
			Viewer.CurSpace = SpacesAvailable[index];
			CurSpace.Invalidate();
		}

		private void OnFileNew(object arc, EventArgs e)
		{
			Board = null;
			Viewer.SetBoard(Board);
		}

		private void OnFileOpen(object arc, EventArgs e)
		{
			Board = XMLControl.LoadXMLFile(Board,SpacesAvailable);
			Viewer.InitializeView();
			Viewer.SetBoard(Board);
		}

		private void OnFileImport(object arc, EventArgs e)
		{
			MessageBox.Show("Feature not implemented yet", "File|Import");
		}

		private void OnFileSave(object arc, EventArgs e)
		{
			XMLControl.SaveXMLFile(Board);
		}

		private void OnFileQuit(object arc, EventArgs e)
		{
			DialogResult res = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo);
			if (res == DialogResult.Yes)
				Application.Exit();
		}

		private void OnEditResize(object src, EventArgs e)
		{
			int width, height;
			if (Board == null)
			{
				width = 0;
				height = 0;
			}
			else
			{
				width = Board.GetUpperBound(0) + 1;
				height = Board.GetUpperBound(1) + 1;
			}
			ResizeForm form = new ResizeForm(width, height);
			form.ShowDialog();
			if (form.DialogResult == DialogResult.OK)
			{
				Space[,] temp = Board;
				Board = new Space[form.BoardWidth, form.BoardHeight];
				if (temp != null) // Copy over the old board
				{
					int widthtocopy = Math.Min(width, form.BoardWidth);
					int heighttocopy = Math.Min(height, form.BoardHeight);
					for (int x = 0; x < widthtocopy; x++)
						for (int y = 0; y < heighttocopy; y++)
							Board[x, y] = temp[x, y];
				}
				Viewer.SetBoard(Board);
			}
		}
	}
}