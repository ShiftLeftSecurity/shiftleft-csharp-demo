using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace netfwWebapi
{
    public class StolenCookiesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            List<string> output = new List<string>();

            output.Add("Your cookies for all to see...");
            var cookies = Request.Headers.GetCookies();
            if (cookies != null && cookies.Count() > 0)
            {
                foreach (var cookie in cookies)
                {
                    output.Add(HttpUtility.UrlDecode(cookie.ToString()));
                }
            }

            return output;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}