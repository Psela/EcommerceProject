using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EcommerceProject.Website.Startup))]
namespace EcommerceProject.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
