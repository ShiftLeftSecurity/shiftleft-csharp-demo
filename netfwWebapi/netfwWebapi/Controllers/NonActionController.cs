using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Extensions.Logging;

namespace netfwWebapi.Controllers
{
    public class NonActionController : ApiController
    {
        private readonly ILogger _logger = new LoggerFactory().CreateLogger("verbs controller");

        [NonAction]
        public string GetSomething(int id)
        {
            // THIS SHOULD NOT LEAD TO CONCLUSIONS, BECAUSE IT'S NOT AN EXPOSED METHOD.
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogInformation("get id {0} ", id);
            return "value";
        }
    }
}