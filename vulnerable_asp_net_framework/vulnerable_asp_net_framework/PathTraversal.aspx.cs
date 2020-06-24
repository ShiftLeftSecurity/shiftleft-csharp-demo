using System;
using System.IO;
using System.Web.UI;
using vulnerable_asp_net_core.Utils;

namespace vulnerable_asp_net_framework
{
    public partial class PathTraversal : Page
	{
        protected void Page_Load(object sender, EventArgs e)
		{
            var filename = ParamUtils.GetParam(Request, "filename");
            if (string.IsNullOrEmpty(filename))
                return;
            ParamUtils.PrintOut(ContentSummary, "Content: " + File.ReadAllText(filename));
        }
	}
}
