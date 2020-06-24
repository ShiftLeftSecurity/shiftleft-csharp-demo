using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace slHealthCareMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {       
            slHealthCareServiceReference.ServiceClient client = new slHealthCareServiceReference.ServiceClient();
            return View(client.GetCustomers());
        }
    }
}