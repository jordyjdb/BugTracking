using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTests
{
	[TestClass]
	public class FullDeveloperBugTest
	{
		[TestMethod]
		public void TestDeveloperBugCreate()
		{
			//public BugLocation(long applicationID, long formID, long controlID, string action, string relatedMethod, string relatedParameter, long startLineNumber, long endlineNumber)

			//create dummy controls
			BugTracking.User user = new BugTracking.User("FirstName", "LastName", "Developer");
			user.Save();
			BugTracking.App app = new BugTracking.App("TestApp1",user);
			app.Save();

			BugTracking.AppForm form = new BugTracking.AppForm("Label Test", "Name Test", true, app.Id);
			form.Save();

			BugTracking.FormControl control = new BugTracking.FormControl("label Test", "Name Test", true, app.Id);
			control.Save();

			BugTracking.Action action = new BugTracking.Action("label Test", "Name Test", app.Id);

			BugTracking.BugLocation location = new BugTracking.BugLocation(app.Id,form.Id,control.Id,action.Name,"Related Method Test","Related Parameter Test",1,99);

			BugTracking.DeveloperBug bug = new BugTracking.DeveloperBug("Test Title", "Test Comment", location,0,-1,false,"Dummy Code");


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

		[TestMethod]
		public void TestListDeveloperBugCreate()
		{
			//public BugLocation(long applicationID, long formID, long controlID, string action, string relatedMethod, string relatedParameter, long startLineNumber, long endlineNumber)
		//list of Created Bug Ids
			List<long> IDlist = new List<long>();



			//first in List
			BugTracking.DeveloperBug bug = DeveloperBugSetup.getBug();


			IDlist.Add(bug.Id);

			//Second In List
			bug.Title = "Test Title Change";
			bug.Save();
			IDlist.Add(bug.Id);

			//third In List
			bug.Comment = "Test Comment Change";
			bug.Save();
			IDlist.Add(bug.Id);
			//forth In List
			bug.Code = "Dummy Code Change";
			bug.Save();
			IDlist.Add(bug.Id);
			//fith In List
			bug.Location.relatedMethod = "Related Method Test Change";
			bug.Save();
			IDlist.Add(bug.Id);
			//sixth In List
			bug.Location.StartlineNumber = 97;
			bug.Location.EndlineNumber = 98;
			bug.Save();
			IDlist.Add(bug.Id);

			



			Boolean AllFound = true;

			//Get Bug History
			List<BugTracking.DeveloperBug> BugHistoryList = BugTracking.DeveloperBug.getBugHistory(IDlist[3]);
			
			int listPosition = BugHistoryList.Count -1;


		
			foreach (BugTracking.DeveloperBug newBug in BugHistoryList)
			{
				if(newBug.Id != IDlist[listPosition])
				{
					AllFound = false;

				}
				else
				{
					//Test that each change was kept from previous to next Bug
					switch (listPosition){
						case 5:
							if (newBug.Location.StartlineNumber != 97)
							{
								AllFound = false;

							}
							if (newBug.Location.EndlineNumber != 98)
							{
								AllFound = false;

							}
							
							break;
						case 4:
							if (newBug.Location.relatedMethod != "Related Method Test Change")
							{
								AllFound = false;

							}
							
							if (newBug.Location.StartlineNumber != 1)
							{
								AllFound = false;

							}
						
							if (newBug.Location.EndlineNumber != 99)
							{
								AllFound = false;

							}
					
							break;
						case 3:
							if (newBug.Location.relatedMethod != "Related Method Test")
							{
								AllFound = false;

							}
						
							if (newBug.Code != "Dummy Code Change")
							{
								AllFound = false;

							}
							
							break;
						case 2:
							if (newBug.Code != "Dummy Code")
							{
								AllFound = false;

							}
							;
							if (newBug.Comment != "Test Comment Change")
							{
								AllFound = false;

							}
					
							break;
						case 1:
							if (newBug.Title != "Test Title Change")
							{
								AllFound = false;

							}
							
							if (newBug.Comment != "Test Comment")
							{
								AllFound = false;

							}
							
							break;
						case 0:
							if (newBug.Title != "Test Title")
							{
								AllFound = false;

							}
							
							break;

					}
				}
				//delete bug once checked
				newBug.Delete();
				listPosition -= 1;
			}

			//delete left overs
			 DeveloperBugSetup.deleteAllBug(bug);






			Assert.AreEqual(AllFound, true);
		}

	}
}
