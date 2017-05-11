using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrossDominCheck.Startup))]
namespace CrossDominCheck
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
