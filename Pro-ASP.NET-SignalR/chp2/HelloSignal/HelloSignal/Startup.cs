using Microsoft.Owin;
using Owin;
using HelloSignal.PersistenceConections;

[assembly: OwinStartupAttribute(typeof(HelloSignal.Startup))]
namespace HelloSignal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<HelloConnection>("/HelloPC");
            ConfigureAuth(app);
        }
    }
}
