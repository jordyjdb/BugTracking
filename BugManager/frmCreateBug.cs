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
		public BugTracking.User LoggedInUser;


		//ID of currently view bug
		public long BugID { get; set; } = 0;

		//Bug code value
		public String Code;


		public FrmCreateBug()
		{
			InitializeComponent();
		}

		public void SaveBug()
		{
			SaveBug(true);
		}
		public void SaveBug(Boolean messsagebox)
		{
	
				long DefaultUserID;

				if (txtComment.Text == "" || txtTitle.Text == "")
				{
				if (messsagebox)
				{
					MessageBox.Show("A Bug entry must have a Comment and a title in order to commit!");

				}
				return;
				}

				switch (LoggedInUser.UserType)
				{

					case "White Box Tester":

						//create new Developer Bug with limited values
						BugTracking.BugLocation locationWB = new BugTracking.BugLocation((long)cboApplication.SelectedValue, (long)cboFormName.SelectedValue, (long)cboControlName.SelectedValue, (String)cboAction.Text, "", "", (long)Convert.ToDouble(0), (long)Convert.ToDouble(0));

						BugTracking.DeveloperBug BlackBoxBug = new BugTracking.DeveloperBug(BugID, txtTitle.Text, txtComment.Text, locationWB, (long)0, 0, true, Code);

						BlackBoxBug.createdByID = LoggedInUser.Id;

						DefaultUserID = ((BugTracking.App)cboApplication.SelectedItem).DefaultUser.Id;
						BlackBoxBug.AssignedUserID = DefaultUserID;

						BlackBoxBug.Save();

						//repopulates form with saved bug
						BugID = BlackBoxBug.Id;
						populateBugDetails();

						//Bug.createdByID = createdByID;
						//DeveloperBug.AssignedUserID = (long)cboAssignedUser.SelectedValue;
						break;
					case "Black Box Tester":
					if (txtStartLineNumber.Text == "")
					{
						txtStartLineNumber.Text = "0";

					}
					if (txtEndLineNumber.Text == "")
					{
						txtEndLineNumber.Text = "0";

					}

					if (Code == null)
					{
						Code = "";
					}
					//creates new Bug
					BugTracking.BugLocation locationBB = new BugTracking.BugLocation((long)cboApplication.SelectedValue, (long)cboFormName.SelectedValue, (long)cboControlName.SelectedValue, (String)cboAction.Text, txtRelatedMethod.Text, txtParameter.Text, (long)Convert.ToDouble(txtStartLineNumber.Text), (long)Convert.ToDouble(txtEndLineNumber.Text));

						BugTracking.Bug WhiteBoxBug = new BugTracking.Bug(BugID, txtTitle.Text, txtComment.Text);
						WhiteBoxBug.createdByID = LoggedInUser.Id;

						//gets default User for Appliocation selected
						DefaultUserID = ((BugTracking.App)cboApplication.SelectedItem).DefaultUser.Id;
						WhiteBoxBug.AssignedUserID = DefaultUserID;


						WhiteBoxBug.Save();

						//repopulates form with saved bug
						BugID = WhiteBoxBug.Id;
						populateBugDetails();
						break;
					case "Developer":


					if(txtStartLineNumber.Text == "")
					{
						txtStartLineNumber.Text = "0";

					}
					if (txtEndLineNumber.Text == "")
					{
						txtEndLineNumber.Text = "0";

					}

					if(Code == null)
					{
						Code = "";
					}
					if (txtPriority.Text == "")
					{
						txtPriority.Text = "0";
					}
					//creates Full developer bug
					BugTracking.BugLocation location = new BugTracking.BugLocation((long)cboApplication.SelectedValue, (long)cboFormName.SelectedValue, (long)cboControlName.SelectedValue, (String)cboAction.Text, txtRelatedMethod.Text, txtParameter.Text, (long)Convert.ToDouble(txtStartLineNumber.Text), (long)Convert.ToDouble(txtEndLineNumber.Text));

						BugTracking.DeveloperBug DeveloperBug = new BugTracking.DeveloperBug(BugID, txtTitle.Text, txtComment.Text, location, (long)0, Convert.ToInt64(txtPriority.Text), !chkOpen.Checked, Code);
						DefaultUserID = (long)cboAssignedUser.SelectedValue;

						DeveloperBug.createdByID = LoggedInUser.Id;
						DeveloperBug.AssignedUserID = DefaultUserID;

						DeveloperBug.Save();
						//repopulates form with saved bug
						BugID = DeveloperBug.Id;
						populateBugDetails();
						break;
					default:


						break;
				}


			
		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveBug();



		}

		public Boolean UnitTesting = false;
		/// <summary>
		/// given logged in user sets available controls and manages interaction-able controls
		/// </summary>
		public void UserFormSettup()
		{
			if (!UnitTesting)
			{
				long LoggedInID = Properties.Settings.Default.LoggedInID;

				LoggedInUser = BugTracking.User.Get(LoggedInID);
			}
			

			switch (LoggedInUser.UserType)
			{

				case "Black Box Tester":
					btnSave.Enabled = true;
					grpBugdetails.Enabled = true;
					grpCodeDetails.Enabled = false;
					grpManagement.Enabled = false;
					grpCodeSnippet.Enabled = false;
					splitContainer1.Panel2Collapsed = true;
					splitContainer1.Panel2.Hide();
					grdBugHistory.Enabled = false;


					break;
				case "White Box Tester":
					
					btnSave.Enabled = true;

					grpCodeSnippet.Enabled = true;
					splitContainer1.Panel2Collapsed = false;
					splitContainer1.Panel2.Show();
					grpBugdetails.Enabled = true;
					grpCodeDetails.Enabled = true;
					grpManagement.Enabled = false;
					break;
				case "Developer":
					grpBugdetails.Enabled = true;
					btnSave.Enabled = true;
					grpCodeSnippet.Enabled = true;
					splitContainer1.Panel2Collapsed = false;
					splitContainer1.Panel2.Show();
					grpManagement.Enabled = true;
					grpCodeDetails.Enabled = true;
					grpManagement.Enabled = true;
					break;
				default:
					btnSave.Enabled = true;
					grpBugdetails.Enabled = false;
					grpCodeDetails.Enabled = false;
					grpManagement.Enabled = false;


					break;
			}
		}


		private void frmCreateBug_Load(object sender, EventArgs e)
		{
           
			//gets App list
            BugTracking.App.Get();
            cboApplication.ValueMember = "Id";
            cboApplication.DisplayMember = "Name";
            cboApplication.DataSource = BugTracking.App.Get();

			///gets user list
			List<BugTracking.User> users = BugTracking.User.Get();

			cboAssignedUser.DisplayMember = "FullName";
			cboAssignedUser.ValueMember = "Id";
			cboAssignedUser.DataSource = users;
			cboAssignedUser.SelectedItem = null;


			UserFormSettup();


			populateBugDetails();







		}

	
		/// <summary>
		/// populates form with bug details if not new Bug
		/// </summary>
		private void populateBugDetails()
		{
			//if not new bug
			if (BugID != 0)
			{

				BugTracking.DeveloperBug newBug = BugTracking.DeveloperBug.Get(BugID);

				//if developer bug then
				if (newBug != null)
				{

					//assign bug details
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




					//gets any bug history
					grdBugHistory.DataSource = BugTracking.DeveloperBug.getBugHistory(newBug.Id);


					//selects current bug from list
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

					//if there are columns to hide
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



					//checks to see if bug already has solution or if not latest in Bug History
					if ((!newBug.BugOpen) || (newBug.NextBugId > 0))
					{
						grpBugdetails.Enabled = false;
						grpCodeDetails.Enabled = false;
						grpManagement.Enabled = false;
						btnSave.Enabled = false;

					}
					else
					{
						UserFormSettup();
					}
				}
				else //if not developer bug yet
				{
					BugTracking.Bug bug = new BugTracking.Bug(BugID);

					if (bug != null)
					{
						txtTitle.Text = bug.Title;
						txtComment.Text = bug.Comment;
						txtPriority.Text = "0";

						cboApplication.SelectedValue = bug.Location.application.Id;
						cboFormName.SelectedValue = bug.Location.form.Id;
						cboControlName.SelectedValue = bug.Location.control.Id;
						cboAction.Text = bug.Location.action;
						

						txtRelatedMethod.Text = "";

						txtParameter.Text = "";
						txtEndLineNumber.Text = "";
						txtStartLineNumber.Text = "";

						cboAssignedUser.SelectedValue = bug.AssignedUserID;
						txtDateCreated.Text = bug.CreatedDate.ToShortDateString();



						grdBugHistory.DataSource = null;



						foreach (DataGridViewRow row in grdBugHistory.Rows)
						{
							if ((long)row.Cells["id"].Value == bug.Id)
							{
								row.Selected = true;
							}
							else
							{
								row.Selected = false;
							}

						}

						Code = "";

						//if there are columns to hide
						if (grdBugHistory.Columns.Count > 0)
						{
							grdBugHistory.Columns["Id"].Visible = false;
							grdBugHistory.Columns["previousBugID"].Visible = false;
							grdBugHistory.Columns["NextBugID"].Visible = false;
							grdBugHistory.Columns["BugOpen"].Visible = false;
							grdBugHistory.Columns["AssignedUserID"].Visible = false;
							grdBugHistory.Columns["createdByID"].Visible = false;
						}

						chkOpen.Checked = true;


						//Black Box testers cannot update a bug
						if (LoggedInUser.UserType == "Black Box Tester")
						{
							btnSave.Enabled = false;
						}
						else
						{
							btnSave.Enabled = true;
						}


						getColourCode();





						UserFormSettup();

					}



				}

			}
		}
	

		/// <summary>
		/// update control, form and action list if Application has changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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



		/// <summary>
		/// formats code colour
		/// </summary>
		public void getColourCode()
		{
			String htmlColouredCode = "";
			if (Code != null)
			{
				htmlColouredCode = new ColorCode.CodeColorizer().Colorize(Code, ColorCode.Languages.CSharp);

			}

				StringBuilder html = new StringBuilder();
			//wraps html around formatted code to display in web browser
				html.AppendFormat("<!doctype html><head><meta charset=\"utf-8\"</head> <body>{0}</body></html>", htmlColouredCode); 

			//set web browser text to formatted code
				wbCode.DocumentText = html.ToString();

			
		}

		/// <summary>
		/// Called from frmCode to return responce
		/// </summary>
		/// <param name="commit">if code should be saved on next save or if code should be left as same</param>
		/// <param name="code">Bug code</param>
		public void CommitCode(Boolean commit,String code)
		{

			//if code is to be commited
			if (commit == true)
			{
				this.Code = code;
			}   //else do not change code


			getColourCode();
		}
		frmCode frmCode;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddCode_Click(object sender, EventArgs e)
		{
			frmCode = new frmCode(Code, this);

			frmCode.ShowDialog(this);
			//frmCode.FormClosed();

			
		}


		private void FrmCreateBug_FormClosed(object sender, FormClosedEventArgs e)
		{


			if (frmCode != null)
			{

				//make sure frmCode is closed if other form is closed
				frmCode.Close();
			}
		}

	

		private void grdBugHistory_DoubleClick(object sender, EventArgs e)
		{

			//changes bug if different bug selected from history
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
