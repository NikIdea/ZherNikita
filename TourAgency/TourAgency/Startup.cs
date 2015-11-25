using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TourAgency.Startup))]
namespace TourAgency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
