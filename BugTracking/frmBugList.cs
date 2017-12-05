using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugTracking
{
    public partial class frmBugList : Form
    {


		List<Bug> bugList;

		public frmBugList()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			refreshData();




		}


		public void refreshData() {
			bugList = Bug.get();
			grdBug.AutoGenerateColumns = true;
			grdBug.DataSource = bugList;
			grdBug.Refresh();
			grdBug.Update();


			cboRelated.ValueMember = "Id";
			cboRelated.DisplayMember = "Title";
			cboRelated.DataSource = bugList;


			cboRelated.Refresh();
			cboRelated.Update();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Bug newBug;
			Boolean safeToSave = true;
			if(txtComment.Text == "")
			{
				safeToSave = false;
				//throw null Exception?
			}

			if (txtComment.Text == "")
			{
				safeToSave = false;
				//throw null Exception?
			}

			if (safeToSave)
			{
				if (cboRelated.SelectedValue != null)
				{
					newBug = new Bug(txtTitle.Text, txtComment.Text, bugList[cboRelated.SelectedIndex].Id);
				}
				else
				{
					newBug = new Bug(txtTitle.Text, txtComment.Text);
				}
				newBug.save();
			}


			refreshData();


		}
	}
}
