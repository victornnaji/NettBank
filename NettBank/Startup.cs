using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NettBank.Startup))]
namespace NettBank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
