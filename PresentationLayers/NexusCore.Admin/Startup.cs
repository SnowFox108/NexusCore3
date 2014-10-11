using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NexusCore.Admin.Startup))]
namespace NexusCore.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
