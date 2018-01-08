using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTests
{
	[TestClass]
	public class AppTest
	{
		[TestMethod]
		public void TestAppCreate()
		{

			BugTracking.User user = new BugTracking.User("FirstName", "LastName", "Developer");
			user.Save();
			BugTracking.App app = new BugTracking.App("TestApp1", user);
			app.Save();

			BugTracking.App testapp = new BugTracking.App(app.Id);

			Boolean AllFound = true;
			
			if (testapp.DefaultUser.Id != app.DefaultUser.Id)
			{
				//app retreived

				AllFound = false;
			}
			if (testapp.Id != app.Id)
			{
				//app retreived

				AllFound = false;
			}
			if(testapp.Name != "TestApp1")
			{
				AllFound = false;
			}

			user.Delete();
			app.Delete();
			
			Assert.AreEqual(AllFound, true);
		}
	}
}
