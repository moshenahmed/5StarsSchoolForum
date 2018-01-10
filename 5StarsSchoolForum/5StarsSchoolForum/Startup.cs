using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_5StarsSchoolForum.Startup))]
namespace _5StarsSchoolForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
