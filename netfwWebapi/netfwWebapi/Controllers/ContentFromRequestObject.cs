using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Extensions.Logging;

namespace netfwWebapi.Controllers
{
    public class ContentFromRequestObject : ApiController
    {
        private readonly ILogger _logger = new LoggerFactory().CreateLogger("contentfromrequest");

        public IEnumerable<string> GetAll()
        {
            var content = Request.Content;
            _logger.LogWarning("request content ", content);
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            var content = Request.Content;
            _logger.LogWarning("request content ", content);
            return "value";
        }
    }
}