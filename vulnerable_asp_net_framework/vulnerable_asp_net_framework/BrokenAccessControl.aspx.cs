using System;
using System.Text.Encodings.Web;
using System.Web.UI;
using vulnerable_asp_net_core.Utils;

namespace vulnerable_asp_net_framework
{
    public partial class BrokenAccessControl : Page
    {
        TextEncoder jsEncode = new TextEncoder();

        protected void Page_Load(object sender, EventArgs e)
        {
            var role = ParamUtils.GetParam(Request, "role");

            if (!role.Equals("admin"))
                role = "user";

            string id = ParamUtils.GetParam(Request, "id");

            if (role.Equals("admin"))
            {
                Response.Redirect("/Admin?id=" + jsEncode.Encode(id));
            }
            else
            {
                ParamUtils.PrintOut(BrokenAccessControlResults, "Logged in as '" + jsEncode.Encode(role) + "'");
            }
        }
    }
}