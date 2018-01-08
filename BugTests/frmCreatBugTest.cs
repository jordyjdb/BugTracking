using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTests
{
	[TestClass]
	public class frmCreateBugTest
	{
		/// <summary>
		/// Test for minimal input to frmCreateBug form
		/// </summary>
		[TestMethod]
		public void TestMinimuInput()
		{
			//Get dummy Bug
			BugTracking.DeveloperBug bug = DeveloperBugSetup.getBug();


			//setup frmCreateBugForm
			BugManager.FrmCreateBug frmCreateBug = new BugManager.FrmCreateBug();
			frmCreateBug.UnitTesting = true;
			frmCreateBug.LoggedInUser = bug.Location.application.DefaultUser;
			frmCreateBug.BugID = 0;
			frmCreateBug.Show();
			frmCreateBug.Hide();
			frmCreateBug.cboAssignedUser.SelectedValue = bug.Location.application.DefaultUser.Id;

			//attempt to save without minimul requirements filled in
			frmCreateBug.SaveBug(false);
			Boolean bugPassed = true;

			//if bug hasnt saved then pass
			if (frmCreateBug.BugID != 0)
			{
				bugPassed = false;
			}

			//attempt to save with minimum requirements filled in
			frmCreateBug.txtComment.Text = "Test Comment";
			
			frmCreateBug.txtTitle.Text = "Test Title";
			frmCreateBug.SaveBug(false);


			//if bug has saved then pass
			if (frmCreateBug.BugID == 0)
			{
				bugPassed = false;
			}

			//check that save was valid
			BugTracking.DeveloperBug checkBug = BugTracking.DeveloperBug.Get(bug.Id);

			//check saved values are correct
			if(checkBug.Title != "Test Title" )
			{
				bugPassed = false;
			}

			if (checkBug.Comment != "Test Comment")
			{
				bugPassed = false;
			}
			
			//delete dummy bug
			DeveloperBugSetup.deleteAllBug(bug);
			Assert.AreEqual(bugPassed, true);
		}
	}
}
