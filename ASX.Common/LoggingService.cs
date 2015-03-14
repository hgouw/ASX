using System;
using System.Collections.Generic;

namespace ASX.Common
{
    public class LoggingService
    {
        public static void LogToFile(List<ILoggable> entities)
        {
            foreach (var entitiy in entities)
            {
                Console.WriteLine(entitiy.Log());
            }
        }
    }
}