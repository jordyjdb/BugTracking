using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class User
	{

		public long Id { get; private set; }
		public String FirstName { get; private set; }
		public String LastName { get; private set; }

		public DateTime AccountCreationDate { get; private set; }

		public String Usertype;


		

	}
}
