using System;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace netcoreWebapi.Controllers
{
    [Serializable]
    public class testcl
    {
        public string _cmd = "calc.exe";
        public testcl(string cmd)
        {
            if (cmd != "calc.exe")
                Console.WriteLine("Invalid command");
            else
                _cmd = cmd;
        }
        public testcl()
        {
            if (_cmd != "calc.exe")
                Console.WriteLine("Invalid command");
        }

        public void Run()
        {
            Process.Start(_cmd);
        }
    }


    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        // GET api/customers
        [HttpGet]
        public JsonResult Get()
        {
            var customers = DataBuilder.CreateCustomers();
            return Json(customers);
        }

        [HttpPost("serial")]
        public JsonResult Serialization([FromBody]string value)
        {
            testcl sc_testcl;
            String fname = value;
            XmlSerializer ser_xml = new XmlSerializer(typeof(testcl));
            using (FileStream fs = new FileStream(fname, FileMode.Open))
            {
                XmlReader xread = XmlReader.Create(fs);
                sc_testcl = (testcl)ser_xml.Deserialize(xread);
            }
            Console.WriteLine("Run: " + sc_testcl._cmd);
            sc_testcl.Run();
            return Json("Ok");
        }

        [HttpGet("xss")]
        public ContentResult XSS(string data)
        {
            var allEntries = new StringBuilder();
            allEntries.Append(data);
            //return Json(string.Format("{0}" ,allEntries));
            return new ContentResult()
            {
                Content = allEntries.ToString(),
                ContentType = "text/html",
            };
        }

        // GET api/customers/4343
        [HttpGet("{id:int}")]
        public JsonResult Get(int id)
        {
            XmlSerializer ser_xml;
            var customers = DataBuilder.CreateCustomers();
            foreach(var c in customers)
            {
                if (c.ClientId == id)
                {
                    var custList = new List<Customer> { c };
                    return Json(custList);
                }
            }
            return Json("Not found");
        }

        [HttpGet("Add")]
        public JsonResult Get(string sql)
        {
            const string connection = @"Data Source=MyData;Initial Catalog=Product;Trusted_Connection=true";
            var conn = new SqlConnection(connection);
            string query = "INSERT INTO customers " + sql;
            var command = new SqlCommand(query, conn);
            int result = command.ExecuteNonQuery();
            return Json(string.Format("Result: {0}", result));
        }

        [HttpPost("xxeSafe")]
        public JsonResult TextReaderSafe([FromBody] string xmldata)
        {
            /*
            string xml = "<?xml version=\"1.0\" ?><!DOCTYPE doc  
            [< !ENTITY win SYSTEM \"file:///C:/Users/user/Documents/testdata2.txt\">]
            >< doc > &win;</ doc > ";
            */

            XmlTextReader myReader = new XmlTextReader(new StringReader(xmldata));
            myReader.DtdProcessing = DtdProcessing.Prohibit;
            while (myReader.Read())
            {
                if (myReader.NodeType == XmlNodeType.Element)
                {
                    //Console.WriteLine(myReader.ReadElementContentAsString());
                    string data = myReader.ReadElementContentAsString();
                }
            }
            return Json(string.Format("Xml Parsed!!"));
        }

        [HttpPost("xxe")]
        public JsonResult TextReader([FromBody] string xmldata)
        {
            /*
            string xml = "<?xml version=\"1.0\" ?><!DOCTYPE doc  
            [< !ENTITY win SYSTEM \"file:///C:/Users/user/Documents/testdata2.txt\">]
            >< doc > &win;</ doc > ";
            */

            XmlTextReader myReader = new XmlTextReader(new StringReader(xmldata));

            while (myReader.Read())
            {
                if (myReader.NodeType == XmlNodeType.Element)
                {
                    //Console.WriteLine(myReader.ReadElementContentAsString());
                    string data = myReader.ReadElementContentAsString();
                }
            }
            return Json(string.Format("Xml Parsed!!"));
        }

        [HttpGet("saveSettings")]
        public JsonResult Get(string[] settingsFromClient)
        {
            string settingsCookie = Request.Cookies["saveSettings"];
            if (settingsCookie == null)
            {
                return Json("Error. Cookie is incorrect.");
            }

            string[] settingsTokens = settingsCookie.Split(",");
            if (settingsTokens.Length < 2)
            {
                return Json("Malformed cookie");
            }

            string base64Text = settingsTokens[0].Replace("settings", "");

            // Check md5sum
            string cookieMD5Sum = settingsTokens[1];
            string calcMD5Sum = CryptoUtils.CalcMD5Hex(base64Text);
            if (cookieMD5Sum != calcMD5Sum)
            {
                return Json("Wrong md5");
            }

            // Store on filesystem
            string[] settings2 = Encoding.UTF8.GetString(Convert.FromBase64String(base64Text)).Split(",");

            StreamWriter sw = new StreamWriter(settings2[0]);
            for (int i = 1; i < settings2.Length; i++)
            {
                sw.Write(settings2[i]);
            }

            sw.Close();

            return Json("Settings saved");
        }

        // POST api/customers
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
