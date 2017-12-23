using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class ContractedApplication : BugTracking.App
	{

        public ContractedApplication(long Id, string Name) : base(Id,Name)
        {
           
        }


        /// <summary>
        /// id occosiated with a row in table ContractedApplication
        /// </summary>
        public Client Client;

		public DateTime StartDate;
		public DateTime EndDate;
	}
}
