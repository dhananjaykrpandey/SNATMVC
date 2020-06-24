using SNAT.Classes.BussinessClasses;
using SNAT.Classes.CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNAT.Controllers
{
    [AuthorizeUserAccess]
    [CompressContent]
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