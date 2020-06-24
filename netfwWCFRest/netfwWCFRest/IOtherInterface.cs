using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace netfwWCFRest
{
    interface IOtherInterface
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Abc/{value}")]
        string OnAbc(string value);
    }
}
