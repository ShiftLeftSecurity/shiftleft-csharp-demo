using System;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace vulnerable_asp_net_core.Utils
{
    [Serializable]
    [XmlRootAttribute("Executable")]
    public class Executable
    {
        public string _cmd = "ls";
        public string _param = "";
        
        public Executable() {}

        public Executable(string cmd, string param)
        {
            if (cmd != "ls")
                Console.WriteLine("Invalid command");
            else
            {
                _cmd = cmd;
                _param = param;
            }
        }

        public string Run()
        {
            return "Execute `" + _cmd + " " + _param + "`";
        }
    }
}