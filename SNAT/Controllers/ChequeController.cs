using SNAT.Classes.CommonClasses;
using SNAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SNAT.Controllers
{
    public class ChequeController : Controller
    {
        // GET: Cheque
        private readonly DbCxSnat db = new DbCxSnat();
        public ActionResult Index()
        {
            return View(db.mChequeEntries.ToList());
            
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mChequeEntry mClaim = db.mChequeEntries.Where(mem => mem.id == id).FirstOrDefault();
            if (mClaim == null)
            {
                return HttpNotFound();
            }
            return View(mClaim);
        }
        public ActionResult ChequeDocumemts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<mChequeDocuments> mClaim = db.mChequeDocuments.Where(mem => mem.ChqReqID == id).ToList();
            if (mClaim == null)
            {
                return HttpNotFound();
            }
            return View(mClaim);
        }
    }
}