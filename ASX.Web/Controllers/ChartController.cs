﻿using System;
using System.Linq;
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
                Chart = GetChart("MPL", new DateTime(2015,1,1), DateTime.Today)
            };
            return View(model);
        }

        private Chart GetChart()
        {
            var chart = new Chart(width: 600, height: 400)
                .AddTitle("Chart Title")
                .AddSeries(
                    name: "Family",
                    chartType: "pie",
                    xValue: new[] { "Herman", "Helen", "Sarah", "Olivia" }, xField: "Name",
                    yValues: new[] { "55", "44", "11", "7" }, yFields: "Age"
                );
            return chart;
        }

        private Chart GetChart(string code, DateTime dtFrom, DateTime dtTo)
        {
            using (ASXDbContext db = new ASXDbContext())
            {
                var endOfDays = db.EndOfDays.Where(d => d.Code == code && (d.Date >= dtFrom || d.Date <= dtTo));
                var prices = endOfDays.Select(r => new { r.High, r.Low, r.Close });
                var dates = endOfDays.Select(r => new { r.Date });
                var chart = new Chart(width: 600, height: 400)
                    .AddTitle(code)
                    .AddSeries(
                        name: code,
                        chartType: "StockChart",
                        xValue: prices, xField: "Price",
                        yValues: dates, yFields: "Date"
                    );
                //.DataBindTable(dataSource: endOfDays, xField: "Date");
                return chart;
            }
        }
    }
}