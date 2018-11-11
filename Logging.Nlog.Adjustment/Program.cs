using System;
using System.IO;
using Logging.Base;
using NLog;

namespace Logging.Nlog.Adjustment
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://blog.yowko.com/nlog-async-keepfileopen/
            // https://blog.darkthread.net/blog/high-capacity-dotnet-logging-survey/

            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.log",
                SearchOption.AllDirectories))
            {
                File.Delete(file);
            }

            LogManager.LoadConfiguration("nlog.config");

            var logger = LogManager.GetCurrentClassLogger();

            LogPattern.DoLog(line => { logger.Info(line); });

            LogManager.Shutdown();        }
    }
}