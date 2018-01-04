using System;
using BugTracking;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BugTracking
{
	public class Developer : User
	{

		List<App> UserAppList = new List<App>();


		public Developer(long Id, String FirstName, String LastName,String Usertype) : base(Id, FirstName,LastName,Usertype)
		{

		}

		public static new Developer Get(long Id) 
		{
			
				//retreives information about bug with ID
				DataSet ds = new DataSet();
				SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
				SqlCommand sqlCom = new SqlCommand("Select Users.*, UserTypes.Type From Users inner join UserTypes on Users.typeId = UserTypes.Id where Users.Id = @ID", sqlCon);
				sqlCom.Parameters.Add(new SqlParameter("@ID", Id));

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

				if (ds.Tables[0].Rows.Count >= 1)
				{
					Developer developer = new Developer((long)ds.Tables[0].Rows[0]["Id"], (String)ds.Tables[0].Rows[0]["FirstName"], (String)ds.Tables[0].Rows[0]["LastName"], (String)ds.Tables[0].Rows[0]["type"]);

					developer.UserAppList = App.GetUserAssignedApps(developer);

					return developer;

				}
				else
				{
					return null;
				}





		}

		/// <summary>
		/// gets all bugs assigned to this developer
		/// </summary>
		/// <returns></returns>
		public List<Bug> getAssignedBugs()
		{
			return null;
		}


		/// <summary>
		/// gets a list of applications assigned to this developer
		/// </summary>
		/// <returns></returns>
		public List<App> getAssignedApplicationList()
		{
			return null;
		}




	}
}
