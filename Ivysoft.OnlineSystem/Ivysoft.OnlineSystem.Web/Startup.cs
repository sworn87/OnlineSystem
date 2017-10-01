using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ivysoft.OnlineSystem.Web.Startup))]
namespace Ivysoft.OnlineSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
