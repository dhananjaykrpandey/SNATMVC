using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SNAT.Classes.CommonClasses;
using SNAT.Models;

namespace SNAT.Controllers
{
   
    [AuthorizeUserAccess]
    public class MembersController : Controller
    {
        private DbCxSnat db = new DbCxSnat();

        // GET: Members
        public ActionResult Index()
        {
            var mMembers = db.mMembers.Include(m => m.MSchoolCollectoin);
            return View(mMembers.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mMember mMember = db.mMembers.Where(mem => mem.nationalid ==id).FirstOrDefault();
            if (mMember == null)
            {
                return HttpNotFound();
            }
            return View(mMember);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.school = new SelectList(db.mSchools, "code", "name");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nationalid,memberid,employeeno,tscno,membername,dob,sex,school,contactno1,contactno2,residentaladdress,nomineenationalid,nomineename,wagesamount,wageseffectivedete,email,nomineereleation,livingstatus,deathdate,mritalstatus,suposenationaid,suposename,suposegender,suposejoindate")] mMember mMember)
        {
            if (ModelState.IsValid)
            {
                db.mMembers.Add(mMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.school = new SelectList(db.mSchools, "code", "name", mMember.school);
            return View(mMember);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mMember mMember = db.mMembers.Find(id);
            if (mMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.school = new SelectList(db.mSchools, "code", "name", mMember.school);
            return View(mMember);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nationalid,memberid,employeeno,tscno,membername,dob,sex,school,contactno1,contactno2,residentaladdress,nomineenationalid,nomineename,wagesamount,wageseffectivedete,email,nomineereleation,livingstatus,deathdate,mritalstatus,suposenationaid,suposename,suposegender,suposejoindate")] mMember mMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.school = new SelectList(db.mSchools, "code", "name", mMember.school);
            return View(mMember);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mMember mMember = db.mMembers.Find(id);
            if (mMember == null)
            {
                return HttpNotFound();
            }
            return View(mMember);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            mMember mMember = db.mMembers.Find(id);
            db.mMembers.Remove(mMember);
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
