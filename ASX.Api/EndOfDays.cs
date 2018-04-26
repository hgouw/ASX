using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace ASX.Api
{
    public static class EndOfDays
    {
        [FunctionName("EndOfDays")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequestMessage req,
            TraceWriter log)
        {
            log.Info("Received EndOfDays request");
            HttpResponseMessage response;
            var company = req.GetQueryNameValuePairs().FirstOrDefault(q => string.Compare(q.Key, "company", true) == 0).Value;
            var from = req.GetQueryNameValuePairs().FirstOrDefault(q => string.Compare(q.Key, "from", true) == 0).Value;
            var to = req.GetQueryNameValuePairs().FirstOrDefault(q => string.Compare(q.Key, "to", true) == 0).Value;
            if (company != null)
            {
                try
                {
                    log.Info("Processed EndOfDays request");
                    response = req.CreateResponse(HttpStatusCode.OK, $"Returned EndOfDays request for {company}");
                    log.Info($"Returned EndOfDays request for {company}");
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