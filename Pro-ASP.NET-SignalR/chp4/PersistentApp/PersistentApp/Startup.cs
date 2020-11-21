using Microsoft.Owin;
using Owin;
using PersistentApp.PersistentConnections;
using PersistentApp.Hubs;

[assembly: OwinStartupAttribute(typeof(PersistentApp.Startup))]
namespace PersistentApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<HelloSocket>("/HelloSocket");
            app.MapSignalR<SignalingSocket>("/SignalSocket");
            app.MapSignalR<MultiUserSocket>("/MultiUserSocket");
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
