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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code">Current Code</param>
		/// <param name="frmCreateBug">needed to return value</param>
		public frmCode(String code, FrmCreateBug frmCreateBug)
		{
			InitializeComponent();
			FrmCreateBug = frmCreateBug;

			rtfCode.Text = code;
			initilCode = rtfCode.Text;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//if new code then commit flag set
			if (!rtfCode.Text.Equals(initilCode))
			{
				commit = true;
			}

			//call back to calling form with new value
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
						commit = false;
	
					break;
				default:
					break;
			}
				//call back to calling form with new value
				FrmCreateBug.CommitCode(commit, rtfCode.Text);

				Close();
			}

		}

	
	}
}
