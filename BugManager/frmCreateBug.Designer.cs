﻿namespace BugManager
{
	partial class FrmCreateBug
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.cboAction = new System.Windows.Forms.ComboBox();
			this.cboApplication = new System.Windows.Forms.ComboBox();
			this.cboFormName = new System.Windows.Forms.ComboBox();
			this.cboControlName = new System.Windows.Forms.ComboBox();
			this.grpBugdetails = new System.Windows.Forms.GroupBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.grpCodeSnippet = new System.Windows.Forms.GroupBox();
			this.btnAddCode = new System.Windows.Forms.Button();
			this.wbCode = new System.Windows.Forms.WebBrowser();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.grdBugHistory = new System.Windows.Forms.DataGridView();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label13 = new System.Windows.Forms.Label();
			this.txtDateCreated = new System.Windows.Forms.TextBox();
			this.grpManagement = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.chkOpen = new System.Windows.Forms.CheckBox();
			this.cboAssignedUser = new System.Windows.Forms.ComboBox();
			this.txtPriority = new System.Windows.Forms.TextBox();
			this.grpCodeDetails = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtStartLineNumber = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtRelatedMethod = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtEndLineNumber = new System.Windows.Forms.TextBox();
			this.txtParameter = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.grpBugdetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.grpCodeSnippet.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdBugHistory)).BeginInit();
			this.panel3.SuspendLayout();
			this.grpManagement.SuspendLayout();
			this.grpCodeDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Title";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Comment";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 406);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Application Name";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 432);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "From Name";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(272, 406);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Control Name";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(272, 432);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Action";
			// 
			// txtTitle
			// 
			this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTitle.Location = new System.Drawing.Point(106, 14);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(414, 20);
			this.txtTitle.TabIndex = 13;
			// 
			// txtComment
			// 
			this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtComment.Location = new System.Drawing.Point(0, 0);
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(204, 356);
			this.txtComment.TabIndex = 14;
			// 
			// cboAction
			// 
			this.cboAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAction.FormattingEnabled = true;
			this.cboAction.Location = new System.Drawing.Point(373, 427);
			this.cboAction.Name = "cboAction";
			this.cboAction.Size = new System.Drawing.Size(131, 21);
			this.cboAction.TabIndex = 26;
			// 
			// cboApplication
			// 
			this.cboApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cboApplication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboApplication.FormattingEnabled = true;
			this.cboApplication.Location = new System.Drawing.Point(106, 402);
			this.cboApplication.Name = "cboApplication";
			this.cboApplication.Size = new System.Drawing.Size(131, 21);
			this.cboApplication.TabIndex = 32;
			this.cboApplication.SelectedIndexChanged += new System.EventHandler(this.cboApplication_SelectedIndexChanged);
			// 
			// cboFormName
			// 
			this.cboFormName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cboFormName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFormName.FormattingEnabled = true;
			this.cboFormName.Location = new System.Drawing.Point(106, 427);
			this.cboFormName.Name = "cboFormName";
			this.cboFormName.Size = new System.Drawing.Size(131, 21);
			this.cboFormName.TabIndex = 33;
			// 
			// cboControlName
			// 
			this.cboControlName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cboControlName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboControlName.FormattingEnabled = true;
			this.cboControlName.Location = new System.Drawing.Point(373, 402);
			this.cboControlName.Name = "cboControlName";
			this.cboControlName.Size = new System.Drawing.Size(131, 21);
			this.cboControlName.TabIndex = 34;
			// 
			// grpBugdetails
			// 
			this.grpBugdetails.Controls.Add(this.label15);
			this.grpBugdetails.Controls.Add(this.label14);
			this.grpBugdetails.Controls.Add(this.splitContainer1);
			this.grpBugdetails.Controls.Add(this.label1);
			this.grpBugdetails.Controls.Add(this.label2);
			this.grpBugdetails.Controls.Add(this.cboControlName);
			this.grpBugdetails.Controls.Add(this.label3);
			this.grpBugdetails.Controls.Add(this.cboFormName);
			this.grpBugdetails.Controls.Add(this.label4);
			this.grpBugdetails.Controls.Add(this.cboApplication);
			this.grpBugdetails.Controls.Add(this.label5);
			this.grpBugdetails.Controls.Add(this.label6);
			this.grpBugdetails.Controls.Add(this.txtTitle);
			this.grpBugdetails.Controls.Add(this.cboAction);
			this.grpBugdetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpBugdetails.Location = new System.Drawing.Point(0, 0);
			this.grpBugdetails.Margin = new System.Windows.Forms.Padding(2);
			this.grpBugdetails.Name = "grpBugdetails";
			this.grpBugdetails.Padding = new System.Windows.Forms.Padding(2);
			this.grpBugdetails.Size = new System.Drawing.Size(525, 455);
			this.grpBugdetails.TabIndex = 36;
			this.grpBugdetails.TabStop = false;
			this.grpBugdetails.Text = "BugDetails";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(106, 40);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.txtComment);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.grpCodeSnippet);
			this.splitContainer1.Size = new System.Drawing.Size(414, 356);
			this.splitContainer1.SplitterDistance = 204;
			this.splitContainer1.TabIndex = 36;
			// 
			// grpCodeSnippet
			// 
			this.grpCodeSnippet.Controls.Add(this.btnAddCode);
			this.grpCodeSnippet.Controls.Add(this.wbCode);
			this.grpCodeSnippet.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpCodeSnippet.Location = new System.Drawing.Point(0, 0);
			this.grpCodeSnippet.Name = "grpCodeSnippet";
			this.grpCodeSnippet.Size = new System.Drawing.Size(206, 356);
			this.grpCodeSnippet.TabIndex = 37;
			this.grpCodeSnippet.TabStop = false;
			this.grpCodeSnippet.Text = "Code snippet";
			// 
			// btnAddCode
			// 
			this.btnAddCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddCode.Location = new System.Drawing.Point(125, 15);
			this.btnAddCode.Name = "btnAddCode";
			this.btnAddCode.Size = new System.Drawing.Size(75, 23);
			this.btnAddCode.TabIndex = 36;
			this.btnAddCode.Text = "Add Code";
			this.btnAddCode.UseVisualStyleBackColor = true;
			this.btnAddCode.Click += new System.EventHandler(this.btnAddCode_Click);
			// 
			// wbCode
			// 
			this.wbCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.wbCode.Location = new System.Drawing.Point(0, 44);
			this.wbCode.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbCode.Name = "wbCode";
			this.wbCode.Size = new System.Drawing.Size(203, 309);
			this.wbCode.TabIndex = 35;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.grpBugdetails);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.panel2);
			this.splitContainer2.Size = new System.Drawing.Size(742, 455);
			this.splitContainer2.SplitterDistance = 525;
			this.splitContainer2.TabIndex = 41;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.grpManagement);
			this.panel2.Controls.Add(this.grpCodeDetails);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(213, 455);
			this.panel2.TabIndex = 41;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 217);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(213, 238);
			this.panel1.TabIndex = 39;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.grdBugHistory);
			this.groupBox1.Location = new System.Drawing.Point(2, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(211, 199);
			this.groupBox1.TabIndex = 33;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bug Audit History";
			// 
			// grdBugHistory
			// 
			this.grdBugHistory.AllowUserToAddRows = false;
			this.grdBugHistory.AllowUserToDeleteRows = false;
			this.grdBugHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdBugHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdBugHistory.Location = new System.Drawing.Point(3, 16);
			this.grdBugHistory.Name = "grdBugHistory";
			this.grdBugHistory.ReadOnly = true;
			this.grdBugHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdBugHistory.Size = new System.Drawing.Size(205, 180);
			this.grdBugHistory.TabIndex = 32;
			this.grdBugHistory.DoubleClick += new System.EventHandler(this.grdBugHistory_DoubleClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(4, 210);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(97, 23);
			this.btnCancel.TabIndex = 31;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(110, 210);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(100, 23);
			this.btnSave.TabIndex = 12;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label13);
			this.panel3.Controls.Add(this.txtDateCreated);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Enabled = false;
			this.panel3.Location = new System.Drawing.Point(0, 183);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(213, 34);
			this.panel3.TabIndex = 37;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(5, 11);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(70, 13);
			this.label13.TabIndex = 31;
			this.label13.Text = "Time Created";
			// 
			// txtDateCreated
			// 
			this.txtDateCreated.Location = new System.Drawing.Point(106, 8);
			this.txtDateCreated.Name = "txtDateCreated";
			this.txtDateCreated.Size = new System.Drawing.Size(100, 20);
			this.txtDateCreated.TabIndex = 32;
			// 
			// grpManagement
			// 
			this.grpManagement.Controls.Add(this.label10);
			this.grpManagement.Controls.Add(this.label11);
			this.grpManagement.Controls.Add(this.chkOpen);
			this.grpManagement.Controls.Add(this.cboAssignedUser);
			this.grpManagement.Controls.Add(this.txtPriority);
			this.grpManagement.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpManagement.Location = new System.Drawing.Point(0, 95);
			this.grpManagement.Margin = new System.Windows.Forms.Padding(2);
			this.grpManagement.Name = "grpManagement";
			this.grpManagement.Padding = new System.Windows.Forms.Padding(2);
			this.grpManagement.Size = new System.Drawing.Size(213, 88);
			this.grpManagement.TabIndex = 38;
			this.grpManagement.TabStop = false;
			this.grpManagement.Text = "Bug Management";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(5, 17);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(38, 13);
			this.label10.TabIndex = 9;
			this.label10.Text = "Priority";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(5, 44);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(75, 13);
			this.label11.TabIndex = 10;
			this.label11.Text = "Assigned User";
			// 
			// chkOpen
			// 
			this.chkOpen.AutoSize = true;
			this.chkOpen.Location = new System.Drawing.Point(106, 68);
			this.chkOpen.Name = "chkOpen";
			this.chkOpen.Size = new System.Drawing.Size(97, 17);
			this.chkOpen.TabIndex = 11;
			this.chkOpen.Text = "Solution Found";
			this.chkOpen.UseVisualStyleBackColor = true;
			// 
			// cboAssignedUser
			// 
			this.cboAssignedUser.FormattingEnabled = true;
			this.cboAssignedUser.Location = new System.Drawing.Point(106, 41);
			this.cboAssignedUser.Name = "cboAssignedUser";
			this.cboAssignedUser.Size = new System.Drawing.Size(100, 21);
			this.cboAssignedUser.TabIndex = 23;
			// 
			// txtPriority
			// 
			this.txtPriority.Location = new System.Drawing.Point(106, 14);
			this.txtPriority.Name = "txtPriority";
			this.txtPriority.Size = new System.Drawing.Size(100, 20);
			this.txtPriority.TabIndex = 30;
			// 
			// grpCodeDetails
			// 
			this.grpCodeDetails.Controls.Add(this.label12);
			this.grpCodeDetails.Controls.Add(this.txtStartLineNumber);
			this.grpCodeDetails.Controls.Add(this.label7);
			this.grpCodeDetails.Controls.Add(this.label8);
			this.grpCodeDetails.Controls.Add(this.txtRelatedMethod);
			this.grpCodeDetails.Controls.Add(this.label9);
			this.grpCodeDetails.Controls.Add(this.txtEndLineNumber);
			this.grpCodeDetails.Controls.Add(this.txtParameter);
			this.grpCodeDetails.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpCodeDetails.Location = new System.Drawing.Point(0, 0);
			this.grpCodeDetails.Margin = new System.Windows.Forms.Padding(2);
			this.grpCodeDetails.Name = "grpCodeDetails";
			this.grpCodeDetails.Padding = new System.Windows.Forms.Padding(2);
			this.grpCodeDetails.Size = new System.Drawing.Size(213, 95);
			this.grpCodeDetails.TabIndex = 37;
			this.grpCodeDetails.TabStop = false;
			this.grpCodeDetails.Text = "Code Details";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(150, 43);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(16, 13);
			this.label12.TabIndex = 37;
			this.label12.Text = "to";
			// 
			// txtStartLineNumber
			// 
			this.txtStartLineNumber.Location = new System.Drawing.Point(106, 40);
			this.txtStartLineNumber.Name = "txtStartLineNumber";
			this.txtStartLineNumber.Size = new System.Drawing.Size(41, 20);
			this.txtStartLineNumber.TabIndex = 36;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 19);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(83, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Related Method";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(5, 45);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Line Numbers";
			// 
			// txtRelatedMethod
			// 
			this.txtRelatedMethod.Location = new System.Drawing.Point(106, 15);
			this.txtRelatedMethod.Name = "txtRelatedMethod";
			this.txtRelatedMethod.Size = new System.Drawing.Size(100, 20);
			this.txtRelatedMethod.TabIndex = 35;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(5, 71);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(95, 13);
			this.label9.TabIndex = 8;
			this.label9.Text = "Related Parameter";
			// 
			// txtEndLineNumber
			// 
			this.txtEndLineNumber.Location = new System.Drawing.Point(167, 40);
			this.txtEndLineNumber.Name = "txtEndLineNumber";
			this.txtEndLineNumber.Size = new System.Drawing.Size(39, 20);
			this.txtEndLineNumber.TabIndex = 28;
			// 
			// txtParameter
			// 
			this.txtParameter.Location = new System.Drawing.Point(106, 67);
			this.txtParameter.Name = "txtParameter";
			this.txtParameter.Size = new System.Drawing.Size(100, 20);
			this.txtParameter.TabIndex = 29;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(89, 17);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(11, 13);
			this.label14.TabIndex = 37;
			this.label14.Text = "*";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(89, 43);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(11, 13);
			this.label15.TabIndex = 38;
			this.label15.Text = "*";
			// 
			// FrmCreateBug
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 455);
			this.Controls.Add(this.splitContainer2);
			this.MinimumSize = new System.Drawing.Size(743, 439);
			this.Name = "FrmCreateBug";
			this.Text = "Manage Bug";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCreateBug_FormClosed);
			this.Load += new System.EventHandler(this.frmCreateBug_Load);
			this.grpBugdetails.ResumeLayout(false);
			this.grpBugdetails.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.grpCodeSnippet.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdBugHistory)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.grpManagement.ResumeLayout(false);
			this.grpManagement.PerformLayout();
			this.grpCodeDetails.ResumeLayout(false);
			this.grpCodeDetails.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox txtTitle;
		public System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.ComboBox cboAction;
		private System.Windows.Forms.ComboBox cboApplication;
		private System.Windows.Forms.ComboBox cboFormName;
		private System.Windows.Forms.ComboBox cboControlName;
        private System.Windows.Forms.GroupBox grpBugdetails;
		private System.Windows.Forms.WebBrowser wbCode;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btnAddCode;
		private System.Windows.Forms.GroupBox grpCodeSnippet;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView grdBugHistory;
		private System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.GroupBox grpManagement;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.CheckBox chkOpen;
		public System.Windows.Forms.ComboBox cboAssignedUser;
		private System.Windows.Forms.TextBox txtPriority;
		private System.Windows.Forms.GroupBox grpCodeDetails;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtStartLineNumber;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtRelatedMethod;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtEndLineNumber;
		private System.Windows.Forms.TextBox txtParameter;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtDateCreated;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
	}
}