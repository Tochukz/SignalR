using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hosting;

namespace PersistentApp.PersistentConnections
{
	public class SignalingSocket: PersistentConnection
	{
		protected override Task OnReceived(IRequest request, string connectionId, string data)
		{
			return Connection.Broadcast(data);
		}
	}
}