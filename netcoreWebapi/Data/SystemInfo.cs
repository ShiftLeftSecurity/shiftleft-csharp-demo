using System;
using System.IO;
using System.Diagnostics;

namespace netcoreWebapi.Data
{
    public class SystemInfo
    {
        public StreamWriter initializeTempFile()
        {
            StreamWriter sw = null;

            try
            {
                var filename = Path.GetTempFileName();
                sw = new StreamWriter(filename);
                sw.Write("This is the temporary file content");
                sw.Close();
                Console.WriteLine(" File Write Successful ");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.StackTrace);
            }

            return sw;
        }

        public void readSystemCallOutput()
        {
            try
            {
                var process = Process.Start("dotnet --version");
                while (!process.StandardOutput.EndOfStream)
                {
                    Console.WriteLine(process.StandardOutput.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.StackTrace);
            }
        }
    }
}
