using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class Bug
	{
		public  String Title { get; set; }
		public String Comment { get; set; }
		private long Id { get; set; }
	public long previousBugId { get; set; }

	#region initialize Bug
	public Bug(long Id, String Title, String Comment, long previousBugId)
		{
			this.Title = Title;
			this.Comment = Comment;
			this.Id = Id;
			this.previousBugId = previousBugId;
		}
		public Bug(long Id, String Title, String Comment)
		{
			this.Title = Title;
			this.Comment = Comment;
			this.Id = Id;
			this.previousBugId = 0;
		}

		public Bug(long Id,String Title, String Comment, Bug PreviousBug)
		{
			this.Title = Title;
			this.Comment = Comment;
			this.Id = Id;
			this.previousBugId = PreviousBug.Id;
		}

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Boolean get(long id)
		{
			//retreives information about bug with ID
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\visual Studio\\BugTracking\\BugTracking\\BugTracking.mdf';Integrated Security=True;Connect Timeout=30");
			SqlCommand sqlCom = new SqlCommand("Select * From BugList where Id = @ID", sqlCon);
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
				this.Id = id;
				this.Title = (String)ds.Tables[0].Rows[0]["Title"];
				this.Comment = (String)ds.Tables[0].Rows[0]["Comment"];
				this.Comment = (String)ds.Tables[0].Rows[0]["previousBugId"];

				return true;
			}else {
				return false;
			}



		}

		/// <summary>
		/// gets all bugs
		/// </summary>
		public static List<Bug> get()
		{
			List<Bug> BugList = new List<Bug>();
			DataSet ds = new DataSet();
			SqlConnection sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\visual Studio\\BugTracking\\BugTracking\\BugTracking.mdf';Integrated Security=True;Connect Timeout=30");
			SqlCommand sqlCom = new SqlCommand("Select * From BugList", sqlCon);

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
					long Id = (int) row["Id"];
					String Title = (String) row["Title"];
					String Comment = (String) row["Comment"];
					long previousBugId = (int) row["previousBugId"];


					Bug newBug = new Bug(Id, Title, Comment, previousBugId);
					BugList.Add(newBug);
				}
		}

			return BugList;
		}




		public void save()
		{
			//if ID == 0 
			//new bug with no previous link

			//if ID != 0 
			//ID = previuosBugID and create new bug with link

		}

		






	}
}
