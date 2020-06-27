using Microsoft.Reporting.WebForms;
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

    [CompressContent]
    [AuthorizeUserAccess]
    public class MembersController : Controller
    {
        private readonly DbCxSnat db = new DbCxSnat();

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
            mMember mMember = db.mMembers.Where(mem => mem.nationalid == id).FirstOrDefault();
            if (mMember == null)
            {
                return HttpNotFound();
            }
            return View(mMember);
        }
        [HttpGet]
        public ActionResult SearchDetails()
        {
            HttpContext.Session["TotalMemberRecordCount"] = "0";
            return View();
        }

        // GET: Members/Details/5
        [HttpPost]

        public ActionResult SearchDetails(string StrSearchCol, string StrSearchValue)
        {
            if (StrSearchCol == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else if (StrSearchValue == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StrSearchValue = StrSearchValue == null || StrSearchValue == "" ? "Dhananjay Kumar Pandey" : StrSearchValue;
            List<mMember> mMember = null;
            switch (StrSearchCol.ToUpper())
            {
                case "ID":
                    mMember = db.mMembers.Where(mem => mem.nationalid.Contains(StrSearchValue)).ToList();
                    break;
                case "EMPNO":
                    mMember = db.mMembers.Where(mem => mem.employeeno.Contains(StrSearchValue)).ToList();
                    break;
                case "MEMNO":
                    mMember = db.mMembers.Where(mem => mem.memberid.Contains(StrSearchValue)).ToList();
                    break;
                case "TSCNO":
                    mMember = db.mMembers.Where(mem => mem.tscno.Contains(StrSearchValue)).ToList();
                    break;
                case "NAME":
                    mMember = db.mMembers.Where(mem => mem.membername.Contains(StrSearchValue)).ToList();
                    break;
                case "PHONE":
                    mMember = db.mMembers.Where(mem => mem.contactno1.Contains(StrSearchValue)).ToList();
                    break;
                case "EMAIL":
                    mMember = db.mMembers.Where(mem => mem.email.Contains(StrSearchValue)).ToList();
                    break;
                default:
                    mMember = db.mMembers.Where(mem => mem.nationalid.Contains(StrSearchValue)).ToList();
                    break;
            }
            HttpContext.Session["TotalMemberRecordCount"] = mMember == null || mMember.Count <= 0 ? "0" : mMember.Count.ToString();
            if (mMember == null || mMember.Count <= 0)
            {

                return View();
            }

            return View(mMember);
        }
        public ActionResult Print(string memberid)
        {

            //D:\Web Project\SNATMVC\SNAT\Reports\Report1.rdlc

            var rptPath = Server.MapPath(@"~/Reports/MemberDetails.rdlc");
            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = rptPath;
            //var shipLabel = new ShippingLabel { ShipmentId = shipment.FBAShipmentId, Barcode = GetBarcode(shipment.FBAShipmentId) };
            var RptMemberData = db.mMembers.Where(x => x.memberid == memberid).ToList();

            viewer.LocalReport.DataSources.Add(new ReportDataSource("RptMemberData", RptMemberData));
            viewer.LocalReport.Refresh();

            var bytes = viewer.LocalReport.Render("PDF", null, out string mimeType, out string encoding, out string filenameExtension, out string[] streamids, out Warning[] warnings);

            return new FileContentResult(bytes, mimeType);

            //return File(bytes, mimeType, shipment.FBAShipmentId + "_PackingSlip.pdf");
        }

        /*
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
        */

    }
}
