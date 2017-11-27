using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Sample.IdentityProvide.Models;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Models;

[assembly: OwinStartup(typeof(IdentityServer3.Sample.IdentityProvide.Startup))]

namespace IdentityServer3.Sample.IdentityProvide
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 設定提供 Identity ( Login 等路徑頁面 )
            app.Map("/identity", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Embedded IdentityServer",
                    SigningCertificate = LoadCertificate(),

                    Factory = new IdentityServerServiceFactory()
                                .UseInMemoryUsers(Users.Get())
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get()),
                                //.UseInMemoryScopes(StandardScopes.All)
                });
            });
        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\idsrv3test.pfx",
                AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}
