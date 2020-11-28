using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ofCourse.Startup))]
namespace ofCourse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
