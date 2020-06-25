using SNAT.Classes.CommonClasses;
using SNAT.Models;
using System.Linq;
namespace SNAT.Classes.BussinessClasses
{
    public class ClsLogin
    {
        public static string StrUserName { get; set; } = "";
        public static string StrUserType { get; set; } = "";
        public static string StrUserEmail { get; set; } = "";
        public static string StrUserPhone { get; set; } = "";

        //private DbCxAdminDashBoard DbCxADB = new DbCxAdminDashBoard();

        public static bool IsValidUser(string StrUserId, string StrPassword)
        {
            try
            {
                using (DbCxSnat DbCxADB = new DbCxSnat())
                {
                    mLogin User = DbCxADB.MLogins.Where(b => b.username == StrUserId & b.password == StrPassword).FirstOrDefault();

                    if (User != null)
                    {

                        switch (User.employee)
                        {
                            case "E":
                                var vEmployeeDetails = DbCxADB.mEmployeeDetails.Where(emp => emp.employeeno == User.employeeno).FirstOrDefault();
                                if (vEmployeeDetails != null)
                                {
                                    StrUserName = ClsUtility.StringDbNull(vEmployeeDetails.name);
                                    StrUserType = ClsUtility.StringDbNull(User.usertype);
                                    StrUserEmail = ClsUtility.StringDbNull(vEmployeeDetails.email);
                                    StrUserPhone = ClsUtility.StringDbNull(vEmployeeDetails.contactno1);
                                }

                                break;
                            case "M":
                                var vMemberDetails = DbCxADB.mMembers.Where(emp => emp.nationalid == User.Memnationalid).FirstOrDefault();
                                if (vMemberDetails != null)
                                {
                                    StrUserName = ClsUtility.StringDbNull(vMemberDetails.membername);
                                    StrUserType = ClsUtility.StringDbNull(User.usertype);
                                    StrUserEmail = ClsUtility.StringDbNull(vMemberDetails.email);
                                    StrUserPhone = ClsUtility.StringDbNull(vMemberDetails.contactno1);
                                }
                                break;
                            case "A":
                                StrUserName = "Administrator";
                                StrUserType = ClsUtility.StringDbNull(User.usertype);
                                StrUserEmail = ClsUtility.StringDbNull(User.emailid);
                                StrUserPhone = ClsUtility.StringDbNull(User.contactno);
                                break;
                            default:
                                StrUserName = ClsUtility.StringDbNull(User.username);
                                StrUserType = ClsUtility.StringDbNull(User.usertype);
                                StrUserEmail = ClsUtility.StringDbNull(User.emailid);
                                StrUserPhone = ClsUtility.StringDbNull(User.contactno);
                                break;
                        }

                        StrUserName = StrUserName == "" ? ClsUtility.StringDbNull(User.username) : StrUserName;
                        StrUserType = StrUserType == "" ? ClsUtility.StringDbNull(User.usertype) : StrUserType;
                        StrUserEmail = StrUserEmail == "" ? ClsUtility.StringDbNull(User.emailid) : StrUserEmail;
                        StrUserPhone = StrUserPhone == "" ? ClsUtility.StringDbNull(User.contactno) : StrUserPhone;


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