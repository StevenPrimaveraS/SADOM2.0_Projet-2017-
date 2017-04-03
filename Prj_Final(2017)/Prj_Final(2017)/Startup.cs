using Microsoft.Owin;
using Owin;
using Prj_Final_2017_.Models.util;

[assembly: OwinStartupAttribute(typeof(Prj_Final_2017_.Startup))]
namespace Prj_Final_2017_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Initialisation du backend
            ApplicationFunctions appFunctionsInit = new ApplicationFunctions();
        }
    }
}
