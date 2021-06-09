using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalServer.Connections
{
	public class FirstSocket: PersistentConnection
	{
		protected override Task OnReceived(IRequest request, string connectionId, string data)
		{
			return Connection.Send(connectionId, data);
		}
	}
}