using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyManager.UI.Startup))]
namespace EasyManager.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
