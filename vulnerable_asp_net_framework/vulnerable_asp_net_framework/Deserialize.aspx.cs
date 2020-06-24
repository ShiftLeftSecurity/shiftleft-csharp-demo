using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Web.UI;
using System.Xml;
using System.Xml.Serialization;
using vulnerable_asp_net_core.Utils;

namespace vulnerable_asp_net_framework
{
    public partial class Deserialize : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextEncoder jsEncode = new TextEncoder();
            // TODO:
            //https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.formatters.binary.binaryformatter?view=netframework-4.7.2
            var xml = ParamUtils.GetParam(Request, "xml");
            if (xml.Length > 0)
            {
                var ser_xml = new XmlSerializer(typeof(Executable));
                try
                {
                    var sread = new StringReader(xml);
                    var xread = XmlReader.Create(sread);
                    var exe = (Executable)ser_xml.Deserialize(xread);
                    ParamUtils.PrintOut(DeserializeResult, "Request results: \'" + jsEncode.Encode(exe.Run()) + "\'");
                }
                catch (Exception)
                {
                    ParamUtils.PrintOut(DeserializeResult,"Request results: \'\'");
                }
            }
        }
    }
}