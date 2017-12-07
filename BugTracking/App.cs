using BugTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	public class App
	{
		public long Id { get; private set; }

		public String Name { get; private set; }




		/// <summary>
		/// user that is assigned to look into this problem by default!
		/// </summary>
		public User DefaultUser;

		public Boolean get(long id)
		{
			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("Select * From Application where Id = @ID", sqlCon);
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
				this.Name = (String)ds.Tables[0].Rows[0]["name"];
				long defaultUserID = (long)ds.Tables[0].Rows[0]["defaultUserID"];

				return true;
			}
			else
			{
				return false;
			}



		}

		/// <summary>
		/// returns list of all applications
		/// </summary>
		/// <returns></returns>
		public static List<App> get()
		{
			List<App> applications = new List<App>();

			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
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

					App application = new App
					{
						Name = (String)ds.Tables[0].Rows[0]["name"],
						Id = (long)ds.Tables[0].Rows[0]["Id"]
					};

					applications.Add(application);
				}
				return applications;
			}
			else
			{
				//throw exeption
				return null;
			}



		}
	}
}
