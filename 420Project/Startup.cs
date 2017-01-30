using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_420Project.Startup))]
namespace _420Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
