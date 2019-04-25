using System;
using System.Data;

namespace SNAT.Classes.CommonClasses
{
    public class ClsMenu
    {
        private static DataTable DtMenu = new DataTable();
        private static readonly DataSet DsCreateDataView = new DataSet();
        private static DataView DvParentMenu = new DataView();
        private static DataView DvChildMenu = new DataView();

        static ClsMenu()
        {
            DtMenu = new DataTable();
            DtMenu.Columns.AddRange(new DataColumn[]{
                new DataColumn("iNodeID", typeof(int))
                ,new DataColumn("cNodeName", typeof(string))
                ,new DataColumn("cNodeText", typeof(string))
                ,new DataColumn("cNodeImageKey", typeof(string))
                ,new DataColumn("iNodeParentID", typeof(int))
            });
            DtMenu.Rows.Add(0, "mnuManiNavigation", "Main Navigation", "");
            DtMenu.Rows.Add(1, "mnuMaster", "Master(s)", @"<a href=""#""><i class=""fa fa-dashboard""></i><span>cMenuText</span><span class=""pull-right-container""><i class=""fa fa-angle-left pull-right""></i></span></a>", 0);
            DtMenu.Rows.Add(2, "mnuDepartment", "Department", @"<li><a href=""~/Departments/index""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 1);
            DtMenu.Rows.Add(3, "mnuDestination", "Destination", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 1);
            DtMenu.Rows.Add(4, "mnuSalary", "Salary Grade", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 1);
            DtMenu.Rows.Add(5, "mnuQualification", "Qualification", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 1);
            DtMenu.Rows.Add(6, "mnuEmployee", "Employee Details", @"<a href=""#""><i class=""fa fa-users""></i> <span>cMenuText</span><span class=""pull-right-container""><i class=""fa fa-angle-left pull-right""></i></span></a>", 0);
            DtMenu.Rows.Add(7, "mnuEmpRegister", "Register", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 6);
            DtMenu.Rows.Add(8, "mnuEmpEntry", "Entry Form", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 6);
            DtMenu.Rows.Add(9, "mnuEmpSalary", "Salary Details", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 6);
            DtMenu.Rows.Add(10, "mnuEmpQualification", "Qualification Details", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 6);
            DtMenu.Rows.Add(11, "mnuReports", "Report(s)", @"<a href=""#""><i class=""fa fa-file-text-o""></i> <span>cMenuText</span><span class=""pull-right-container""><i class=""fa fa-angle-left pull-right""></i></span></a>", 0);
            DtMenu.Rows.Add(12, "mnuRptDepartment", "Department List", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 11);
            DtMenu.Rows.Add(13, "mnuRptDesignation", "Designation List", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 11);
            DtMenu.Rows.Add(14, "mnuRptSalaryGrades", "Salary Grades", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 11);
            DtMenu.Rows.Add(15, "mnuRptQualificationList", "Qualification List", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 11);
            DtMenu.Rows.Add(16, "mnuRptEmpRegister", "Employee Register", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 11);
            DtMenu.Rows.Add(17, "mnuRptEmpSalarySlip", "Employee Salary Slip", @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i>cMenuText</a></li>", 11);
        }

        public static string GetUserDefineMenu()
        {
            try
            {
                string StrUserMenu = "";
                DvParentMenu = DsCreateDataView.DefaultViewManager.CreateDataView(DtMenu);
                DvChildMenu = DsCreateDataView.DefaultViewManager.CreateDataView(DtMenu);
                DvParentMenu = DvParentMenu.ToTable(true, "iNodeID", "iNodeParentID").DefaultView;
                DvParentMenu.RowFilter = "iNodeParentID Is  Null";
                DvChildMenu.RowFilter = "iNodeParentID Is Not Null";

                foreach (DataRowView DrvParent in DvParentMenu)
                {
                    DvChildMenu.RowFilter = "iNodeParentID='" + DrvParent["iNodeID"] + "'";
                    foreach (DataRowView DrvChild in DvChildMenu)
                    {
                        StrUserMenu = StrUserMenu + Environment.NewLine + GetChildItem(DrvChild);
                    }
                }

                return StrUserMenu;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private static string GetChildItem(DataRowView DrvChildData)
        {
            try
            {
                string StrDefautText = @"<li><a href=""#""><i class=""fa fa-dot-circle-o""></i> cMenuText </a></li>";
                string StrUserMenu = @"<li class=""treeview"">";
                string StrMenuText = "";
                StrMenuText = DrvChildData["cNodeText"] == DBNull.Value || DrvChildData["cNodeText"] == null || DrvChildData["cNodeText"].ToString().Trim() == "" ? "Menu Name" : DrvChildData["cNodeText"].ToString().Trim();
                string StrMenuHtml = "";
                StrMenuHtml = DrvChildData["cNodeImageKey"] == DBNull.Value || DrvChildData["cNodeImageKey"] == null || DrvChildData["cNodeImageKey"].ToString().Trim() == "" ? StrDefautText : DrvChildData["cNodeImageKey"].ToString().Trim();

                if (StrMenuHtml.ToUpper().Contains("CMENUTEXT"))
                {
                    StrMenuHtml = StrMenuHtml.Replace("cMenuText", StrMenuText);
                }

                StrUserMenu = StrUserMenu + Environment.NewLine + StrMenuHtml;
                DvChildMenu.RowFilter = "iNodeParentID='" + DrvChildData["iNodeID"] + "'";
                if (DvChildMenu.Count > 0)
                {
                    StrUserMenu = StrUserMenu + Environment.NewLine + @"<ul class=""treeview-menu""> ";
                    foreach (DataRowView DrvChild in DvChildMenu)
                    {
                        StrMenuText = "";
                        StrMenuHtml = "";

                        StrMenuText = DrvChild["cNodeText"] == DBNull.Value || DrvChild["cNodeText"] == null || DrvChild["cNodeText"].ToString().Trim() == "" ? "Menu Name" : DrvChild["cNodeText"].ToString().Trim();
                        StrMenuHtml = DrvChild["cNodeImageKey"] == DBNull.Value || DrvChild["cNodeImageKey"] == null || DrvChild["cNodeImageKey"].ToString().Trim() == "" ? StrDefautText : DrvChild["cNodeImageKey"].ToString().Trim();
                        if (StrMenuHtml.ToUpper().Contains("CMENUTEXT"))
                        {
                            StrMenuHtml = StrMenuHtml.Replace("cMenuText", StrMenuText);
                        }
                        StrUserMenu = StrUserMenu + Environment.NewLine + StrMenuHtml;
                    }
                    StrUserMenu = StrUserMenu + Environment.NewLine + @"</ul>";
                }
                StrUserMenu = StrUserMenu + Environment.NewLine + @"</li>";
                /*
                 <li class="active treeview">
                        <a href="#">
                            <i class="fa fa-dashboard"></i> <span> Dashboard</span>
                            <span class="pull-right-container">
                                <i class="fa fa-angle-left pull-right"></i>
                            </span>
                        </a>
                        <ul class="treeview-menu">
                            <li class="active"><a href="#"><i class="fa fa-dot-circle-o"></i> Dashboard v1</a></li>
                            <li><a href="index2.html"><i class="fa fa-dot-circle-o"></i> Dashboard v2</a></li>
                        </ul>
                    </li>
                 */
                return StrUserMenu;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}