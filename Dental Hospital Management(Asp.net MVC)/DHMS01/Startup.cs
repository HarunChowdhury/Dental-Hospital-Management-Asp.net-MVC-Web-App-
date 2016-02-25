using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DHMS01.Startup))]
namespace DHMS01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
