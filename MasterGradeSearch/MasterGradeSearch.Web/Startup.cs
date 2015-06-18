using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasterGradeSearch.Web.Startup))]
namespace MasterGradeSearch.Web
{
    /// <summary>
    ///     Класс, обеспечивающий старт веб приложения
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
