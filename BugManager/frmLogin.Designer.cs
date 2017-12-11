namespace BugManager
{
	partial class FrmLogin
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
			this.cboUsers = new System.Windows.Forms.ComboBox();
			this.btnLogin = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cboUsers
			// 
			this.cboUsers.FormattingEnabled = true;
			this.cboUsers.Location = new System.Drawing.Point(64, 85);
			this.cboUsers.Name = "cboUsers";
			this.cboUsers.Size = new System.Drawing.Size(121, 21);
			this.cboUsers.TabIndex = 0;
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(92, 213);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 1;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// FrmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(262, 277);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.cboUsers);
			this.Name = "FrmLogin";
			this.Text = "Login";
			this.Load += new System.EventHandler(this.frmLogin_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cboUsers;
		private System.Windows.Forms.Button btnLogin;
	}
}

