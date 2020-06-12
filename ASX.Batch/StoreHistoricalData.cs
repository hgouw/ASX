using Microsoft.Azure;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASX.BusinessLayer;
using ASX.DataAccess;

namespace ASX.Api
{
    // 1. Check the file dropped in blob container (asx-text)
    // 2. If it is a txt file then load the txt file to database
    public static class StoreHistoricalData
    {
        [FunctionName("StoreHistoricalData")]
        public static void Run([BlobTrigger("asx-text/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name, TraceWriter log)
        {
            log.Info($"C# Blob trigger function executed at {DateTime.Now} to process blob {name} of {myBlob.Length} bytes");

            try
            {
                if (name.Split('.').Last().ToLower() == "txt")
                {
                    log.Info($"Storing file {name} at {DateTime.Now}");

                    LoadTextFile(name, log);
                }
            }
            catch (Exception ex)
            {
                log.Info($"Unable to store the file {name} at {DateTime.Now} - {ex.Message}");
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
                    var blobContainer = blobClient.GetContainerReference(CloudConfigurationManager.GetSetting("TextContainerName"));
                    var blockBlob = blobContainer.GetBlockBlobReference(filename);
                    var lines = blockBlob.DownloadTextAsync().Result.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    var csv = lines.Select(l => l.Split(',')).ToArray();
                    var endOfDays = csv.Select(x => new EndOfDay()
                    {
                        Code = x[0],
                        Date = DateTime.ParseExact(x[1], "yyyyMMdd", CultureInfo.InvariantCulture),
                        Open = Decimal.Parse(x[2]),
                        High = Decimal.Parse(x[3]),
                        Low = Decimal.Parse(x[4]),
                        Close = Decimal.Parse(x[5]),
                        Volume = Int64.Parse(x[6])
                    });
                    IList<WatchList> _watchLists = ASXDbContext.GetWatchLists();
                    IList<EndOfDay> _endOfDays = endOfDays.Where(a => _watchLists.Any(w => w.Code == a.Code)).OrderBy(w => w.Date).ToList(); // Select the EndOfDays in WatchLists only
                    db.EndOfDays.AddRange(_endOfDays);
                    SaveDatabase(db, log);
                }
            }
            catch (Exception ex)
            {
                log.Info($"Unable to load the textfile {filename} at {DateTime.Now} - {ex.Message}");
                return false;
            }

            return true;
        }

        private static void SaveDatabase(ASXDbContext db, TraceWriter log)
        {
            try
            {
                db.SaveChanges();
                log.Info($"Successfully saving database at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                log.Info($"Unable to save the database at {DateTime.Now} - {ex.InnerException.InnerException.Message}");
            };
        }
    }
}