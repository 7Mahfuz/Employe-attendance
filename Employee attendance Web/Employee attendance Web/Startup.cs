using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Employee_attendance_Web.Startup))]
namespace Employee_attendance_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
