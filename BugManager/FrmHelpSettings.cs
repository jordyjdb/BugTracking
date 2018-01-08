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
	public partial class FrmHelpSettings : Form
	{
		public FrmHelpSettings()
		{
			InitializeComponent();
		}

		private void FrmHelpSettings_Load(object sender, EventArgs e)
		{
			String help = Properties.Settings.Default.HelpfileLocation;

			txtHelpFile.Text = help;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.HelpfileLocation = txtHelpFile.Text;
			this.Close();
		}
	}
}
