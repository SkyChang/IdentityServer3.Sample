using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityServer3.Sample.IdentityProvide.Models
{
    /// <summary>
    /// 定義有哪些應用程式會來呼叫
    /// </summary>
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
            // 提供 IdentityServer3.Sample.Web 使用
            new Client
            {
                Enabled = true,
                ClientName = "MVC Client",
                ClientId = "mvc",
                Flow = Flows.Implicit,

                // 完成登入後導航之位置
                RedirectUris = new List<string>
                {
                    "http://localhost:28545/"
                },
                // 登出時往返
                 PostLogoutRedirectUris = new List<string>
                {
                    "http://localhost:28545/"
                },
                AllowAccessToAllScopes = true
            },
            // 提供 IdentityServer3.Sample.Api 使用
            new Client
            {
                ClientName = "MVC Client (service communication)",
                ClientId = "mvc_service",
                Flow = Flows.ClientCredentials,

                ClientSecrets = new List<Secret>
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = new List<string>
                {
                    "sampleApi"
                }
            }
        };
        }
    }
}