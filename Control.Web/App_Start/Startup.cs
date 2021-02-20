using System;
using System.Threading.Tasks;
using Control.Data.Data;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Control.Web.App_Start.Startup))]

namespace Control.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",

                LoginPath = new PathString("/Account/Login")

            });
        }
    }
}
