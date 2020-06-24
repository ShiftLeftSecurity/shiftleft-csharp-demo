using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;

namespace netfwMVCBasic.Controllers
{
    [RoutePrefix("Users")]
    public class WhateverController : Controller
    {
        private ILogger _logger = new LoggerFactory().CreateLogger("<routed>");

        [Route("Here/{id}")]
        public string Index(int id)
        {
            _logger.LogInformation("got routed users/here ", id);
            string msg = string.Format("message from routed users/here {0}", id);

            return HttpUtility.HtmlEncode(msg);
        }
    }
}
