namespace BugManager
{
	partial class frmCreateBug
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
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.chkOpen = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.cboAction = new System.Windows.Forms.ComboBox();
			this.txtLineNumber = new System.Windows.Forms.TextBox();
			this.txtParameter = new System.Windows.Forms.TextBox();
			this.txtPriority = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.cboApplication = new System.Windows.Forms.ComboBox();
			this.cboFormName = new System.Windows.Forms.ComboBox();
			this.cboControlName = new System.Windows.Forms.ComboBox();
			this.txtRelatedMethod = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Title";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Comment";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 115);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Application Name";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 141);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "From Name";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 167);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Control Name";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 193);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Action";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(250, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(83, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Related Method";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(250, 35);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(67, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Line Number";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(250, 61);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(95, 13);
			this.label9.TabIndex = 8;
			this.label9.Text = "Related Parameter";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(250, 100);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(38, 13);
			this.label10.TabIndex = 9;
			this.label10.Text = "Priority";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(250, 127);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(75, 13);
			this.label11.TabIndex = 10;
			this.label11.Text = "Assigned User";
			// 
			// chkOpen
			// 
			this.chkOpen.AutoSize = true;
			this.chkOpen.Location = new System.Drawing.Point(351, 151);
			this.chkOpen.Name = "chkOpen";
			this.chkOpen.Size = new System.Drawing.Size(97, 17);
			this.chkOpen.TabIndex = 11;
			this.chkOpen.Text = "Solution Found";
			this.chkOpen.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(376, 193);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(113, 6);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(131, 20);
			this.txtTitle.TabIndex = 13;
			// 
			// txtComment
			// 
			this.txtComment.Location = new System.Drawing.Point(113, 32);
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(131, 74);
			this.txtComment.TabIndex = 14;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(351, 124);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(100, 21);
			this.comboBox2.TabIndex = 23;
			// 
			// cboAction
			// 
			this.cboAction.FormattingEnabled = true;
			this.cboAction.Location = new System.Drawing.Point(113, 190);
			this.cboAction.Name = "cboAction";
			this.cboAction.Size = new System.Drawing.Size(131, 21);
			this.cboAction.TabIndex = 26;
			// 
			// txtLineNumber
			// 
			this.txtLineNumber.Location = new System.Drawing.Point(351, 32);
			this.txtLineNumber.Name = "txtLineNumber";
			this.txtLineNumber.Size = new System.Drawing.Size(100, 20);
			this.txtLineNumber.TabIndex = 28;
			// 
			// txtParameter
			// 
			this.txtParameter.Location = new System.Drawing.Point(351, 58);
			this.txtParameter.Name = "txtParameter";
			this.txtParameter.Size = new System.Drawing.Size(100, 20);
			this.txtParameter.TabIndex = 29;
			// 
			// txtPriority
			// 
			this.txtPriority.Location = new System.Drawing.Point(351, 97);
			this.txtPriority.Name = "txtPriority";
			this.txtPriority.Size = new System.Drawing.Size(100, 20);
			this.txtPriority.TabIndex = 30;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(295, 193);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 31;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// cboApplication
			// 
			this.cboApplication.FormattingEnabled = true;
			this.cboApplication.Location = new System.Drawing.Point(113, 112);
			this.cboApplication.Name = "cboApplication";
			this.cboApplication.Size = new System.Drawing.Size(131, 21);
			this.cboApplication.TabIndex = 32;
			this.cboApplication.SelectedIndexChanged += new System.EventHandler(this.cboApplication_SelectedIndexChanged);
			// 
			// cboFormName
			// 
			this.cboFormName.FormattingEnabled = true;
			this.cboFormName.Location = new System.Drawing.Point(113, 137);
			this.cboFormName.Name = "cboFormName";
			this.cboFormName.Size = new System.Drawing.Size(131, 21);
			this.cboFormName.TabIndex = 33;
			// 
			// cboControlName
			// 
			this.cboControlName.FormattingEnabled = true;
			this.cboControlName.Location = new System.Drawing.Point(113, 164);
			this.cboControlName.Name = "cboControlName";
			this.cboControlName.Size = new System.Drawing.Size(131, 21);
			this.cboControlName.TabIndex = 34;
			// 
			// txtRelatedMethod
			// 
			this.txtRelatedMethod.Location = new System.Drawing.Point(351, 6);
			this.txtRelatedMethod.Name = "txtRelatedMethod";
			this.txtRelatedMethod.Size = new System.Drawing.Size(100, 20);
			this.txtRelatedMethod.TabIndex = 35;
			// 
			// frmCreateBug
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 223);
			this.Controls.Add(this.txtRelatedMethod);
			this.Controls.Add(this.cboControlName);
			this.Controls.Add(this.cboFormName);
			this.Controls.Add(this.cboApplication);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtPriority);
			this.Controls.Add(this.txtParameter);
			this.Controls.Add(this.txtLineNumber);
			this.Controls.Add(this.cboAction);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.chkOpen);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmCreateBug";
			this.Text = "frmCreateBug";
			this.Load += new System.EventHandler(this.frmCreateBug_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.CheckBox chkOpen;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox cboAction;
		private System.Windows.Forms.TextBox txtLineNumber;
		private System.Windows.Forms.TextBox txtParameter;
		private System.Windows.Forms.TextBox txtPriority;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cboApplication;
		private System.Windows.Forms.ComboBox cboFormName;
		private System.Windows.Forms.ComboBox cboControlName;
		private System.Windows.Forms.TextBox txtRelatedMethod;
	}
}