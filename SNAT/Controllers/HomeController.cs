using SNAT.Classes.BussinessClasses;
using SNAT.Classes.CommonClasses;
using System.Web.Mvc;

namespace SNAT.Controllers
{
    // [AuthorizeUserAccess]
    [CompressContent]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizeUserAccess]
        public ActionResult Home()
        {
            return View();
        }

    }
}