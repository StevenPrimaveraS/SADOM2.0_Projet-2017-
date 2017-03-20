using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prj_Final_2017_.Startup))]
namespace Prj_Final_2017_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
