using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCustomer.Startup))]
namespace MyCustomer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
