using System;
using System.Web.UI;
using System.IO;
using System.Net;
using System.Xml;


namespace vulnerable_asp_net_framework
{
    public partial class XXE : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string xml = Request.QueryString["xml"];
            XmlUrlResolver resolver = new XmlUrlResolver();
            resolver.Credentials = CredentialCache.DefaultCredentials;
            Console.WriteLine(xml);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.XmlResolver = resolver;
            xmlDoc.LoadXml(xml);
			
            XXEResults.Text = string.Empty;
			
            foreach(XmlNode xn in xmlDoc)
            {
                switch (xn.Name)
                {
                    case "user" :
                        XXEResults.Text = xn.InnerText;
                        break;
                }
            }
        }
    }
}