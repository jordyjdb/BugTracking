using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTests
{
	[TestClass]
	public class frmCreatBugTest
	{
		[TestMethod]
		public void TestMinimuInput()
		{

			BugTracking.DeveloperBug bug = DeveloperBugSetup.getBug();

			BugManager.FrmCreateBug frmCreateBug = new BugManager.FrmCreateBug();
			frmCreateBug.UnitTesting = true;
			frmCreateBug.LoggedInUser = bug.Location.application.DefaultUser;
			frmCreateBug.BugID = 0;
			frmCreateBug.Show();
			frmCreateBug.Hide();
			frmCreateBug.cboAssignedUser.SelectedValue = bug.Location.application.DefaultUser.Id;
			frmCreateBug.SaveBug(false);
			Boolean bugPassed = true;
			if (frmCreateBug.BugID != 0)
			{
				bugPassed = false;
			}

			frmCreateBug.txtComment.Text = "Test Comment";
			
			frmCreateBug.txtTitle.Text = "Test Title";
			frmCreateBug.SaveBug(false);


			//Assert
			if (frmCreateBug.BugID == 0)
			{
				bugPassed = false;
			}

			//check that save was valid
			BugTracking.DeveloperBug checkBug = BugTracking.DeveloperBug.Get(bug.Id);

			//Assert
			if(checkBug.Title != "Test Title" )
			{
				bugPassed = false;
			}

			if (checkBug.Comment != "Test Comment")
			{
				bugPassed = false;
			}
			

			DeveloperBugSetup.deleteAllBug(bug);
			Assert.AreEqual(bugPassed, true);
		}
	}
}
