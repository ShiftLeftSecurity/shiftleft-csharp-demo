using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace netfwWebapi.Controllers
{
    public class RedirectController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Doit(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = new Uri("http://www.whatever?param=" + id);
            return response;
        }
    }
}
