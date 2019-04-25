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
    }
}