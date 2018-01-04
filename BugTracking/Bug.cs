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

		public DateTime CreationDate;
		

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
				//this. = (String)ds.Tables[0].Rows[0]["previousBugId"];

				this.Location = new BugLocation((long)ds.Tables[0].Rows[0]["LocationID"]);

			


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
					long previousBugId = (long) row["previousBugId"];


					Bug newBug = new Bug(Id, Title, Comment);
					BugList.Add(newBug);
				}
		} else{
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

			Id = SaveBug();
			return Id;

		}

		protected long SaveBug()
		{
			//if ID == 0 
			//new bug with no previous link

			//if ID != 0 
			//ID = previuosBugID and create new bug with link


			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("Insert into Bugs(Title, Comment, previousBugId) values (@Title, @Comment, @previousBugId);SELECT SCOPE_IDENTITY() ", sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@Title", Title));
			sqlCom.Parameters.Add(new SqlParameter("@Comment", Comment));
			sqlCom.Parameters.Add(new SqlParameter("@previousBugId", Id));


			try
			{
				sqlCon.Open();

				decimal id = (decimal)sqlCom.ExecuteScalar();


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




	}





	

}
