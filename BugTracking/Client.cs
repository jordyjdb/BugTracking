using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class Client
	{
		public long id { get; private set; }

		/// <summary>
		/// Companies name
		/// </summary>
		public String name;

		/// <summary>
		/// main point of contact for client
		/// </summary>
		public User ClientConnection;



		/// <summary>
		/// users ossociated with this client
		/// </summary>
		public List<User> Testers() {
			return null;
		}


		/// <summary>
		/// applications that the client can choose when filling in bug information
		/// </summary>
		public List<Application> GetOwnedApps()
		{

		
			{
				List<Application> applications = new List<Application();
				DataSet ds = new DataSet();
				SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\visual Studio\\BugTracking\\BugTracking\\BugTracking.mdf';Integrated Security=True;Connect Timeout=30");
				SqlCommand sqlCom = new SqlCommand("Select * From ", sqlCon);

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
						long Id = (int)row["Id"];
						String Title = (String)row["Title"];
						String Comment = (String)row["Comment"];
						long previousBugId = (int)row["previousBugId"];


						Bug newBug = new Bug(Id, Title, Comment, previousBugId);
						BugList.Add(newBug);
					}
				}

				return BugList;
			}
			return null;
		}




		//
		public Boolean get(long id)
		{
			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\visual Studio\\BugTracking\\BugTracking\\BugTracking.mdf';Integrated Security=True;Connect Timeout=30");
			SqlCommand sqlCom = new SqlCommand("Select * From Client where Id = @ID", sqlCon);
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

			if (ds.Tables[0].Rows.Count == 1)
			{
				


				return true;
			}
			else
			{
				return false;
			}



		}









	}
}
