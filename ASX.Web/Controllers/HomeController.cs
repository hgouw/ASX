using System.Web.Mvc;

namespace ASX.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Route("")]
        public ActionResult Default()
        {
            return View();
        }
    }
}