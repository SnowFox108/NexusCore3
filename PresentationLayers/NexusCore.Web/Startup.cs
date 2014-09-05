using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NexusCore.Web.Startup))]
namespace NexusCore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
