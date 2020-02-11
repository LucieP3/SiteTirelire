using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteTirelire.Startup))]
namespace SiteTirelire
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
