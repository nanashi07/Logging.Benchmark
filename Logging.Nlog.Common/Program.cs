using System;
using System.IO;
using Logging.Base;
using NLog;

namespace Logging.Nlog.Common
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

            LogManager.LoadConfiguration("nlog.config");

            var logger = LogManager.GetCurrentClassLogger();

            LogPattern.DoLog(args, line => { logger.Info(line); });

            LogManager.Shutdown();
        }
    }
}