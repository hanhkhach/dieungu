using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DieuNgu.Startup))]
namespace DieuNgu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
