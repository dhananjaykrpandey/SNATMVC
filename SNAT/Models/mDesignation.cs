using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    public class mDesignation
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int id { get; set; }

        [Key]
        [Column("code",Order =1)]
        [Display(Name = "Designation Code")]
        [StringLength(15)]
        public string code { get; set; }
        [ForeignKey("code")]
        public virtual ICollection<mEmployeeDetails> mEmployeeDetailsCollection { get; set; }
        [Column("name")]
        [Display(Name = "Designation Name")]
        [StringLength(50)]
        public string name { get; set; }
        [Key]
        [Column("DepartCode", Order = 2)]
        [Display(Name = "Department Code")]
        [StringLength(50)]
        public string DepartCode { get; set; }
        [ForeignKey("DepartCode")]
        public virtual mDepartment mDepartmentCollectoin { get; set; }
   

        [Column("HeadofDepartment")]
        [Display(Name = "Head of Department")]
        [StringLength(50)]
        public string HeadofDepartment { get; set; }

        [Column("IsReportingDesg")]
        [Display(Name = "Is Reporting Designation")]
        [StringLength(50)]
        public string IsReportingDesg { get; set; }

        [Column("ReportCode")]
        [Display(Name = "Report Code")]
        [StringLength(50)]
        public string ReportCode { get; set; }

        [Column("lStatus")]
        [Display(Name = "Status")]
        public bool lStatus { get; set; } = false;

        [Column("remarks")]
        [Display(Name = "Remarks")]
        [StringLength(500)]
        public string remarks { get; set; }
    }
}