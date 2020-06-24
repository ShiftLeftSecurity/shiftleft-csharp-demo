using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Extensions.Logging;

namespace netfwWebapi.Controllers
{
    public class UnannotatedSuffixedController : ApiController
    {
        private readonly ILogger _logger = new LoggerFactory().CreateLogger("unannoatedSUFFIXcontroller");

        // GET api/<controller>/5
        public string GetSpecific(int id)
        {
            var content = Request.Content;
            _logger.LogWarning("request content ", content);
            _logger.LogInformation("get id {0} ", id);
            return "value";
        }

        // POST api/<controller>
        public void PostSomething([FromBody]string value)
        {
            var content = Request.Content;
            _logger.LogWarning("request content ", content);
            _logger.LogInformation("post value {0} ", value);
        }

        // PUT api/<controller>/5
        public void PutThings(int id, [FromBody]string value)
        {
            var content = Request.Content;
            _logger.LogWarning("request content ", content);
            _logger.LogInformation("put id {0} ", id);
            _logger.LogInformation("put value {0} ", value);
        }

        // DELETE api/<controller>/5
        public void DeleteSpecific(int id)
        {
            var content = Request.Content;
            _logger.LogWarning("request content ", content);
            _logger.LogInformation("put id {0} ", id);
        }
    }
}