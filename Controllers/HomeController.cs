using System.Web.Mvc;

namespace SAP.Addon.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}