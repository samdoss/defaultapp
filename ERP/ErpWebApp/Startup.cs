using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ErpWebApp.Startup))]
namespace ErpWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
