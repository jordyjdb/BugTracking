using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking
{
	static class  Settings
	{
		static public String AzureBugTrackingConnectionString = "Data Source=jbailey6874.database.windows.net;Initial Catalog=BugTrackingDataSet;Integrated Security=False;User ID=jordyjdb;Password=Jordyjune26;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		static public object iif(bool expression, object truePart, object falsePart)
		{ return expression ? truePart : falsePart; }
	}
}
