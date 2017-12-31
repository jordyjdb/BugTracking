namespace BugManager
{
	partial class frmListBugs
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
            ((System.ComponentModel.ISupportInitialize)(this.grdBugs)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdBugs
            // 
            this.grdBugs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBugs.Location = new System.Drawing.Point(224, 32);
            this.grdBugs.Margin = new System.Windows.Forms.Padding(4);
            this.grdBugs.Name = "grdBugs";
            this.grdBugs.Size = new System.Drawing.Size(880, 361);
            this.grdBugs.TabIndex = 0;
            // 
            // btnCreateBug
            // 
            this.btnCreateBug.Location = new System.Drawing.Point(13, 32);
            this.btnCreateBug.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateBug.Name = "btnCreateBug";
            this.btnCreateBug.Size = new System.Drawing.Size(200, 28);
            this.btnCreateBug.TabIndex = 1;
            this.btnCreateBug.Text = "Create Bug";
            this.btnCreateBug.UseVisualStyleBackColor = true;
            this.btnCreateBug.Click += new System.EventHandler(this.btnCreateBug_Click);
            // 
            // btnApplication
            // 
            this.btnApplication.Location = new System.Drawing.Point(13, 104);
            this.btnApplication.Margin = new System.Windows.Forms.Padding(4);
            this.btnApplication.Name = "btnApplication";
            this.btnApplication.Size = new System.Drawing.Size(200, 28);
            this.btnApplication.TabIndex = 2;
            this.btnApplication.Text = "Manage Applications";
            this.btnApplication.UseVisualStyleBackColor = true;
            this.btnApplication.Click += new System.EventHandler(this.btnApplication_Click);
            // 
            // btnUpdateSelected
            // 
            this.btnUpdateSelected.Location = new System.Drawing.Point(13, 68);
            this.btnUpdateSelected.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateSelected.Name = "btnUpdateSelected";
            this.btnUpdateSelected.Size = new System.Drawing.Size(200, 28);
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
            this.menuStrip1.Size = new System.Drawing.Size(1120, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(13, 140);
            this.btnUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(200, 28);
            this.btnUser.TabIndex = 5;
            this.btnUser.Text = "Manage Users";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // frmListBugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 407);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnUpdateSelected);
            this.Controls.Add(this.btnApplication);
            this.Controls.Add(this.btnCreateBug);
            this.Controls.Add(this.grdBugs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListBugs";
            this.Text = "frmListBugs";
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
    }
}