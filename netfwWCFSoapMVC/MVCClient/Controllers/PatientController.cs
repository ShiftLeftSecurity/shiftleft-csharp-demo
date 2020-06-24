using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;

namespace MVCClient.Controllers
{
    public class PatientController : Controller
    {
        private ILogger _logger = new LoggerFactory().CreateLogger("MVCLocalLogger");

        // GET: Patient
        public ActionResult Index()
        {
            ServiceReference.WcfServiceClient client = new ServiceReference.WcfServiceClient();
            return View(client.GetPatients1());
        }

        public ActionResult Index2()
        {
            ServiceReference.WcfServiceClient client = new ServiceReference.WcfServiceClient();
            return View(client.GetPatients2());
        }

        public ActionResult Index3()
        {
            ServiceReference.WcfServiceClient client = new ServiceReference.WcfServiceClient();
            return View(client.GetPatients3());
        }

        public ActionResult Index4()
        {
            ServiceReference.WcfServiceClient client = new ServiceReference.WcfServiceClient();
            return View(client.GetPatients4());
        }

        public ActionResult Index5()
        {
            ServiceReference.WcfServiceClient client = new ServiceReference.WcfServiceClient();
            var data = client.GetPatients5();
            ViewData["message"] = data;
            return View();
        }
    
        public ActionResult Index6()
        {
            ServiceReference.WcfServiceClient client = new ServiceReference.WcfServiceClient();
            var data = client.GetPatients5();
            ViewData["message"] = data;
            return View();
        }

        public ActionResult Details(int id)
        {
            ServiceReference.WcfServiceClient client = new ServiceReference.WcfServiceClient();
            var allergies = client.GetPatientDetails(id);

            _logger.LogInformation("<mvc client> request details of patient ID {0}", id);

            return View(allergies);
        }

        public ActionResult SendSomethig(int id)
        {
            ServiceReference.WcfServiceClient client = new ServiceReference.WcfServiceClient();
            var whatever = client.SomeSoapData(id);

            return View();
        }

        public ActionResult SendSomethigAgain(int id)
        {
            ServiceReference.WcfServiceClient client = new ServiceReference.WcfServiceClient();
            client.ModifySoapData(id);

            return View();
        }

        public ActionResult OnTextBox()
        {
            ViewData["message"] = "text box has been clicked";
            return View();
        }

        public ActionResult OnTextArea()
        {


            ViewData["message"] = "text area has been clicked";
            return View();
        }
    }
}