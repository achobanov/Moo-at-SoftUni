using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Moo.Startup))]
namespace Moo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
