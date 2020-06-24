using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace netfwWCFRest
{
    interface IInterfaceAgain : IOtherInterface
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Process/{value}")]
        string Process(string value);

        [OperationContract]
        [WebGet(UriTemplate = "/Process2/{value}")]
        string Process2(string value);

    }
}