using System;
using System.Net.Mime;
using Logging.Base;

namespace Logging.File
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "logfile.log";
            System.IO.File.Delete(file);
            LogPattern.DoLog(line =>
            {
                System.IO.File.AppendAllText(file, $"{DateTime.Now:yyyy/mm/dd HH:mm:ss} INFO {line}{Environment.NewLine}");
            });
        }
    }
}