using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace HubApp.Hubs
{
	/*A strongly typed Hub*/
	public class StrongHub: Hub<IClient>
	{
		public async Task SendToAll(string message)
		{
			await Clients.All.NewMessage(message);
		}
	}

	public interface IClient
	{
		Task NewMessage(string message);
	}
}