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

			//opens 



			switch (((BugTracking.User)cboUsers.SelectedItem).Usertype)
			{
				case 0:

					
					break;
				case 1:
frmListBugs listBugs = new frmListBugs();

					listBugs.Show();
					break;
				case 2:

					break;
				default:

					break;
			}


			this.Close();

		}
	}
}
