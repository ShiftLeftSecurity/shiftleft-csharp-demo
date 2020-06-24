using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace netfwMVCBasic.Controllers
{
    public class RedirectController : Controller
    {
        [Route("Go/{id}")]
        public ActionResult Go(int id)
        {
            return Redirect("http://www.google.com?param=" + id);
        }

        [Route("Go-new/{id}")]
        public ActionResult GoNew(int id)
        {
            return new RedirectResult("http://www.google.com?param=" + id);
        }

        [Route("Go2/{id}")]
        public ActionResult Go2(string id)
        {
            return Redirect(Url.Content("whatever") + Uri.EscapeDataString(id));
        }

        [Route("Go3/{id}")]
        public ActionResult Go3(string id)
        {
            return RedirectToAction("Secret", "Redirect", new { id });
        }

        [Route("Go4/{id}")]
        public ActionResult Go4(string id)
        {
            return RedirectToRoute("FixedRoute", new { id });
        }

        public string Secret(int id)
        {
            var msg = string.Format("secret accessed: {0}", id);

            return HttpUtility.HtmlEncode(msg);
        }

        public string Index()
        {
            return "this is index";
        }
    }
}