﻿using BugTracking;
using System;
using System.Collections.Generic;

namespace BugTrack
{
	public class AppForm
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

		/// <summary>
		/// if this is currently active in the application
		/// </summary>
		public Boolean active { get; private set; }

		#region controls
		//controls on the form
		public List<FormControl> controls()
		{
			return null;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="control"></param>
		/// <returns>returns controlID</returns>
		public int addControl(FormControl control)
		{

			return -1;
		}

		public int removeControl(FormControl control)
		{

			return -1;
		}

		#endregion

		//methods in form
		public List<String> methods;

		//methods in form
		public List<String> parameters;



	}
}
