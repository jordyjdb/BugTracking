namespace BugTracking
{
    partial class frmBugList
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
			this.grdBug = new System.Windows.Forms.DataGridView();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.cboRelated = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.grdBug)).BeginInit();
			this.SuspendLayout();
			// 
			// grdBug
			// 
			this.grdBug.AllowUserToAddRows = false;
			this.grdBug.AllowUserToDeleteRows = false;
			this.grdBug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grdBug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdBug.Location = new System.Drawing.Point(342, 6);
			this.grdBug.Name = "grdBug";
			this.grdBug.ReadOnly = true;
			this.grdBug.Size = new System.Drawing.Size(316, 169);
			this.grdBug.TabIndex = 0;
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(62, 6);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(274, 20);
			this.txtTitle.TabIndex = 1;
			// 
			// txtComment
			// 
			this.txtComment.Location = new System.Drawing.Point(62, 33);
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(274, 87);
			this.txtComment.TabIndex = 2;
			// 
			// cboRelated
			// 
			this.cboRelated.FormattingEnabled = true;
			this.cboRelated.Location = new System.Drawing.Point(62, 126);
			this.cboRelated.Name = "cboRelated";
			this.cboRelated.Size = new System.Drawing.Size(274, 21);
			this.cboRelated.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Title";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Comment";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 129);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Related";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(261, 153);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// frmBugList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(670, 181);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboRelated);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.grdBug);
			this.Name = "frmBugList";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdBug)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.DataGridView grdBug;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.ComboBox cboRelated;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSave;
	}
}

