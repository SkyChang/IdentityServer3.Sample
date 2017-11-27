using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

[assembly: OwinStartup(typeof(IdentityServer3.Sample.Web.Startup))]

namespace IdentityServer3.Sample.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "https://localhost:44365/identity",

                Scope = "openid profile roles",
                ClientId = "mvc",
                RedirectUri = "http://localhost:28545/",
                ResponseType = "id_token",

                SignInAsAuthenticationType = "Cookies"
            });
        }
    }
}
