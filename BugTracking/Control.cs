using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class Control
	{
		public long id { get; private set; }

		/// <summary>
		/// optional, what text the control has if any
		/// </summary>
		public long label { get; private set; }

		/// <summary>
		/// what is the Control name called programatically
		/// Can only be set if set by an inhouse user
		/// </summary>
		public long name { get; private set; }


		/// <summary>
		/// Type of control, including button, textbox, label, grid, list etc
		/// </summary>
		public String controlType { get; private set; }

		/// <summary>
		/// if this is currently active in the application
		/// </summary>
		public Boolean active { get; private set; }

	}






}
