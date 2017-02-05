using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChessTDD.Web.Startup))]
namespace ChessTDD.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
