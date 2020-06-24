using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Http;
using netfwWebapi.Data;
using netfwWebapi.Models;
using Microsoft.Extensions.Logging;

namespace netfwWebapi.Controllers
{
    public class CustomersController : ApiController
    {
        public CustomersController()
        {
            _objContext = new LibraryContext();
            _logger = new LoggerFactory().CreateLogger("Controller.CustomersController");
        }

        private readonly LibraryContext _objContext;

        private readonly ILogger _logger;

        [Serializable]
        public class testcl
        {
            public string _cmd = "calc.exe";
            public testcl(string cmd)
            {
                if (cmd != "calc.exe")
                    Console.WriteLine("Invalid command");
                else
                    _cmd = cmd;
            }
            public testcl()
            {
                if (_cmd != "calc.exe")
                    Console.WriteLine("Invalid command");
            }

            public void Run()
            {
                Process.Start(_cmd);
            }
        }

        // GET: api/Customers
        public IEnumerable<Customer> Get()
        {
            var customers = DataBuilder.CreateCustomers();
            return customers;
        }

        // GET: api/Customers/5
        [HttpGet]
        public Customer Get(int id)
        {
            _logger.LogInformation("GET: {0}", id);

            var customers = DataBuilder.CreateCustomers();
            foreach (var c in customers)
            {
                _logger.LogInformation("customer: {0}", c.ClientId);
                if (c.ClientId == id)
                {
                    return c;
                }
            }
            throw new ArgumentException("No customer found by that id"); ;
        }

        // POST: api/Customers
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogInformation("post value {0} ", value);
        }

        // PUT: api/Customers/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogInformation("put id {0} ", id);
            _logger.LogInformation("put value {0} ", value);
        }

        // DELETE: api/Customers/5
        [HttpDelete]
        public void Delete(int id)
        {
            var customer = _objContext.Customers.Create();
            _logger.LogInformation("delete customer {0}:", customer.Id);
        }
    }
}
