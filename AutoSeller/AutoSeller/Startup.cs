using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoSeller.Startup))]
namespace AutoSeller
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
