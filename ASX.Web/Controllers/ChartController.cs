using System.Web.Helpers;
using System.Web.Mvc;
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
    }
}