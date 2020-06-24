using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Extensions.Logging;

namespace netfwWebapi.Controllers
{
    public class UnannotatedController : ApiController
    {
        private readonly ILogger _logger = new LoggerFactory().CreateLogger("unannoatedcontroller");

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogWarning("get id {0} ", id);
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogWarning("post value {0} ", value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogWarning("put id {0} ", id);
            _logger.LogWarning("put value {0} ", value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogWarning("put id {0} ", id);
        }
    }
}