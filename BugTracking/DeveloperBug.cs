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
		public long PreviousBugId { get; private set; }

		/// <summary>
		/// The bug the developer is reacting to.
		/// </summary>
		public List<Bug> UserBugs;

		/// <summary>
		/// Assigned priority of the bug by a developer or a manager
		/// </summary>
		public String Priority;

		/// <summary>
		/// developers/user who are subscribed to this bug for updates.
		/// </summary>
		public List<User> AlertList;

		/// <summary>
		/// if the bug is open then it can be added to
		/// </summary>
		public Boolean BugOpen { get; private set; }

		private DeveloperBug(long Id,String title, String comment, BugLocation location, long PreviousBugId, String Priority, Boolean BugOpen):this(title, comment, location, PreviousBugId, Priority, BugOpen)
		{
			this.Id = Id;
		}
		public DeveloperBug() { }
		public DeveloperBug( String title, String comment, BugLocation location, long PreviousBugId, String Priority, Boolean BugOpen) : base(title, comment, location)
		{

			this.PreviousBugId = PreviousBugId;
			this.Priority = Priority;
			this.BugOpen = BugOpen;
		}

		public new long Save() 
		{

			base.Save();

			

			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			String insertDeveloperBug = "INSERT INTO DEVELOPERBUG(BugId,PreviousBugId,Priority,BugOpen) VALUES (@Id,@PreviousBugId,@Priority,@BugOpen) SELECT SCOPE_IDENTITY()";
			String UpdatePreviousBug = "UPDATE DEVELOPERBUG(Archived,NextBugId) values (1,@NextId) where BugId = @Id; SELECT @@Rowcount";
			SqlCommand sqlCom = new SqlCommand(insertDeveloperBug, sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@Id", Id));
			sqlCom.Parameters.Add(new SqlParameter("@PreviousBugId", PreviousBugId));
			sqlCom.Parameters.Add(new SqlParameter("@Priority", Priority));
			sqlCom.Parameters.Add(new SqlParameter("@BugOpen", BugOpen));



			try
			{
				sqlCon.Open();

				decimal id = (decimal)sqlCom.ExecuteScalar();


			

				Id = (long)id;

				if (PreviousBugId != 0)
				{
					sqlCom.CommandText = UpdatePreviousBug;
					sqlCom.Parameters.Add(new SqlParameter("@NextId", Id));
					sqlCom.Parameters.Add(new SqlParameter("@Id", Id));
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
				SqlCommand sqlCom = new SqlCommand("SELECT dbo.Bugs.Title, dbo.Bugs.Comment, dbo.Bugs.LocationID, dbo.DeveloperBug.BugOpen, dbo.DeveloperBug.Archived, dbo.DeveloperBug.NextBugId, dbo.DeveloperBug.Priority, dbo.DeveloperBug.PreviousBugId, dbo.Bugs.id FROM dbo.DeveloperBug INNER JOIN dbo.Bugs ON dbo.DeveloperBug.BugID = dbo.Bugs.id", sqlCon);

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

						String priority = (String)row["priority"];


					DeveloperBug newBug = new DeveloperBug(Id, Title, Comment, bugLocation,previousBugId, priority,BugOpen);
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


		/// <summary>
		/// gets the previous bug in the chain
		/// </summary>
		/// <returns>NoPreviousBugException is thrown if no previous bug is found, else return object of type type Bug</returns>
		private Bug GetPreviousBug()
		{
			Bug previousBug = new Bug();

			//if bug 
			if (PreviousBugId != 0 && previousBug.Get(PreviousBugId) == true)
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
