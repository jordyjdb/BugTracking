using System;
using BugTracking;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class Developer : User
	{
	



		public Developer(long Id, String FirstName, String LastName,String Usertype) : base(Id, FirstName,LastName,Usertype)
		{

		}



		/// <summary>
		/// gets all bugs assigned to this developer
		/// </summary>
		/// <returns></returns>
		public List<Bug> getAssignedBugs()
		{
			return null;
		}


		/// <summary>
		/// gets a list of applications assigned to this developer
		/// </summary>
		/// <returns></returns>
		public List<App> getAssignedApplicationList()
		{
			return null;
		}




	}
}
