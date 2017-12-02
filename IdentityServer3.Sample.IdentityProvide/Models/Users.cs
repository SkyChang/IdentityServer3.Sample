using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace IdentityServer3.Sample.IdentityProvide.Models
{
    // 這個 IDP 提供的使用者帳號與密碼，等同於 Google 帳號的意思
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
        {
            new InMemoryUser
            {
                Username = "Sky",
                Password = "12345",
                Subject = "1",

                //Claims = new[]
                //{
                //    new Claim(Constants.ClaimTypes.GivenName, "Bob"),
                //    new Claim(Constants.ClaimTypes.FamilyName, "Smith")
                //}
                Claims = new[]
                {
                    new Claim(Constants.ClaimTypes.GivenName, "Bob"),
                    new Claim(Constants.ClaimTypes.FamilyName, "Smith"),
                    new Claim(Constants.ClaimTypes.Role, "Geek"),
                    new Claim(Constants.ClaimTypes.Role, "Foo")
                }
            }
        };
        }
    }
}