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
			switch (LoggedInUser.UserType)
			{
				case "White Box Tester":
					
					break;
				case "Black Box Tester":
				
					break;
				case "Developer":
					//(long applicationID, long formID, long controlID, string action, string relatedMethod, string relatedParameter, long lineNumber)
					BugTracking.BugLocation location = new BugTracking.BugLocation((long)cboApplication.SelectedValue, (long)cboFormName.SelectedValue, (long)cboControlName.SelectedValue, (String)cboAction.SelectedValue, txtRelatedMethod.Text, txtParameter.Text, (long)Convert.ToDouble(txtLineNumber.Text));

					BugTracking.DeveloperBug DeveloperBug = new BugTracking.DeveloperBug(txtTitle.Text, txtComment.Text, location, (long)0, Convert.ToInt64(txtPriority.Text), chkOpen.Checked);


					DeveloperBug.Save();
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


			if (BugID != 0)
			{

				BugTracking.DeveloperBug newBug = new BugTracking.DeveloperBug();

				if (newBug.Get(BugID))
				{
					txtTitle.Text = newBug.Title;
					txtComment.Text = newBug.Comment;
					txtPriority.Text = newBug.Priority.ToString();



					cboApplication.SelectedValue = newBug.Location.application.Id;
					cboFormName.SelectedValue = newBug.Location.form.Id;
					cboControlName.SelectedValue = newBug.Location.control.Id;
					cboAction.SelectedValue =  newBug.Location.action;
					txtRelatedMethod.Text = newBug.Location.relatedMethod;

					txtParameter.Text = newBug.Location.relatedParameter;
					txtLineNumber.Text =  newBug.Location.lineNumber.ToString();


					chkOpen.Checked = newBug.BugOpen;

					btnSave.Enabled = newBug.BugOpen;

					getColourCode();
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
			String htmlColouredCode = new ColorCode.CodeColorizer().Colorize(Code, ColorCode.Languages.CSharp);
			StringBuilder html = new StringBuilder();
			html.AppendFormat("<!doctype html><head><meta charset=\"utf-8\"</head> <body>{1}</body></html>", htmlColouredCode);

			webBrowser1.DocumentText = html.ToString();
		}



		private void btnAddCode_Click(object sender, EventArgs e)
		{
			frmCode frmCode = new frmCode(Code);

			frmCode.ShowDialog();
			//frmCode.FormClosed();

			if (frmCode.commit == true)
			{
				Code = frmCode.rtfCode.Text;
			}

			getColourCode();
		}


		private void Form1_FormClosing(Object sender, FormClosingEventArgs e)

		{

		}
				
	}
}
