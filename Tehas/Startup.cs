using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Klinik.Frontend.Startup))]
namespace Klinik.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
