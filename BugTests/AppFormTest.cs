using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTests
{
	[TestClass]
	public class AppFormTest
	{
		[TestMethod]
		public void TestAppFormCreate()
		{
			BugTracking.Developer user = new BugTracking.Developer("FirstName", "LastName", "Developer");
			user.Save();
			BugTracking.App app = new BugTracking.App("TestApp1", user);
			app.Save();

			BugTracking.AppForm form = new BugTracking.AppForm("Label Test", "Name Test", true, app.Id);
			form.Save();

			BugTracking.AppForm testform = new BugTracking.AppForm(form.Id);


			Boolean AllFound = true;
			if (testform.Id != form.Id)
			{
				//app retreived

				AllFound = false;
			}
			if(testform.ApplicationID != app.Id)
			{
				//app retreived

				AllFound = false;
			}

			BugTracking.App testApp = new BugTracking.App(testform.ApplicationID);
			if (user.Id != testApp.DefaultUser.Id)
			{
				//app retreived

				AllFound = false;
			}
			if (form.Id != form.Id)
			{
				//form retreived
				AllFound = false;

			}
			if (form.Label != "Label Test")
			{
				//form retreived
				AllFound = false;

			}
			if (form.Name != "Name Test")
			{
				//form retreived
				AllFound = false;

			}
			if (form.Active != true)
			{
				//form retreived
				AllFound = false;

			}

			user.Delete();
			app.Delete();
			form.Delete();

			Assert.AreEqual(AllFound, true);
		}
	}
}
