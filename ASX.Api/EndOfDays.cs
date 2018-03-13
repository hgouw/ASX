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
            log.Info("Process EndOfDays API");

            Company endOfDay = await req.Content.ReadAsAsync<Company>();

            log.Info($"Request EndOfDays API for {endOfDay.Code}");

            return req.CreateResponse(HttpStatusCode.OK, $"Return from EndOfDays API with data for {endOfDay.Code}");
        }
    }
}
