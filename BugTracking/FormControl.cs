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

		public static List<FormControl> get(long AppID)
		{
			List<FormControl> formControls = new List<FormControl>();

			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("SELECT dbo.ControlType.Type AS ControlType, dbo.Controls.label, dbo.Controls.name, dbo.Controls.id, dbo.Controls.active FROM dbo.ApplicationControls INNER JOIN dbo.Controls ON dbo.ApplicationControls.ControlID = dbo.Controls.id INNER JOIN dbo.ControlType ON dbo.Controls.controlTypeId = dbo.ControlType.id WHERE(dbo.ApplicationControls.Applicationid = @ID)", sqlCon);
			sqlCom.Parameters.Add(new SqlParameter("@ID", AppID));


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

					if ((int) row["Active"] == 1)
					{
						Active = true;
					}
					else
					{
						Active = false;
							}




					FormControl formControl = new FormControl
					{
						Name = (String)row["name"],
						Id = (long)row["Id"],
						Label = (String)row["Label"],
						ControlType = (String)row["ControlType"],
						Active = Active
					}; 

					formControls.Add(formControl);
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
