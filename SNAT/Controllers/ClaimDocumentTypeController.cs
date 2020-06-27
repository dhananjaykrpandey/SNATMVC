using SNAT.Classes.BussinessClasses;
using SNAT.Classes.CommonClasses;
using System.Linq;
using System.Web.Mvc;

namespace SNAT.Controllers
{
    [CompressContent]
    [AuthorizeUserAccess]
    public class ClaimDocumentTypeController : Controller
    {
        // GET: ClaimDocumentType
        private DbCxSnat db = new DbCxSnat();
        public ActionResult Index()
        {
            return View(db.mClaimDocTypes.ToList());
        }
    }
}