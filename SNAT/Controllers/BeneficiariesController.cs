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
    public class BeneficiariesController : Controller
    {
        private DbCxSnat db = new DbCxSnat();

        // GET: Beneficiaries
        public ActionResult Index()
        {
            return View(db.mBeneficiaries.ToList());
        }

        // GET: Beneficiaries/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mBeneficiary mBeneficiary = db.mBeneficiaries.Find(id);
            if (mBeneficiary == null)
            {
                return HttpNotFound();
            }
            return View(mBeneficiary);
        }

        // GET: Beneficiaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beneficiaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "membernationalid,beneficiarynatioanalid,memberid,membername,beneficiaryname,dob,sex,dateofsubmission,relationship,contactno1,contactno2,residentaladrees,nomineenationalid,nomineename,wages,effactivedate,email,lstatus,livingstatus,dateofDate")] mBeneficiary mBeneficiary)
        {
            if (ModelState.IsValid)
            {
                db.mBeneficiaries.Add(mBeneficiary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mBeneficiary);
        }

        // GET: Beneficiaries/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mBeneficiary mBeneficiary = db.mBeneficiaries.Find(id);
            if (mBeneficiary == null)
            {
                return HttpNotFound();
            }
            return View(mBeneficiary);
        }

        // POST: Beneficiaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "membernationalid,beneficiarynatioanalid,memberid,membername,beneficiaryname,dob,sex,dateofsubmission,relationship,contactno1,contactno2,residentaladrees,nomineenationalid,nomineename,wages,effactivedate,email,lstatus,livingstatus,dateofDate")] mBeneficiary mBeneficiary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mBeneficiary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mBeneficiary);
        }

        // GET: Beneficiaries/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mBeneficiary mBeneficiary = db.mBeneficiaries.Find(id);
            if (mBeneficiary == null)
            {
                return HttpNotFound();
            }
            return View(mBeneficiary);
        }

        // POST: Beneficiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            mBeneficiary mBeneficiary = db.mBeneficiaries.Find(id);
            db.mBeneficiaries.Remove(mBeneficiary);
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
