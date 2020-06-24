using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Logging;

namespace netfwWCFRest
{
    public class ClassBase
    {
        protected ILogger _logger = new LoggerFactory().CreateLogger("<class base>");

        public string Process2(string value)
        {
            _logger.LogInformation("on process2 {0} !!!", value);
            return "on Process2";
        }
    }

    public class ClassDerived : ClassBase, IInterfaceAgain
    {
        public string OnAbc(string value)
        {
            _logger.LogInformation("on Abc {0} !!!", value);
            return "on Abc";
        }

        public string Process(string value)
        {
            _logger.LogInformation("on Abc2 {0} !!!", value);
            return "on Process";
        }
    }
}