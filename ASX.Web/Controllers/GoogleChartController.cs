using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using ASX.DataAccess;
using ASX.Web.Models;

namespace ASX.Web.Controllers
{
    public class GoogleChartController : Controller
    {
        [Route("GoogleChart")]
        public ActionResult Default()
        {
            return View();
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

            return View();
        }
    }
}