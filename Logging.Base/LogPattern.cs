using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Logging.Base
{
    public class LogPattern
    {
        private static string[] TextContext =
        {
            "111",
            "222"
        };

        private static int Count = 1000000;

        public static void DoLog(Action<string> action)
        {
            DoLog(Count, action);
        }

        public static void DoLog(int count, Action<string> action)
        {
            using (var contents = LogContents().GetEnumerator())
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                for (int i = 0; i < count; i++)
                {
                    contents.MoveNext();
                    action.Invoke(contents.Current);
                }

                stopwatch.Stop();
                Console.WriteLine($"Time used: {stopwatch.Elapsed}");
            }
        }

        private static IEnumerable<string> LogContents()
        {
            int i = 0;
            int size = TextContext.Length;
            while (true)
            {
                yield return TextContext[i++ % size];
            }
        }
    }
}