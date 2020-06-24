using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace netfwWebapi
{
    public class FilePathController : ApiController
    {
        // GET: api/FilePath
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FilePath/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FilePath
        public void Post([FromBody]string value)
        {
            if (string.IsNullOrEmpty(value))
                return;

            string[] tokens = value.Split(':');
            string basename = tokens[1].Replace("\"", "");
            basename = basename.Replace("}", "");
            StringBuilder filePathBuilder = new StringBuilder(@"c:\windows\");
            filePathBuilder.Append(@"..\");
            filePathBuilder.Append(basename);
            filePathBuilder.Append(".cmd");

            using (StreamWriter writer = new StreamWriter(filePathBuilder.ToString()))
            {
                writer.Write(@"dir");
            }
        }

        // PUT: api/FilePath/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FilePath/5
        public void Delete(int id)
        {
        }
    }
}
