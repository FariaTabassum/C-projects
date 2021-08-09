using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(University_Management_MVC.Startup))]
namespace University_Management_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
