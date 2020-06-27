using SNAT.Classes.BussinessClasses;
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
    [CompressContent]
    [AuthorizeUserAccess]
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
            mChequeEntry _mCheque = db.mChequeEntries.Where(mem => mem.id == id).FirstOrDefault();
            if (_mCheque == null)
            {
                return HttpNotFound();
            }
            return View(_mCheque);
        }
        public ActionResult ChequeDocumemts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<mChequeDocuments> _mChequeDocuments = db.mChequeDocuments.Where(mem => mem.ChqReqID == id).ToList();

            foreach (var DocCode in _mChequeDocuments)
            {
                var DocDesc = db.mChequeDocTypes.Where(chq => chq.code == DocCode.doccode).FirstOrDefault();
                DocCode.docDescription = DocDesc.name;

            }
            

            if (_mChequeDocuments == null)
            {
                return HttpNotFound();
            }
            return View(_mChequeDocuments);
        }
    }
}