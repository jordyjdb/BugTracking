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
	public partial class frmCode : Form
	{

		public Boolean commit = false;
		String initilCode;
		FrmCreateBug FrmCreateBug;
		public frmCode(String code, FrmCreateBug frmCreateBug)
		{
			InitializeComponent();
			FrmCreateBug = frmCreateBug;

			rtfCode.Text = code;
			initilCode = rtfCode.Text;
		}

		private void button1_Click(object sender, EventArgs e)
		{

			if (!rtfCode.Text.Equals(initilCode))
			{
				commit = true;
			}

			FrmCreateBug.CommitCode(commit, rtfCode.Text);

			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{


			if (!rtfCode.Text.Equals(initilCode))
			{


			DialogResult result = MessageBox.Show("Close", "Would you like to commit changes before closing?", MessageBoxButtons.YesNoCancel);

			switch (result)
			{
				case DialogResult.Yes:
					commit = true;
					break;
				case DialogResult.No:
					Close();
					break;
				default:
					break;
			}
				
			}

		}

		private void frmCode_Load(object sender, EventArgs e)
		{

		}
	}
}
