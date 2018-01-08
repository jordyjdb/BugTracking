using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
    public class UserType
    {
		/// <summary>
		/// Breif Desciption of bug
		/// </summary>
        public String Description { get; set; }

		
        public long Id { get; set; }

        public UserType(long Id, String Description)
        {
            this.Id = Id;
            this.Description = Description;
        }

		/// <summary>
		/// Gets a list of Bug Types
		/// </summary>
		/// <returns></returns>
        public static List<UserType> Get()
        {
            List<UserType> UserType = new List<UserType>();
            DataSet ds = new DataSet();
            SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
            SqlCommand sqlCom = new SqlCommand("Select * From userTypes", sqlCon);

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
                 
                    long Id = (long)row["Id"];
                    String type = (String)row["type"];

                    UserType newUser = new UserType(Id, type);
                    UserType.Add(newUser);
                }
            }

            return UserType;
        }


    }
}
