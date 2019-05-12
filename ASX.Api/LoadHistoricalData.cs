using Microsoft.Azure;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Globalization;
using System.Net;

namespace ASX.Api
{
    // TO DO
    // 1. Get the last downloaded zip file info
    // 2. Calculate if there is the latest zip file
    // 3. Check if the latest zip file is available
    // 4. If the latest zip file is available
    //    a. Copy the zip file to blob container (asx-zip)
    //    b. Unzip the zip file to blob container (asx-txt)
    //    c. Load the txt files to database
    //    d. Update the last download zip file info (asx-last)
    //    e. Remove the zip file and txt files
    //    f. Send message upon when loading is completed
    // 5. If the latest zip file is not available then send message
    // Note: log files 

    public static class LoadHistoricalData
    {
        [FunctionName("LoadHistoricalData")]
        // https://en.wikipedia.org/wiki/Cron
        // https://codehollow.com/2017/02/azure-functions-time-trigger-cron-cheat-sheet/
        // http://www.openjs.com/scripts/jslibrary/demos/crontab.php
        // "0 30 9  * * *" - every day at 9.30AM
        // "0 0  6  * * *" - every day at 6AM
        // "0 0 18  * * *" - every day at 6PM
        // "0 0 */6 * * *" - every 6 hours
        // "0 0 * * * *"   - every hour
        // "0 */5 * * * *" - every 5 minutes
        // "0 */1 * * * *" - every minute
        // "*/5 * * * * *" - every 5 seconds
        public static void Run([TimerTrigger("0 0 18  * * *")]TimerInfo myTimer, TraceWriter log)
        {
            if (myTimer.IsPastDue)
            {
                log.Info("Timer is running late!");
            }
            log.Info($"C# Timer trigger function executed at {DateTime.Now}");

            var dateFormat = CloudConfigurationManager.GetSetting("DateFormat");
            var last = DateTime.ParseExact(CheckBlobContainer(log), dateFormat, CultureInfo.InvariantCulture);
            while (last < CurrentFriday())
            {
                last = last.AddDays(7);
                var filename = "week" + last.ToString(dateFormat) + ".zip";
                var url = CloudConfigurationManager.GetSetting("HistorialDataUrl") + "/" + filename;
                if (CheckUrl(url))
                {
                    if (ProcessBlobContainer(filename, url, log))
                    {
                        UpdateBlobContainer(last.ToString(dateFormat), log);
                        log.Info($"Successfully processed the file {url} at {DateTime.Now}");
                    }
                }
                else
                {
                    log.Info($"Unable to locate the file {url} at {DateTime.Now}");
                }
            }
        }

        private static bool CheckUrl(string url)
        {
            var urlCheck = new Uri(url);
            var request = WebRequest.Create(urlCheck);
            request.Timeout = 1000; // 1000 milliseconds = 1 second

            try
            {
                request.GetResponse();
            }
            catch
            {
                return false;
            }

            return true;
        }
        private static string CheckBlobContainer(TraceWriter log)
        {
            var text = "";

            try
            {
                var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureWebJobsStorage"));
                var blobClient = storageAccount.CreateCloudBlobClient();
                var blobContainer = blobClient.GetContainerReference(CloudConfigurationManager.GetSetting("ContainerName"));
                var lastBlockBlob = blobContainer.GetBlockBlobReference(CloudConfigurationManager.GetSetting("BlockBlob"));
                text = lastBlockBlob.DownloadText();
            }
            catch (Exception ex)
            {
                log.Info($"Error in CheckBlobContainer - {ex.Message}");
            }

            return text;
        }

        private static bool ProcessBlobContainer(string filename, string url, TraceWriter log)
        {
            try
            {
                var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureWebJobsStorage"));
                var blobClient = storageAccount.CreateCloudBlobClient();
                var blobContainer = blobClient.GetContainerReference(CloudConfigurationManager.GetSetting("ContainerName"));
                blobContainer.CreateIfNotExists();
                var zipBlockBlob = blobContainer.GetBlockBlobReference(filename);
                zipBlockBlob.StartCopy(new Uri(url), null, null, null);
            }
            catch (Exception ex)
            {
                log.Info($"Error in ProcessBlobContainer - {ex.Message}");
                return false;
            }

            return true;
        }

        private static void UpdateBlobContainer(string text, TraceWriter log)
        {
            try
            {
                var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureWebJobsStorage"));
                var blobClient = storageAccount.CreateCloudBlobClient();
                var blobContainer = blobClient.GetContainerReference(CloudConfigurationManager.GetSetting("ContainerName"));
                blobContainer.CreateIfNotExists();
                var lastBlockBlob = blobContainer.GetBlockBlobReference(CloudConfigurationManager.GetSetting("BlockBlob"));
                lastBlockBlob.UploadText(text);
            }
            catch (Exception ex)
            {
                log.Info($"Error in UpdateBlobContainer - {ex.Message}");
            }
        }

        // Return the Friday of the current week
        private static DateTime CurrentFriday()
        {
            var today = DateTime.Today;
            return today.AddDays(-(int)today.DayOfWeek).AddDays(5);
        }
    }
}