using SNAT.Classes.BussinessClasses;
using SNAT.Classes.CommonClasses;
using SNAT.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SNAT.Controllers
{
    [AuthorizeUserAccess]
    [CompressContent]
    public class SchoolsController : Controller
    {
        private DbCxSnat db = new DbCxSnat();

        // GET: Schools
        public ActionResult Index()
        {
            return View(db.mSchools.ToList());
        }

        // GET: Schools/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mSchool mSchool = db.mSchools.Find(id);
            if (mSchool == null)
            {
                return HttpNotFound();
            }
            return View(mSchool);
        }

        // GET: Schools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "code,name,status,remarks")] mSchool mSchool)
        {
            if (ModelState.IsValid)
            {
                db.mSchools.Add(mSchool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mSchool);
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mSchool mSchool = db.mSchools.Find(id);
            if (mSchool == null)
            {
                return HttpNotFound();
            }
            return View(mSchool);
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "code,name,status,remarks")] mSchool mSchool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mSchool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mSchool);
        }

        // GET: Schools/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mSchool mSchool = db.mSchools.Find(id);
            if (mSchool == null)
            {
                return HttpNotFound();
            }
            return View(mSchool);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            mSchool mSchool = db.mSchools.Find(id);
            db.mSchools.Remove(mSchool);
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
