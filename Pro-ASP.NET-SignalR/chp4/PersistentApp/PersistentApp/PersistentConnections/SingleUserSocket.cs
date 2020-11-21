using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting;
using System.Threading.Tasks;

namespace PersistentApp.PersistentConnections
{
	/* implementing a Single User Group*/
	public class SingleUserSocket: PersistentConnection
	{
		protected override Task OnReceived(IRequest request, string connectionId, string data)
		{
			string groupName = request.User.Identity.Name;
			return Groups.Send(groupName, data);
		}

		protected override Task OnConnected(IRequest request, string connectionId)
		{
			string groupName = request.User.Identity.Name;
			if (!string.IsNullOrWhiteSpace(groupName))
			{
				Groups.Add(connectionId, groupName);
			}
			return base.OnConnected(request, connectionId);
		}

		protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
		{
			string groupName = request.User.Identity.Name;
			if (!string.IsNullOrWhiteSpace(groupName))
			{
			   Groups.Remove(connectionId, groupName);
			}
			return base.OnDisconnected(request, connectionId, stopCalled);
		}
	}
}