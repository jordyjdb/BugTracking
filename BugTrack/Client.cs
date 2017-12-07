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
		public List<Apps> GetOwnedApps()
		{

				List<Apps> applications = new List<Apps>();
				DataSet ds = new DataSet();
				SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.AzureBugTrackingConnectionString);
				SqlCommand sqlCom = new SqlCommand("Select * From Application", sqlCon);

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
						String name = (String)row["name"];


						Apps newApplication = new Apps();
						applications.Add(newApplication);
					}
				}

				return applications;
			
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


		public List<Client> get()
		{

				List<Client> clientList = new List<Client>();
				DataSet ds = new DataSet();
				SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\visual Studio\\BugTracking\\BugTracking\\BugTracking.mdf';Integrated Security=True;Connect Timeout=30");
				SqlCommand sqlCom = new SqlCommand("Select * From Client", sqlCon);

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
						String name = (String)row["name"];
						long ClientConnectionID = (long)row["ClientConnectionID"];



						Client newClient = new Client();


						clientList.Add(newClient);
					}
				}

				return clientList;
	
		}
	}
}
