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
	public partial class frmCreateBug : Form
	{
		public frmCreateBug()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{


			//(long applicationID, long formID, long controlID, string action, string relatedMethod, string relatedParameter, long lineNumber)
			BugTracking.BugLocation location = new BugTracking.BugLocation((long) cboApplication.SelectedValue, (long)cboFormName.SelectedValue, (long)cboControlName.SelectedValue, (String) cboAction.SelectedValue, txtRelatedMethod.Text, txtRelatedMethod.Text, (long) Convert.ToDouble(txtLineNumber.Text));

			BugTracking.DeveloperBug DeveloperBug = new BugTracking.DeveloperBug(txtTitle.Text, txtComment.Text,location,(long) 0, txtPriority.Text, chkOpen.Checked);


			DeveloperBug.Save();
		}

		private void frmCreateBug_Load(object sender, EventArgs e)
		{


			BugTracking.App.get();
			cboApplication.DataSource = BugTracking.App.get();

		

		


		}

		private void cboApplication_SelectedIndexChanged(object sender, EventArgs e)
		{

			cboControlName.DisplayMember = "Label";
			cboControlName.ValueMember = "Id";
			cboControlName.DataSource = BugTracking.FormControl.get((long) cboApplication.SelectedValue);

			cboFormName.DisplayMember = "Name";
			cboFormName.ValueMember = "Id";
			cboFormName.DataSource = BugTracking.App.get();


			cboAction.DisplayMember = "Name";
			cboAction.ValueMember = "Id";
			cboAction.DataSource = BugTracking.Action.Get();

		}
	}
}
