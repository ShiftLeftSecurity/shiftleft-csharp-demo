using System;
using System.Web.UI;
using vulnerable_asp_net_core.Utils;

namespace vulnerable_asp_net_framework
{
	public partial class InsufficientLogging : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            var log = "";
            string Msg(string msg)
            {
                return new DateTime() + ":" + msg + "</br>";
            }
           
            if (ParamUtils.GetParam(Request, "showlogs").Length > 0)
            {
                log += Msg("[info] user 'alice' logged in");
                log += Msg("[info] user 'claire' logged out");
                log += Msg("[info] user 'bob' logged in");
                log += Msg("[info] user 'bob' logged out");
                log += Msg("[warn] /data is almost full");
            }

            ParamUtils.PrintOut(InsufficientLoggingResults, log);
        }
	}
}