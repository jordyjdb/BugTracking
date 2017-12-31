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
    public partial class frmUserManagement : Form
    {
        List<BugTracking.User> userList = new List<BugTracking.User>();

        List<BugTracking.UserType> userTypeList = new List<BugTracking.UserType>();
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboUser.SelectedItem != null)
            {
                chkNew.Checked = false;

                BugTracking.User selectedUser = (BugTracking.User) cboUser.SelectedItem;

                txtFirstName.Text = selectedUser.FirstName;
                txtLastName.Text = selectedUser.LastName;
                //cboUserType.SelectedText = selectedUser.Usertype;


            } else
            {
                cboUser.Enabled = false;
                chkNew.Checked = true;
                
            }
           
        }

        private void chkNew_CheckedChanged(object sender, EventArgs e)
        {
            if (cboUser.Enabled != false)
            {
                cboUser.Enabled = false;
                txtFirstName.Text = "";
                txtLastName.Text = "";
                cboUserType.SelectedValue = 0;

                

            }
            else
            {
                cboUser.Enabled = true;
                cboUser.SelectedValue = cboUser.SelectedValue;
            }
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            cboUser.DisplayMember = "FullName";
            cboUser.ValueMember = "Id";

            cboUserType.DisplayMember = "Description";
            cboUserType.ValueMember = "Id";

            userList = BugTracking.User.Get();
            userTypeList = BugTracking.UserType.Get();

            cboUserType.DataSource = userTypeList;
            cboUser.DataSource = userList;
      



        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            BugTracking.User savedUser;

            //if enabled then update
            if(cboUser.Enabled == true)
            {
                savedUser = (BugTracking.User)cboUser.SelectedItem;
                savedUser.FirstName = txtFirstName.Text;
                savedUser.LastName = txtLastName.Text;
                savedUser.Usertype = cboUserType.Text;
            }
            else //new User
            {
                savedUser = new BugTracking.User(txtFirstName.Text,txtLastName.Text,cboUserType.Text);
            }

            savedUser.save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
