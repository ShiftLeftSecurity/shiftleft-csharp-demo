using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Web.UI;
using vulnerable_asp_net_core.Utils;

namespace vulnerable_asp_net_framework
{
    public partial class BrokenAuthentication : Page
	{

        TextEncoder jsEncode = new TextEncoder();

        private static readonly Dictionary<string, string> Users =
    new Dictionary<string, string> { { "evan", "abc" }, { "marta", "001" } };

        protected void Page_Load(object sender, EventArgs e)
		{
            var name = ParamUtils.GetParam(Request, "name");
            var pw = ParamUtils.GetParam(Request, "pw");

            if (Users.ContainsKey(name) && Users[name] == pw)
            {
                ParamUtils.PrintOut(BrokenAuthenticationResults, "Successfully logged in as " + jsEncode.Encode(name));
            }
            else
            {
                ParamUtils.PrintOut(BrokenAuthenticationResults, "Please login by providing a valid username and password");
            }
        }
	}
}
