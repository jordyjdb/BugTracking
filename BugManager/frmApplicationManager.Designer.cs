namespace BugManager
{
	partial class frmApplicationManager
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
            this.grpApplication = new System.Windows.Forms.GroupBox();
            this.cboApplication = new System.Windows.Forms.ComboBox();
            this.grpFormDetails = new System.Windows.Forms.GroupBox();
            this.chkFormActive = new System.Windows.Forms.CheckBox();
            this.txtFormLabel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFormDetails = new System.Windows.Forms.Button();
            this.cboFormName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpControlDetails = new System.Windows.Forms.GroupBox();
            this.chkControlActive = new System.Windows.Forms.CheckBox();
            this.txtControlLabel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnControlDetails = new System.Windows.Forms.Button();
            this.cboControlName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpActionDetails = new System.Windows.Forms.GroupBox();
            this.txtActionDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnActionDetails = new System.Windows.Forms.Button();
            this.cboActionName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApplicationSave = new System.Windows.Forms.Button();
            this.cboDefaultUser = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpApplication.SuspendLayout();
            this.grpFormDetails.SuspendLayout();
            this.grpControlDetails.SuspendLayout();
            this.grpActionDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpApplication
            // 
            this.grpApplication.Controls.Add(this.label8);
            this.grpApplication.Controls.Add(this.cboDefaultUser);
            this.grpApplication.Controls.Add(this.cboApplication);
            this.grpApplication.Controls.Add(this.grpFormDetails);
            this.grpApplication.Controls.Add(this.label1);
            this.grpApplication.Controls.Add(this.grpControlDetails);
            this.grpApplication.Controls.Add(this.grpActionDetails);
            this.grpApplication.Controls.Add(this.panel1);
            this.grpApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpApplication.Location = new System.Drawing.Point(0, 0);
            this.grpApplication.Name = "grpApplication";
            this.grpApplication.Size = new System.Drawing.Size(377, 494);
            this.grpApplication.TabIndex = 0;
            this.grpApplication.TabStop = false;
            this.grpApplication.Text = "Application Details";
            // 
            // cboApplication
            // 
            this.cboApplication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboApplication.FormattingEnabled = true;
            this.cboApplication.Location = new System.Drawing.Point(132, 19);
            this.cboApplication.Name = "cboApplication";
            this.cboApplication.Size = new System.Drawing.Size(237, 24);
            this.cboApplication.TabIndex = 1;
            this.cboApplication.SelectedValueChanged += new System.EventHandler(this.cboApplication_SelectedValueChanged);
            this.cboApplication.TextChanged += new System.EventHandler(this.cboApplication_TextChanged);
            // 
            // grpFormDetails
            // 
            this.grpFormDetails.Controls.Add(this.chkFormActive);
            this.grpFormDetails.Controls.Add(this.txtFormLabel);
            this.grpFormDetails.Controls.Add(this.label5);
            this.grpFormDetails.Controls.Add(this.btnFormDetails);
            this.grpFormDetails.Controls.Add(this.cboFormName);
            this.grpFormDetails.Controls.Add(this.label2);
            this.grpFormDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpFormDetails.Enabled = false;
            this.grpFormDetails.Location = new System.Drawing.Point(3, 78);
            this.grpFormDetails.Name = "grpFormDetails";
            this.grpFormDetails.Size = new System.Drawing.Size(371, 127);
            this.grpFormDetails.TabIndex = 1;
            this.grpFormDetails.TabStop = false;
            this.grpFormDetails.Text = "Form Details";
            // 
            // chkFormActive
            // 
            this.chkFormActive.AutoSize = true;
            this.chkFormActive.Location = new System.Drawing.Point(128, 83);
            this.chkFormActive.Name = "chkFormActive";
            this.chkFormActive.Size = new System.Drawing.Size(68, 21);
            this.chkFormActive.TabIndex = 8;
            this.chkFormActive.Text = "Active";
            this.chkFormActive.UseVisualStyleBackColor = true;
            // 
            // txtFormLabel
            // 
            this.txtFormLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormLabel.Location = new System.Drawing.Point(128, 55);
            this.txtFormLabel.Name = "txtFormLabel";
            this.txtFormLabel.Size = new System.Drawing.Size(237, 22);
            this.txtFormLabel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Form label";
            // 
            // btnFormDetails
            // 
            this.btnFormDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFormDetails.Location = new System.Drawing.Point(290, 98);
            this.btnFormDetails.Name = "btnFormDetails";
            this.btnFormDetails.Size = new System.Drawing.Size(75, 23);
            this.btnFormDetails.TabIndex = 5;
            this.btnFormDetails.Text = "Add";
            this.btnFormDetails.UseVisualStyleBackColor = true;
            this.btnFormDetails.Click += new System.EventHandler(this.btnFormDetails_Click);
            // 
            // cboFormName
            // 
            this.cboFormName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFormName.FormattingEnabled = true;
            this.cboFormName.Location = new System.Drawing.Point(128, 24);
            this.cboFormName.Name = "cboFormName";
            this.cboFormName.Size = new System.Drawing.Size(237, 24);
            this.cboFormName.TabIndex = 4;
            this.cboFormName.TextChanged += new System.EventHandler(this.cboFormName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Form name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application name";
            // 
            // grpControlDetails
            // 
            this.grpControlDetails.Controls.Add(this.chkControlActive);
            this.grpControlDetails.Controls.Add(this.txtControlLabel);
            this.grpControlDetails.Controls.Add(this.label6);
            this.grpControlDetails.Controls.Add(this.btnControlDetails);
            this.grpControlDetails.Controls.Add(this.cboControlName);
            this.grpControlDetails.Controls.Add(this.label3);
            this.grpControlDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpControlDetails.Enabled = false;
            this.grpControlDetails.Location = new System.Drawing.Point(3, 205);
            this.grpControlDetails.Name = "grpControlDetails";
            this.grpControlDetails.Size = new System.Drawing.Size(371, 129);
            this.grpControlDetails.TabIndex = 2;
            this.grpControlDetails.TabStop = false;
            this.grpControlDetails.Text = "Controls Details";
            // 
            // chkControlActive
            // 
            this.chkControlActive.AutoSize = true;
            this.chkControlActive.Location = new System.Drawing.Point(129, 81);
            this.chkControlActive.Name = "chkControlActive";
            this.chkControlActive.Size = new System.Drawing.Size(68, 21);
            this.chkControlActive.TabIndex = 10;
            this.chkControlActive.Text = "Active";
            this.chkControlActive.UseVisualStyleBackColor = true;
            // 
            // txtControlLabel
            // 
            this.txtControlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtControlLabel.Location = new System.Drawing.Point(129, 53);
            this.txtControlLabel.Name = "txtControlLabel";
            this.txtControlLabel.Size = new System.Drawing.Size(237, 22);
            this.txtControlLabel.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Control label";
            // 
            // btnControlDetails
            // 
            this.btnControlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControlDetails.Location = new System.Drawing.Point(290, 100);
            this.btnControlDetails.Name = "btnControlDetails";
            this.btnControlDetails.Size = new System.Drawing.Size(75, 23);
            this.btnControlDetails.TabIndex = 5;
            this.btnControlDetails.Text = "Add";
            this.btnControlDetails.UseVisualStyleBackColor = true;
            this.btnControlDetails.Click += new System.EventHandler(this.btnControlDetails_Click);
            // 
            // cboControlName
            // 
            this.cboControlName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboControlName.FormattingEnabled = true;
            this.cboControlName.Location = new System.Drawing.Point(129, 24);
            this.cboControlName.Name = "cboControlName";
            this.cboControlName.Size = new System.Drawing.Size(236, 24);
            this.cboControlName.TabIndex = 4;
            this.cboControlName.SelectedIndexChanged += new System.EventHandler(this.cboControlName_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Control name";
            // 
            // grpActionDetails
            // 
            this.grpActionDetails.Controls.Add(this.txtActionDescription);
            this.grpActionDetails.Controls.Add(this.label7);
            this.grpActionDetails.Controls.Add(this.btnActionDetails);
            this.grpActionDetails.Controls.Add(this.cboActionName);
            this.grpActionDetails.Controls.Add(this.label4);
            this.grpActionDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpActionDetails.Enabled = false;
            this.grpActionDetails.Location = new System.Drawing.Point(3, 334);
            this.grpActionDetails.Name = "grpActionDetails";
            this.grpActionDetails.Size = new System.Drawing.Size(371, 114);
            this.grpActionDetails.TabIndex = 3;
            this.grpActionDetails.TabStop = false;
            this.grpActionDetails.Text = "Action Details";
            // 
            // txtActionDescription
            // 
            this.txtActionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActionDescription.Location = new System.Drawing.Point(129, 54);
            this.txtActionDescription.Name = "txtActionDescription";
            this.txtActionDescription.Size = new System.Drawing.Size(236, 22);
            this.txtActionDescription.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Action Description";
            // 
            // btnActionDetails
            // 
            this.btnActionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActionDetails.Location = new System.Drawing.Point(290, 85);
            this.btnActionDetails.Name = "btnActionDetails";
            this.btnActionDetails.Size = new System.Drawing.Size(75, 23);
            this.btnActionDetails.TabIndex = 5;
            this.btnActionDetails.Text = "Add";
            this.btnActionDetails.UseVisualStyleBackColor = true;
            this.btnActionDetails.Click += new System.EventHandler(this.btnActionDetails_Click);
            // 
            // cboActionName
            // 
            this.cboActionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboActionName.FormattingEnabled = true;
            this.cboActionName.Location = new System.Drawing.Point(129, 24);
            this.cboActionName.Name = "cboActionName";
            this.cboActionName.Size = new System.Drawing.Size(236, 24);
            this.cboActionName.TabIndex = 4;
            this.cboActionName.SelectedIndexChanged += new System.EventHandler(this.cboActionName_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Action name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApplicationSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 448);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 43);
            this.panel1.TabIndex = 4;
            // 
            // btnApplicationSave
            // 
            this.btnApplicationSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplicationSave.Enabled = false;
            this.btnApplicationSave.Location = new System.Drawing.Point(287, 11);
            this.btnApplicationSave.Name = "btnApplicationSave";
            this.btnApplicationSave.Size = new System.Drawing.Size(75, 23);
            this.btnApplicationSave.TabIndex = 2;
            this.btnApplicationSave.Text = "Save";
            this.btnApplicationSave.UseVisualStyleBackColor = true;
            this.btnApplicationSave.Click += new System.EventHandler(this.btnApplicationSave_Click);
            // 
            // cboDefaultUser
            // 
            this.cboDefaultUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDefaultUser.FormattingEnabled = true;
            this.cboDefaultUser.Location = new System.Drawing.Point(132, 50);
            this.cboDefaultUser.Name = "cboDefaultUser";
            this.cboDefaultUser.Size = new System.Drawing.Size(237, 24);
            this.cboDefaultUser.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Default User";
            // 
            // frmApplicationManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 494);
            this.Controls.Add(this.grpApplication);
            this.Name = "frmApplicationManager";
            this.Text = "frmApplicationManager";
            this.Load += new System.EventHandler(this.frmApplicationManager_Load);
            this.grpApplication.ResumeLayout(false);
            this.grpApplication.PerformLayout();
            this.grpFormDetails.ResumeLayout(false);
            this.grpFormDetails.PerformLayout();
            this.grpControlDetails.ResumeLayout(false);
            this.grpControlDetails.PerformLayout();
            this.grpActionDetails.ResumeLayout(false);
            this.grpActionDetails.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpApplication;
		private System.Windows.Forms.ComboBox cboApplication;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApplicationSave;
        private System.Windows.Forms.GroupBox grpFormDetails;
        private System.Windows.Forms.TextBox txtFormLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFormDetails;
        private System.Windows.Forms.ComboBox cboFormName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpControlDetails;
        private System.Windows.Forms.TextBox txtControlLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnControlDetails;
        private System.Windows.Forms.ComboBox cboControlName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpActionDetails;
        private System.Windows.Forms.Button btnActionDetails;
        private System.Windows.Forms.ComboBox cboActionName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkFormActive;
        private System.Windows.Forms.CheckBox chkControlActive;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtActionDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDefaultUser;
    }
}