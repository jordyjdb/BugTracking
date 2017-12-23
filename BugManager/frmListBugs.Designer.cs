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
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdBugs)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBugs
            // 
            this.grdBugs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBugs.Location = new System.Drawing.Point(224, 15);
            this.grdBugs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdBugs.Name = "grdBugs";
            this.grdBugs.Size = new System.Drawing.Size(880, 378);
            this.grdBugs.TabIndex = 0;
            // 
            // btnCreateBug
            // 
            this.btnCreateBug.Location = new System.Drawing.Point(16, 15);
            this.btnCreateBug.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateBug.Name = "btnCreateBug";
            this.btnCreateBug.Size = new System.Drawing.Size(200, 28);
            this.btnCreateBug.TabIndex = 1;
            this.btnCreateBug.Text = "Create Bug";
            this.btnCreateBug.UseVisualStyleBackColor = true;
            // 
            // btnApplication
            // 
            this.btnApplication.Location = new System.Drawing.Point(16, 50);
            this.btnApplication.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApplication.Name = "btnApplication";
            this.btnApplication.Size = new System.Drawing.Size(200, 28);
            this.btnApplication.TabIndex = 2;
            this.btnApplication.Text = "Manage Applications";
            this.btnApplication.UseVisualStyleBackColor = true;
            this.btnApplication.Click += new System.EventHandler(this.btnApplication_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 86);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // frmListBugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 407);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnApplication);
            this.Controls.Add(this.btnCreateBug);
            this.Controls.Add(this.grdBugs);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmListBugs";
            this.Text = "frmListBugs";
            this.Load += new System.EventHandler(this.frmListBugs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBugs)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView grdBugs;
		private System.Windows.Forms.Button btnCreateBug;
		private System.Windows.Forms.Button btnApplication;
		private System.Windows.Forms.Button button3;
	}
}