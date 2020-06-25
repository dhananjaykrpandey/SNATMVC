using SNAT.Classes.BussinessClasses;
using SNAT.Classes.CommonClasses;
using SNAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SNAT.Controllers
{
    [AuthorizeUserAccess]
    [CompressContent]
    public class WagesUploadController : Controller
    {
        private DbCxSnat db = new DbCxSnat();
        // GET: WagesUpload
        public ActionResult Index()
        {
            return View(db.mWagesUploads.ToList());
        }
        private int _IPremiumMonth = 0;
        private int _IPremiumYear = 0;
        [HttpGet]
        public ActionResult SearchPremium()
        {
            HttpContext.Session["TotalPremiumRecordCount"] = "0";
            return View();
        }
        [HttpPost]
        public ActionResult SearchPremium(string StrSearchCol, string StrSearchValue)
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

            List<mWagesUpload> mWagesUploads = null;
            switch (StrSearchCol.ToUpper())
            {
                case "MEMID":
                    mWagesUploads = db.mWagesUploads.Where(mem => mem.memNationalID.Contains(StrSearchValue)).ToList();
                    break;
                case "NAME":
                    mWagesUploads = db.mWagesUploads.Where(mem => mem.memName.Contains(StrSearchValue)).ToList();
                    break;
                case "MEMNO":
                    mWagesUploads = db.mWagesUploads.Where(mem => mem.memMemberID.Contains(StrSearchValue)).ToList();
                    break;
                case "EMPNO":
                    mWagesUploads = db.mWagesUploads.Where(mem => mem.memEmployeeNo.Contains(StrSearchValue)).ToList();
                    break;
                case "TSCNO":
                    mWagesUploads = db.mWagesUploads.Where(mem => mem.memTSCNo.Contains(StrSearchValue)).ToList();
                    break;
                case "MONYEAR":
                    mWagesUploads = db.mWagesUploads.Where(mem => mem.wageMonthYear.Contains(StrSearchValue)).ToList();
                    break;
                case "FROM":
                    mWagesUploads = db.mWagesUploads.Where(mem => mem.wageFrom.Contains(StrSearchValue)).ToList();
                    break;
                case "INVALID":
                    bool lINVALID = StrSearchValue == null || StrSearchValue == "" || StrSearchValue == "0" || StrSearchValue == "Dhananjay Kumar Pandey" ? false : true;
                    mWagesUploads = db.mWagesUploads.Where(mem => mem.lValidMemmber == lINVALID).ToList();
                    break;
                case "PROCESSED":
                    bool lUpload = StrSearchValue == null || StrSearchValue == "" || StrSearchValue == "0" || StrSearchValue == "Dhananjay Kumar Pandey" ? false : true;
                    mWagesUploads = db.mWagesUploads.Where(mem => mem.lWagesProcessed == lUpload).ToList();
                    break;
                case "APPROVED":
                    bool lApproved = StrSearchValue == null || StrSearchValue == "" || StrSearchValue == "0" || StrSearchValue == "Dhananjay Kumar Pandey" ? false : true;
                    StrSearchValue = StrSearchValue == null || StrSearchValue == "" ? "Dhananjay Kumar Pandey" : StrSearchValue;
                    mWagesUploads = db.mWagesUploads.Where(mem => mem.lApproved == lApproved).ToList();
                    break;
                default:
                    mWagesUploads = db.mWagesUploads.Where(mem => mem.wageFrom.Contains(StrSearchValue)).ToList();
                    break;
            }
            HttpContext.Session["TotalPremiumRecordCount"] = mWagesUploads == null || mWagesUploads.Count <= 0 ? "0" : mWagesUploads.Count.ToString();
            if (mWagesUploads == null || mWagesUploads.Count <= 0)
            {
                return View();
            }
            return View(mWagesUploads);


        }
        public ActionResult Details(string StrWageMonthYear, string StrMemberID)
        {
            if (StrWageMonthYear == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (StrMemberID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vMemberDetails = db.mMembers.Where(mm => mm.nationalid == StrMemberID).FirstOrDefault();
            if (vMemberDetails != null)
            {
                HttpContext.Session.Add("nationalid", vMemberDetails.nationalid);
                HttpContext.Session.Add("memberid", vMemberDetails.memberid);
                HttpContext.Session.Add("membername", vMemberDetails.membername);
                HttpContext.Session.Add("EmployeeNo", vMemberDetails.employeeno);
            }
            _IPremiumMonth = Convert.ToInt32(StrWageMonthYear.Substring(0, 2));
            _IPremiumYear = Convert.ToInt32(StrWageMonthYear.Substring(3, 4));
            var mWagesUploads = db.mWagesUploads.Where(ben => ben.memNationalID == StrMemberID).OrderByDescending(od => od.wageMonthYear).ToList();

            decimal iTotalPremium = mWagesUploads.Sum(sm => sm.wagecredit);
            decimal iTotalBlancePremium = mWagesUploads.Sum(sm => sm.wagebalnace); ;
            ViewBag.TotalPremium = iTotalPremium;
            ViewBag.TotalBlancePremium = iTotalBlancePremium;

            var mWagesUploadsFilterd = mWagesUploads.Where(ben => ben.iPremiumMonth <= _IPremiumMonth && ben.iPremiumYear <= _IPremiumYear).OrderByDescending(od => od.wageMonthYear).ToList();

            decimal iTotalPremiumMonth = mWagesUploadsFilterd.Sum(sm => sm.wagecredit);
            decimal iTotalBlancePremiumMonth = mWagesUploadsFilterd.Sum(sm => sm.wagebalnace); ;
            ViewBag.iTotalPremiumMonth = iTotalPremiumMonth;
            ViewBag.iTotalBlancePremiumMonth = iTotalBlancePremiumMonth;

            return View(mWagesUploadsFilterd.ToList());

        }
    }
}