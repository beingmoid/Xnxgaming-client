using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(XnxGaming.Startup))]
namespace XnxGaming
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
