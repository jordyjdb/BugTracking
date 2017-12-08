using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	public class Action
	{
		public long Id { get; private set; }
		public String Name { get; set; }

		public static List<BugTracking.Action> Get()
		{
			List<Action> formControls = new List<Action>();

			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("SELECT * from Actions", sqlCon);



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

			


					Action action = new Action
					{
						Name = (String)row["name"],
						Id = (long)row["Id"],
						
					};

					formControls.Add(action);
				}
				return formControls;
			}
			else
			{
				//throw exeption
				return null;
			}
		}

	}
}
