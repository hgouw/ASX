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

            DateTime onDate = new DateTime();
            dynamic endOfDay = null;
            HttpResponseMessage response = null;

            if (code == null)
            {
                var errorMessage = "Missing company code";
                log.Error(errorMessage);
                response = req.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
            }
            else
            {
                using (ASXDbContext db = new ASXDbContext())
                {
                    if (!db.EndOfDays.Select(c => new { Code = c.Code }).Distinct().OrderBy(c => c.Code).Any(c => c.Code == code))
                    {
                        var errorMessage = "Invalid company code";
                        log.Error(errorMessage);
                        response = req.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
                    }
                }

                if (response == null)
                {
                    var date = req.GetQueryNameValuePairs().FirstOrDefault(q => string.Compare(q.Key, "date", true) == 0).Value;
                    if (date != null &&
                        !DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out onDate) &&
                        !DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out onDate))
                    {
                        var errorMessage = "Invalid date";
                        log.Error(errorMessage);
                        response = req.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
                    }
                }
            }

            if (response == null)
            {
                try
                {
                    log.Info("Processed Price request");
                    using (ASXDbContext db = new ASXDbContext())
                    {
                        if (onDate == default(DateTime))
                        {
                            endOfDay = db.EndOfDays.Where(d => d.Code == code).OrderByDescending(e => e.Date)
                                                   .Select(o => new { Code = o.Code, Name = o.Company.Name, Date = o.Date, Last = o.Close, Volume = o.Volume })
                                                   .FirstOrDefault();
                        }
                        else
                        {
                            endOfDay = db.EndOfDays.Where(d => d.Code == code && d.Date == onDate.Date)
                                                   .Select(o => new { Code = o.Code, Name = o.Company.Name, Date = o.Date, Last = o.Close, Volume = o.Volume })
                                                   .FirstOrDefault();
                        }
                        if (endOfDay == null)
                        {
                            var errorMessage = "No data on the given date";
                            log.Error(errorMessage);
                            response = req.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
                        }
                        else
                        {
                            response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(endOfDay), Encoding.UTF8, "application/json") };
                        }
                    }
                    log.Info($"Returned Price request for {code}");
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