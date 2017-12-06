using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class Application
	{
		public long Id { get; private set; }
	
		public String name { get; private set; }
		public static object OpenForms { get; internal set; }



		/// <summary>
		/// user that is assigned to look into this problem by default!
		/// </summary>
		public User defaultUser;

		public Boolean get(long id)
		{
			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\visual Studio\\BugTracking\\BugTracking\\BugTracking.mdf';Integrated Security=True;Connect Timeout=30");
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
				this.name = (String)ds.Tables[0].Rows[0]["name"];
				long defaultUserID = (long)ds.Tables[0].Rows[0]["defaultUserID"];

				return true;
			}
			else {
				return false;
			}



		}
	}
}
