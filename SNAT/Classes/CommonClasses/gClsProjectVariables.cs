namespace SNAT.Classes.CommonClasses
{
    public class gClsProjectVariables
    {
        public static string gExcutionPath { get; set; } = default;
        private static string _gDBPath = "";

        public static string gDBPath
        {
            get => @"Data Source=" + _gDBPath;
            set => _gDBPath = value;
        }

        private static string _ConnectionString = "";
        public static string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                switch (System.Environment.MachineName.ToUpper())
                {

                    case "ADITYA":
                        _ConnectionString = ConfigurationManager.ConnectionStrings("SNAT");
                        break;
                    case "NW6877":
                        _ConnectionString = "snatburi_snat";
                        break;
                    default:
                        _ConnectionString = "";
                        break;


                }

            }
        }

    }
}