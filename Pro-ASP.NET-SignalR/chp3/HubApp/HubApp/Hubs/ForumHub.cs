using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;
namespace HubApp.Hubs
{
	public class ForumHub: Hub
	{
		public void PostMessage(Post post)
		{
			Debug.WriteLine($"Origin: {Context.Headers["Origin"]}");
			Debug.WriteLine($"State: {Clients.Caller.CustomClientName}");
			Clients.Group(post.GroupName).newMessage(post);					
		}

		public Task Join(string groupName)
		{
			return Groups.Add(Context.ConnectionId, groupName);
		}

		public Task Leave(string groupName)
		{
			return Groups.Remove(Context.ConnectionId, groupName);
		}

		/** Events Methods */
		public override Task OnConnected()
		{
			Debug.WriteLine($"New Connection to {Context.Headers["User-Agent"]}");
			Debug.WriteLine($"Connection ID {Context.ConnectionId}");
			return base.OnConnected();
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			return base.OnDisconnected(stopCalled);
		}

		public override Task OnReconnected()
		{
			return base.OnReconnected();
		}
	}

	public struct Post
	{
		public string Username;
		public string Text;
		public string GroupName;
	}
}