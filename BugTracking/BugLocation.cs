using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	class BugLocation
	{


		public long id { get; private set; }
		/// <summary>
		/// The application the bug resides on
		/// </summary>
		public Application application;

		/// <summary>
		/// the form were the bug occurs
		/// </summary>
		public Form form;

		/// <summary>
		/// the control interacted with by the user when the bug occurs
		/// </summary>
		public Control control;

		/// <summary>
		/// a quick description of the action performed by the user bug occured
		/// </summary>
		public String action;

		/// <summary>
		/// Optional, method relating to bug
		/// </summary>
		public String relatedMethod;

		/// <summary>
		/// Optional, parameter relating to bug
		/// </summary>
		public String relatedParameter;


		public long lineNumber { get; private set; }


	}
}
