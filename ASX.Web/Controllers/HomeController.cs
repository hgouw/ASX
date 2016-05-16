using System.Web.Mvc;

namespace ASX.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Default()
        {
            return View();
        }
    }
}