using System;
using System.Linq;
using System.Web.Mvc;
using ASX.DataAccess;
using ASX.Web.Models;

namespace ASX.Web.Controllers
{
    public class GoogleChartController : Controller
    {
        public ActionResult Default()
        {
            DropLists(null, null);
            return View();
        }

        private void DropLists(string industryGroup, string company)
        {
            var industryGroups = ASXDbContext.GetIndustryGroups().AsEnumerable().Select((i, index) => new SelectListItem() { Text = i.Group, Value = (index + 1).ToString() }).ToList();
            ViewBag.IndustryGroupList = new SelectList(industryGroups, "Value", "Text", industryGroup);

            var companies = ASXDbContext.GetWatchLists().AsEnumerable().Select((c, index) => new SelectListItem() { Text = c.Code, Value = (index + 1).ToString() }).ToList();
            ViewBag.CompanyList = new SelectList(companies, "Value", "Text", company);
        }

        public ActionResult Display(string code, DateTime? from = null, DateTime? to = null)
        {
            DateTime startDate;
            if (from == null)
            {
                using (var db = new ASXDbContext())
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

            using (var db = new ASXDbContext())
            {
                var endOfDays = db.EndOfDays.Where(d => d.Code == code && d.Date >= startDate.Date && d.Date <= endDate.Date);
                var prices = endOfDays.Select(r => new { Price = r.Close }).ToList();
                var dates = endOfDays.Select(r => new { r.Date }).ToList();
            }

            var model = new GoogleChartModel();
            return View(model);
        }
    }
}