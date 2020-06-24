using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;

namespace netfwMVCBasic.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger = new LoggerFactory().CreateLogger("<home mvc>");

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string About()
        {
            return "this is the about page";
        }

        /*
         * The WelcomeXXX methods below receive 2 parameters: one of them, 'id',
         * is specified in the default routing of RouteConfig and can be passed
         * directly in the URL path; the other, 'name', is *not* part of the
         * default route and must be supplied in the form of a query string.
         * We should be able to detect flows through both.
         */

        public string Welcome(string name, int id)
        {
            _logger.LogInformation("welcoming name {0} with  !!! ", name);
            _logger.LogInformation("welcoming id {0} with  !!! ", id);


            return HttpUtility.HtmlEncode("this is the welcome page for " + name + " with id " + id + " !!!");
        }

        public string WelcomeNoEncodingAtAll(string name, int id)
        {
            _logger.LogInformation("welcoming name {0} !!! <no encoding> ", name);
            _logger.LogInformation("welcoming id {0} !!! <no encoding> ", id);

            return "welcome again page for " + name + " with id " + id + " !!! <no encoding>";
        }

        public ActionResult WelcomeNoEncodingHereButInWebpage(string name, int id)
        {
            _logger.LogInformation("welcoming name {0}  !!! <encoding in webpage> ", name);
            _logger.LogInformation("welcoming id {0} !!! <encoding in webpage> ", id);


            var data = "this is the welcome page for " + name + " with id " + id + " !!! <encoding in webpage>";
            ViewData["non-encoded"] = data;
            return View();
        }

        public ActionResult WelcomeNoEncodingNeitherHereNorInWebpage(string name, int id)
        {
            _logger.LogInformation("welcoming name {0} !! ", name);
            _logger.LogInformation("welcoming id {0} !! ", id);


            var data = "this is the welcome page for " + name + " with id " + id + " !!! <neither here nor in page encoding >";
            ViewData["non-encoded"] = data;
            return View();
        }

        public ActionResult WelcomeDynamicViewObject(int id)
        {
            ViewBag.SomeField = "this is SomeField id:" + id + " received as input";
            ViewBag.OtherField = "this is OtherField id:" + id + " received as input";
            ViewBag.HeyHoField = HttpUtility.HtmlEncode("this is HeyHoField id ENCODED " + id + " received as input");
            return View();
        }

        public string WelcomeEncodeOtherAPI(string name, int id)
        {
            _logger.LogInformation("welcoming name {0} with  !!! ", name);
            _logger.LogInformation("welcoming id {0} with  !!! ", id);


            return Server.HtmlEncode("this is the welcome page for " + name + " with id " + id + " !!!");
        }
    }
}