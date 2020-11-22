using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DebugApp.Startup))]
namespace DebugApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
