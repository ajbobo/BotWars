using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BotWars
{
	public partial class ResizeForm : Form
	{

		public int BoardWidth, BoardHeight;

		public ResizeForm(int width, int height)
		{
			InitializeComponent();
			BoardWidth = width;
			BoardHeight = height;
			editWidth.Text = width.ToString();
			editHeight.Text = height.ToString();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			BoardWidth = int.Parse(editWidth.Text);
			BoardHeight = int.Parse(editHeight.Text);

			DialogResult = DialogResult.OK;
		}
	}
}