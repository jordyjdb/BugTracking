using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	public class BugLocation
	{


		public long Id { get; private set; }
		/// <summary>
		/// The application the bug resides on
		/// </summary>
		public Apps application;

		/// <summary>
		/// the form were the bug occurs
		/// </summary>
		public Form form;

		/// <summary>
		/// the control interacted with by the user when the bug occurs
		/// </summary>
		public Control control;

		/// <summary>
		/// a quick description of the action performed by the user bug occured
		/// </summary>
		public String action;

		/// <summary>
		/// Optional, method relating to bug
		/// </summary>
		public String relatedMethod;

		/// <summary>
		/// Optional, parameter relating to bug
		/// </summary>
		public String relatedParameter;


		public long lineNumber { get; private set; }



		
		public Boolean get(long id)
		{
			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("Select * From BugLocation where Id = @ID", sqlCon);
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
				lineNumber = (long) ds.Tables[0].Rows[0]["lineNumber"];
				

				long applicationID = (long)ds.Tables[0].Rows[0]["applicationID"];

				long formID = (long)ds.Tables[0].Rows[0]["formID"];

				long controlID = (long)ds.Tables[0].Rows[0]["controlID"];

				 action = (String)ds.Tables[0].Rows[0]["action"];

				 relatedMethod = (String)ds.Tables[0].Rows[0]["relatedMethod"];

				 relatedParameter = (String) ds.Tables[0].Rows[0]["relatedParameter"];
				


				return true;
			}
			else {
				return false;
			}



		}



















	}
}
