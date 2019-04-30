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
    [AuthorizeUserAccess]
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