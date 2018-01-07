﻿using BugTracking;
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

		public App(long Id) {
			this.Id = Id;
			Get(Id);
		}

		public App(long Id,string Name) : this(Name)
        {
            this.Id = Id;
        }


        public App(string Name)
        {
            this.Name = Name;
        }

		/// <summary>
		/// Saves Application to database
		/// </summary>
		/// <returns>new Application ID</returns>
		public long Save()
        {

     
                //if ID == 0 
                //new bug with no previous link

                //if ID != 0 
                //ID = previuosBugID and create new bug with link


                SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
                SqlCommand sqlCom = new SqlCommand("Insert into Application(name, defaultUserID) values (@name, @defaultUserId);SELECT SCOPE_IDENTITY() ", sqlCon);
                sqlCom.Parameters.Add(new SqlParameter("@name", Name));
                sqlCom.Parameters.Add(new SqlParameter("@defaultUserId", DefaultUser.Id));
            


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
		/// retreives saved Application
		/// </summary>
		/// <param name="id">Wanted application's ID</param>
		/// <returns></returns>
        public Boolean Get(long id)
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
		/// Lists Applications assigned to user
		/// </summary>
		/// <returns>returns list of all applications</returns>
		public static List<App> GetUserAssignedApps(Developer user)
		{
			List<App> applications = new List<App>();

			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("Select * From Application where DEFAULTUSERID = @DefaultUserID", sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@DefaultUserID", user.Id));

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

					App application = new App((long)row["Id"], (String)row["name"]);
					
					application.DefaultUser = user;

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

		/// <summary>
		/// returns list of all applications
		/// </summary>
		/// <returns></returns>
		public static List<App> Get()
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

					App application = new App((long)row["Id"], (String)row["name"]);

					Developer developer = Developer.Get((long)row["DEFAULTUSERID"]);
					application.DefaultUser = developer;

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
