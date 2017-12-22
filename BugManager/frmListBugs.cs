﻿using System;
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
	}
}