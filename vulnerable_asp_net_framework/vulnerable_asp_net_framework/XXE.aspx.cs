using System;
using System.Web.UI;
using System.Net;
using System.Xml;
using vulnerable_asp_net_core.Utils;
using System.Text.Encodings.Web;

namespace vulnerable_asp_net_framework
{
    public partial class XXE : Page
    {

        TextEncoder jsEncode = new TextEncoder();

        protected void Page_Load(object sender, EventArgs e)
        {
            var xml = ParamUtils.GetParam(Request, "xml");

            if (xml.Length <= 0)
            {
                XXEResults.Text = "upload your request";
            }
            else
            {

                var resolver = new XmlUrlResolver();
                resolver.Credentials = CredentialCache.DefaultCredentials;
                var xmlDoc = new XmlDocument();
                xmlDoc.XmlResolver = resolver;

                try
                {
                    xmlDoc.LoadXml(xml);
                }
                catch (Exception) { }

                ParamUtils.PrintOut(XXEResults, "Results of your request: " + string.Empty);

                foreach (XmlNode xn in xmlDoc)
                {
                    if (xn.Name == "user")
                        ParamUtils.PrintOut(XXEResults, "Results of your request: " +
                            jsEncode.Encode(xn.InnerText));
                }
            }
        }
    }
}