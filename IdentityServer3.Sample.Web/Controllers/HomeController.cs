using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace IdentityServer3.Sample.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Detail()
        {
            return View((User as ClaimsPrincipal).Claims);
        }
    }
}