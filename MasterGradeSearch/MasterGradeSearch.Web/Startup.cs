using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasterGradeSearch.Web.Startup))]
namespace MasterGradeSearch.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
