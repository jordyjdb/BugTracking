namespace BugManager
{
	partial class FrmListBugs
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
			this.grdBugs = new System.Windows.Forms.DataGridView();
			this.btnCreateBug = new System.Windows.Forms.Button();
			this.btnApplication = new System.Windows.Forms.Button();
			this.btnUpdateSelected = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnUser = new System.Windows.Forms.Button();
			this.chkOpen = new System.Windows.Forms.CheckBox();
			this.cboFilters = new System.Windows.Forms.ComboBox();
			this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.grdBugs)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdBugs
			// 
			this.grdBugs.AllowUserToAddRows = false;
			this.grdBugs.AllowUserToDeleteRows = false;
			this.grdBugs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grdBugs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.grdBugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdBugs.Location = new System.Drawing.Point(247, 26);
			this.grdBugs.Name = "grdBugs";
			this.grdBugs.ReadOnly = true;
			this.grdBugs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdBugs.Size = new System.Drawing.Size(581, 293);
			this.grdBugs.TabIndex = 0;
			// 
			// btnCreateBug
			// 
			this.btnCreateBug.Location = new System.Drawing.Point(10, 26);
			this.btnCreateBug.Name = "btnCreateBug";
			this.btnCreateBug.Size = new System.Drawing.Size(150, 23);
			this.btnCreateBug.TabIndex = 1;
			this.btnCreateBug.Text = "Create Bug";
			this.btnCreateBug.UseVisualStyleBackColor = true;
			this.btnCreateBug.Click += new System.EventHandler(this.btnCreateBug_Click);
			// 
			// btnApplication
			// 
			this.btnApplication.Location = new System.Drawing.Point(10, 84);
			this.btnApplication.Name = "btnApplication";
			this.btnApplication.Size = new System.Drawing.Size(150, 23);
			this.btnApplication.TabIndex = 2;
			this.btnApplication.Text = "Manage Applications";
			this.btnApplication.UseVisualStyleBackColor = true;
			this.btnApplication.Click += new System.EventHandler(this.btnApplication_Click);
			// 
			// btnUpdateSelected
			// 
			this.btnUpdateSelected.Location = new System.Drawing.Point(10, 55);
			this.btnUpdateSelected.Name = "btnUpdateSelected";
			this.btnUpdateSelected.Size = new System.Drawing.Size(150, 23);
			this.btnUpdateSelected.TabIndex = 3;
			this.btnUpdateSelected.Text = "Update Selected bug";
			this.btnUpdateSelected.UseVisualStyleBackColor = true;
			this.btnUpdateSelected.Click += new System.EventHandler(this.btnUpdateSelected_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(840, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// logOutToolStripMenuItem
			// 
			this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
			this.logOutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.logOutToolStripMenuItem.Text = "Log out";
			this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.settingsToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// btnUser
			// 
			this.btnUser.Location = new System.Drawing.Point(10, 114);
			this.btnUser.Name = "btnUser";
			this.btnUser.Size = new System.Drawing.Size(150, 23);
			this.btnUser.TabIndex = 5;
			this.btnUser.Text = "Manage Users";
			this.btnUser.UseVisualStyleBackColor = true;
			this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
			// 
			// chkOpen
			// 
			this.chkOpen.AutoSize = true;
			this.chkOpen.Checked = true;
			this.chkOpen.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOpen.Location = new System.Drawing.Point(167, 28);
			this.chkOpen.Name = "chkOpen";
			this.chkOpen.Size = new System.Drawing.Size(74, 17);
			this.chkOpen.TabIndex = 6;
			this.chkOpen.Text = "Only open";
			this.chkOpen.UseVisualStyleBackColor = true;
			this.chkOpen.CheckedChanged += new System.EventHandler(this.chkOpen_CheckedChanged);
			// 
			// cboFilters
			// 
			this.cboFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFilters.FormattingEnabled = true;
			this.cboFilters.Location = new System.Drawing.Point(167, 51);
			this.cboFilters.Name = "cboFilters";
			this.cboFilters.Size = new System.Drawing.Size(74, 21);
			this.cboFilters.TabIndex = 7;
			this.cboFilters.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
			// 
			// helpToolStripMenuItem1
			// 
			this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
			this.helpToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.helpToolStripMenuItem1.Text = "Help";
			this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// FrmListBugs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(840, 331);
			this.Controls.Add(this.cboFilters);
			this.Controls.Add(this.chkOpen);
			this.Controls.Add(this.btnUser);
			this.Controls.Add(this.btnUpdateSelected);
			this.Controls.Add(this.btnApplication);
			this.Controls.Add(this.btnCreateBug);
			this.Controls.Add(this.grdBugs);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmListBugs";
			this.Text = "Main Menu";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmListBugs_FormClosed);
			this.Load += new System.EventHandler(this.frmListBugs_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdBugs)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView grdBugs;
		private System.Windows.Forms.Button btnCreateBug;
		private System.Windows.Forms.Button btnApplication;
		private System.Windows.Forms.Button btnUpdateSelected;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnUser;
		private System.Windows.Forms.CheckBox chkOpen;
		private System.Windows.Forms.ComboBox cboFilters;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
	}
}