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
	public partial class FrmListBugs : Form
	{
		BugTracking.User user;
		Boolean RefreshingTable = false;
		public FrmListBugs()
		{
			InitializeComponent();
		}

		private void frmListBugs_Load(object sender, EventArgs e)
		{
			user = new BugTracking.User(Properties.Settings.Default.LoggedInID);

			switch (user.UserType)
			{
				case "White Box Tester":
					grdBugs.Enabled = false;
					break;
				case "Black Box Tester":
					grdBugs.Enabled = false;

					break;
				case "Developer":


					RefreshingTable = true;
					grdBugs.DataSource = BugTracking.DeveloperBug.GetAssignedBugs(user.Id, chkOpen.Checked);
					RefreshingTable = false;
					break;
				default:
					


					break;
			}





			

	






		}



        private void btnApplication_Click(object sender, EventArgs e)
        {
            FrmApplicationManager frmApplicationManager = new FrmApplicationManager();
            frmApplicationManager.ShowDialog();

        }

        private void btnCreateBug_Click(object sender, EventArgs e)
        {
            FrmCreateBug frmCreateBug = new FrmCreateBug();
            frmCreateBug.ShowDialog();
        }


        private void btnUpdateSelected_Click(object sender, EventArgs e)
        {
			FrmCreateBug frmCreateBug = new FrmCreateBug();
			frmCreateBug.BugID = (long) grdBugs.SelectedRows[0].Cells["Id"].Value;
			frmCreateBug.ShowDialog();
		}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FrmUserManagement frmUserManagement = new FrmUserManagement();
            frmUserManagement.ShowDialog();

        }

		private void chkOpen_CheckedChanged(object sender, EventArgs e)
		{
			if (RefreshingTable) { }
			switch (user.UserType)
			{
				case "White Box Tester":
					grdBugs.Enabled = false;
					break;
				case "Black Box Tester":
					grdBugs.Enabled = false;

					break;
				case "Developer":



					grdBugs.DataSource = BugTracking.DeveloperBug.GetAssignedBugs(user.Id, chkOpen.Checked);

					break;
				default:



					break;
			}
		}
	}
}
