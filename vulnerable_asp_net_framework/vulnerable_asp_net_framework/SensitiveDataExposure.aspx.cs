using System;
using System.Text.Encodings.Web;
using System.Web.UI;
using System.Xml;
using vulnerable_asp_net_core.Utils;

namespace vulnerable_asp_net_framework
{
	public partial class SensitiveDataExposure : Page
	{
        TextEncoder jsEncode = new TextEncoder();

        private const string UserPwPlain = @"<data>
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

        // credit card security codes are stored encrypted
        private const string UserCreditCardInfo = @"<data>
                                 <user>
                                 <name>claire</name>
                                 <cardno>11111111</cardno>
								 <secno>ba1f2511fc30423bdbb183fe33f3dd0f</secno>
                                 </user>
                                 <user>
                                 <name>alice</name>
                                 <cardno>2222222</cardno>
								 <secno>d2d362cdc6579390f1c0617d74a7913d</secno>
                                 </user>
                                 <user>
                                 <name>bob</name>
								 <cardno>33333333</cardno>
                                 <secno>aa3f5bb8c988fa9b75a1cdb1dc4d93fc</secno>
                                 </user>
                                 </data>";

        protected void Page_Load(object sender, EventArgs e)
        {

            var userDoc = new XmlDocument();
            userDoc.LoadXml(UserPwPlain);
            var loginNav = userDoc.CreateNavigator();

            var creditCardDoc = new XmlDocument();
            creditCardDoc.LoadXml(UserCreditCardInfo);
            var creditCardNav = creditCardDoc.CreateNavigator();

            var login = ParamUtils.GetParam(Request, "name");
            var pw = ParamUtils.GetParam(Request, "pw");
            var cardprop = ParamUtils.GetParam(Request, "cardprop");

            // authenticate user
            var authQuery = "string(//user[name/text()='"
                            + login
                            + "' and password/text() ='"
                            + pw + "']/account/text())";

            var account = Convert.ToString(loginNav.Evaluate(loginNav.Compile(authQuery)));
            if (account.Length <= 0)
            {
                ParamUtils.PrintOut(SensitiveDataExposureResults, "Please login by providing a valid username and password");
            }
            else
            {
                var cardno = "string(//user[name/text()='"
                             + login
                             + "']/" + cardprop + "/text())";

                var creditCard = Convert.ToString(creditCardNav.Evaluate(creditCardNav.Compile(cardno)));
                ParamUtils.PrintOut(SensitiveDataExposureResults, "'" + jsEncode.Encode(login) 
                    + "' successfully logged in; your card-number is '" 
                    + jsEncode.Encode(creditCard) + "'");
            }

        }
    }
}
