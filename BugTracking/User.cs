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

		public String FirstName { get;  set; }
		public String LastName { get;  set; }

		public DateTime AccountCreationDate { get; private set; }

		public String Usertype;

		protected User(long Id, String FirstName, String LastName, String Usertype) :this(FirstName,  LastName,  Usertype)
		{
			this.Id = Id;
		}
		public User(String FirstName, String LastName, String Usertype)
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

			if (ds.Tables[0].Rows.Count >= 1)
			{
				this.Id = (long)ds.Tables[0].Rows[0]["Id"];
				this.FirstName = (String) ds.Tables[0].Rows[0]["FirstName"];
				this.LastName = (String) ds.Tables[0].Rows[0]["LastName"];

				FullName = FirstName + " " + LastName;
				
				this.Usertype = (String) ds.Tables[0].Rows[0]["Usertype"];
				return true;
			}
			else
			{
				return false;
			}



		}

        public static User Get(long id)
        {
            //retreives information about bug with ID
            DataSet ds = new DataSet();
            SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
            SqlCommand sqlCom = new SqlCommand("Select Users.*, UserTypes.Type From Users inner join UserTypes on Users.typeId = UserTypes.Id where Users.Id = @ID", sqlCon);
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

            if (ds.Tables[0].Rows.Count >= 1)
            {
                User user = new User((long)ds.Tables[0].Rows[0]["Id"], (String)ds.Tables[0].Rows[0]["FirstName"], (String)ds.Tables[0].Rows[0]["LastName"], (String)ds.Tables[0].Rows[0]["type"]);

                return user;
            }
            else
            {
                return null;
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
			SqlCommand sqlCom = new SqlCommand("Select Users.*, UserTypes.Type From Users inner join UserTypes on Users.typeId = UserTypes.Id", sqlCon);

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
					String typeID = (String)row["type"];

					User newUser = new User(Id, FirstName, LastName, typeID);
					Users.Add(newUser);
				}
			}

			return Users;

		}

        public void Save()
        {
            SqlConnection sqlCon = new SqlConnection(Settings.AzureBugTrackingConnectionString);
			DataSet ds = new DataSet();

			String sqlCommand;
            SqlCommand sqlCom;
            //if existing User
            if (Id!= 0)
            {
                sqlCommand = "Update Users set(FirstName = @FirstName, LastName = @LastName, TypeID = (Select id from UserTypes where Type =  @Usertype)) where Id = @Id";

                sqlCom = new SqlCommand(sqlCommand, sqlCon);
                sqlCom.Parameters.Add(new SqlParameter("@Id", Id));


            }
            else //if new User
            {
                sqlCommand = "Insert into Users(FirstName, LastName, TypeID) values (@FirstName, @LastName,(Select id from UserTypes where Type =  @Usertype));SELECT SCOPE_IDENTITY()";
                sqlCom = new SqlCommand(sqlCommand, sqlCon);

            }
           
            sqlCom.Parameters.Add(new SqlParameter("@FirstName", FirstName));
            sqlCom.Parameters.Add(new SqlParameter("@LastName", LastName));
            sqlCom.Parameters.Add(new SqlParameter("@Usertype", Usertype));


            try
            {
				//sqlCon.Open();

				//decimal id = (decimal)sqlCom.ExecuteScalar();


				//Id = (long)id;

				sqlCon.Open();

				SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCom);

				sqlDa.Fill(ds);


			}
            catch (SqlException ex)
            {

            }
            finally
            {
                sqlCon.Close();

            }
       

			if (ds != null)
			{
				Id = System.Decimal.ToInt64((decimal) ((DataRow)ds.Tables[0].Rows[0])[0]);
			}
        }


	}
}
