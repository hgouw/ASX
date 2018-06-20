using System;
using System.Globalization;
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
    public static class EndOfDays
    {
        [FunctionName("EndOfDays")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "endofdays/{code}")]
            HttpRequestMessage req,
            string code,
            TraceWriter log)
        {
            log.Info("Received EndOfDays request");

            HttpResponseMessage response;
            var from = req.GetQueryNameValuePairs().FirstOrDefault(q => string.Compare(q.Key, "from", true) == 0).Value;
            var to = req.GetQueryNameValuePairs().FirstOrDefault(q => string.Compare(q.Key, "to", true) == 0).Value;
            if (code != null)
            {
                try
                {
                    log.Info("Processed EndOfDays request");
                    using (ASXDbContext db = new ASXDbContext())
                    {
                        if (from == null) from = "01/01/1997";
                        if (to == null) to = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime startDate = DateTime.ParseExact(from, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime endDate = DateTime.ParseExact(to, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        var endOfDays = db.EndOfDays.Where(d => d.Code == code && d.Date >= startDate.Date && d.Date <= endDate.Date);
                        response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(endOfDays.ToList()), Encoding.UTF8, "application/json") };
                    }
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