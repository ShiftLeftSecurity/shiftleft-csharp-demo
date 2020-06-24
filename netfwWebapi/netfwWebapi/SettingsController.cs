using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;

namespace netfwWebapi
{
    public class SettingsController : ApiController
    {
        // GET: api/Settings
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Settings/5
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/loadSettings
        [Route("api/settings/loadSettings")]
        [HttpGet]
        public HttpResponseMessage LoadSettings()
        {
            if (!checkCookie(HttpContext.Current.Request))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "cookie is incorrect");
            }

            string md5sum = HttpContext.Current.Request.Cookies["settings"].Value;

            DirectoryInfo d = new DirectoryInfo(@".\static\");
            FileInfo[] files = d.GetFiles("*");
            string fileContent = string.Empty;

            foreach (FileInfo file in files)
            {
                FileStream fs = file.OpenRead();
                byte[] encoded = new byte[file.Length];
                fs.Read(encoded, 0, (int)file.Length);
                fileContent = Encoding.UTF8.GetString(encoded);
            }

            if (fileContent.Contains(md5sum))
            {
                string temp = fileContent.Replace(md5sum, "");
                byte[] bytes = Encoding.ASCII.GetBytes(temp);
                string s = System.Convert.ToBase64String(bytes);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                CookieHeaderValue cookieHeaderValue = new CookieHeaderValue("settings", s);
                response.Headers.AddCookies(new List<CookieHeaderValue>() { cookieHeaderValue });
                return response;
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "bad cookie");
        }

        // POST: api/Settings
        [Route("api/settings/saveSettings")]
        public HttpResponseMessage Post([FromBody]string value)
        {
            //if (!checkCookie(HttpContext.Current.Request))
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "cookie is incorrect");
            //}

            if (string.IsNullOrEmpty(value))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "invalid json data");
            }

            Settings settings = JsonConvert.DeserializeObject<Settings>(value);

            //string settings = HttpContext.Current.Request.Cookies["settings"].Value;
            //HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;


            //#pragma warning disable SG0006 // Weak hashing function
            //            MD5 md5 = MD5.Create();
            //#pragma warning restore SG0006 // Weak hashing function
            //            byte[] bytes = Encoding.ASCII.GetBytes(settings);
            //            byte[] hash = md5.ComputeHash(bytes);
            //            StringBuilder sb = new StringBuilder();
            //            for(int i=0; i < hash.Length; i++)
            //            {
            //                sb.Append(hash[i].ToString("X2"));
            //            }

            //            string calcMD5Sum = sb.ToString();

            //            if (!calcMD5Sum.Equals(settings))
            //            {
            //                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "invalid md5");
            //            }

            string filename = @".\static\" + settings.Filepath + "\\companyData.csv";
            StreamWriter writer = new StreamWriter(filename);
            foreach(var item in settings.Data)
            {
                writer.WriteLine("{0},{1}", item.Key, item.Value);
            }
            writer.Close();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/Settings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Settings/5
        public void Delete(int id)
        {
        }

        private bool checkCookie(HttpRequest request)
        {
            try
            {
                HttpCookie settingsCookie = request.Cookies["settings"];
                return true;
            }
            catch(Exception ex)
            {
                Trace.Fail(ex.Message);
            }

            return false;
        }
    }

    [Serializable]
    public class Settings
    {
        public string Filepath { get; set; }

        public IDictionary<string, string> Data { get; set; }
    }
}
