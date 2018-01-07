using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	public class DeveloperBug :Bug
	{


		/// <summary>
		/// Last historical bug save.
		/// </summary>
		public long PreviousBugID { get; private set; }

		public long NextBugId { get; private set; }



		/// <summary>
		/// The bug the developer is reacting to.
		/// </summary>
		public List<Bug> UserBugs;

		/// <summary>
		/// Assigned priority of the bug by a developer or a manager
		/// </summary>
		public long Priority;

		/// <summary>
		/// developers/user who are subscribed to this bug for updates.
		/// </summary>
		public List<User> AlertList;

		/// <summary>
		/// if the bug is open then it can be added to
		/// </summary>
		public Boolean BugOpen { get; private set; }

		public String Code { get; private set; }

		public DeveloperBug(long Id,String title, String comment, BugLocation location, long PreviousBugId, long Priority, Boolean BugOpen, String Code) :this(title, comment, location, PreviousBugId, Priority, BugOpen,Code)
		{
			this.Id = Id;
		}
		public DeveloperBug() { }
		public DeveloperBug( String title, String comment, BugLocation location, long PreviousBugId, long Priority, Boolean BugOpen, String Code) : base(title, comment, location)
		{

			this.PreviousBugID = PreviousBugId;
			this.Priority = Priority;
			this.BugOpen = BugOpen;
			this.Code = Code;

		}

		public new long Save() 
		{
			long newPreviousID = Id;
			base.Save();
			


			if (newPreviousID != 0)
			{
				PreviousBugID = newPreviousID;
			}


			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			String insertDeveloperBug = "INSERT INTO DEVELOPERBUG(BugId,Priority,BugOpen,Code,PreviousBugID) VALUES (@Id,@Priority,@BugOpen,@Code,@PreviousBugID); SELECT SCOPE_IDENTITY()";
			String UpdatePreviousBug = "UPDATE DEVELOPERBUG set  NextBugId = @NextId where BugId = @PreviousBugId; SELECT @@Rowcount";
			SqlCommand sqlCom = new SqlCommand(insertDeveloperBug, sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@Id", Id));
			sqlCom.Parameters.Add(new SqlParameter("@PreviousBugId", PreviousBugID));
			sqlCom.Parameters.Add(new SqlParameter("@Priority", Priority));
			sqlCom.Parameters.Add(new SqlParameter("@BugOpen", BugOpen));
			sqlCom.Parameters.Add(new SqlParameter("@Code", Code));
			




			try
			{
				sqlCon.Open();

				sqlCom.ExecuteScalar();
				
				
				if (PreviousBugID != 0)
				{
					sqlCom.CommandText = UpdatePreviousBug;
					sqlCom.Parameters.Add(new SqlParameter("@NextId", Id));
					
					sqlCom.ExecuteNonQuery();
				}

				




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

		public static new List<DeveloperBug> Get()
		{
			
				List<DeveloperBug> BugList = new List<DeveloperBug>();
				DataSet ds = new DataSet();
				SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
				SqlCommand sqlCom = new SqlCommand("SELECT dbo.Bugs.id, dbo.Bugs.Title, dbo.Bugs.Comment, dbo.Bugs.LocationID, dbo.DeveloperBug.BugOpen, dbo.Bugs.Archived, dbo.DeveloperBug.NextBugId, dbo.Bugs.CreatedById, dbo.Bugs.previousBugID, dbo.Bugs.Priority, dbo.Bugs.AssignedUserID FROM dbo.DeveloperBug LEFT OUTER JOIN dbo.Bugs ON dbo.DeveloperBug.BugID = dbo.Bugs.id", sqlCon);

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
						long previousBugId = (long)Settings.iif(Convert.IsDBNull(row["previousBugId"]), 0, (long)row["previousBugId"]);
					String code = (String)row["Code"];

					Boolean isNull = Convert.IsDBNull(row["NextBugID"]);
					long NextBugId = (long)0;
					if (!isNull)
					{
						NextBugId = (long)row["NextBugID"];
					}
					

					long locationID = (long) Settings.iif(Convert.IsDBNull(row["locationID"]), (long)row["locationID"],(long) 0);
						BugLocation bugLocation = new BugLocation(locationID);
					

					bool BugOpen;

					if ((bool)row["BugOpen"] == true)
					{
						BugOpen = true;
					}
					else
					{
						BugOpen = false;
					}
					bugLocation.Get();

						long priority = (long)row["priority"];


					DeveloperBug newBug = new DeveloperBug(Id, Title, Comment, bugLocation,previousBugId, priority,BugOpen,code);

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


		/// <summary>
		/// gets latest bugs in chains
		/// </summary>
		/// <param name="DeveloperID"></param>
		/// <param name="openOnly">parameter to show only open if true, else show open and close</param>
		/// <returns>list of bugs that Assigned user's ID = Developer ID</returns>
		public static new List<DeveloperBug> GetAssignedDevloperBugs(long DeveloperID,Boolean openOnly)
		{

			List<DeveloperBug> BugList = new List<DeveloperBug>();
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("SELECT dbo.Bugs.id, dbo.Bugs.Title, dbo.Bugs.Comment, dbo.Bugs.LocationID, dbo.DeveloperBug.BugOpen,dbo.Bugs.CreatedDate,dbo.DeveloperBug.Code, dbo.Bugs.Archived, dbo.DeveloperBug.NextBugId, dbo.Bugs.CreatedById, dbo.DeveloperBug.previousBugID, dbo.DeveloperBug.Priority, dbo.Bugs.AssignedUserID FROM dbo.DeveloperBug LEFT OUTER JOIN dbo.Bugs ON dbo.DeveloperBug.BugID = dbo.Bugs.id where (AssignedUserID = @Id or CreatedByID = @Id ) and dbo.DeveloperBug.NextBugId is null", sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@Id", DeveloperID));
			if (openOnly == true)
			{
				sqlCom.Parameters.Add(new SqlParameter("@open", true));
				sqlCom.CommandText += " AND BugOpen = @open";
			}
			


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
					long previousBugId = (long)Settings.iif(Convert.IsDBNull(row["previousBugId"]), 0, (long)row["previousBugId"]);
					long locationID = (long)Settings.iif(Convert.IsDBNull(row["locationID"]), (long)row["locationID"], (long)0);
					BugLocation bugLocation = new BugLocation(locationID);


					DateTime CreatedDate = (DateTime)row["CreatedDate"];
					bool BugOpen;

					if ((bool)row["BugOpen"] == true)
					{
						BugOpen = true;
					}
					else
					{
						BugOpen = false;
					}
					bugLocation.Get();

					long priority = (long)row["priority"];



					String code = "";

					if (row["Code"] != DBNull.Value)
					{
						code = (String)row["Code"];
					}



					DeveloperBug newBug = new DeveloperBug(Id, Title, Comment, bugLocation, previousBugId, priority, BugOpen, code);

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

		

		public Bug GetLatestBug()
		{
			//TODO Select top(1) * from Bug where PreviousBug = 



			return null;
		}




		public Bug GetNextBug()
		{
			//TODO Select top(1) * from Bug where CreationDate > @CreationDate order by CreationDate ASC



			return null;
		}

		public Bug GetFirstBug()
		{
			//TODO Select top(1) * from Bug where firstBugID = @FirstbugID ish order by CreationDate DESC



			return null;
		}

		public static new DeveloperBug  Get(long id)
		{
			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("SELECT dbo.Bugs.id, dbo.Bugs.Title, dbo.Bugs.Comment, dbo.Bugs.LocationID, dbo.Bugs.CreatedDate, dbo.DeveloperBug.BugOpen,dbo.DeveloperBug.Code, dbo.Bugs.Archived, dbo.DeveloperBug.NextBugId, dbo.Bugs.CreatedById, dbo.DeveloperBug.previousBugID, dbo.DeveloperBug.Priority, dbo.Bugs.AssignedUserID FROM dbo.DeveloperBug LEFT OUTER JOIN dbo.Bugs ON dbo.DeveloperBug.BugID = dbo.Bugs.id where Id = @ID", sqlCon);
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


				long Id = id;
				
				String Title = (String)ds.Tables[0].Rows[0]["Title"];

				String Comment = (String)ds.Tables[0].Rows[0]["Comment"];

		 BugLocation Location= new BugLocation((long)ds.Tables[0].Rows[0]["LocationID"]);

	
				DateTime CreatedDate = (DateTime)ds.Tables[0].Rows[0]["CreatedDate"];


				long PreviousBugId = 0;
				if (ds.Tables[0].Rows[0]["PreviousBugID"] != DBNull.Value)
				{
					PreviousBugId = (long)ds.Tables[0].Rows[0]["PreviousBugID"];
				}

				long NextBugID = 0;
				if (ds.Tables[0].Rows[0]["NextBugId"] != DBNull.Value)
				{
					NextBugID = (long)ds.Tables[0].Rows[0]["NextBugId"];
				}


				List<Bug> UserBugs;


				long Priority = (long)ds.Tables[0].Rows[0]["Priority"];


				Boolean BugOpen = (Boolean) ds.Tables[0].Rows[0]["BugOpen"];

				String code = "";
				if(ds.Tables[0].Rows[0]["Code"] != DBNull.Value)
				{
					 code = (String)ds.Tables[0].Rows[0]["Code"];
				}

				long assignedUserID = 0;

				if (ds.Tables[0].Rows[0]["Code"] != DBNull.Value)
				{
					 assignedUserID = (long)ds.Tables[0].Rows[0]["AssignedUserID"];

				}



				DeveloperBug bug = new DeveloperBug(Id, Title, Comment , Location , PreviousBugId,Priority,BugOpen,code);
				bug.CreatedDate = CreatedDate;
				bug.NextBugId = NextBugID;
				bug.AssignedUserID = assignedUserID;
				




				return bug;
			}
			else
			{
				return null;
			}



		}


		public static List<DeveloperBug> getBugHistory(long developerBugID)
		{
			List<DeveloperBug> developerBugs = new List<DeveloperBug>();

			List<DeveloperBug> nextDeveloperBugs = new List<DeveloperBug>();
			DeveloperBug firstBug = DeveloperBug.Get(developerBugID);

			
			Boolean hasPreviousBugID = (firstBug.PreviousBugID != 0);

			Boolean hasNextBugID = (firstBug.NextBugId != 0);
			DeveloperBug nextBug = firstBug;
			DeveloperBug PreviousBug = firstBug;

			while (hasNextBugID)
			{
				nextBug = DeveloperBug.Get(nextBug.NextBugId);
				nextDeveloperBugs.Add(nextBug);
				hasNextBugID = (nextBug.NextBugId != 0);

			}

			developerBugs.AddRange(nextDeveloperBugs.Reverse<DeveloperBug>());
			developerBugs.Add(firstBug);

			while (hasPreviousBugID)
			{
				PreviousBug = DeveloperBug.Get(PreviousBug.PreviousBugID);
				if (PreviousBug != null)
				{
					developerBugs.Add(PreviousBug);
					hasPreviousBugID = (PreviousBug.PreviousBugID != 0);
				}
				else
				{
					hasPreviousBugID = false;
				}

			}



			return developerBugs;



		}

		/// <summary>
		/// gets the previous bug in the chain
		/// </summary>
		/// <returns>NoPreviousBugException is thrown if no previous bug is found, else return object of type type Bug</returns>
		private DeveloperBug GetPreviousBug()
		{
			DeveloperBug previousBug = DeveloperBug.Get(PreviousBugID);

			//if bug 
			if (PreviousBugID != 0 && previousBug != null)
			{
				return previousBug;
			}
			else
			{
				throw new NoPreviousBugException(string.Format("no previous Bug. Bug by id {0} is the first bug in the chain", Id));
			}

		}



	}
}
