using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsyncChatNew.Startup))]
namespace AsyncChatNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
