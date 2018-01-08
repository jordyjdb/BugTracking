using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTests
{
	[TestClass]
	public class UserTest
	{
		[TestMethod]
		public void TestUserCreate()
		{
			BugTracking.User user = new BugTracking.User("FirstName", "LastName", "Developer");
			user.Save();


			BugTracking.User Testuser = BugTracking.User.Get(user.Id);
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
