using System;
using System.Text.Encodings.Web;
using System.Web.UI;
using System.Xml;
using vulnerable_asp_net_core.Utils;

namespace vulnerable_asp_net_framework
{
    public partial class XPATHInjection : Page
    {

        TextEncoder jsEncode = new TextEncoder();

        private static string UserPwPlain = @"<data>
                                 <user>
                                 <name>claire</name>
                                 <password>clairepw</password>
                                 <account>admin</account>
                                 </user>
                                 <user>
                                 <name>alice</name>
                                 <password>alicepw</password>
                                 <account>user</account>
                                 </user>
                                 <user>
                                 <name>bob</name>
                                 <password>bobpw</password>
                                 <account>bob</account>
                                 </user>
                                 </data>";
        
        protected void Page_Load(object sender, EventArgs e)
        {

            var XmlDoc = new XmlDocument();
            XmlDoc.LoadXml(UserPwPlain);
            var nav = XmlDoc.CreateNavigator();

            var name = ParamUtils.GetParam(Request, "name");
            var pw = ParamUtils.GetParam(Request, "pw");

            var query = "string(//user[name/text()='"
                        + name
                        + "' and password/text() ='"
                        + pw + "']/account/text())";

            var expr = nav.Compile(query);
            var account = Convert.ToString(nav.Evaluate(expr));

            if (account.Length <= 0)
            {
                ParamUtils.PrintOut(XPATHInjectionResults, 
                    "Please login by providing a valid username and password");
            }
            else
            {
                ParamUtils.PrintOut(XPATHInjectionResults,
                    "Successfully logged in as " + jsEncode.Encode(name));
            }
        }
    }
}