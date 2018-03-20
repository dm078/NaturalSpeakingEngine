using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rhipe_WebApp1.Startup))]
namespace Rhipe_WebApp1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
