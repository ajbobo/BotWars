namespace BotWars
{
	partial class ResizeForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.editWidth = new System.Windows.Forms.TextBox();
			this.editHeight = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.OKButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Width";
			// 
			// editWidth
			// 
			this.editWidth.Location = new System.Drawing.Point(49, 12);
			this.editWidth.Name = "editWidth";
			this.editWidth.Size = new System.Drawing.Size(101, 20);
			this.editWidth.TabIndex = 1;
			// 
			// editHeight
			// 
			this.editHeight.Location = new System.Drawing.Point(49, 39);
			this.editHeight.Name = "editHeight";
			this.editHeight.Size = new System.Drawing.Size(100, 20);
			this.editHeight.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Height";
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(73, 66);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 4;
			this.OKButton.Text = "&OK";
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// ResizeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(171, 104);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.editHeight);
			this.Controls.Add(this.editWidth);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ResizeForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Resize Map";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox editWidth;
		private System.Windows.Forms.TextBox editHeight;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button OKButton;
	}
}