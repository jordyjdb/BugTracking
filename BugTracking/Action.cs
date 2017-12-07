using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	public class Action
	{
		public long Id { get; private set; }
		public long Name { get; set; }

		public static List<BugTracking.Action> Get()
		{
			return null;
		}

	}
}
