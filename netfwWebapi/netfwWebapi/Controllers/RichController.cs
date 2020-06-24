using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Extensions.Logging;

namespace netfwWebapi.Controllers
{
    public class RichController : ApiController
    {
        private readonly ILogger _logger = new LoggerFactory().CreateLogger("richcontroller");

        [HttpGet]
        public IEnumerable<string> FetchAll()
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public string FindById(int id)
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogInformation("get id {0} ", id);
            return "rich";
        }

        [HttpPost]
        public void UpdateValues([FromBody]string value)
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogInformation("post value {0} ", value);
        }

        [HttpPut]
        public void WhateverEntry(int id, [FromBody]string value)
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogInformation("put id {0} ", id);
            _logger.LogInformation("put value {0} ", value);
        }

        [HttpDelete]
        public void EraseById(int id)
        {
            var content = Request.Content;
            _logger.LogInformation("request content ", content);
            _logger.LogInformation("put id {0} ", id);
        }
    }
}