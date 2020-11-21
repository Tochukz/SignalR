using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNet.SignalR;

namespace PersistentApp.PersistentConnections
{
	public class MultiUserSocket: PersistentConnection
	{
		protected override Task OnReceived(IRequest request, string connectionId, string data)
		{
			string groupName = request.QueryString["roomName"];
			Debug.WriteLine($"Sending {data} to {groupName} {connectionId}");
			//return Connection.Send(connectionId, data);
			// return Groups.Send(groupName, data, connectionId); // excludes the specified connectionId to array of connectionIds
			return Groups.Send(groupName, data);
		}

		protected override Task OnConnected(IRequest request, string connectionId)
		{
			string groupName = request.QueryString["roomName"];
			if (!string.IsNullOrWhiteSpace(groupName))
			{
				Debug.WriteLine($"Joing group {groupName}");
				Groups.Add(connectionId, groupName);
			}			
			return base.OnConnected(request, connectionId);
		}
		
		protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
		{
			string groupName = request.QueryString["roomName"];
			if (!string.IsNullOrWhiteSpace(groupName))
			{
				Groups.Remove(connectionId, groupName);
			}
			return base.OnDisconnected(request, connectionId, stopCalled);
		}
	}
}