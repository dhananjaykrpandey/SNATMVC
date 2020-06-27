using SNAT.Classes.BussinessClasses;
using SNAT.Classes.CommonClasses;
using System.Linq;
using System.Web.Mvc;

namespace SNAT.Controllers
{
    [CompressContent]
    [AuthorizeUserAccess]
    public class ChequeDocumentTypeController : Controller
    {
        // GET: ChequeDocumentType
        private DbCxSnat db = new DbCxSnat();
        public ActionResult Index()
        {
            return View(db.mChequeDocTypes.ToList());
        }
    }
}