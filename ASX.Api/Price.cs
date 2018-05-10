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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequestMessage req,
            TraceWriter log)
        {
            log.Info("Received Price request");

            HttpResponseMessage response;
            var code = req.GetQueryNameValuePairs().FirstOrDefault(q => string.Compare(q.Key, "code", true) == 0).Value;
            if (code != null)
            {
                try
                {
                    log.Info("Processed Price request");
                    using (ASXDbContext db = new ASXDbContext())
                    {
                        var endOfDay = db.EndOfDays.Where(d => d.Code == code).OrderByDescending(e => e.Date).FirstOrDefault();
                        string s = JsonConvert.SerializeObject(endOfDay);
                        response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(endOfDay), Encoding.UTF8, "application/json") };
                    }
                    log.Info($"Returned Price request for {code}");
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                    response = req.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            else
            {
                var errorMessage = "Invalid company code";
                log.Error(errorMessage);
                response = req.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
            }

            return response;
        }
    }
}