using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Development.Startup))]
namespace Development
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
