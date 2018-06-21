using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using ASX.DataAccess;

namespace ASX.Api
{
    public static class Price
    {
        [FunctionName("Price")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "price/{code}")]
            HttpRequestMessage req,
            string code,
            TraceWriter log)
        {
            log.Info("Received Price request");

            HttpResponseMessage response = null;

            if (code == null)
            {
                var errorMessage = "Missing company code";
                log.Error(errorMessage);
                response = req.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
            }
            else
            {
                // Check if the company code is valid
            }

            if (response == null)
            {
                try
                {
                    log.Info("Processed Price request");
                    using (ASXDbContext db = new ASXDbContext())
                    {
                        if (code != null)
                        {
                            var endOfDay = db.EndOfDays.Where(d => d.Code == code).OrderByDescending(e => e.Date).FirstOrDefault();
                            var obj = new { Code = endOfDay.Code, Name = endOfDay.Company.Name, Date = endOfDay.Date, Last = endOfDay.Close, Volume = endOfDay.Volume };
                            response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json") };
                        }
                        else
                        {
                            var errorMessage = "Invalid company code";
                            log.Error(errorMessage);
                            response = req.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
                        }
                    }
                    log.Info($"Successfully Processed Price request");
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                    response = req.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                    log.Info($"Unsuccessfully Processed Price request");
                }
            }

            return response;
        }
    }
}