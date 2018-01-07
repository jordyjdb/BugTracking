using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	public class Bug
	{
	public long Id { get; set; }
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
		public BugLocation Location;

		public DateTime CreatedDate { get; set; }

		public long AssignedUserID { get; set; }

		public long createdByID { get; set; }

		#region initialize Bug
		public Bug() {  }
		
	private Bug(long Id, String Title, String Comment, BugLocation location)
		{
			this.Title = Title;
			this.Comment = Comment;
			this.Id = Id;
			this.Location = location;
		}
		private Bug(long Id, String Title, String Comment)
		{
			this.Title = Title;
			this.Comment = Comment;
			this.Id = Id;

		}
		public Bug(String Title, String Comment)
		{
			this.Title = Title;
			this.Comment = Comment;
			this.Id = 0;

		}

		public Bug(string Title, string Comment, BugLocation location) : this(Title, Comment)
		{
			Location = location;
		}



		#endregion



		/// <summary>
		/// gets defaulted user based on location
		/// </summary>
		/// <returns>defaulted user to attend this bug</returns>
		public static User GetDefaultedUser(BugLocation location)
		{
			
			return null;

		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Boolean Get(long id)
		{
			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
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

			if (ds.Tables[0].Rows.Count > 0)
			{
				this.Id = id;
				this.Title = (String)ds.Tables[0].Rows[0]["Title"];
				this.Comment = (String)ds.Tables[0].Rows[0]["Comment"];
				this.Location = new BugLocation((long)ds.Tables[0].Rows[0]["LocationID"]);

				this.CreatedDate = (DateTime)ds.Tables[0].Rows[0]["CreatedDate"];


				return true;
			}else {
				return false;
			}



		}

	

		/// <summary>
		/// gets all bugs
		/// </summary>
		public static List<Bug> Get()
		{
			List<Bug> BugList = new List<Bug>();
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
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
					long Id = (long) row["Id"];
					String Title = (String) row["Title"];
					String Comment = (String) row["Comment"];
					DateTime CreatedDate = (DateTime)row["CreatedDate"];


					Bug newBug = new Bug(Id, Title, Comment);
					newBug.CreatedDate = CreatedDate;
					BugList.Add(newBug);
				}
		} else{
				//throw exeption
				return null;
			}

			return BugList;
		}

		/// <summary>
		/// Get list of bugs created by user
		/// </summary>
		/// <param name="Id">Users ID</param>
		/// <param name="open"> filters Bugs based on if the bug is open or closed</param>
		/// <returns></returns>
		public static List<Bug> GetBoxBugs(Boolean open,Boolean includeBlackBox)
		{
			List<Bug> BugList = new List<Bug>();
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);


			String sqlString = "SELECT Bugs.*, dbo.UserTypes.Type FROM dbo.Bugs INNER JOIN dbo.Users ON dbo.Bugs.CreatedById = dbo.Users.id INNER JOIN dbo.UserTypes ON dbo.Users.typeID = dbo.UserTypes.id WHERE dbo.UserTypes.Type = WhiteBoxTester ";

			if (includeBlackBox)
			{
				sqlString += " or dbo.UserTypes.Type = BlackBoxTester";
				
			}
			

			sqlString += " ORDER BY CreatedDate DESC";
			SqlCommand sqlCom = new SqlCommand(sqlString, sqlCon);
			
			sqlCom.Parameters.Add(new SqlParameter("@open", open));





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
					long id = (long)row["Id"];
					String Title = (String)row["Title"];
					String Comment = (String)row["Comment"];

					DateTime CreatedDate = (DateTime)row["CreatedDate"];


					Bug newBug = new Bug(id, Title, Comment);
					newBug.CreatedDate = CreatedDate;
					BugList.Add(newBug);
				}
			}
			else
			{
				//throw exeption
				return null;
			}

			return BugList;
		}

		/// <summary>
		/// Get list of bugs created by user
		/// </summary>
		/// <param name="Id">Users ID</param>
		/// <param name="open"> filters Bugs based on if the bug is open or closed</param>
		/// <returns></returns>
		public static List<Bug> GetCreatedBugs(long Id, Boolean open)
		{
			List<Bug> BugList = new List<Bug>();
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);


			String sqlString = "Select * From Bugs where CreatedByID = @Id and open = @open";



			sqlString += " ORDER BY CreatedDate DESC";
			SqlCommand sqlCom = new SqlCommand(sqlString, sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@Id", Id));
			sqlCom.Parameters.Add(new SqlParameter("@open", open));





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
					long id = (long)row["Id"];
					String Title = (String)row["Title"];
					String Comment = (String)row["Comment"];

					DateTime CreatedDate = (DateTime)row["CreatedDate"];


					Bug newBug = new Bug(id, Title, Comment);
					newBug.CreatedDate = CreatedDate;
					BugList.Add(newBug);
				}
			}
			else
			{
				//throw exeption
				return null;
			}

			return BugList;
		}


		/// <summary>
		/// saves bug to database
		/// </summary>
		/// <returns>ID of new row in table buglist</returns>
		public long Save()
		{

			Location.Save();
			Id = SaveBug();



			return Id;

		}




		protected long SaveBug()
		{
			//if ID == 0 
			//new bug with no previous link

			//if ID != 0 
			//ID = previuosBugID and create new bug with link
			CreatedDate = DateTime.Now;

			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("Insert into Bugs(Title, Comment,createdByID,AssignedUserID,LocationID,CreatedDate) values (@Title, @Comment,@createdByID,@AssignedUserID,@LocationID,@CreatedDate);SELECT SCOPE_IDENTITY() ", sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@Title", Title));
			sqlCom.Parameters.Add(new SqlParameter("@Comment", Comment));

			sqlCom.Parameters.Add(new SqlParameter("@createdByID", createdByID));
			sqlCom.Parameters.Add(new SqlParameter("@AssignedUserID", AssignedUserID));

			sqlCom.Parameters.Add(new SqlParameter("@LocationID", Location.Id));
			sqlCom.Parameters.Add(new SqlParameter("@CreatedDate", CreatedDate));
			//createdByID
			//Priority
			//AssignedUserID
			//LocationID


			try
			{
				sqlCon.Open();

				decimal id = (decimal)sqlCom.ExecuteScalar();
				CreatedDate = DateTime.Now;

				Id = (long)id;


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




		/// <summary>
		/// gets latest bugs in chains
		/// </summary>
		/// <param name="DeveloperID"></param>
		/// <param name="openOnly">parameter to show only open if true, else show open and close</param>
		/// <returns>list of bugs that Assigned user's ID = Developer ID</returns>
		public static List<Bug> GetAssignedBugs(long DeveloperID, Boolean openOnly)
		{

			List<Bug> BugList = new List<Bug>();
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("SELECT dbo.Bugs.id, dbo.Bugs.Title, dbo.Bugs.Comment, dbo.Bugs.LocationID ,dbo.Bugs.CreatedDate, dbo.Bugs.CreatedById, dbo.Bugs.AssignedUserID FROM Bugs where AssignedUserID = @Id", sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@Id", DeveloperID));
			

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
					long Id = (long)row["Id"];
					String Title = (String)row["Title"];
					String Comment = (String)row["Comment"];
					
					long locationID = (long)Settings.iif(Convert.IsDBNull(row["locationID"]), (long)row["locationID"], (long)0);
					BugLocation bugLocation = new BugLocation(locationID);


					DateTime CreatedDate = (DateTime)row["CreatedDate"];
					
					
					Bug newBug = new Bug(Id, Title, Comment, bugLocation);

					newBug.CreatedDate = CreatedDate;
					Developer developer = Developer.Get((long)row["CreatedById"]);
					
					BugList.Add(newBug);
				}
			}
			else
			{
				//throw exeption
				return null;
			}

			return BugList;

		}
	}





	

}
