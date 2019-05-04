using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnunciApp.Startup))]
namespace AnunciApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
