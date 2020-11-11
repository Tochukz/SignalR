using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace HelloSignal.PersistenceConections
{
	public class HelloConnection : PersistentConnection
	{
		protected override Task OnReceived(IRequest request, string connectionId, string data)
		{
			return Connection.Broadcast(data);
		}
	}
}