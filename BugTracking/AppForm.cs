
﻿using BugTracking;
using System;

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BugTracking
{
	public class AppForm
	{
		public long Id { get; private set; }

		/// <summary>
		/// what the form displays on its header
		/// </summary>
		public String label { get; private set; }

		/// <summary>
		/// what is the form name called programatically
		/// Can only be set if set by an inhouse user
		/// </summary>
		public String name { get; private set; }

		/// <summary>
		/// if this is currently active in the application
		/// </summary>
		public Boolean active { get; private set; }

		public long ApplicationID { get; set; }



        

		#region controls
		//controls on the form
		public List<FormControl> controls()
		{
			return null;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="control"></param>
		/// <returns>returns controlID</returns>

		public int addControl(FormControl control)
		{

			return -1;
		}


		public int removeControl(FormControl control)
		{
			return -1;
		}

        public long Save()
        {
          


                //if ID == 0 
                //new bug with no previous link

                //if ID != 0 
                //ID = previuosBugID and create new bug with link


                SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
                SqlCommand sqlCom = new SqlCommand("Insert into Form(label, name,active, ApplicationID) values (@label, @name,@active,@ApplicationID);SELECT SCOPE_IDENTITY() ", sqlCon);
                sqlCom.Parameters.Add(new SqlParameter("@label", label));
                sqlCom.Parameters.Add(new SqlParameter("@name", name));
                sqlCom.Parameters.Add(new SqlParameter("@active", active));
                sqlCom.Parameters.Add(new SqlParameter("@ApplicationID", ApplicationID));



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


        #endregion

        //methods in form
        public List<String> methods;

		//methods in form
		public List<String> parameters;

        public AppForm( string label, string name, bool active, long applicationID)
        {
          
            this.label = label ?? throw new ArgumentNullException(nameof(label));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.active = active;
            this.ApplicationID = applicationID;
        }

        public AppForm(long id, string label, string name, bool active, long applicationID) : this( label, name, active, applicationID)
        {
            this.Id = id;
        }

        /// <summary>
        /// returns list of all applications
        /// </summary>
        /// <returns></returns>
        public static List<AppForm> Get(long ApplicationID)
		{
			List<AppForm> AppForm = new List<AppForm>();

			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("Select * From Form where ApplicationID = @AppID", sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@AppID", ApplicationID));


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
					bool Active;


					if ((long)row["Active"] == 1)
					{
						Active = true;
					}
					else
					{
						Active = false;
					}
					AppForm appForm = new AppForm((long)row["ID"], (String)row["label"], (String)row["name"], Active, (long)row["ApplicationID"]);
				


					AppForm.Add(appForm);
				}
				return AppForm;
			}
			else
			{
				//throw exeption
				return null;
			}



		}
	}
}
