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

        List<BugTracking.App> AppList;
        List<BugTracking.AppForm> FormList;
        List<BugTracking.FormControl> ControlList;
        List<BugTracking.Action> ActionList;


        public FrmApplicationManager()
		{
			InitializeComponent();
		}

        private void btnApplicationSave_Click(object sender, EventArgs e)
        {
            BugTracking.App selectedApp;
            //if application name is new
            if (cboApplication.SelectedValue == null)
            {

                selectedApp = new BugTracking.App(cboApplication.SelectedText);
                selectedApp.Save();

                AppList.Add(selectedApp);

            }
            else
            {
                selectedApp = (BugTracking.App)cboApplication.SelectedItem;
            }
                foreach(BugTracking.AppForm form in FormList)
                {
                    if (form.Id == 0)
                    {
                        form.ApplicationID = selectedApp.Id;
                        form.Save();
                    }
                }
                foreach (BugTracking.FormControl control in ControlList)
                {
                    if (control.Id == 0)
                    {
                        control.Save();
                    }
                }
                foreach (BugTracking.Action action in ActionList)
                {
                    if (action.Id == 0)
                    {
                        
                        action.Save();
                    }
                }
            
        }

        private void frmApplicationManager_Load(object sender, EventArgs e)
        {
            //Assigns Apps to combobox
            AppList = BugTracking.App.Get();
            cboApplication.ValueMember = "Id";
            cboApplication.DisplayMember = "Name";
            cboApplication.DataSource = AppList;

            cboControlName.ValueMember = "Id";
            cboControlName.DisplayMember = "Name";
            //cboControlName.DataSource = ControlList;

            cboFormName.ValueMember = "Id";
            cboFormName.DisplayMember = "Name";
            //cboFormName.DataSource = FormList;

            cboActionName.ValueMember = "Id";
            cboActionName.DisplayMember = "Description";


            cboDefaultUser.ValueMember = "Id";
            cboDefaultUser.DisplayMember = "Full Name";

            List<BugTracking.DeveloperBug> userList = BugTracking.DeveloperBug.Get();

            cboDefaultUser.DataSource = userList;

        }

        private void cboApplication_TextChanged(object sender, EventArgs e)
        {
           
              btnApplicationSave.Enabled = (cboApplication.SelectedValue != null);
            
        }

        private void cboApplication_SelectedValueChanged(object sender, EventArgs e)
        {
            Boolean enableGroupBoxes = (cboApplication.SelectedValue != null);
          
                grpActionDetails.Enabled = enableGroupBoxes;
                grpControlDetails.Enabled = enableGroupBoxes;
                grpFormDetails.Enabled = enableGroupBoxes;

            if (enableGroupBoxes)
            {
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

            cboFormName.DataSource = FormList;
            cboControlName.DataSource = ControlList;
            cboActionName.DataSource = ControlList;

        }

        private void cboFormName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

       // private long FormSelectedValue = 0;
        private void cboFormName_TextChanged(object sender, EventArgs e)
        {
            if (cboFormName.SelectedValue != null)
            {
                txtFormLabel.Text = ((BugTracking.AppForm)cboFormName.SelectedItem).Label;
                chkFormActive.Enabled = ((BugTracking.AppForm)cboFormName.SelectedItem).Active;
            }
            else
            {
                txtFormLabel.Text = "";
                chkFormActive.Enabled = true;
            }

            // FormSelectedValue = (long)cboFormName.SelectedValue;
        }

  

        private void cboControlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboControlName.SelectedValue != null)
            {
                txtControlLabel.Text = ((BugTracking.AppForm)cboControlName.SelectedItem).Label;
                chkControlActive.Enabled = ((BugTracking.AppForm)cboControlName.SelectedItem).Active;
            }else
            {
                txtControlLabel.Text = "";
                chkControlActive.Enabled = true;
            }
        }

        private void cboActionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // not needed?
            if (cboActionName.SelectedValue != null)
            {
                txtActionDescription.Text = ((BugTracking.Action)cboControlName.SelectedItem).Description;
            }
            else
            {
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
                BugTracking.FormControl newControl = new BugTracking.FormControl(txtFormLabel.Text, cboFormName.Text, chkFormActive.Checked, (long) cboApplication.SelectedValue);
                ControlList.Add(newControl);

                cboControlName.DataSource = ControlList;

            }
        }


        private void btnActionDetails_Click(object sender, EventArgs e)
        {
            if (cboActionName.SelectedValue == null)
            {
                BugTracking.Action newAction = new BugTracking.Action(cboActionName.Text, txtActionDescription.Text,(long)cboApplication.SelectedValue);
                ActionList.Add(newAction);

                cboActionName.DataSource = ActionList;
            }
        }

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
