using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularMVCApp.Startup))]
namespace AngularMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
