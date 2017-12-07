using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class DeveloperBug :Bug
	{
		/// <summary>
		/// Last historical bug save.
		/// </summary>
		public long PreviousBugId { get; private set; }



		/// <summary>
		/// The bug the developer is reacting to.
		/// </summary>
		public List<Bug> UserBugs;

		/// <summary>
		/// Assigned priority of the bug by a developer or a manager
		/// </summary>
		public String Priority;

		/// <summary>
		/// developers/user who are subscribed to this bug for updates.
		/// </summary>
		public List<User> AlertList;



		/// <summary>
		/// if the bug is open then it can be added to
		/// </summary>
		public Boolean Open { get; private set; }

		public Bug getLatestBug()
		{
			//TODO Select top(1) * from Bug where 



			return null;
		}




		public Bug getNextBug()
		{
			//TODO Select top(1) * from Bug where CreationDate > @CreationDate order by CreationDate ASC



			return null;
		}

		public Bug getFirstBug()
		{
			//TODO Select top(1) * from Bug where firstBugID = @FirstbugID ish order by CreationDate DESC



			return null;
		}


		/// <summary>
		/// gets the previous bug in the chain
		/// </summary>
		/// <returns>NoPreviousBugException is thrown if no previous bug is found, else return object of type type Bug</returns>
		private Bug GetPreviousBug()
		{
			Bug previousBug = new Bug();

			//if bug 
			if (PreviousBugId != 0 && previousBug.get(PreviousBugId) == true)
			{
				return previousBug;
			}
			else
			{
				throw new NoPreviousBugException(string.Format("no previous Bug. Bug by id {0} is the first bug in the chain", Id));
			}

		}



	}
}
