using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Scania.VT.UI.Web.Startup))]
namespace Scania.VT.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
