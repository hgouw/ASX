using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using ASX.DataAccess;
using ASX.Web.Models;

namespace ASX.Web.Controllers
{
    public class ChartController : Controller
    {
        [Route("Chart")]
        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Display(string code, DateTime? from = null, DateTime? to = null)
        {
            DateTime startDate;
            if (from == null)
            {
                using (ASXDbContext db = new ASXDbContext())
                {
                    startDate = db.EndOfDays.Where(e => e.Code == code).OrderBy(e => e.Date).ToList()[0].Date;
                }
            }
            else
            {
                startDate = (DateTime)from;
            }

            DateTime endDate;
            if (to == null)
            {
                endDate = DateTime.Today;
            }
            else
            {
                endDate = (DateTime)to;
            }

            var model = new ChartViewModel
            {
                Chart = GetChart(code, startDate, endDate)
            };
            return View(model);
        }

        private Chart GetChart(string code, DateTime startDate, DateTime endDate)
        {
            using (ASXDbContext db = new ASXDbContext())
            {
                var endOfDays = db.EndOfDays.Where(d => d.Code == code && d.Date >= startDate.Date && d.Date <= endDate.Date);
                var prices = endOfDays.Select(r => new { Price = r.Close }).ToList();
                var dates = endOfDays.Select(r => new { r.Date }).ToList();
                var chart = new Chart(width: 1000, height: 400)
                    .AddTitle(code)
                    .AddSeries(
                        name: code,
                        chartType: "Line",
                        xValue: dates, xField: "Date",
                        yValues: prices, yFields: "Price"
                    );
                return chart;
            }
        }
    }
}