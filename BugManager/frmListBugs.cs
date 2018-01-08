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
			List<String> FilterList = new List<string>();

			//sets appropriate filters for user type
			switch (user.UserType)
			{
				case "Black Box Tester":
					FilterList.Add("BlackBox Bugs Only");
					cboFilters.Enabled = false;

					break;
				case "White Box Tester":
					FilterList.Add("BlackBox Bugs Only");
					FilterList.Add("WhiteBox & BlackBox Bugs");

					break;
				case "Developer":
					FilterList.Add("BlackBox Bugs Only");
					FilterList.Add("WhiteBox & BlackBox Bugs");
					FilterList.Add("Developer Bugs Only");


					gridRefresh();


					break;
				default:



					break;
			}












			cboFilters.DataSource = FilterList;

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
			if (grdBugs.SelectedRows.Count > 0)
			{
				FrmCreateBug frmCreateBug = new FrmCreateBug();
				frmCreateBug.BugID = (long)grdBugs.SelectedRows[0].Cells["Id"].Value;
				frmCreateBug.ShowDialog();
			}

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
					gridRefresh();
					break;
				case "Black Box Tester":
					grdBugs.Enabled = false;
					gridRefresh();
					break;
				case "Developer":

					gridRefresh();
					break;
				default:



					break;
			}
		}

		public void gridRefresh()
		{
			RefreshingTable = true;




			switch (user.UserType)
			{
				case "White Box Tester":

					//shows only bugs that have been created by logged in user
					grdBugs.DataSource = BugTracking.Bug.GetCreatedBugs(user.Id);


					break;
				case "Black Box Tester":



					switch (cboFilters.SelectedIndex)
					{
						case 0:
							//gets all open Bugs that are created by black box testers
							grdBugs.DataSource = BugTracking.Bug.GetBoxBugs(false);

							break;

						case 1:
							//gets all open Bugs that are created by black box testers and white box testers
							grdBugs.DataSource = BugTracking.Bug.GetBoxBugs(true);
							break;

					}


					//grdBugs.DataSource = BugTracking.DeveloperBug.GetAssignedDevloperBugs(user.Id, chkOpen.Checked);


					break;
				case "Developer":

					switch (cboFilters.SelectedIndex)
					{
						case 0:
							//gets all open Bugs that are created by black box testers
							grdBugs.DataSource = BugTracking.Bug.GetBoxBugs(false);

							break;

						case 1:
							//gets all open Bugs that are created by black box testers and white box testers
							grdBugs.DataSource = BugTracking.Bug.GetBoxBugs(true);
							break;

						case 2:
							//DeveloperBugsOnly

							//gets developer bugs assigned to logged in user where open = chkOpen.checked
							grdBugs.DataSource = BugTracking.DeveloperBug.GetAssignedDevloperBugs(user.Id, chkOpen.Checked);


							//hide if has any data
							if (grdBugs.Columns.Count > 0)
							{

								grdBugs.Columns["previousBugID"].Visible = false;
								grdBugs.Columns["NextBugID"].Visible = false;
								grdBugs.Columns["BugOpen"].Visible = false;

							}
							break;

						default:
							//whiteBoxTester
							grdBugs.DataSource = BugTracking.Bug.GetBoxBugs(chkOpen.Checked);
							break;
					}

					break;
				default:

					break;
			}

			//hide if has any data
			if (grdBugs.Columns.Count > 0)
			{
				grdBugs.Columns["Id"].Visible = false;

				grdBugs.Columns["AssignedUserID"].Visible = false;
				grdBugs.Columns["createdByID"].Visible = false;
			}
			RefreshingTable = false;
		}

		private void FrmListBugs_FormClosed(object sender, FormClosedEventArgs e)
		{
			//shuts down application if no other forms are open
			FormCollection fc = Application.OpenForms;

			if (fc.Count == 0)
			{
				Application.Exit();
			}


		}

		/// <summary>
		/// Refreshes on filter change
		/// </summary>
		private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			gridRefresh();
		}
	}
}
