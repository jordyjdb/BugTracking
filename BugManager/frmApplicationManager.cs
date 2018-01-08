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
	public partial class FrmApplicationManager : Form
	{

        List<BugTracking.App> AppList = BugTracking.App.Get();
		List<BugTracking.AppForm> FormList;
        List<BugTracking.FormControl> ControlList;
        List<BugTracking.Action> ActionList;
		List<BugTracking.Developer> UserList = BugTracking.Developer.Get();

		public FrmApplicationManager()
		{
			InitializeComponent();
		}


		/// <summary>
		/// Saves Application with form, controls and action.
		/// </summary>
        private void btnApplicationSave_Click(object sender, EventArgs e)
        {
            BugTracking.App selectedApp;
            //if application is new then add to app list
            if (cboApplication.SelectedValue == null)
            {

                selectedApp = new BugTracking.App(cboApplication.SelectedText);
                selectedApp.Save();

                AppList.Add(selectedApp);

            }
            else
            {//else update exisiting app


                selectedApp = (BugTracking.App)cboApplication.SelectedItem;
				selectedApp.DefaultUser =(BugTracking.Developer) cboDefaultUser.SelectedItem;
				selectedApp.Save();


			}

			//save each form that has not been saved before
			foreach (BugTracking.AppForm form in FormList)
                {
                    if (form.Id == 0)
                    {
                        form.ApplicationID = selectedApp.Id;
                        form.Save();
                    }
                }
			//save each control that has not been saved before
			foreach (BugTracking.FormControl control in ControlList)
                {
                    if (control.Id == 0)
                    {
						control.ApplicationID = selectedApp.Id;
					control.Save();
                    }
                }
			//save each action that has not been saved before
			foreach (BugTracking.Action action in ActionList)
                {
                    if (action.Id == 0)
                    {
					action.ApplicationId = selectedApp.Id;
					action.Save();
                    }
                }

			this.Close();
            
        }


        private void frmApplicationManager_Load(object sender, EventArgs e)
        {
            //Assigns Apps to combobox
         

			ComboMembers();


			
			cboApplication.DataSource = AppList;
			cboDefaultUser.DataSource = UserList;

        }

        private void cboApplication_TextChanged(object sender, EventArgs e)
        {
           
              //btnApplicationSave.Enabled = (cboApplication.SelectedValue != null);
            
        }

        private void cboApplication_SelectedValueChanged(object sender, EventArgs e)
        {
		
            Boolean enableGroupBoxes = (cboApplication.SelectedValue != null);
          
                grpActionDetails.Enabled = enableGroupBoxes;
                grpControlDetails.Enabled = enableGroupBoxes;
                grpFormDetails.Enabled = enableGroupBoxes;
			cboDefaultUser.DataSource = UserList;
			if (enableGroupBoxes)
            {

				//populate app details if not new app

                FormList = BugTracking.AppForm.Get((long)cboApplication.SelectedValue);
                ControlList = BugTracking.FormControl.Get((long)cboApplication.SelectedValue);
                ActionList  = BugTracking.Action.Get((long)cboApplication.SelectedValue);
				cboDefaultUser.SelectedValue = ((BugTracking.App)cboApplication.SelectedItem).DefaultUser.Id;

            } else
            {
                FormList = new List<BugTracking.AppForm>();
                ControlList = new List<BugTracking.FormControl>();
                ActionList = new List<BugTracking.Action>();
            }

			cboFormName.DataSource = null;
			txtFormLabel.Text = "";
			chkFormActive.Checked = false;

			cboControlName.DataSource = null;
			txtControlLabel.Text = "";
			chkControlActive.Checked = false;

			cboActionName.DataSource = null;
			txtActionDescription.Text = "";



			ComboMembers();

			cboFormName.DataSource = FormList;
            cboControlName.DataSource = ControlList;
            cboActionName.DataSource = ActionList;

        }

		/// <summary>
		/// sets display and value members of combo box
		/// </summary>
		private void ComboMembers()
		{

			cboApplication.ValueMember = "Id";
			cboApplication.DisplayMember = "Name";

			cboControlName.ValueMember = "Id";
			cboControlName.DisplayMember = "Name";

			cboFormName.ValueMember = "Id";
			cboFormName.DisplayMember = "Name";
			//cboFormName.DataSource = FormList;

			//cboActionName.ValueMember = "Id";
			//cboActionName.DisplayMember = "Description";


			cboDefaultUser.ValueMember = "Id";
			cboDefaultUser.DisplayMember = "FullName";

			cboActionName.ValueMember = "Id";
			cboActionName.DisplayMember = "Name";
		}

       

       // private long FormSelectedValue = 0;
        private void cboFormName_TextChanged(object sender, EventArgs e)
        {

			//populates details if not new
            if (cboFormName.SelectedValue != null)
            {
                txtFormLabel.Text = ((BugTracking.AppForm)cboFormName.SelectedItem).Label;
                chkFormActive.Enabled = ((BugTracking.AppForm)cboFormName.SelectedItem).Active;
            }
            else 
            {
				//else empties
                txtFormLabel.Text = "";
                chkFormActive.Enabled = true;
            }

            // FormSelectedValue = (long)cboFormName.SelectedValue;
        }

  

        private void cboControlName_SelectedIndexChanged(object sender, EventArgs e)
        {
			//populates details if not new
			if (cboControlName.SelectedValue != null)
            {
                txtControlLabel.Text = ((BugTracking.FormControl)cboControlName.SelectedItem).Label;
                chkControlActive.Enabled = ((BugTracking.FormControl)cboControlName.SelectedItem).Active;
            }else
            {
				//else empties
				txtControlLabel.Text = "";
                chkControlActive.Enabled = true;
            }
        }

        private void cboActionName_SelectedIndexChanged(object sender, EventArgs e)
		{
			//populates details if not new
			if (cboActionName.SelectedValue != null)
            {
                txtActionDescription.Text = ((BugTracking.Action)cboActionName.SelectedItem).Description;
            }
            else
            {
				//else empties
				txtActionDescription.Text = "";
            }
        }

        private void btnFormDetails_Click(object sender, EventArgs e)
        {
            if (cboFormName.SelectedValue == null)
            {
                BugTracking.AppForm newApp = new BugTracking.AppForm(txtFormLabel.Text,cboFormName.Text,chkFormActive.Checked,(long) cboApplication.SelectedValue);
                FormList.Add(newApp);

                cboFormName.DataSource = FormList;
                    
            }
        }

        private void btnControlDetails_Click(object sender, EventArgs e)
        {
            if (cboControlName.SelectedValue == null)
            {
                BugTracking.FormControl newControl = new BugTracking.FormControl(  txtControlLabel.Text, cboControlName.Text, chkControlActive.Checked, (long) cboApplication.SelectedValue);
                ControlList.Add(newControl);

				cboControlName.DataSource = null;

				cboControlName.ValueMember = "Id";
				cboControlName.DisplayMember = "Label";

				cboControlName.DataSource = ControlList;

            }
        }


        private void btnActionDetails_Click(object sender, EventArgs e)
        {
            if (cboActionName.SelectedValue == null)
            {
                BugTracking.Action newAction = new BugTracking.Action(cboActionName.Text, txtActionDescription.Text,(long)cboApplication.SelectedValue);
                ActionList.Add(newAction);
				cboActionName.DataSource = null;

				cboActionName.ValueMember = "Id";
				cboActionName.DisplayMember = "Name";
				cboActionName.DataSource = ActionList;
            }
        }

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
