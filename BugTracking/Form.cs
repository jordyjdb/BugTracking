using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class Form
	{
		public long id { get; private set; }

		/// <summary>
		/// what the form displays on its header
		/// </summary>
		public long label { get; private set; }

		/// <summary>
		/// what is the form name called programatically
		/// Can only be set if set by an inhouse user
		/// </summary>
		public long name { get; private set; }

		public List<Control> controls;

		//methods in form
		public List<String> methods;

		//methods in form
		public List<String> parameters;


	}
}
