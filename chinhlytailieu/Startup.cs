using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chinhlytailieu.Startup))]
namespace chinhlytailieu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
