using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContainermanagementsystemTP034963.Startup))]
namespace ContainermanagementsystemTP034963
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
