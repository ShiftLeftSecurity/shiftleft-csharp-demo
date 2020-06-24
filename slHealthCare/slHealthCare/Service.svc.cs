using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace slHealthCare
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public string Home()
        {
            return "Welcome to SL HealthCare";
        }

        public List<Customer> GetCustomers()
        {
            HealthCareDBEntities entities = new HealthCareDBEntities();
            var customers = from c in entities.Customers select c;
            //var customers2 = entities.Customers.Select(s => s);
            return customers.ToList();
        }
    }      
}
