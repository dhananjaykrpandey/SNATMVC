using SNAT.Classes.CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNAT.Controllers
{
   // [AuthorizeUserAccess]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [AuthorizeUserAccess]
        public ActionResult Home()
        {
            return View();
        }
       
    }
}