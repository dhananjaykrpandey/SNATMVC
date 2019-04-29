using SNAT.Classes.CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNAT.Controllers
{
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