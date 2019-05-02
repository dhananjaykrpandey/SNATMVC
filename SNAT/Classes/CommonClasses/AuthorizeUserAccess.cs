using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace SNAT.Classes.CommonClasses
{
    public class AuthorizeUserAccess :ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            System.Web.HttpContextBase context = filterContext.HttpContext;
            if (HttpContext.Current.Session["Login"] == null || Convert.ToBoolean(HttpContext.Current.Session["Login"]) == false)
            {
                //FormsAuthentication.RedirectToLoginPage();
                filterContext.HttpContext.Response.Redirect("~/Login", true);
                
            }
            else if (context.Session != null)
            {
                if (context.Session.IsNewSession)
                {
                    string sessionCookie = context.Request.Headers["Cookie"];

                    if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        FormsAuthentication.SignOut();
                        string redirectTo = "~/Login";
                        if (!string.IsNullOrEmpty(context.Request.RawUrl))
                        {
                            redirectTo = string.Format("~/Login/index?ReturnUrl={0}", HttpUtility.UrlEncode(context.Request.RawUrl));
                        }
                        filterContext.HttpContext.Response.Redirect(redirectTo, true);
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}