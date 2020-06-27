using SNAT.Classes.BussinessClasses;
using SNAT.Classes.CommonClasses;
using SNAT.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SNAT.Controllers
{
    [CompressContent]
    [AuthorizeUserAccess]
    public class DocumentTypesController : Controller
    {
        private DbCxSnat db = new DbCxSnat();

        // GET: DocumentTypes
        public ActionResult Index()
        {
            return View(db.mDocumentTypes.ToList());
        }

        // GET: DocumentTypes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mDocumentType mDocumentType = db.mDocumentTypes.Find(id);
            if (mDocumentType == null)
            {
                return HttpNotFound();
            }
            return View(mDocumentType);
        }

        // GET: DocumentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "code,name,status,remarks")] mDocumentType mDocumentType)
        {
            if (ModelState.IsValid)
            {
                db.mDocumentTypes.Add(mDocumentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mDocumentType);
        }

        // GET: DocumentTypes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mDocumentType mDocumentType = db.mDocumentTypes.Find(id);
            if (mDocumentType == null)
            {
                return HttpNotFound();
            }
            return View(mDocumentType);
        }

        // POST: DocumentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code,name,status,remarks")] mDocumentType mDocumentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mDocumentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mDocumentType);
        }

        // GET: DocumentTypes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mDocumentType mDocumentType = db.mDocumentTypes.Find(id);
            if (mDocumentType == null)
            {
                return HttpNotFound();
            }
            return View(mDocumentType);
        }

        // POST: DocumentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            mDocumentType mDocumentType = db.mDocumentTypes.Find(id);
            db.mDocumentTypes.Remove(mDocumentType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
