using Microsoft.Owin;
using Owin;
using SignalServer.Connections;

[assembly: OwinStartupAttribute(typeof(SignalServer.Startup))]
namespace SignalServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<FirstSocket>("/FirstSocket");
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
