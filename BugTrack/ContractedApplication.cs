﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class ContractedApplication : Apps
	{

		/// <summary>
		/// id occosiated with a row in table ContractedApplication
		/// </summary>
		public Client client;

		public DateTime StartDate;
		public DateTime EndDate;
	}
}
