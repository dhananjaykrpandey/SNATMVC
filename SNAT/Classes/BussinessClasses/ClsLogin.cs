using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNAT.Classes.CommonClasses;
using SNAT.Models;
namespace SNAT.Classes.BussinessClasses
{
    public class ClsLogin
    {
        public static string StrUserName { get; set; }
        public static string StrUserType { get; set; }
        public static string StrUserEmail { get; set; }
        public static string StrUserPhone { get; set; }

        //private DbCxAdminDashBoard DbCxADB = new DbCxAdminDashBoard();

        public static bool IsValidUser(string StrUserId, string StrPassword)
        {
            try
            {
                using (DbCxSnat DbCxADB = new DbCxSnat())
                {
                    Models.mLogin User = DbCxADB.MLogins.Where(b => b.username == StrUserId & b.password == StrPassword).FirstOrDefault();

                    if (User != null)
                    {
                        StrUserName =  ClsUtility.StringDbNull(User.emailid);
                        StrUserType = ClsUtility.StringDbNull(User.usertype);
                        StrUserEmail = ClsUtility.StringDbNull(User.emailid);
                        StrUserPhone = ClsUtility.StringDbNull(User.contactno);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}