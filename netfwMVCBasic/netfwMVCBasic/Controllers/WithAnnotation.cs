using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;

namespace netfwMVCBasic.Controllers
{
    /*
     * Bear in mind the difference:
     * 
     * [HttpGet] classical MVC (System.Web.Mvc.HttpGetAttribute)
     * https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.httpgetattribute?view=aspnet-mvc-5.2
     * 
     * [HttpGet] MVC, WebApi - .NET Core (Microsoft.AspNetCore.Mvc.HttpGetAttribute)
     * https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.httpgetattribute?view=aspnetcore-2.2
     * 
     */
    public class WithAnnotation : Controller
    {
        private ILogger _logger = new LoggerFactory().CreateLogger("with annotation");

        // GET: WithAnnotation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RetrieveFor(int id)
        {
            _logger.LogInformation("retrieve for", id);
            return View();
        }

        [HttpPost]
        public string ChangeFor(int id)
        {
            _logger.LogInformation("change for ", id);
            return "changed for " + id;
        }
    }
}