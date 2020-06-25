using SNAT.Classes.BussinessClasses;
using SNAT.Models;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Web = System.Web;


namespace SNAT.Controllers
{
    [CompressContent]
    public class LoginController : Controller
    {
        [Route("Login/{Index}")]

        // GET: Login
        public ActionResult Index()

        {
            return View();
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "username,password")] mLogin mLog)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    System.Collections.Generic.IEnumerable<System.Exception> errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                    ModelState.AddModelError("authenticationError", "User name or Password is wrong. Try it again");
                    return View(mLog);
                }


                bool userLoging = ClsLogin.IsValidUser(mLog.username, mLog.password);
                if (userLoging == true)
                {
                    Web.HttpContext.Current.Session["Login"] = true;
                    FormsAuthentication.SetAuthCookie(ClsLogin.StrUserName, false);
                    Web.HttpContext.Current.Session["UserName"] = ClsLogin.StrUserName;
                    Web.HttpContext.Current.Session["UserType"] = ClsLogin.StrUserType;
                    Web.HttpContext.Current.Session["UserEmail"] = ClsLogin.StrUserEmail;
                    Web.HttpContext.Current.Session["UserPhone"] = ClsLogin.StrUserPhone;

                    //Web.HttpContext.Current.Session["Menu"] = ClsMenu.GetUserDefineMenu();

                    //DbCxSnat  dbCxAdminDashBoard = new DbCxSnat();
                    //Web.HttpContext.Current.Session["MProjectMenu"] = "";
                    //dynamic jsonObj = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dbCxAdminDashBoard.MProjectMenu));
                    //Web.HttpContext.Current.Session["MProjectMenu"] = jsonObj;
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("authenticationError", "User name or Password is wrong. Try it again");
                    return View();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            try
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Login");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public ActionResult ForgetPassword()
        {
            try
            {
                return View();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public ActionResult RegisterUser()
        {
            try
            {
                return View();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegisterUser(mRegister mLog)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(mLog);
                }

                //if (mLog.UserID == null && mLog.Password == null && mLog.ConfirmPassword == null && mLog.Name == null)
                //{
                //    return View();
                //}
                return View(mLog);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}