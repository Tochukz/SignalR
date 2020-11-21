using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PersistentApp.Hubs
{
	public class HelloHub: Hub
	{
		public void BroadcastMessage(string message)
		{
			Clients.All.SendMessage(message);
		}

		public void GetTime()
		{
			Clients.Caller.SendTime(DateTime.Now.ToString());
		}
	}
}