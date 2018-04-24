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
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
            HttpRequestMessage req,
            TraceWriter log)
        {
            log.Info("Received EndOfDays request");
            HttpResponseMessage response;
            var company = await req.Content.ReadAsAsync<Company>();
            if (company != null)
            {
                try
                {
                    log.Info("Processed EndOfDays request");
                    response = req.CreateResponse(HttpStatusCode.OK, $"Returned EndOfDays request for {company.Code}");
                    log.Info($"Returned EndOfDays request for {company.Code}");
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