using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace PersistentApp.PersistentConnections
{
	public class HelloSocket : PersistentConnection
	{
		protected override Task OnReceived(IRequest request, string connectionId, string data)
		{
			//return base.OnReceived(request, connectionId, data);
			return (data.StartsWith("GetTime")) ? Connection.Send(connectionId, $"Time: {DateTime.Now.ToString()}") : Connection.Broadcast(data);
		}
	}
}