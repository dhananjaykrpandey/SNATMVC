using System.Web;
using System.Web.Optimization;

namespace SNAT
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Style Sheets
            /*Font Awesome*/
            string CSSfontAwesome = "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.8.1/css/all.min.css";
            bundles.Add(new StyleBundle("~/bundles/CSSfontAwesome", CSSfontAwesome).Include("~/Content/fontawesome-all.min.css"));
            /*Font Awesome*/
            /*bootstrap*/
            string CSSbootstrapMin = "https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css";
            bundles.Add(new StyleBundle("~/bundles/CSSbootstrapMin", CSSbootstrapMin).Include("~/Content/bootstrap.min.css"));
            string CSSbootstrapdatepicker = "https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/css/bootstrap-datepicker.min.css";
            bundles.Add(new StyleBundle("~/bundles/CSSbootstrapdatepicker", CSSbootstrapdatepicker).Include("~/Content/bootstrap-datepicker.min.css"));
            string CSSbootstrapdaterangepicker = "https://cdnjs.cloudflare.com/ajax/libs/bootstrap-daterangepicker/3.0.3/daterangepicker.css";
            bundles.Add(new StyleBundle("~/bundles/CSSbootstrapdaterangepicker", CSSbootstrapdaterangepicker).Include("~/Content/daterangepicker.css"));
            string CSSBootstrapDataTables = "https://cdnjs.cloudflare.com/ajax/libs/datatables/1.10.19/css/dataTables.bootstrap.min.css";
            bundles.Add(new StyleBundle("~/bundles/CSSBootstrapDataTables", CSSBootstrapDataTables).Include("~/Content/dataTables.bootstrap.min.css"));
            string CSSdatatables = "https://cdn.datatables.net/v/bs4-4.1.1/datatables.min.css";
            bundles.Add(new StyleBundle("~/bundles/Datatables", CSSdatatables).Include("~/Content/dataTables.min.css"));
            /*bootstrap*/

            /*BootAdmin CSS*/
            bundles.Add(new StyleBundle("~/bundles/BootadminCSS").Include("~/Content/bootadmin.min.css"));
            /*BootAdmin CSS*/

            #endregion Style Sheets
            #region Scripts (Java Scripts/JQuery/Other JS)
            /*JQuery Version*/
            string JSJQueryVersioin = "https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js";
            bundles.Add(new ScriptBundle("~/bundles/JSJQueryVersioin", JSJQueryVersioin).Include("~/Scripts/jquery-{version}.min.js"));

            string JSJQueryMin = "https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js";
            bundles.Add(new ScriptBundle("~/bundles/JSJQueryMin", JSJQueryMin).Include("~/Scripts/jquery.min.js"));
            string JSDataTable = "https://cdn.datatables.net/v/bs4-4.1.1/datatables.min.js";
            bundles.Add(new ScriptBundle("~/bundles/JSDataTable", JSDataTable).Include("~/Scripts/datatables.min.js"));

            /*BootStrap*/
            string JSBootStrapMin = "https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js";
            bundles.Add(new ScriptBundle("~/bundles/JSBootStrapMin", JSBootStrapMin).Include("~/Scripts/bootstrap.min.js"));


            string JSBootstrapBundle = "https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js";
            bundles.Add(new ScriptBundle("~/bundles/JSBootstrapBundle", JSBootstrapBundle).Include("~/Scripts/bootstrap.bundle.min.js"));



            //string JSBootstrapDaterangepicker = "https://cdnjs.cloudflare.com/ajax/libs/bootstrap-daterangepicker/3.0.3/daterangepicker.min.js";
            //bundles.Add(new ScriptBundle("~/bundles/JSBootstrapDaterangepicker", JSBootstrapDaterangepicker).Include("~/Content/bower_components/bootstrap-daterangepicker/daterangepicker.js"));

            //string JSBootStrapDatepicker = "https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/js/bootstrap-datepicker.min.js";
            //bundles.Add(new ScriptBundle("~/bundles/JSBootStrapDatepicker", JSBootStrapDatepicker).Include("~/Content/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"));

            //string JSBootStrapWysihtml5 = "https://cdnjs.cloudflare.com/ajax/libs/bootstrap3-wysiwyg/0.3.3/bootstrap3-wysihtml5.all.min.js";
            //bundles.Add(new ScriptBundle("~/bundles/JSBootStrapWysihtml5", JSBootStrapWysihtml5).Include("~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"));

            string JSDataTables = "https://cdn.datatables.net/v/bs4-4.1.1/datatables.min.js";
            bundles.Add(new ScriptBundle("~/bundles/JSDataTables", JSDataTables).Include("~/Scripts/dataTables.bootstrap.min.js"));
                        /*BootStrap*/

            ///*BootAdmin*/
            bundles.Add(new ScriptBundle("~/bundles/BootadminJS").Include("~/Scripts/bootadmin.min.js", "~/Scripts/bootadmin.min.js"));
            ///*BootAdmin*/
           
            #endregion (Java Scripts/JQuery/Other JS)
        }
    }
}
