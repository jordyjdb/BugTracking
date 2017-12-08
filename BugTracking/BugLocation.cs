using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BugTracking
{
	public class BugLocation
	{
		public long Id { get; private set; }
		/// <summary>
		/// The application the bug resides on
		/// </summary>
		public App application;

		/// <summary>
		/// the form were the bug occurs
		/// </summary>
		public AppForm form;

		/// <summary>
		/// the control interacted with by the user when the bug occurs
		/// </summary>
		public FormControl control;

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
		private long applicationID;
		private long formID;
		private long controlID;

		public BugLocation(long id)
		{
			this.Id = id;
		}
	
		public BugLocation(long applicationID, long formID, long controlID, string action, string relatedMethod, string relatedParameter, long lineNumber)
		{
			this.applicationID = applicationID;
			this.formID = formID;
			this.controlID = controlID;
			this.action = action;
			this.relatedMethod = relatedMethod;
			this.relatedParameter = relatedParameter;
			this.lineNumber = lineNumber;
		}

		public long lineNumber { get; private set; }


		public Boolean get()
		{
			return get(Id);
		}

			public Boolean get(long id)
		{
			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
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
				lineNumber = (long)ds.Tables[0].Rows[0]["lineNumber"];


				long applicationID = (long)ds.Tables[0].Rows[0]["applicationID"];

				long formID = (long)ds.Tables[0].Rows[0]["formID"];

				long controlID = (long)ds.Tables[0].Rows[0]["controlID"];

				action = (String)ds.Tables[0].Rows[0]["action"];

				relatedMethod = (String)ds.Tables[0].Rows[0]["relatedMethod"];

				relatedParameter = (String)ds.Tables[0].Rows[0]["relatedParameter"];



				return true;
			}
			else
			{
				return false;
			}



		}

		public long Save()
		{
			String insertLocation = "INSERT INTO BUGLOCATIONS(applicationID,formID,controlID,action,relatedMethod,relatedParameter,lineNumber) values (@applicationID,@formID,@controlID,@action,@relatedMethod,@relatedParameter,@LineNumber); SELECT SCOPE_IDENTITY()";
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand(insertLocation, sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@applicationID", applicationID));
			sqlCom.Parameters.Add(new SqlParameter("@formID", formID));
			sqlCom.Parameters.Add(new SqlParameter("@controlID", controlID));
			sqlCom.Parameters.Add(new SqlParameter("@action", action));
			sqlCom.Parameters.Add(new SqlParameter("@relatedMethod", relatedMethod));
			sqlCom.Parameters.Add(new SqlParameter("@relatedParameter", relatedParameter));
			sqlCom.Parameters.Add(new SqlParameter("@lineNumber", lineNumber));


			try
			{
				sqlCon.Open();

			decimal id = (decimal) sqlCom.ExecuteScalar();


				Id = (long) id;

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
	
	}
}
