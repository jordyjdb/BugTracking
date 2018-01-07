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
			Get();
		}
	
		public BugLocation(long applicationID, long formID, long controlID, string action, string relatedMethod, string relatedParameter, long startLineNumber, long endlineNumber)
		{
			this.applicationID = applicationID;
			this.formID = formID;
			this.controlID = controlID;
			this.action = action;
			this.relatedMethod = relatedMethod;
			this.relatedParameter = relatedParameter;
			this.EndlineNumber = endlineNumber;
			this.StartlineNumber = startLineNumber;
		}

		public long EndlineNumber { get; private set; }
		public long StartlineNumber { get; private set; }
		

		public Boolean Get()
		{
			return Get(Id);
		}

			public Boolean Get(long id)
		{
			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("Select * From BugLocations where Id = @ID", sqlCon);
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



	EndlineNumber = 0;

				if (ds.Tables[0].Rows[0]["EndlineNumber"] != DBNull.Value)
				{
					EndlineNumber = (int)ds.Tables[0].Rows[0]["EndlineNumber"];
				}

			
			

				if (ds.Tables[0].Rows[0]["StartlineNumber"] != DBNull.Value)
				{
					StartlineNumber = (int)ds.Tables[0].Rows[0]["StartlineNumber"];
				}

				

				long applicationID = (int)ds.Tables[0].Rows[0]["applicationID"];

				long formID = (int)ds.Tables[0].Rows[0]["formID"];

				long controlID = (int)ds.Tables[0].Rows[0]["controlID"];

				action = (String)ds.Tables[0].Rows[0]["action"];

				relatedMethod = (String)ds.Tables[0].Rows[0]["relatedMethod"];

				relatedParameter = (String)ds.Tables[0].Rows[0]["relatedParameter"];

				application = new App(applicationID);
				
				form = new AppForm(formID);

				control = new FormControl(controlID);

				return true;
			}
			else
			{
				return false;
			}



		}

		public long Save()
		{
			String insertLocation = "INSERT INTO BUGLOCATIONS(applicationID,formID,controlID,action,relatedMethod,relatedParameter,StartlineNumber,EndLineNumber) values (@applicationID,@formID,@controlID,@action,@relatedMethod,@relatedParameter,@StartLineNumber,@EndLineNumber); SELECT SCOPE_IDENTITY()";
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand(insertLocation, sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@applicationID", applicationID));
			sqlCom.Parameters.Add(new SqlParameter("@formID", formID));
			sqlCom.Parameters.Add(new SqlParameter("@controlID", controlID));
			sqlCom.Parameters.Add(new SqlParameter("@action", action));
			sqlCom.Parameters.Add(new SqlParameter("@relatedMethod", relatedMethod));
			sqlCom.Parameters.Add(new SqlParameter("@relatedParameter", relatedParameter));
			sqlCom.Parameters.Add(new SqlParameter("@EndLineNumber", EndlineNumber));
			sqlCom.Parameters.Add(new SqlParameter("@StartLineNumber", StartlineNumber));


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
