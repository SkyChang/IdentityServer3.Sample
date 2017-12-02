using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer3.Sample.Web.Controllers
{
    public class CallApiController : Controller
    {
        // GET: CallApi
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> ClientCredentials()
        {
            var response = await GetTokenAsync();
            var result = await CallApi(response.AccessToken);

            ViewBag.Json = result;
            return View("ShowApiResult");
        }

        private async Task<TokenResponse> GetTokenAsync()
        {
            var client = new TokenClient(
                "https://localhost:44365/identity/connect/token",
                "mvc_service",
                "secret");

            return await client.RequestClientCredentialsAsync("sampleApi");
        }

        private async Task<string> CallApi(string token)
        {
            var client = new HttpClient();
            client.SetBearerToken(token);

            var json = await client.GetStringAsync("http://localhost:54144/identity");
            return JArray.Parse(json).ToString();
        }
    }
}