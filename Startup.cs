using Microsoft.Owin;
using Owin;
using System.Net.Http;
using System.Web.Http;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
