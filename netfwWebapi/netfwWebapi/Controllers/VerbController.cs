using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Extensions.Logging;

namespace netfwWebapi.Controllers
{
    public class VerbController : ApiController
    {
        private readonly ILogger _logger = new LoggerFactory().CreateLogger("verbs controller");


        [AcceptVerbs("GET", "HEAD", "POST", "PATCH")]
        public string DoSomething(int id)
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogInformation("get id {0} ", id);
            return "do something";
        }
    }
}