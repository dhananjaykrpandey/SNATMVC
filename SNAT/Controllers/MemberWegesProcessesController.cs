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
    public class MemberWegesProcessesController : Controller
    {
        private DbCxSnat db = new DbCxSnat();

        // GET: MemberWegesProcesses
        public ActionResult Index()
        {
            return View(db.mMemberWegesProcesses.ToList());
        }


        public ActionResult MemberPremiumDetails(string Memberid)
        {
            if (Memberid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vMemberDetails = db.mMembers.Where(mm => mm.nationalid == Memberid).FirstOrDefault();
            if (vMemberDetails != null)
            {
                HttpContext.Session.Add("nationalid", vMemberDetails.nationalid);
                HttpContext.Session.Add("memberid", vMemberDetails.memberid);
                HttpContext.Session.Add("membername", vMemberDetails.membername);
                HttpContext.Session.Add("EmployeeNo", vMemberDetails.employeeno);
            }
            List<mMemberWegesProcess> mMemberWegesProcesses = db.mMemberWegesProcesses.Where(ben => ben.memNationalID == Memberid).OrderByDescending(od => od.cProcessed).ToList();

            decimal iTotalPremium = mMemberWegesProcesses.Sum(sm => sm.wagecredit);
            decimal iTotalPendingPremium = mMemberWegesProcesses.Sum(sm => sm.wagePending); ;
            decimal iTotalBlancePremium = mMemberWegesProcesses.Sum(sm => sm.wagebalnace); ;

            ViewBag.TotalPremium = iTotalPremium;
            ViewBag.TotalPendingPremium = iTotalPendingPremium;
            ViewBag.TotalBlancePremium = iTotalBlancePremium;

            return View(mMemberWegesProcesses);
        }
        // GET: MemberWegesProcesses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mMemberWegesProcess mMemberWegesProcess = db.mMemberWegesProcesses.Find(id);
            if (mMemberWegesProcess == null)
            {
                return HttpNotFound();
            }
            return View(mMemberWegesProcess);
        }

        // GET: MemberWegesProcesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberWegesProcesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wageMonthYear,wageFrom,memNationalID,memMemberID,memEmployeeNo,memTSCNo,memName,wagecredit,wagePending,wagebalnace,memWegeRemarks,processingdate,Remarks,luploaded,cProcessed,lProcessed,ProcessedBy,Processeddate,lApproved,ApprovedBy,ApprovedDate,cApprovalRemarks")] mMemberWegesProcess mMemberWegesProcess)
        {
            if (ModelState.IsValid)
            {
                db.mMemberWegesProcesses.Add(mMemberWegesProcess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mMemberWegesProcess);
        }

        // GET: MemberWegesProcesses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mMemberWegesProcess mMemberWegesProcess = db.mMemberWegesProcesses.Find(id);
            if (mMemberWegesProcess == null)
            {
                return HttpNotFound();
            }
            return View(mMemberWegesProcess);
        }

        // POST: MemberWegesProcesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "wageMonthYear,wageFrom,memNationalID,memMemberID,memEmployeeNo,memTSCNo,memName,wagecredit,wagePending,wagebalnace,memWegeRemarks,processingdate,Remarks,luploaded,cProcessed,lProcessed,ProcessedBy,Processeddate,lApproved,ApprovedBy,ApprovedDate,cApprovalRemarks")] mMemberWegesProcess mMemberWegesProcess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mMemberWegesProcess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mMemberWegesProcess);
        }

        // GET: MemberWegesProcesses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mMemberWegesProcess mMemberWegesProcess = db.mMemberWegesProcesses.Find(id);
            if (mMemberWegesProcess == null)
            {
                return HttpNotFound();
            }
            return View(mMemberWegesProcess);
        }

        // POST: MemberWegesProcesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            mMemberWegesProcess mMemberWegesProcess = db.mMemberWegesProcesses.Find(id);
            db.mMemberWegesProcesses.Remove(mMemberWegesProcess);
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

