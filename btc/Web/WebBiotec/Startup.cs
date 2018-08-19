using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBiotec.Startup))]
namespace WebBiotec
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
