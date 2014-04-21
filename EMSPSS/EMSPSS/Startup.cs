using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMSPSS.Startup))]
namespace EMSPSS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
