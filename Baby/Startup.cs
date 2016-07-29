using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Baby.Startup))]
namespace Baby
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
