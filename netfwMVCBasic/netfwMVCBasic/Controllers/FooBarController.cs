using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;

namespace netfwMVCBasic.Controllers
{
    public class FooBarController : Controller
    {
        private ILogger _logger = new LoggerFactory().CreateLogger("<home mvc>");

        public string Test(int foo, int bar)
        {
            _logger.LogInformation("foo passed: ", foo);
            _logger.LogInformation("bar passed: ", bar);

            var msg = string.Format("received foo: {0} and bar {1} !", foo, bar);
            return HttpUtility.HtmlEncode(msg);
        }

        [Route("AddExternal")]
        public string AddExternal(int what)
        {
            _logger.LogInformation("add external: ", what);
            var msg = string.Format("add external: {0} !", what);

            return HttpUtility.HtmlEncode(msg);
        }

        // Accessible http://localhost:51005/AddOther?what=123, but not through name 'Hoho',
        // not with what as part of the route (only through query string), and not through 'FooBar'.
        [Route("AddOther")]
        public string Hoho(int what)
        {
            _logger.LogInformation("add other: ", what);
            var msg = string.Format("add other: {0} !", what);

            return HttpUtility.HtmlEncode(msg);
        }

        // Accessible via http://localhost:51005/AddSomething/123, but not through 'Hihi' and
        // not through 'FooBar'.
        [Route("AddSomething/{what}")]
        public string Hihi(int what)
        {
            _logger.LogInformation("add other: ", what);
            var msg = string.Format("add other: {0} !", what);

            return HttpUtility.HtmlEncode(msg);
        }
    }
}