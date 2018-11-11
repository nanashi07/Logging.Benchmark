using System;
using System.IO;
using Logging.Base;
using Serilog;

namespace Logging.Serilog
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.log",
                SearchOption.AllDirectories))
            {
                File.Delete(file);
            }

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log.serilog.log")
                .CreateLogger();

            LogPattern.DoLog(line => { Log.Information(line); });
        }
    }
}