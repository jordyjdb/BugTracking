using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class Manager : Developer
	{
		public Manager(long Id, String FirstName, String LastName, String Usertype) : base(Id, FirstName, LastName, Usertype)
		{

		}



		/// <summary>
		/// A list of developers assigned to this manager
		/// </summary>
		public List<Developer> Team = null;


		/// <summary>
		/// A list of clients assigned to this manager
		/// </summary>
		public List<Client> getClients()
		{
			return null;
		}
		


	}
}
