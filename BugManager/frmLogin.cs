using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugManager
{
	public partial class FrmLogin : Form
	{
		public FrmLogin()
		{
			InitializeComponent();
		}



		private void frmLogin_Load(object sender, EventArgs e)
		{
			//gets list of all users
			List<BugTracking.User> users = BugTracking.User.Get();

			cboUsers.DisplayMember = "FullName";
			cboUsers.ValueMember = "Id";

			cboUsers.DataSource = users;
			cboUsers.SelectedItem = null;


		}

		private void btnLogin_Click(object sender, EventArgs e)
		{

			//Saves User ID of selected user to settings
			if (cboUsers.SelectedValue != null) { 
				Properties.Settings.Default.LoggedInID = (long)cboUsers.SelectedValue;
				Properties.Settings.Default.Save();
			}

            //opens main form

            FrmListBugs listBugs = new FrmListBugs();

            listBugs.Show();

			//closes frmLogin
            this.Close();

		}

		private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
		{
			//closes application if no other forms were open
			FormCollection fc = Application.OpenForms;

			if (fc.Count == 0)
			{
				Application.Exit();
			}
		}
	}
}
