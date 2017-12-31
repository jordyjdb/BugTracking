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
	public partial class frmListBugs : Form
	{
		public frmListBugs()
		{
			InitializeComponent();
		}

		private void frmListBugs_Load(object sender, EventArgs e)
		{


			List<BugTracking.Bug> bugs = BugTracking.Bug.Get();

			grdBugs.DataSource = bugs;



		}

        private void btnApplication_Click(object sender, EventArgs e)
        {
            frmApplicationManager frmApplicationManager = new frmApplicationManager();
            frmApplicationManager.ShowDialog();

        }

        private void btnCreateBug_Click(object sender, EventArgs e)
        {
            frmCreateBug frmCreateBug = new frmCreateBug();
            frmCreateBug.ShowDialog();
        }


        private void btnUpdateSelected_Click(object sender, EventArgs e)
        {

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
            frmUserManagement frmUserManagement = new frmUserManagement();
            frmUserManagement.ShowDialog();

        }
    }
}
