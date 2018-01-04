using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	public class FormControl
	{

		public FormControl(long Id)
		{
			this.Id = Id;

			Get();
		}



		private FormControl(long Id, string label, string name, bool active, long applicationId) : this(label, name, active, applicationId) { 

            this.Id = Id;
        }

        public FormControl(string label, string name, bool active, long applicationId)
        {
            this.ApplicationID = applicationId;
            Label = label;
            Name = name;
            Active = active;
        }

        public long Id { get; private set; }

		/// <summary>
		/// optional, what text the control has if any
		/// </summary>
		public String Label { get; private set; }

		/// <summary>
		/// what is the Control name called programatically
		/// Can only be set if set by an inhouse user
		/// </summary>
		public String Name { get; private set; }


		/// <summary>
		/// Type of control, including button, textbox, label, grid, list etc
		/// </summary>
		public String ControlType { get; private set; }

		/// <summary>
		/// if this is currently active in the application
		/// </summary>
		public Boolean Active { get; private set; }

        public long ApplicationID { get; private set; }

		public Boolean Get()
		{
			List<AppForm> AppForm = new List<AppForm>();

			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("Select * From Form where ID = @ID", sqlCon);
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

			if (ds.Tables[0].Rows.Count > 0)
			{

				bool Active;


				if ((long)(ds.Tables[0].Rows[0]["Active"]) == 1)
				{
					Active = true;
				}
				else
				{
					Active = false;
				}

				Id = Id;
				Label = (String)ds.Tables[0].Rows[0]["label"];
				Name = (String)ds.Tables[0].Rows[0]["name"];
				this.Active = Active;
				ApplicationID = (long)ds.Tables[0].Rows[0]["ApplicationID"];



				return true;


			}
			else
			{
				return false;
			}



		}
		public static List<FormControl> Get(long AppID)
		{
			List<FormControl> formControls = new List<FormControl>();

			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("SELECT * FROM controls where Applicationid = @ID", sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@ID", AppID));


			try
			{
				sqlCon.Open();

				SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCom);

				sqlDa.Fill(ds);

			}catch(Exception e)
			{
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
						//Active = (bool)row["Active"];
					




					FormControl formControl = new FormControl((long)row["Id"], (String)row["Label"], (String)row["name"],Active, AppID);



                    formControls.Add(formControl);
				}
				
			}
			return formControls;
		}

        public long Save()
        {
            SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
            SqlCommand sqlCom = new SqlCommand("Insert into Form(label, name,active, ApplicationID) values (@label, @name,@active,@ApplicationID);SELECT SCOPE_IDENTITY() ", sqlCon);
            sqlCom.Parameters.Add(new SqlParameter("@label", Label));
            sqlCom.Parameters.Add(new SqlParameter("@name", Name));
            sqlCom.Parameters.Add(new SqlParameter("@active", Active));
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
    }






}
