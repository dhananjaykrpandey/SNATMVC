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
    public class ClaimEntryController : Controller
    {
        // GET: ClaimEntry
        private DbCxSnat db = new DbCxSnat();
        public ActionResult Index()
        {
            
             return View(db.mClaimEntries.ToList());
            
        }
    }
}