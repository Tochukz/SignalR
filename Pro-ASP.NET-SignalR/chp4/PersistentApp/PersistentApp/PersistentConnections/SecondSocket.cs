using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting;

namespace PersistentApp.PersistentConnections
{
	public class SecondSocket: PersistentConnection
	{
		public override void Initialize(IDependencyResolver resolver)
		{
			base.Initialize(resolver);
		}

		public override Task ProcessRequest(HostContext context)
		{
			/* Thre Items property does not exist in the HostContext type for the version */
			//context.Items[HostConstants.SupportsWebSockets] = true;
			// context.Items[HostConstants.WebSocketServerUrl] = "ws://localhost:8219";
			return base.ProcessRequest(context);
		}
	}
}