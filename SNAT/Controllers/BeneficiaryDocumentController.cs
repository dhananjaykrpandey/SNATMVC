using SNAT.Classes.BussinessClasses;
using SNAT.Classes.CommonClasses;
using System.Linq;
using System.Web.Mvc;

namespace SNAT.Controllers
{
    [CompressContent]
    [AuthorizeUserAccess]
    public class BeneficiaryDocumentController : Controller
    {
        // GET: BeneficiaryDocument
        private DbCxSnat db = new DbCxSnat();
        public ActionResult Index(string StrBeneficiaryID)
        {
            var vMemberDetails = db.mBeneficiaries.Where(mm => mm.beneficiarynatioanalid == StrBeneficiaryID).FirstOrDefault();
            if (vMemberDetails != null)
            {
                HttpContext.Session.Add("nationalid", vMemberDetails.membernationalid);
                HttpContext.Session.Add("memberid", vMemberDetails.memberid);
                HttpContext.Session.Add("membername", vMemberDetails.membername);
                HttpContext.Session.Add("beneficiarynatioanalid", vMemberDetails.beneficiarynatioanalid);
                HttpContext.Session.Add("beneficiaryname", vMemberDetails.beneficiaryname);

            }
            var mBeneficiary = db.mBeneficiryDocuments.Where(ben => ben.beneficirynationalid == StrBeneficiaryID).ToList();
            return View(mBeneficiary);
        }
    }
}