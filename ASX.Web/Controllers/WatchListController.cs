using System.Web.Mvc;
using ASX.DataAccess;

namespace ASX.Web.Controllers
{
    public class WatchListController : Controller
    {
        public ActionResult List()
        {
            var watchLists = ASXDbContext.GetWatchLists();
            ViewBag.WatchLists = new SelectList(watchLists, "Code", "Code");
            return View();
        }
    }
}