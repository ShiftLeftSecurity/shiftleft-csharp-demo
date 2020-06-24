using System;
using System.Diagnostics;

namespace netcoreConsole
{
    class Program
    {
        public static Process startProcessWithOutput(string command, string args, bool showWindow)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(command, args);
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = !showWindow;
            //p.ErrorDataReceived += (s, a) => addLogLine(a.Data);
            p.Start();
            p.BeginErrorReadLine();

            return p;
        }
        static void Main(string[] args)
        {
            const string EX_MESSAGE = "Got an exception";

            int[] ints = new int[] { 1, 2, 3, 5, 6, 7, 10, 12, 15 };

            try
            {
                for (int i = 0; i < ints.Length; i++)
                {
                    Console.WriteLine(ints[i].ToString());
                }
                Console.WriteLine("Write a command to execute!");
                String userName = Console.ReadLine();
                startProcessWithOutput(userName, "", true);
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} {1}", EX_MESSAGE, e.Message);
            }


        }
    }
}
