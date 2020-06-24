using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;

namespace netfwMVCBasic.Controllers
{
    public class AppController : Controller { }

    public class ResultKindController : AppController
    {
        private ILogger _looger = new LoggerFactory().CreateLogger("<resultkindcontrolller>");

        public ViewResult ResultA(int id)
        {
            _looger.LogInformation("action result A with id {0} received!", id);

            return View();
        }

        public PartialViewResult ResultB(int id)
        {
            _looger.LogInformation("action result B with id {0} received!", id);

            return PartialView();
        }

        public EmptyResult ResultC(int id)
        {
            _looger.LogInformation("action result C with id {0} received!", id);

            return new EmptyResult();
        }

        public AppResult ResultD(int id)
        {
            _looger.LogInformation("action result D with id {0} received!", id);

            return new AppResult();
        }

        public MySpecificResult ResultE(int id)
        {
            _looger.LogInformation("action result E with id {0} received!", id);

            return new MySpecificResult();
        }

        public JsonResult ResultF(int id)
        {
            _looger.LogInformation("action result F with id {0} received!", id);

            return Json("hey json");
        }

        public JavaScriptResult ResultG(int id)
        {
            _looger.LogInformation("action result G with id {0} received!", id);

            return JavaScript("alert(js)");
        }

        public ContentResult ResultH(int id)
        {
            _looger.LogInformation("action result H with id {0} received!", id);

            return Content("<html> hey html</html>");
        }
    }

    public class AppResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class MySpecificResult : AppResult
    { }
}