namespace BugTracking
{
	partial class BugDetails
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BugDetails));
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.linkToBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lblTitle.Location = new System.Drawing.Point(4, 4);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(52, 26);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Title";
			// 
			// lblDescription
			// 
			this.lblDescription.AutoEllipsis = true;
			this.lblDescription.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lblDescription.Location = new System.Drawing.Point(4, 30);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(244, 46);
			this.lblDescription.TabIndex = 1;
			this.lblDescription.Text = "Description";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::BugTracking.Properties.Resources.ellipsis;
			this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
			this.pictureBox1.Location = new System.Drawing.Point(213, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(35, 36);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDetailsToolStripMenuItem,
            this.linkToBugToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
			// 
			// openDetailsToolStripMenuItem
			// 
			this.openDetailsToolStripMenuItem.Name = "openDetailsToolStripMenuItem";
			this.openDetailsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openDetailsToolStripMenuItem.Text = "Open Details";
			// 
			// linkToBugToolStripMenuItem
			// 
			this.linkToBugToolStripMenuItem.Name = "linkToBugToolStripMenuItem";
			this.linkToBugToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.linkToBugToolStripMenuItem.Text = "Link To Bug";
			// 
			// BugDetails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.lblTitle);
			this.Name = "BugDetails";
			this.Size = new System.Drawing.Size(251, 79);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem openDetailsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem linkToBugToolStripMenuItem;
	}
}
