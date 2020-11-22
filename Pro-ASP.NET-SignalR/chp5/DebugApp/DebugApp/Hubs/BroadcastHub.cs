using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace DebugApp.Hubs
{
	public class BroadcastHub: Hub
	{
		public void Broadcast(string message)
		{
			Clients.All.sendMessage(message);
		}
	}
}