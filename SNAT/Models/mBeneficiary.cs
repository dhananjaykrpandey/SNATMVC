using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    [Table("T_Beneficiary")]
    public class mBeneficiary
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int id { get; set; }

        [Key]
        [Column("membernationalid", Order = 1)]
        [Display(Name = "Member National ID")]
        [StringLength(20)]
        public string membernationalid { get; set; }
       

        [Column("memberid")]
        [Display(Name = "Member ID")]
        [StringLength(20)]
        public string memberid { get; set; }

        [Column("membername")]
        [Display(Name = "Member Name")]
        [StringLength(20)]
        public string membername { get; set; }

        [Key]
        [Column("beneficiarynatioanalid", Order = 2)]
        [Display(Name = "Beneficiary Natioanal ID")]
        [StringLength(20)]
        public string beneficiarynatioanalid { get; set; }

        [Column("beneficiaryname")]
        [Display(Name = "Beneficiary Name")]
        [StringLength(20)]
        public string beneficiaryname { get; set; }

        [Column("dob")]
        [Display(Name = "Date Of Birth")]
        public DateTime? dob { get; set; }

        [Column("sex")]
        [Display(Name = "Gender")]
        [StringLength(20)]
        public string sex { get; set; }

        [Column("dateofsubmission")]
        [Display(Name = "Date Of Submission")]
        public DateTime? dateofsubmission { get; set; }

        [Column("relationship")]
        [Display(Name = "Relationship")]
        [StringLength(20)]
        public string relationship { get; set; }


        [Column("contactno1")]
        [Display(Name = "Contact No - 1")]
        [StringLength(20)]
        public string contactno1 { get; set; }

        [Column("contactno2")]
        [Display(Name = "Contact No - 2")]
        [StringLength(20)]
        public string contactno2 { get; set; }

        [Column("residentaladrees")]
        [Display(Name = "Residental Address")]
        [StringLength(20)]
        public string residentaladrees { get; set; }

        [Column("nomineenationalid")]
        [Display(Name = "Nominee National ID")]
        [StringLength(20)]
        public string nomineenationalid { get; set; }

        [Column("nomineename")]
        [Display(Name = "Nominee Name")]
        [StringLength(20)]
        public string nomineename { get; set; }

        [Column("wages")]
        [Display(Name = "Premium Amount")]
        public decimal? wages { get; set; }

        [Column("effactivedate")]
        [Display(Name = "Premiumn Effective Date")]

        public DateTime? effactivedate { get; set; }

        [NotMapped]
        [Column("imagelocation")]
        [Display(Name = "imageLocation")]
        [StringLength(20)]
        public string imagelocation { get; set; }

        [Column("email")]
        [Display(Name = "Email ID")]
        [StringLength(20)]
        public string email { get; set; }

        [Column("lstatus")]
        [Display(Name = "Status")]
        public bool? lstatus { get; set; }

        [Column("livingstatus")]
        [Display(Name = "Living Status")]
        [StringLength(2)]
        public string livingstatus { get; set; }

        [Column("dateofDate")]
        [Display(Name = "Date Of Death")]

        public DateTime? dateofDate { get; set; }
       
    }
}