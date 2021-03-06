﻿using SNAT.Classes.BussinessClasses;
using SNAT.Classes.CommonClasses;
using SNAT.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SNAT.Controllers
{
    [CompressContent]
    [AuthorizeUserAccess]
    public class MemberDocumentsController : Controller
    {
        private DbCxSnat db = new DbCxSnat();

        // GET: MemberDocuments
        public ActionResult Index()
        {
            var mMemberDocuments = db.mMemberDocuments.Include(m => m.mDocumentTypeCollectoin);
            return View(mMemberDocuments.ToList());
        }

        public ActionResult MemberDocumentList(string StrMemberNationalId)
        {
            if (StrMemberNationalId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vMemberDetails = db.mMembers.Where(mm => mm.nationalid == StrMemberNationalId).FirstOrDefault();
            if (vMemberDetails != null)
            {
                HttpContext.Session.Add("nationalid", vMemberDetails.nationalid);
                HttpContext.Session.Add("memberid", vMemberDetails.memberid);
                HttpContext.Session.Add("membername", vMemberDetails.membername);
            }

            var mMemberDocuments = db.mMemberDocuments.Include(m => m.mDocumentTypeCollectoin);
            var MemberDocList = mMemberDocuments.Where(mb => mb.nationalid == StrMemberNationalId);
            return View(MemberDocList.ToList());
        }

        // GET: MemberDocuments/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mMemberDocument mMemberDocument = db.mMemberDocuments.Find(id);
            if (mMemberDocument == null)
            {
                return HttpNotFound();
            }
            return View(mMemberDocument);
        }

        // GET: MemberDocuments/Create
        public ActionResult Create()
        {
            ViewBag.doccode = new SelectList(db.mDocumentTypes, "code", "name");
            return View();
        }

        // POST: MemberDocuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nationalid,memberid,doccode,membername,docLocation,docUploaded")] mMemberDocument mMemberDocument)
        {
            if (ModelState.IsValid)
            {
                db.mMemberDocuments.Add(mMemberDocument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doccode = new SelectList(db.mDocumentTypes, "code", "name", mMemberDocument.doccode);
            return View(mMemberDocument);
        }

        // GET: MemberDocuments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mMemberDocument mMemberDocument = db.mMemberDocuments.Find(id);
            if (mMemberDocument == null)
            {
                return HttpNotFound();
            }
            ViewBag.doccode = new SelectList(db.mDocumentTypes, "code", "name", mMemberDocument.doccode);
            return View(mMemberDocument);
        }

        // POST: MemberDocuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nationalid,memberid,doccode,membername,docLocation,docUploaded")] mMemberDocument mMemberDocument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mMemberDocument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doccode = new SelectList(db.mDocumentTypes, "code", "name", mMemberDocument.doccode);
            return View(mMemberDocument);
        }

        // GET: MemberDocuments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mMemberDocument mMemberDocument = db.mMemberDocuments.Find(id);
            if (mMemberDocument == null)
            {
                return HttpNotFound();
            }
            return View(mMemberDocument);
        }

        // POST: MemberDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            mMemberDocument mMemberDocument = db.mMemberDocuments.Find(id);
            db.mMemberDocuments.Remove(mMemberDocument);
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
