using System;
using System.Web.UI;
using vulnerable_asp_net_core.Utils;


namespace vulnerable_asp_net_framework
{
    public partial class XSS : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            var comment = ParamUtils.GetParam(Request, "comment");

            ParamUtils.PrintOut(XSSInput, $"your comment is '{comment}'");
        }
	}
}