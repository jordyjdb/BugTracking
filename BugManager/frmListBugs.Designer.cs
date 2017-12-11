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
			this.button2 = new System.Windows.Forms.Button();
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
			this.grdBugs.Location = new System.Drawing.Point(168, 12);
			this.grdBugs.Name = "grdBugs";
			this.grdBugs.Size = new System.Drawing.Size(660, 307);
			this.grdBugs.TabIndex = 0;
			// 
			// btnCreateBug
			// 
			this.btnCreateBug.Location = new System.Drawing.Point(12, 12);
			this.btnCreateBug.Name = "btnCreateBug";
			this.btnCreateBug.Size = new System.Drawing.Size(91, 23);
			this.btnCreateBug.TabIndex = 1;
			this.btnCreateBug.Text = "Create Bug";
			this.btnCreateBug.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 41);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 70);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// frmListBugs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(840, 331);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btnCreateBug);
			this.Controls.Add(this.grdBugs);
			this.Name = "frmListBugs";
			this.Text = "frmListBugs";
			this.Load += new System.EventHandler(this.frmListBugs_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdBugs)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView grdBugs;
		private System.Windows.Forms.Button btnCreateBug;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}