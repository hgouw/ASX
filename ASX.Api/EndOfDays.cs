using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using ASX.DataAccess;

namespace ASX.Api
{
    public static class EndOfDays
    {
        [FunctionName("EndOfDays")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "endofdays/{code}/{from?}/{to?}")]
            HttpRequestMessage req,
            string code,
            string from,
            string to,
            TraceWriter log)
        {
            log.Info("Received EndOfDays request");

            HttpResponseMessage response;
            if (code != null)
            {
                try
                {
                    log.Info("Processed EndOfDays request");
                    using (ASXDbContext db = new ASXDbContext())
                    {
                        var endOfDays = db.EndOfDays.Where(d => d.Code == code); // && d.Date >= startDate.Date && d.Date <= endDate.Date);
                    }
                    response = req.CreateResponse(HttpStatusCode.OK, $"Returned EndOfDays request for {code}");
                    log.Info($"Returned EndOfDays request for {code}");
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