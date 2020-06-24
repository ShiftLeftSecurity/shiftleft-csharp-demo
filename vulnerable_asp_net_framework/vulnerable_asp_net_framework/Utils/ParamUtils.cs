using System.Web;

namespace System.Text.Encodings.Web
{
    public class TextEncoder
    {
        public String Encode(String s)
        {
           return HttpUtility.JavaScriptStringEncode(s);
        }
    }
}

namespace vulnerable_asp_net_core.Utils
{
    public class ParamUtils
    {
        public static string GetParam(HttpRequest request, string paramname)
        {
            var ret = "";
            if (request.Form[paramname] != null && request.Form[paramname].Length > 0)
                ret = request.Form[paramname].ToString();

            if (ret.Length == 0 && request.QueryString[paramname] != null && request.QueryString[paramname].Length > 0) 
                ret = request.QueryString[paramname];

            return ret;
        }

        public static void PrintOut(System.Web.UI.WebControls.Label lbl, string msg)
        {
            lbl.Text = msg;
        }

        public static void PrintOut(System.Web.UI.WebControls.TextBox box, string msg)
        {
            box.Text = msg;
        }

    }
}