using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTests
{
	[TestClass]
	public class FormControlTest
	{
		[TestMethod]
		public void TestControlCreate()
		{
			BugTracking.User user = new BugTracking.User("FirstName", "LastName", "Developer");
			user.Save();
			BugTracking.App app = new BugTracking.App("TestApp1", user);
			app.Save();

			BugTracking.FormControl control = new BugTracking.FormControl("label Test", "Name Test", true, app.Id);
			control.Save();


			BugTracking.FormControl Testcontrol = new BugTracking.FormControl(control.Id);

			Boolean AllFound = true;

			if (Testcontrol.Label != control.Label)
			{
				//app retreived

				AllFound = false;
			}
			if (Testcontrol.Name != control.Name)
			{
				//app retreived

				AllFound = false;
			}
			if (Testcontrol.Active != control.Active)
			{
				//app retreived

				AllFound = false;
			}
			if (Testcontrol.ApplicationID != control.ApplicationID)
			{
				//app retreived

				AllFound = false;
			}



			user.Delete();
			control.Delete();
			app.Delete();
			

			Assert.AreEqual(AllFound, true);

		}
	}
}
