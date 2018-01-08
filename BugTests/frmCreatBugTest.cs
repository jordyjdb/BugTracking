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

			//first in List
			BugTracking.DeveloperBug bug = DeveloperBugSetup.getBug();

			BugManager.FrmCreateBug frmCreateBug = new BugManager.FrmCreateBug();

			frmCreateBug.LoggedInUser = bug.Location.application.DefaultUser;
			frmCreateBug.BugID = 0;
			frmCreateBug.SaveBug(false);
			Boolean bugPassed = true;
			if (frmCreateBug.BugID != 0)
			{
				bugPassed = false;
			}

			frmCreateBug.txtComment.Text = "TestComment";

			frmCreateBug.txtTitle.Text = "TestTitle";
			frmCreateBug.SaveBug();

			if (frmCreateBug.BugID == 0)
			{
				bugPassed = false;
			}

			BugTracking.DeveloperBug checkBug = BugTracking.DeveloperBug.Get(bug.Id);


			if(checkBug.Title != "TestTitle" || checkBug.Title != "TestComment")
			{
				bugPassed = false;
			}



			DeveloperBugSetup.deleteAllBug(bug);
			Assert.AreEqual(bugPassed, true);
		}
	}
}
