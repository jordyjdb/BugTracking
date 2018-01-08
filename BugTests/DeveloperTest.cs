using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTests
{
	[TestClass]
	public class DeveloperTest
	{
		[TestMethod]
		public void TestDeveloperCreate()
		{

			BugTracking.Developer user = new BugTracking.Developer("FirstName", "LastName", "Developer");
			user.Save();


			BugTracking.Developer Testuser = BugTracking.Developer.Get(user.Id);
			Boolean AllFound = true;

			if (user.Id != Testuser.Id)
			{
				//app retreived

				AllFound = false;
			}
			if ("FirstName" != Testuser.FirstName)
			{
				//app retreived

				AllFound = false;
			}
			if ("LastName" != Testuser.LastName)
			{
				//app retreived

				AllFound = false;
			}
			if ("Developer" != Testuser.UserType)
			{
				//app retreived

				AllFound = false;
			}
			user.Delete();
			Assert.AreEqual(AllFound, true);
		}
	}
}
