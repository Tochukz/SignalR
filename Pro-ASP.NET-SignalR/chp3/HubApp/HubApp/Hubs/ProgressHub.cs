using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace HubApp.Hubs
{
	public class ProgressHub: Hub
	{
		public async Task<string> Download(IProgress<int> progress)
		{
			int end = 267;
			for (int i = 0; i < end; i++) {
				double frac = (i * 100) / end;
				int prog = (int)Math.Floor(frac);

				await Task.Delay(100);
				progress.Report(prog);
			}
			return "Downlod Complete";
		}
	}
}