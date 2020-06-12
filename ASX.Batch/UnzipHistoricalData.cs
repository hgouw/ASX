using Microsoft.Azure;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace ASX.Api
{
    // 1. Check the file dropped in blob container (asx-zip)
    // 2. If it is a zip file then unzip the zip file to blob container (asx-text)
    public static class UnzipHistoricalData
    {
        [FunctionName("UnzipHistoricalData")]
        public static async Task Run([BlobTrigger("asx-zip/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name, TraceWriter log)
        {
            log.Info($"C# Blob trigger function executed at {DateTime.Now} to process blob {name} of {myBlob.Length} bytes");

            try
            {
                if (name.Split('.').Last().ToLower() == "zip")
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var archive = new ZipArchive(myBlob))
                        {
                            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureWebJobsStorage"));
                            var blobClient = storageAccount.CreateCloudBlobClient();
                            var blobContainer = blobClient.GetContainerReference(CloudConfigurationManager.GetSetting("TextContainerName"));
                            blobContainer.CreateIfNotExists();

                            foreach (var entry in archive.Entries)
                            {
                                if (!string.IsNullOrEmpty(entry.Name))
                                {
                                    log.Info($"Unzipping file {entry.Name} at {DateTime.Now}");
                                    var blob = blobContainer.GetBlockBlobReference(entry.Name);
                                    using (var fileStream = entry.Open())
                                    {
                                        await blob.UploadFromStreamAsync(fileStream);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Info($"Unable to unzip the file {name} at {DateTime.Now} - {ex.Message}");
            }
        }
    }
}