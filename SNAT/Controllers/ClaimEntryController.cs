using SNAT.Classes.BussinessClasses;
using SNAT.Classes.CommonClasses;
using SNAT.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace SNAT.Controllers
{
    [AuthorizeUserAccess]
    [CompressContent]
    public class ClaimEntryController : Controller
    {
        // GET: ClaimEntry
        private readonly DbCxSnat db = new DbCxSnat();
        public ActionResult Index()
        {
            
             return View(db.mClaimEntries.ToList());
            
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mClaimEntry mClaim = db.mClaimEntries.Where(mem => mem.ID == id).FirstOrDefault();
            if (mClaim == null)
            {
                return HttpNotFound();
            }
            return View(mClaim);
        }
        public ActionResult ClaimDocumemts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           IEnumerable<mClaimDocuments> mClaim = db.mClaimDocuments.Where(mem => mem.claimid == id).ToList();
            if (mClaim == null)
            {
                return HttpNotFound();
            }
            return View(mClaim);
        }
    }
}