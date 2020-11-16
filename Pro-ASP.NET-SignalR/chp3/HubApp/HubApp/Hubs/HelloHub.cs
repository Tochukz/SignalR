using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace HubApp.Hubs
{
	//[HubName("helloHub")]
	public class HelloHub: Hub
	{
		public void BroadcastMessage(string text)
		{
			Clients.All.displayText(text);
		}
	}
}