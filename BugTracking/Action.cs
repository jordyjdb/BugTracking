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


        public Action(string name, String Description, long ApplicationId)
        {
            Name = name;
            this.Description = Description;
            this.ApplicationId = ApplicationId;
        }
        
        public Action(long Id, string name,String Description, long ApplicationId) :this(name,Description,ApplicationId)
        {
            this.Id = Id;
        }
        public long Id { get; private set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public long ApplicationId { get; set; }


		/// <summary>
		/// Saves Action to database
		/// </summary>
		/// <returns>new Action ID</returns>
        public long Save()
        {
            SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
            SqlCommand sqlCom = new SqlCommand("Insert into Actions(name,Description, ApplicationID) values (@name,@Description,@ApplicationID);SELECT SCOPE_IDENTITY()", sqlCon);
            sqlCom.Parameters.Add(new SqlParameter("@Description", Description));
            sqlCom.Parameters.Add(new SqlParameter("@name", Name));
            sqlCom.Parameters.Add(new SqlParameter("@ApplicationID", ApplicationId));



            try
            {
                sqlCon.Open();

                decimal id = (decimal)sqlCom.ExecuteScalar();


                Id = (long)id;


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
    



   /// <summary>
   /// Gets actions relating to Application
   /// </summary>
   /// <param name="AppID"></param>
   /// <returns>List of actions</returns>
    public static List<BugTracking.Action> Get(long AppID)
		{
			List<Action> formControls = new List<Action>();

			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("SELECT * from Actions where ApplicationID = @ApplicationID", sqlCon);
            sqlCom.Parameters.Add(new SqlParameter("@ApplicationID", AppID));


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
                    
                    Action action = new Action((long)row["Id"], (String)row["name"], (String)row["Description"], AppID);
				

					formControls.Add(action);
				}
				
			}
            return formControls;
        }

	}
}
