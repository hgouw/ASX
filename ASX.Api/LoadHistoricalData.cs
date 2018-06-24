using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace ASX.Api
{
    public static class LoadHistoricalData
    {
        [FunctionName("LoadHistoricalData")]
        public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            var url = "/assets/data/week20180615.zip";

            if (myTimer.IsPastDue)
            {
                log.Info("Timer is running late!");
            }
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}