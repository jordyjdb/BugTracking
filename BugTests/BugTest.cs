using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTests
{
	[TestClass]
	public class BugTest
	{
		[TestMethod]
		public void TestBugCreate()
		{
			BugTracking.User user = new BugTracking.User("FirstName", "LastName", "Developer");
			user.Save();
			BugTracking.App app = new BugTracking.App("TestApp1", user);
			app.Save();

			BugTracking.AppForm form = new BugTracking.AppForm("Label Test", "Name Test", true, app.Id);
			form.Save();

			BugTracking.FormControl control = new BugTracking.FormControl("label Test", "Name Test", true, app.Id);
			control.Save();

			BugTracking.Action action = new BugTracking.Action("label Test", "Name Test", app.Id);

			BugTracking.BugLocation location = new BugTracking.BugLocation(app.Id, form.Id, control.Id, action.Name, "Related Method Test", "Related Parameter Test", 1, 99);

			BugTracking.Bug bug = new BugTracking.Bug("Test Title", "Test Comment", location);


			bug.createdByID = user.Id;


			bug.AssignedUserID = user.Id;
			bug.Save();

			BugTracking.Bug commitedBug = new BugTracking.Bug(bug.Id);


			Boolean AllFound = true;

			if (user.Id != commitedBug.AssignedUserID)
			{
				//app retreived

				AllFound = false;
			}
			if (user.Id != commitedBug.createdByID)
			{
				//app retreived

				AllFound = false;
			}
			if (app.Id != commitedBug.Location.application.Id)
			{
				//app retreived

				AllFound = false;
			}
			if (form.Id != commitedBug.Location.form.Id)
			{
				//form retreived
				AllFound = false;

			}
			if (control.Id != commitedBug.Location.control.Id)
			{
				//control retreived
				AllFound = false;

			}
			if (action.Name != commitedBug.Location.action)
			{
				//action retreived

				AllFound = false;
			}
			if (location.Id != commitedBug.Location.Id)
			{
				//location retreived

				AllFound = false;
			}
			if (bug.Id != commitedBug.Id)
			{
				//app retreived

				AllFound = false;
			}





			user.Delete();
			control.Delete();
			form.Delete();
			app.Delete();
			location.Delete();
			bug.Delete();

			Assert.AreEqual(AllFound, true);
		}
	}
}
