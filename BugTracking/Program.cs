using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugTracking
{
    static class Program
    {


		static void FormClosed(object sender, FormClosedEventArgs e)
		{
			((Form)sender).FormClosed -= FormClosed;
			if (Application.OpenForms.Count == 0) Application.ExitThread();
			else Application.OpenForms[0].FormClosed += FormClosed;
		}




		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmBugList());
        }
    }
}
