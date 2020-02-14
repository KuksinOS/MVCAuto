using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAuto.Startup))]
namespace MVCAuto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
