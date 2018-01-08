using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTests
{
	class DeveloperBugSetup
	{

		public static BugTracking.DeveloperBug getBug()
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

			BugTracking.DeveloperBug bug = new BugTracking.DeveloperBug("Test Title", "Test Comment", location, 0, -1, false, "Dummy Code");


			bug.createdByID = user.Id;


			bug.AssignedUserID = user.Id;
			bug.Save();

			return bug;
		}

		public static void deleteAllBug(BugTracking.DeveloperBug deleteBug)
		{
			deleteBug.Location.control.Delete();
			deleteBug.Location.form.Delete();
			deleteBug.Location.application.Delete();
			deleteBug.Location.application.DefaultUser.Delete();
			deleteBug.Location.Delete();
			deleteBug.Delete();
		}

	}
}
