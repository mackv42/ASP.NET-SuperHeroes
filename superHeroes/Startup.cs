using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(superHeroes.Startup))]
namespace superHeroes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
