using System.Web.Mvc;
using ASX.BusinessLayer;
using ASX.DataAccess;

namespace ASX.Web.Controllers
{
    public class WatchListController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            var watchLists = ASXDbContext.GetWatchLists();
            ViewBag.WatchLists = new SelectList(watchLists, "Code", "Code");
            return View();
        }

        [HttpPost]
        public ActionResult List(WatchList watchlist)
        {
            if (ModelState.IsValid)
            {
            }
            return View();
        }
    }
}