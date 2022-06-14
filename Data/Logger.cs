using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace Data
{
    internal class Logger
    {
        private static List<IBall> balls;
        private bool isLogging = true;
        private Stopwatch sw;
        internal Logger(List<IBall> BallList)
        {
            balls = BallList;

            Thread thread = new Thread(() => StartLogging(10));

            thread.IsBackground = true;
            thread.Start();

        }

        private void StartLogging(int ms)
        {
            sw = Stopwatch.StartNew();

            while (isLogging)
            {
                if (sw.ElapsedMilliseconds >= ms)
                {
                    sw.Restart();
                    string time = ($"{ DateTime.Now:o}");
                    StringWriter wr = new StringWriter();

                    foreach (Ball ball in balls)
                    {
                        wr.WriteLine(time + " - " + JsonSerializer.Serialize(ball));
                    }

                    using (StreamWriter file = new StreamWriter(".\\logs.txt", true))
                    {
                        file.Write(wr.ToString());
                    }

                }


            }

        }

        internal void StopLogging()
        {
            isLogging = false;
        }
    }
}
