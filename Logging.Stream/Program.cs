using System;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using Logging.Base;

namespace Logging.Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "logstream.log";
            System.IO.File.Delete(file);

            using (var stream = new FileStream(file, FileMode.Append, FileAccess.Write))
            {
                LogPattern.DoLog(line =>
                {
                    var data = Encoding.UTF8.GetBytes($"{DateTime.Now:yyyy/mm/dd HH:mm:ss} INFO {line}{Environment.NewLine}");
                    stream.Write(data);
                });
            }
        }
    }
}