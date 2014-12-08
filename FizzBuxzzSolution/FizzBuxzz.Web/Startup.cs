using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FizzBuxzz.Web.Startup))]
namespace FizzBuxzz.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            

        }
    }
}
