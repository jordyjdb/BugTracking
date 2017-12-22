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
	public partial class frmApplicationManager : Form
	{

        List<BugTracking.App> AppList;
        List<BugTracking.AppForm> FormList;
        List<BugTracking.FormControl> ControlList;

        public frmApplicationManager()
		{
			InitializeComponent();
		}

        private void btnApplicationSave_Click(object sender, EventArgs e)
        {

            //if application name is new
            if (cboApplication.SelectedValue == null)
            {
            
                BugTracking.App newApp = new BugTracking.App(cboApplication.SelectedText);
                newApp.Save();

                AppList.Add(newApp);

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

            } else
            {
                FormList = new List<BugTracking.AppForm>();
                ControlList = new List<BugTracking.FormControl>();
            }

        }

        private void cboFormName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboFormName.SelectedValue != null)
            {
                txtFormLabel.Text =((BugTracking.AppForm) cboFormName.SelectedItem).label;
                chkFormActive.Enabled = ((BugTracking.AppForm)cboFormName.SelectedItem).active;
            } else
            {
                txtFormLabel.Text = "";
                chkFormActive.Enabled = true;
            }
        }

        private void cboControlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboControlName.SelectedValue != null)
            {
                txtControlLabel.Text = ((BugTracking.AppForm)cboControlName.SelectedItem).label;
                chkControlActive.Enabled = ((BugTracking.AppForm)cboControlName.SelectedItem).active;
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
                
            }
        }

        private void btnFormDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnControlDetails_Click(object sender, EventArgs e)
        {

        }


        private void btnActionDetails_Click(object sender, EventArgs e)
        {

        }
    }
}
