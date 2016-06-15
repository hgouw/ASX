using System.Web.Mvc;
using ASX.DataAccess;

namespace ASX.Web.Controllers
{
    public class IndustryGroupController : Controller
    {
        public ActionResult List()
        {
            var industryGroups = ASXDbContext.GetIndustryGroups();
            ViewBag.IndustryGroups = new SelectList(industryGroups, "Group", "Group");
            return View();
        }
    }
}