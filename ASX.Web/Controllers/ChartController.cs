using System;
using System.Web.Helpers;
using System.Web.Mvc;
using ASX.DataAccess;
using ASX.Web.Models;

namespace ASX.Web.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Display()
        {
            var model = new ChartViewModel
            {
                Chart = GetChart()
            };
            return View(model);
        }

        private Chart GetChart()
        {
            var chart = new Chart(width: 600, height: 400)
                .AddTitle("Chart Title")
                .AddSeries(
                    name: "Family",
                    xValue: new[] { "Herman", "Helen", "Sarah", "Olivia" },
                    yValues: new[] { "55", "44", "11", "7" }
                );
            return chart;
        }

        private static Chart GetChart(string code, DateTime dtFrom, DateTime dtTo)
        {
            var chart = new Chart(width: 600, height: 400);
            using (var db = new ASXDbContext())
            {
                var endOfDays = ASXDbContext.GetEndOfDays();
                endOfDays.Where(d => d.Code == watchList.Code && d.Date >= new DateTime(year, 1, 1).Date && d.Date <= new DateTime(year, 12, 31).Date);
            }
            return chart;
        }
    }
}