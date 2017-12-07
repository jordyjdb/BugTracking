using System;
using System.Collections.Generic;
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

		public DeveloperBug( String title, String comment, BugLocation location, long PreviousBugId, String Priority, Boolean BugOpen) : base(title, comment, location)
		{

			this.PreviousBugId = PreviousBugId;
			this.Priority = Priority;
			this.BugOpen = BugOpen;
		}

		public new long Save()
		{



			 SaveBug();
			

			SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\visual Studio\\BugTracking\\BugTracking\\BugTracking.mdf';Integrated Security=True;Connect Timeout=30");
			String insertDeveloperBug = "INSERT INTO DEVELOPERBUG(Id,PreviousBugId,Priority,BugOpen) VALUES (@Id,@PreviousBugId,@Priority,@BugOpen)";
			SqlCommand sqlCom = new SqlCommand(insertDeveloperBug, sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@Id", Id));
			sqlCom.Parameters.Add(new SqlParameter("@PreviousBugId", PreviousBugId));
			sqlCom.Parameters.Add(new SqlParameter("@Priority", Priority));
			sqlCom.Parameters.Add(new SqlParameter("@BugOpen", BugOpen));



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

		public List<DeveloperBug> Get()
		{


			return null;
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
			if (PreviousBugId != 0 && previousBug.get(PreviousBugId) == true)
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
