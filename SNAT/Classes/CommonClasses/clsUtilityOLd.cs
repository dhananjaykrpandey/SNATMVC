using SNAT.Models;
using System.Data.Entity;

namespace SNAT.Classes.CommonClasses
{
    internal class clsUtility
    {
        public static string GetExcutionPath()
        {
            try
            {
                string StrExcutionPath = "";
                // StrExcutionPath = AppDomain.CurrentDomain.GetAssemblies.;
                return StrExcutionPath;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string StringDbNull(object objValue)
        {
            try
            {
                if (objValue is null)
                {
                    return "";
                }
                else if (objValue != null && objValue.ToString().Trim() == "")
                { return ""; }
                else
                {
                    return objValue.ToString().Trim();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int IntDbNull(object objValue)
        {
            try
            {
                if (objValue is null)
                {
                    return 0;
                }
                else if (objValue != null && objValue.ToString().Trim() == "")
                { return 0; }
                else
                {
                    return Convert.ToInt32(objValue);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool BoolDbNull(object objValue)
        {
            try
            {
                if (objValue is null)
                {
                    return false;
                }
                else if (objValue != null && objValue.ToString().Trim() == "")
                { return false; }
                else
                {
                    return Convert.ToBoolean(objValue);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static decimal DecimaDbNull(object objValue)
        {
            try
            {
                if (objValue is null)
                {
                    return 0;
                }
                else if (objValue != null && objValue.ToString().Trim() == "")
                { return 0; }
                else
                {
                    return Convert.ToDecimal(objValue);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static double DoubleDbNull(object objValue)
        {
            try
            {
                if (objValue is null)
                {
                    return 0;
                }
                else if (objValue != null && objValue.ToString().Trim() == "")
                { return 0; }
                else
                {
                    return Convert.ToDouble(objValue);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DateTime DateTimeDbNull(object objValue)
        {
            try
            {
                if (objValue is null)
                {
                    return Convert.ToDateTime("0001/01/01");
                }
                else if (objValue != null && objValue.ToString().Trim() == "")
                { return Convert.ToDateTime("0001/01/01"); }
                else
                {
                    return Convert.ToDateTime(objValue);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}