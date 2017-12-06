using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class Bug
	{

		/// <summary>
		/// Summary of the bug
		/// </summary>
		public  String Title { get; set; }

		/// <summary>
		/// what is the outcome of this bug, give an overview of the what went wrong! and what you think it should have done
		/// </summary>
		public String Comment { get; set; }

		/// <summary>
		/// Location the bug was found/set off from
		/// </summary>
		public BugLocation location;

		/// <summary>
		/// developer/user who is assigned to this bug
		/// </summary>
		public User assignedUser;

		/// <summary>
		/// Assigned priority of the bug by a developer or a manager
		/// </summary>
		public String Priority;


		public long Id { get; set; }


		/// <summary>
		/// if the bug is open then it can be added to
		/// </summary>
		public Boolean open { get; private set; }

		
			
		public long previousBugId { get;private set; }

		/// <summary>
		/// gets the previous bug in the chain
		/// </summary>
		/// <returns>NoPreviousBugException is thrown if no previous bug is found, else return object of type type Bug</returns>
		private Bug getPreviousBug() 
		{
			Bug previousBug = new Bug();

			//if bug 
			if (previousBugId != 0 && previousBug.get(previousBugId) == true) {
				return previousBug;
			} else
			{
				throw new NoPreviousBugException(string.Format("no previous Bug. Bug by id {0} is the first bug in the chain", Id));
			}
			
		}

		#region initialize Bug
		public Bug() {  }
		
	public Bug(long Id, String Title, String Comment, long previousBugId)
		{
			this.Title = Title;
			this.Comment = Comment;
			this.Id = Id;
			this.previousBugId = previousBugId;
		}
		public Bug(long Id, String Title, String Comment)
		{
			this.Title = Title;
			this.Comment = Comment;
			this.Id = Id;
			this.previousBugId = 0;
		}
		public Bug(String Title, String Comment)
		{
			this.Title = Title;
			this.Comment = Comment;
			this.Id = 0;
			this.previousBugId = 0;
		}

		public Bug(String Title, String Comment, long previousBugId)
		{
			this.Title = Title;
			this.Comment = Comment;
			this.Id = 0;
			this.previousBugId = previousBugId;
		}

		public Bug(long Id,String Title, String Comment, Bug PreviousBug)
		{
			this.Title = Title;
			this.Comment = Comment;
			this.Id = Id;
			this.previousBugId = PreviousBug.Id;
		}

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Boolean get(long id)
		{
			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\visual Studio\\BugTracking\\BugTracking\\BugTracking.mdf';Integrated Security=True;Connect Timeout=30");
			SqlCommand sqlCom = new SqlCommand("Select * From Bugs where Id = @ID", sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@ID", id));

			try
			{
				sqlCon.Open();

				SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCom);

				sqlDa.Fill(ds);

			}
			finally
			{
				sqlCon.Close();
			}

			if (ds.Tables[0].Rows.Count == 0)
			{
				this.Id = id;
				this.Title = (String)ds.Tables[0].Rows[0]["Title"];
				this.Comment = (String)ds.Tables[0].Rows[0]["Comment"];
				this.Comment = (String)ds.Tables[0].Rows[0]["previousBugId"];

				return true;
			}else {
				return false;
			}



		}

		/// <summary>
		/// gets all bugs
		/// </summary>
		public static List<Bug> get()
		{
			List<Bug> BugList = new List<Bug>();
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\visual Studio\\BugTracking\\BugTracking\\BugTracking.mdf';Integrated Security=True;Connect Timeout=30");
			SqlCommand sqlCom = new SqlCommand("Select * From Bugs", sqlCon);

			try
			{
				sqlCon.Open();

				SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCom);

				sqlDa.Fill(ds);

			}
			finally
			{
				sqlCon.Close();
			}

			 
			if (ds.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow row in ds.Tables[0].Rows)
				{
					long Id = (int) row["Id"];
					String Title = (String) row["Title"];
					String Comment = (String) row["Comment"];
					long previousBugId = (int) row["previousBugId"];


					Bug newBug = new Bug(Id, Title, Comment, previousBugId);
					BugList.Add(newBug);
				}
		}

			return BugList;
		}



		/// <summary>
		/// saves bug to database
		/// </summary>
		/// <returns>ID of new row in table buglist</returns>
		public long save()
		{
			//if ID == 0 
			//new bug with no previous link

			//if ID != 0 
			//ID = previuosBugID and create new bug with link


			SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\visual Studio\\BugTracking\\BugTracking\\BugTracking.mdf';Integrated Security=True;Connect Timeout=30");
			SqlCommand sqlCom = new SqlCommand("Insert into Bugs(Title, Comment, previousBugId) values (@Title, @Comment, @previousBugId", sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@Title", Title));
			sqlCom.Parameters.Add(new SqlParameter("@Comment", Comment));
			sqlCom.Parameters.Add(new SqlParameter("@previousBugId", Id));


			try
			{
				sqlCon.Open();

			 Id = (int)sqlCom.ExecuteScalar();


			}
			catch (SqlException ex)
			{
			
			}
			finally
			{
				sqlCon.Close();
			
			}
	return Id;


		}


		/// <summary>
		///thrown when no previous bug
		/// </summary>
		public class NoPreviousBugException : Exception
		{
			public NoPreviousBugException(string message)
			   : base(message)
			{
			}
		}




	}





	

}
