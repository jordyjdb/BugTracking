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
	public partial class FrmCreateBug : Form
	{
		BugTracking.User LoggedInUser;

		public long BugID { get; set; } = 0;

		public String Code;


		public FrmCreateBug()
		{
			InitializeComponent();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			long DefaultUserID;
			long createdByID = LoggedInUser.Id;

			switch (LoggedInUser.UserType)
			{
				case "White Box Tester":

					DefaultUserID = ((BugTracking.App)cboApplication.SelectedItem).DefaultUser.Id;
					//Bug.AssignedUserID = (long)cboAssignedUser.SelectedValue;
					break;
				case "Black Box Tester":



					 DefaultUserID = ((BugTracking.App)cboApplication.SelectedItem).DefaultUser.Id;
					//Bug.createdByID = createdByID;
					//DeveloperBug.AssignedUserID = (long)cboAssignedUser.SelectedValue;
					break;
				case "Developer":
					//(long applicationID, long formID, long controlID, string action, string relatedMethod, string relatedParameter, long lineNumber)
					BugTracking.BugLocation location = new BugTracking.BugLocation((long)cboApplication.SelectedValue, (long)cboFormName.SelectedValue, (long)cboControlName.SelectedValue, (String)cboAction.Text, txtRelatedMethod.Text, txtParameter.Text, (long)Convert.ToDouble(txtStartLineNumber.Text),(long)Convert.ToDouble(txtEndLineNumber.Text));

					BugTracking.DeveloperBug DeveloperBug = new BugTracking.DeveloperBug(BugID,txtTitle.Text, txtComment.Text, location, (long)0, Convert.ToInt64(txtPriority.Text), !chkOpen.Checked,Code);
					DefaultUserID = (long)cboAssignedUser.SelectedValue;

					DeveloperBug.createdByID = createdByID;
					DeveloperBug.AssignedUserID = DefaultUserID;

					DeveloperBug.Save();

					BugID = DeveloperBug.Id;
					populateBugDetails();
					break;
				default:
					

					break;
			}

			
		}

		private void frmCreateBug_Load(object sender, EventArgs e)
		{
            long LoggedInID = Properties.Settings.Default.LoggedInID;

            LoggedInUser = BugTracking.User.Get(LoggedInID);

            switch (LoggedInUser.UserType)
            {
                case "White Box Tester":
                    grpBugdetails.Enabled = true;
                    grpCodeDetails.Enabled = false;
                    grpManagement.Enabled = false;

					grdBugHistory.Enabled = false;
                    break;
                case "Black Box Tester":
                    grpBugdetails.Enabled = true;
                    grpCodeDetails.Enabled = true;
                    grpManagement.Enabled = false;
                    break;
                case "Developer":
                    grpManagement.Enabled = true;
                    grpCodeDetails.Enabled = true;
                    grpManagement.Enabled = true;
                    break;
                default:
                    grpBugdetails.Enabled = false;
                    grpCodeDetails.Enabled = false;
                    grpManagement.Enabled = false;


                    break;
            }

            BugTracking.App.Get();
            cboApplication.ValueMember = "Id";
            cboApplication.DisplayMember = "Name";
            cboApplication.DataSource = BugTracking.App.Get();
			List<BugTracking.User> users = BugTracking.User.Get();

			cboAssignedUser.DisplayMember = "FullName";
			cboAssignedUser.ValueMember = "Id";

			cboAssignedUser.DataSource = users;
			cboAssignedUser.SelectedItem = null;





			populateBugDetails();







		}

		private void populateHistoryGrid(BugTracking.DeveloperBug bug)
		{

		}

		private void populateBugDetails()
		{
			if (BugID != 0)
			{

				BugTracking.DeveloperBug newBug = BugTracking.DeveloperBug.Get(BugID);

				if (newBug != null)
				{
					txtTitle.Text = newBug.Title;
					txtComment.Text = newBug.Comment;
					txtPriority.Text = newBug.Priority.ToString();



					cboApplication.SelectedValue = newBug.Location.application.Id;
					cboFormName.SelectedValue = newBug.Location.form.Id;
					cboControlName.SelectedValue = newBug.Location.control.Id;
					cboAction.Text = newBug.Location.action;
					txtRelatedMethod.Text = newBug.Location.relatedMethod;

					txtParameter.Text = newBug.Location.relatedParameter;
					txtEndLineNumber.Text = newBug.Location.EndlineNumber.ToString();
					txtStartLineNumber.Text = newBug.Location.StartlineNumber.ToString();

					cboAssignedUser.SelectedValue = newBug.AssignedUserID;
					txtDateCreated.Text = newBug.CreatedDate.ToShortDateString();



					grdBugHistory.DataSource = BugTracking.DeveloperBug.getBugHistory(newBug.Id);


				
					foreach (DataGridViewRow row in grdBugHistory.Rows)
					{
						if ((long)row.Cells["id"].Value == newBug.Id)
						{
							row.Selected = true;
						}
						else
						{
							row.Selected = false;
						}
      
					}

					Code = newBug.Code;
					if (grdBugHistory.Columns.Count > 0)
					{
						grdBugHistory.Columns["Id"].Visible = false;
						grdBugHistory.Columns["previousBugID"].Visible = false;
						grdBugHistory.Columns["NextBugID"].Visible = false;
						grdBugHistory.Columns["BugOpen"].Visible = false;
						grdBugHistory.Columns["AssignedUserID"].Visible = false;
						grdBugHistory.Columns["createdByID"].Visible = false;
					}

					chkOpen.Checked = !newBug.BugOpen;

					btnSave.Enabled = newBug.BugOpen;

					getColourCode();




					if ((!newBug.BugOpen) || (newBug.NextBugId > 0))
					{
						grpBugdetails.Enabled = false;
						grpCodeDetails.Enabled = false;
						grpManagement.Enabled = false;
						btnSave.Enabled = false;

					}
					else
					{
						grpBugdetails.Enabled = true;
						grpCodeDetails.Enabled = true;
						grpManagement.Enabled = true;
						btnSave.Enabled = true;
					}
				}
				else
				{
					//bug with bugID not found!

					MessageBox.Show("Unable to open bug with Id: " + BugID);


				}





			}
		}
	
		private void cboApplication_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboApplication.SelectedValue != null)
			{
				cboControlName.DisplayMember = "Label";
				cboControlName.ValueMember = "Id";
				cboControlName.DataSource = BugTracking.FormControl.Get((long)cboApplication.SelectedValue);

				cboFormName.DisplayMember = "Name";
				cboFormName.ValueMember = "Id";
				cboFormName.DataSource = BugTracking.AppForm.Get((long)cboApplication.SelectedValue);


				cboAction.DisplayMember = "Name";
				cboAction.ValueMember = "Id";
				cboAction.DataSource = BugTracking.Action.Get((long)cboApplication.SelectedValue);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}




		public void getColourCode()
		{
			String htmlColouredCode = "";
			if (Code != null)
			{
				htmlColouredCode = new ColorCode.CodeColorizer().Colorize(Code, ColorCode.Languages.CSharp);

			}

				StringBuilder html = new StringBuilder();
				html.AppendFormat("<!doctype html><head><meta charset=\"utf-8\"</head> <body>{0}</body></html>", htmlColouredCode);

				webBrowser1.DocumentText = html.ToString();

			
		}

		public void CommitCode(Boolean commit,String code)
		{
			if (commit == true)
			{
				this.Code = code;
			}

			getColourCode();
		}
		frmCode frmCode;
		private void btnAddCode_Click(object sender, EventArgs e)
		{
			frmCode = new frmCode(Code, this);

			frmCode.ShowDialog(this);
			//frmCode.FormClosed();

			
		}


		private void Form1_FormClosing(Object sender, FormClosingEventArgs e)

		{

		}

		private void FrmCreateBug_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (frmCode != null)
			{
				frmCode.Close();
			}
		}

		private void grdBugHistory_SelectionChanged(object sender, EventArgs e)
		{

			

		}

		private void grdBugHistory_DoubleClick(object sender, EventArgs e)
		{
			long ID = (long)grdBugHistory.SelectedRows[0].Cells["ID"].Value;
			if (ID > 0 && ID != BugID)
			{
				BugID = ID;
				populateBugDetails();


			}

		}

		private void btnCancel_Click_1(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
