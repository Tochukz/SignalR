using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(HubApp.Startup))]
namespace HubApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			//HubConfiguration hubConfig = new HubConfiguration();            
			//hubConfig.EnableDetailedErrors = true;
			//hubConfig.EnableJavaScriptProxies = false;
			//app.MapSignalR("/custom-proxy-path", hubConfig);

			//app.UseCors(CorsOptions.AllowAll);
			app.MapSignalR("/signalr", new HubConfiguration { EnableDetailedErrors = true});

			//app.MapSignalR();

			//app.Map("/signalr", map =>
			//{
			//	app.UseCors(CorsOptions.AllowAll);
			//	map.RunSignalR(new HubConfiguration { EnableDetailedErrors = true, EnableJSONP = true });
			//});

			ConfigureAuth(app);           
        }
    }
}
