namespace BotWars
{
   partial class GameSetup
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
			this.SetupTabs = new System.Windows.Forms.TabControl();
			this.PlayersTab = new System.Windows.Forms.TabPage();
			this.PlayersTableView = new System.Windows.Forms.DataGridView();
			this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PlayerImage = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.PlayersData = new System.Data.DataSet();
			this.PlayersTable = new System.Data.DataTable();
			this.NameCol = new System.Data.DataColumn();
			this.ImageCol = new System.Data.DataColumn();
			this.CardsTable = new System.Data.DataTable();
			this.CardFileNameCol = new System.Data.DataColumn();
			this.CardImportCol = new System.Data.DataColumn();
			this.SpacesTable = new System.Data.DataTable();
			this.SpaceFileNameCol = new System.Data.DataColumn();
			this.SpaceImportCol = new System.Data.DataColumn();
			this.ModsTable = new System.Data.DataTable();
			this.ModFileNameCol = new System.Data.DataColumn();
			this.ModImportCol = new System.Data.DataColumn();
			this.NumPlayers = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.MovementTab = new System.Windows.Forms.TabPage();
			this.CardsView = new System.Windows.Forms.DataGridView();
			this.CardFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CardImport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.SpacesTab = new System.Windows.Forms.TabPage();
			this.SpacesView = new System.Windows.Forms.DataGridView();
			this.SpaceFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SpaceImport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.label3 = new System.Windows.Forms.Label();
			this.ModificationsTab = new System.Windows.Forms.TabPage();
			this.ModsView = new System.Windows.Forms.DataGridView();
			this.ModFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ModImport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.label4 = new System.Windows.Forms.Label();
			this.OK = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.SetupTabs.SuspendLayout();
			this.PlayersTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PlayersTableView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PlayersData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PlayersTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CardsTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SpacesTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ModsTable)).BeginInit();
			this.MovementTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CardsView)).BeginInit();
			this.SpacesTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpacesView)).BeginInit();
			this.ModificationsTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModsView)).BeginInit();
			this.SuspendLayout();
			// 
			// SetupTabs
			// 
			this.SetupTabs.Controls.Add(this.PlayersTab);
			this.SetupTabs.Controls.Add(this.MovementTab);
			this.SetupTabs.Controls.Add(this.SpacesTab);
			this.SetupTabs.Controls.Add(this.ModificationsTab);
			this.SetupTabs.Location = new System.Drawing.Point(10, 10);
			this.SetupTabs.Name = "SetupTabs";
			this.SetupTabs.SelectedIndex = 0;
			this.SetupTabs.Size = new System.Drawing.Size(347, 240);
			this.SetupTabs.TabIndex = 0;
			// 
			// PlayersTab
			// 
			this.PlayersTab.Controls.Add(this.PlayersTableView);
			this.PlayersTab.Controls.Add(this.NumPlayers);
			this.PlayersTab.Controls.Add(this.label1);
			this.PlayersTab.Location = new System.Drawing.Point(4, 22);
			this.PlayersTab.Name = "PlayersTab";
			this.PlayersTab.Padding = new System.Windows.Forms.Padding(3);
			this.PlayersTab.Size = new System.Drawing.Size(339, 214);
			this.PlayersTab.TabIndex = 1;
			this.PlayersTab.Text = "Players";
			// 
			// PlayersTableView
			// 
			this.PlayersTableView.AllowUserToAddRows = false;
			this.PlayersTableView.AllowUserToDeleteRows = false;
			this.PlayersTableView.AutoGenerateColumns = false;
			this.PlayersTableView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName,
            this.PlayerImage});
			this.PlayersTableView.DataMember = "PlayersTable";
			this.PlayersTableView.DataSource = this.PlayersData;
			this.PlayersTableView.Location = new System.Drawing.Point(6, 32);
			this.PlayersTableView.Name = "PlayersTableView";
			this.PlayersTableView.RowHeadersVisible = false;
			this.PlayersTableView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.PlayersTableView.Size = new System.Drawing.Size(327, 175);
			this.PlayersTableView.TabIndex = 2;
			this.PlayersTableView.Text = "dataGridView1";
			// 
			// PlayerName
			// 
			this.PlayerName.DataPropertyName = "Name";
			this.PlayerName.HeaderText = "Name";
			this.PlayerName.Name = "PlayerName";
			this.PlayerName.Width = 183;
			// 
			// PlayerImage
			// 
			this.PlayerImage.DataPropertyName = "Image";
			this.PlayerImage.HeaderText = "Image";
			this.PlayerImage.Name = "PlayerImage";
			this.PlayerImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.PlayerImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.PlayerImage.Width = 120;
			// 
			// PlayersData
			// 
			this.PlayersData.DataSetName = "NewDataSet";
			this.PlayersData.Tables.AddRange(new System.Data.DataTable[] {
            this.PlayersTable,
            this.CardsTable,
            this.SpacesTable,
            this.ModsTable});
			// 
			// PlayersTable
			// 
			this.PlayersTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.NameCol,
            this.ImageCol});
			this.PlayersTable.TableName = "PlayersTable";
			// 
			// NameCol
			// 
			this.NameCol.ColumnName = "Name";
			// 
			// ImageCol
			// 
			this.ImageCol.Caption = "Image";
			this.ImageCol.ColumnName = "Image";
			this.ImageCol.DataType = typeof(object);
			// 
			// CardsTable
			// 
			this.CardsTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.CardFileNameCol,
            this.CardImportCol});
			this.CardsTable.TableName = "CardsTable";
			// 
			// CardFileNameCol
			// 
			this.CardFileNameCol.Caption = "FileName";
			this.CardFileNameCol.ColumnName = "FileName";
			this.CardFileNameCol.ReadOnly = true;
			// 
			// CardImportCol
			// 
			this.CardImportCol.Caption = "Import";
			this.CardImportCol.ColumnName = "Import";
			this.CardImportCol.DataType = typeof(bool);
			this.CardImportCol.DefaultValue = true;
			// 
			// SpacesTable
			// 
			this.SpacesTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.SpaceFileNameCol,
            this.SpaceImportCol});
			this.SpacesTable.TableName = "SpacesTable";
			// 
			// SpaceFileNameCol
			// 
			this.SpaceFileNameCol.ColumnName = "FileName";
			this.SpaceFileNameCol.ReadOnly = true;
			// 
			// SpaceImportCol
			// 
			this.SpaceImportCol.ColumnName = "Import";
			this.SpaceImportCol.DataType = typeof(bool);
			// 
			// ModsTable
			// 
			this.ModsTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.ModFileNameCol,
            this.ModImportCol});
			this.ModsTable.TableName = "ModsTable";
			// 
			// ModFileNameCol
			// 
			this.ModFileNameCol.Caption = "FileName";
			this.ModFileNameCol.ColumnName = "FileName";
			this.ModFileNameCol.ReadOnly = true;
			// 
			// ModImportCol
			// 
			this.ModImportCol.ColumnName = "Import";
			this.ModImportCol.DataType = typeof(bool);
			// 
			// NumPlayers
			// 
			this.NumPlayers.Location = new System.Drawing.Point(166, 6);
			this.NumPlayers.Name = "NumPlayers";
			this.NumPlayers.Size = new System.Drawing.Size(105, 20);
			this.NumPlayers.TabIndex = 1;
			this.NumPlayers.TextChanged += new System.EventHandler(this.NumPlayers_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(68, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Number of Players:";
			// 
			// MovementTab
			// 
			this.MovementTab.Controls.Add(this.CardsView);
			this.MovementTab.Controls.Add(this.label2);
			this.MovementTab.Location = new System.Drawing.Point(4, 22);
			this.MovementTab.Name = "MovementTab";
			this.MovementTab.Padding = new System.Windows.Forms.Padding(3);
			this.MovementTab.Size = new System.Drawing.Size(339, 214);
			this.MovementTab.TabIndex = 2;
			this.MovementTab.Text = "Movement";
			// 
			// CardsView
			// 
			this.CardsView.AllowUserToAddRows = false;
			this.CardsView.AllowUserToDeleteRows = false;
			this.CardsView.AutoGenerateColumns = false;
			this.CardsView.ColumnHeadersVisible = false;
			this.CardsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CardFileName,
            this.CardImport});
			this.CardsView.DataMember = "CardsTable";
			this.CardsView.DataSource = this.PlayersData;
			this.CardsView.Location = new System.Drawing.Point(7, 24);
			this.CardsView.Name = "CardsView";
			this.CardsView.RowHeadersVisible = false;
			this.CardsView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.CardsView.Size = new System.Drawing.Size(221, 183);
			this.CardsView.TabIndex = 1;
			this.CardsView.Text = "dataGridView1";
			// 
			// CardFileName
			// 
			this.CardFileName.DataPropertyName = "FileName";
			this.CardFileName.HeaderText = "FileName";
			this.CardFileName.Name = "CardFileName";
			this.CardFileName.ReadOnly = true;
			this.CardFileName.Width = 175;
			// 
			// CardImport
			// 
			this.CardImport.DataPropertyName = "Import";
			this.CardImport.HeaderText = "Import";
			this.CardImport.Name = "CardImport";
			this.CardImport.Width = 25;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(37, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(164, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Select movement cards to import:";
			// 
			// SpacesTab
			// 
			this.SpacesTab.Controls.Add(this.SpacesView);
			this.SpacesTab.Controls.Add(this.label3);
			this.SpacesTab.Location = new System.Drawing.Point(4, 22);
			this.SpacesTab.Name = "SpacesTab";
			this.SpacesTab.Padding = new System.Windows.Forms.Padding(3);
			this.SpacesTab.Size = new System.Drawing.Size(339, 214);
			this.SpacesTab.TabIndex = 3;
			this.SpacesTab.Text = "Spaces";
			// 
			// SpacesView
			// 
			this.SpacesView.AllowUserToAddRows = false;
			this.SpacesView.AllowUserToDeleteRows = false;
			this.SpacesView.AutoGenerateColumns = false;
			this.SpacesView.ColumnHeadersVisible = false;
			this.SpacesView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SpaceFileName,
            this.SpaceImport});
			this.SpacesView.DataMember = "SpacesTable";
			this.SpacesView.DataSource = this.PlayersData;
			this.SpacesView.Location = new System.Drawing.Point(7, 24);
			this.SpacesView.Name = "SpacesView";
			this.SpacesView.RowHeadersVisible = false;
			this.SpacesView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.SpacesView.Size = new System.Drawing.Size(221, 183);
			this.SpacesView.TabIndex = 3;
			this.SpacesView.Text = "dataGridView1";
			// 
			// SpaceFileName
			// 
			this.SpaceFileName.DataPropertyName = "FileName";
			this.SpaceFileName.HeaderText = "FileName";
			this.SpaceFileName.Name = "SpaceFileName";
			this.SpaceFileName.ReadOnly = true;
			this.SpaceFileName.Width = 175;
			// 
			// SpaceImport
			// 
			this.SpaceImport.DataPropertyName = "Import";
			this.SpaceImport.HeaderText = "Import";
			this.SpaceImport.Name = "SpaceImport";
			this.SpaceImport.Width = 25;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(59, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Select spaces to import:";
			// 
			// ModificationsTab
			// 
			this.ModificationsTab.Controls.Add(this.ModsView);
			this.ModificationsTab.Controls.Add(this.label4);
			this.ModificationsTab.Location = new System.Drawing.Point(4, 22);
			this.ModificationsTab.Name = "ModificationsTab";
			this.ModificationsTab.Padding = new System.Windows.Forms.Padding(3);
			this.ModificationsTab.Size = new System.Drawing.Size(339, 214);
			this.ModificationsTab.TabIndex = 4;
			this.ModificationsTab.Text = "Modifications";
			// 
			// ModsView
			// 
			this.ModsView.AllowUserToAddRows = false;
			this.ModsView.AllowUserToDeleteRows = false;
			this.ModsView.AutoGenerateColumns = false;
			this.ModsView.ColumnHeadersVisible = false;
			this.ModsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ModFileName,
            this.ModImport});
			this.ModsView.DataMember = "ModsTable";
			this.ModsView.DataSource = this.PlayersData;
			this.ModsView.Location = new System.Drawing.Point(7, 24);
			this.ModsView.Name = "ModsView";
			this.ModsView.RowHeadersVisible = false;
			this.ModsView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ModsView.Size = new System.Drawing.Size(221, 183);
			this.ModsView.TabIndex = 3;
			this.ModsView.Text = "dataGridView1";
			// 
			// ModFileName
			// 
			this.ModFileName.DataPropertyName = "FileName";
			this.ModFileName.HeaderText = "FileName";
			this.ModFileName.Name = "ModFileName";
			this.ModFileName.ReadOnly = true;
			this.ModFileName.Width = 175;
			// 
			// ModImport
			// 
			this.ModImport.DataPropertyName = "Import";
			this.ModImport.HeaderText = "Import";
			this.ModImport.Name = "ModImport";
			this.ModImport.Width = 25;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(46, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(147, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Select modifications to import:";
			// 
			// OK
			// 
			this.OK.Location = new System.Drawing.Point(200, 256);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(75, 23);
			this.OK.TabIndex = 1;
			this.OK.Text = "&OK";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// Cancel
			// 
			this.Cancel.Location = new System.Drawing.Point(281, 256);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 2;
			this.Cancel.Text = "&Cancel";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// dataGridViewComboBoxColumn1
			// 
			this.dataGridViewComboBoxColumn1.DataPropertyName = "Image";
			this.dataGridViewComboBoxColumn1.HeaderText = "Image";
			this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
			this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewComboBoxColumn1.Width = 120;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Image";
			this.dataGridViewTextBoxColumn1.HeaderText = "Image";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 120;
			// 
			// dataGridViewComboBoxColumn2
			// 
			this.dataGridViewComboBoxColumn2.DataPropertyName = "Image";
			this.dataGridViewComboBoxColumn2.HeaderText = "Image";
			this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
			this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewComboBoxColumn2.Width = 120;
			// 
			// GameSetup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(367, 289);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.OK);
			this.Controls.Add(this.SetupTabs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "GameSetup";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BotWars Setup";
			this.Load += new System.EventHandler(this.GameSetup_Load);
			this.SetupTabs.ResumeLayout(false);
			this.PlayersTab.ResumeLayout(false);
			this.PlayersTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PlayersTableView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PlayersData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PlayersTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CardsTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SpacesTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ModsTable)).EndInit();
			this.MovementTab.ResumeLayout(false);
			this.MovementTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CardsView)).EndInit();
			this.SpacesTab.ResumeLayout(false);
			this.SpacesTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpacesView)).EndInit();
			this.ModificationsTab.ResumeLayout(false);
			this.ModificationsTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ModsView)).EndInit();
			this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl SetupTabs;
      private System.Windows.Forms.TabPage PlayersTab;
      private System.Windows.Forms.Button OK;
      private System.Windows.Forms.Button Cancel;
      private System.Windows.Forms.DataGridView PlayersTableView;
      private System.Data.DataSet PlayersData;
      private System.Windows.Forms.TextBox NumPlayers;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TabPage MovementTab;
      private System.Windows.Forms.TabPage SpacesTab;
      private System.Windows.Forms.TabPage ModificationsTab;
      private System.Data.DataTable PlayersTable;
      private System.Data.DataColumn NameCol;
      private System.Data.DataTable CardsTable;
      private System.Windows.Forms.DataGridView CardsView;
      private System.Windows.Forms.Label label2;
      private System.Data.DataColumn CardFileNameCol;
      private System.Data.DataColumn CardImportCol;
      private System.Data.DataTable SpacesTable;
      private System.Data.DataColumn SpaceFileNameCol;
      private System.Data.DataTable ModsTable;
      private System.Data.DataColumn SpaceImportCol;
      private System.Data.DataColumn ModFileNameCol;
      private System.Data.DataColumn ModImportCol;
      private System.Windows.Forms.DataGridView SpacesView;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.DataGridView ModsView;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridViewTextBoxColumn CardFileName;
		private System.Windows.Forms.DataGridViewCheckBoxColumn CardImport;
		private System.Windows.Forms.DataGridViewTextBoxColumn SpaceFileName;
		private System.Windows.Forms.DataGridViewCheckBoxColumn SpaceImport;
		private System.Windows.Forms.DataGridViewTextBoxColumn ModFileName;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ModImport;
		private System.Data.DataColumn ImageCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
		private System.Windows.Forms.DataGridViewComboBoxColumn PlayerImage;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
   }
}