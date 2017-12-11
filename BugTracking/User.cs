using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	public class User
	{

		public long Id { get; private set; }

		public String FullName { get; private set; }

		public String FirstName { get; private set; }
		public String LastName { get; private set; }

		public DateTime AccountCreationDate { get; private set; }

		public long Usertype;

		protected User(long Id, String FirstName, String LastName, long Usertype) :this(FirstName,  LastName,  Usertype)
		{
			this.Id = Id;
		}
		public User(String FirstName, String LastName, long Usertype)
		{
			this.FirstName = FirstName;
			this.LastName = LastName;

			FullName = FirstName + " " + LastName;
				

			this.Usertype = Usertype;
		}

		public Boolean get(long id)
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
				this.Id = (long)ds.Tables[0].Rows[0]["Id"];
				this.FirstName = (String) ds.Tables[0].Rows[0]["FirstName"];
				this.LastName = (String) ds.Tables[0].Rows[0]["LastName"];

				FullName = FirstName + " " + LastName;
				
				this.Usertype = (long) ds.Tables[0].Rows[0]["Usertype"];
				return true;
			}
			else
			{
				return false;
			}



		}

		/// <summary>
		/// applications that the client can choose when filling in bug information
		/// </summary>
		public static List<User> Get()
		{

			List<User> Users = new List<User>();
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			SqlCommand sqlCom = new SqlCommand("Select * From Users", sqlCon);

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

					String FirstName = (String)row["FirstName"];
					String LastName = (String)row["LastName"];
					long typeID = (long)row["typeID"];

					User newUser = new User(Id, FirstName, LastName, typeID);
					Users.Add(newUser);
				}
			}

			return Users;

		}


	}
}
