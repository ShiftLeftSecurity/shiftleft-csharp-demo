using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;

namespace netfwMVCBasic.Controllers
{
    public class BaseAppController : Controller { }

    public class MyAppController : BaseAppController
    {
        protected ILogger _logger = new LoggerFactory().CreateLogger("<home mvc>");
    }

    public class CustomController : MyAppController
    {
        public ActionResult Action1(int id)
        {
            _logger.LogInformation("received id:{0} from action1", id);

            ViewBag.MyMessage = "Hello id:" + id + " !!!";

            return View();
        }
    }
}