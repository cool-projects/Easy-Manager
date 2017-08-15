using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyManager.Startup))]
namespace EasyManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
