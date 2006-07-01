using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace BotWars
{
	public static class XMLControl
	{
		public static void SaveXMLFile(Space[,] Board)
		{
			int width = Board.GetUpperBound(0) + 1;
			int height = Board.GetUpperBound(1) + 1;

			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "Map Files (.map)|*.map|All Files (*.*)|*.*";
			dialog.FilterIndex = 1;
			dialog.RestoreDirectory = true;

			if (dialog.ShowDialog() != DialogResult.OK)
				return;

			string filename = dialog.FileName;

			// Open and start the document
			XmlTextWriter writer = new XmlTextWriter(filename, null);
			writer.Formatting = Formatting.Indented;
			writer.WriteStartDocument();

			// Start the <board> tag
			writer.WriteStartElement("board");
			writer.WriteAttributeString("width",width.ToString());
			writer.WriteAttributeString("height",height.ToString());

			// Write each <space> tag
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					Space curspace = Board[x, y];
					if (curspace == null)
						continue;

					// Start the <space> tag
					writer.WriteStartElement("space");
					writer.WriteAttributeString("class", curspace.Name);
					writer.WriteAttributeString("xloc", x.ToString());
					writer.WriteAttributeString("yloc", y.ToString());

					// Add tags for all of the possible variables
					WriteVariable(writer, "pit", curspace.IsPit.ToString());
					WriteVariable(writer, "wallnorth", curspace.IsWall(Direction.North).ToString());
					WriteVariable(writer, "wallsouth", curspace.IsWall(Direction.South).ToString());
					WriteVariable(writer, "walleast", curspace.IsWall(Direction.East).ToString());
					WriteVariable(writer, "wallwest", curspace.IsWall(Direction.West).ToString());
					for (int reg = 1; reg <= 5; reg++)
					{
						string varname = "register" + reg.ToString();
						WriteVariable(writer, varname, curspace.IsRegisterActive(reg).ToString());
					}
					WriteVariable(writer, "entry", curspace.IsEntry.ToString());

					// End the <space> tag
					writer.WriteEndElement();
				}
			}

			// End the <board> tag
			writer.WriteEndElement();

			// Close up and clean up the document
			writer.WriteEndDocument();
			writer.Flush();
			writer.Close();
		}

		public static Space[,] LoadXMLFile(Space[,] Board, List<Space> spacelist)
		{
			Space[,] temp = new Space[0,0];
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Map Files {*.map)|*.map|All Files (*.*)|*.*";
			dialog.FilterIndex = 1;
			dialog.RestoreDirectory = true;
			dialog.InitialDirectory = "c:"; // Set this to something better later - FINISH ME 

			if (dialog.ShowDialog() != DialogResult.OK)
				return Board;

			string filename = dialog.FileName;

			XmlTextReader reader = new XmlTextReader(filename);
			reader.WhitespaceHandling = WhitespaceHandling.None;

			Space curspace = null;
			while (reader.Read())
			{
				if (reader.NodeType != XmlNodeType.Element)
					continue;

				if (reader.Name == "board")
				{
					int width = int.Parse(reader.GetAttribute("width"));
					int height = int.Parse(reader.GetAttribute("height"));
					temp = new Space[width, height];
				}
				else if (reader.Name == "space")
				{
					int xloc = int.Parse(reader.GetAttribute("xloc"));
					int yloc = int.Parse(reader.GetAttribute("yloc"));
					string classname = reader.GetAttribute("class");
					curspace = null;
					for (int cnt = 0; cnt < spacelist.Count && curspace == null; cnt++)
					{
						if (spacelist[cnt].Name == classname)
							curspace = spacelist[cnt].MakeClone();
					}
					if (curspace == null) // Didn't find the right space type - use the default
						curspace = spacelist[0].MakeClone();
					temp[xloc, yloc] = curspace;
					curspace.BoardX = xloc;
					curspace.BoardY = yloc;
				}
				else if (reader.Name == "pit")
				{
					curspace.IsPit = ReadBoolVariable(reader);
				}
				else if (reader.Name == "wallnorth")
				{
					curspace.SetWall(Direction.North, ReadBoolVariable(reader));
				}
				else if (reader.Name == "wallsouth")
				{
					curspace.SetWall(Direction.South, ReadBoolVariable(reader));
				}
				else if (reader.Name == "walleast")
				{
					curspace.SetWall(Direction.East, ReadBoolVariable(reader));
				}
				else if (reader.Name == "wallwest")
				{
					curspace.SetWall(Direction.West, ReadBoolVariable(reader));
				}
				else if (reader.Name == "register1")
				{
					curspace.SetRegisterActive(1, ReadBoolVariable(reader));
				}

				else if (reader.Name == "register2")
				{
					curspace.SetRegisterActive(2, ReadBoolVariable(reader));
				}
				else if (reader.Name == "register3")
				{
					curspace.SetRegisterActive(3, ReadBoolVariable(reader));
				}
				else if (reader.Name == "register4")
				{
					curspace.SetRegisterActive(4, ReadBoolVariable(reader));
				}
				else if (reader.Name == "register5")
				{
					curspace.SetRegisterActive(5, ReadBoolVariable(reader));
				}
				else if (reader.Name == "entry")
				{
					curspace.IsEntry = ReadBoolVariable(reader);
				}
			}
			reader.Close();
			return temp;
		}

		private static void WriteVariable(XmlWriter writer, string varname, string val)
		{
			writer.WriteStartElement(varname);
			writer.WriteAttributeString("value", val);
			writer.WriteEndElement();
		}

		private static bool ReadBoolVariable(XmlReader reader)
		{
			return bool.Parse(reader.GetAttribute("value"));
		}

		private static int ReadIntVariable(XmlReader reader)
		{
			return int.Parse(reader.GetAttribute("value"));
		}

		private static float ReadFloatVariable(XmlReader reader)
		{
			return float.Parse(reader.GetAttribute("value"));
		}

		private static string ReadStringVariable(XmlReader reader)
		{
			return reader.GetAttribute("value");
		}
	}
}
