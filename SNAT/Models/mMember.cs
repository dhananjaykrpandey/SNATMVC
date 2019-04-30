using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    [Table("T_Member")]
    public class mMember
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int id { get; set; }

        [Key]
        [Column("nationalid", Order = 1)]
        [Display(Name = "National ID")]
        [StringLength(20)]
        public string nationalid { get; set; }

        //[ForeignKey("nationalid")]
        public virtual ICollection<mLogin> mLoginCollection { get; set; }

        [Key]
        [Column("memberid", Order = 2)]
        [Display(Name = "Member ID")]
        [StringLength(20)]
        public string memberid { get; set; }

        [Key]
        [Column("employeeno", Order = 3)]
        [Display(Name = "Employee No")]
        [StringLength(20)]
        public string employeeno { get; set; }

        [Column("tscno")]
        [Display(Name = "TSC No")]
        [StringLength(20)]
        public string tscno { get; set; }

        [Column("membername")]
        [Display(Name = "Member Name")]
        [StringLength(20)]
        public string membername { get; set; }

        [Column("dob")]
        [Display(Name = "Date Of Birth")]
        public DateTime? dob { get; set; }

        [Column("sex")]
        [Display(Name = "Gender")]
        [StringLength(20)]
        public string sex { get; set; }

        [Column("school")]
        [Display(Name = "School")]
        [StringLength(20)]
        public string school { get; set; }

        [ForeignKey("school")]
        public virtual mSchool MSchoolCollectoin { get; set; }

        [Column("contactno1")]
        [Display(Name = "Contact No - 1")]
        [StringLength(20)]
        public string contactno1 { get; set; }

        [Column("contactno2")]
        [Display(Name = "Contact No - 2")]
        [StringLength(20)]
        public string contactno2 { get; set; }

        [Column("residentaladdress")]
        [Display(Name = "Residental Address")]
        [StringLength(20)]
        public string residentaladdress { get; set; }

        [Column("nomineenationalid")]
        [Display(Name = "Nominee National ID")]
        [StringLength(20)]
        public string nomineenationalid { get; set; }

        [Column("nomineename")]
        [Display(Name = "Nominee Name")]
        [StringLength(20)]
        public string nomineename { get; set; }

        [Column("wagesamount")]
        [Display(Name = "Premium Amount")]
        public decimal? wagesamount { get; set; }

        [Column("wageseffectivedete")]
        [Display(Name = "Premiumn Effective Date")]

        public DateTime? wageseffectivedete { get; set; }

        [NotMapped]
        [Column("imageLocation")]
        [Display(Name = "imageLocation")]
        [StringLength(20)]
        public string imageLocation { get; set; }

        [Column("email")]
        [Display(Name = "Email ID")]
        [StringLength(20)]
        public string email { get; set; }

        [Column("nomineereleation")]
        [Display(Name = "Nominee Releation")]
        [StringLength(20)]
        public string nomineereleation { get; set; }

        [Column("livingstatus")]
        [Display(Name = "Living Status")]

        [StringLength(20)]
        public string livingstatus { get; set; }

        [Column("deathdate")]
        [Display(Name = "Date Of Death")]

        public DateTime? deathdate { get; set; }

        [Column("mritalstatus")]
        [Display(Name = "Mrital Status")]
        [StringLength(20)]
        public string mritalstatus { get; set; }

        [Column("suposenationaid")]
        [Display(Name = "Supose Nationa ID")]
        [StringLength(20)]
        public string suposenationaid { get; set; }

        [Column("suposename")]
        [Display(Name = "Supose Name")]
        [StringLength(20)]
        public string suposename { get; set; }

        [Column("suposegender")]
        [Display(Name = "Supose Gender")]
        [StringLength(20)]
        public string suposegender { get; set; }

        [Column("suposejoindate")]
        [Display(Name = "Supose join Date")]

        public DateTime? suposejoindate { get; set; }
    }
}