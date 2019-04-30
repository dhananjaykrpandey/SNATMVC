using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SNAT.Models
{
    public class mEmployeeDetails
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int id { get; set; }

        [Key]
        [Column("employeeno")]
        [Display(Name = "Employee No.")]
        [StringLength(10)]
        public string employeeno { get; set; }

        //[ForeignKey("employeeno")]
        public virtual ICollection<mLogin> mLoginCollection { get; set; }

        [Column("nationalid")]
        [Display(Name = "National ID")]
        [StringLength(20)]
        public string nationalid { get; set; }

        [Column("name")]
        [Display(Name = "Employee Name")]
        [StringLength(150)]
        public string name { get; set; }


        [Column("sex")]
        [Display(Name = "Gender")]
        [StringLength(1)]
        public string sex { get; set; }

        [Column("dob")]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? dob { get; set; }

        [Column("deptcode")]
        [Display(Name = "Department Code")]
        [StringLength(10)]
        public string deptcode { get; set; }
        //[ForeignKey("deptcode")]
        //public virtual mDepartment mDepartmentCollectoin { get; set; }

        [Column("desigcode")]
        [Display(Name = "Desgination Code")]
        [StringLength(10)]
        public string desigcode { get; set; }
        //[ForeignKey("desigcode")]
        //public virtual mDesignation mDesignationCollectoin { get; set; }

        [Column("contactno1")]
        [Display(Name = "Contact No - 1")]
        [StringLength(15)]
        public string contactno1 { get; set; }

        [Column("contactno2")]
        [Display(Name = "Contact No - 2")]
        [StringLength(15)]
        public string contactno2 { get; set; }

        [Column("email")]
        [Display(Name = "E-Mail ID")]
        [StringLength(100)]
        public string email { get; set; }

        [Column("physicaladdress")]
        [Display(Name = "Residential address")]
        [StringLength(5000)]
        public string physicaladdress { get; set; }

        [Column("dateofjoining")]
        [Display(Name = "Date Of Joining")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? dateofjoining { get; set; }
        public string wrokstatus { get; set; }

        [Column("leaveingdate")]
        [Display(Name = "Date Of Resignation")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? leaveingdate { get; set; }
        public string imagelocation { get; set; }
        public bool? Approval_Chairperson { get; set; }
        public bool? Approval_Sectretary { get; set; }
        public bool? Approval_Treasurer { get; set; }
    }
}