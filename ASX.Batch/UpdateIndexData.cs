using Microsoft.Azure;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using ASX.DataAccess;

namespace ASX.Batch
{
    // 1. Check the file dropped in blob container (asx-index)
    // 2. If it is a txt file then load the index file to update database
    public static class UpdateIndexData
    {
        [FunctionName("UpdateIndexData")]
        public static void Run([BlobTrigger("asx-index/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name, TraceWriter log)
        {
            log.Info($"C# Blob trigger function executed at {DateTime.Now} to process blob {name} of {myBlob.Length} bytes");
            try
            {
                if (name.Split('.').Last().ToLower() == "txt")
                {
                    log.Info($"Updating index file {name} at {DateTime.Now}");

                    LoadTextFile(name, log);
                }
            }
            catch (Exception ex)
            {
                log.Info($"Unable to update the index file {name} at {DateTime.Now} - {ex.Message}");
            }
        }

        private static bool LoadTextFile(string filename, TraceWriter log)
        {
            try
            {
                using (var db = new ASXDbContext())
                {
                    var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureWebJobsStorage"));
                    var blobClient = storageAccount.CreateCloudBlobClient();
                    var blobContainer = blobClient.GetContainerReference(CloudConfigurationManager.GetSetting("IndexContainerName"));
                    var blockBlob = blobContainer.GetBlockBlobReference(filename);
                    var lines = blockBlob.DownloadTextAsync().Result.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    var indices = lines.Select(l => l.Split(',')).ToArray();
                    foreach (var index in indices)
                    {
                        var code = index[0];
                        var date = DateTime.ParseExact(index[1], "yyyyMMdd", CultureInfo.InvariantCulture);
                        var volume = Int64.Parse(index[6]);
                        db.EndOfDays.First(e => (e.Code == code) && (e.Date == date)).Volume = volume;
                    }
                    log.Info($"Successfully updating indices at {DateTime.Now}");
                    UpdateDatabase(db, log);
                }
            }
            catch (Exception ex)
            {
                log.Info($"Unable to load the index textfile {filename} at {DateTime.Now} - {ex.Message}");
                return false;
            }

            return true;
        }

        private static void UpdateDatabase(ASXDbContext db, TraceWriter log)
        {
            try
            {
                db.SaveChanges();
                log.Info($"Successfully updating database at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                log.Info($"Unable to update the database at {DateTime.Now} - {ex.InnerException.InnerException.Message}");
            };
        }
    }
}