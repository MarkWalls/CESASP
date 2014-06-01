using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CES.ASP.Startup))]
namespace CES.ASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
