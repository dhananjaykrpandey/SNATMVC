using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    [Table("T_ClaimEntery")]
    public class mClaimEntry
    {

        [Key]
        [Column(TypeName = "numeric")]
        public int ID { get; set; }


        [Display(Name = "Let Person")]
        [StringLength(2)]
        public string LetPerson { get; set; }


        [Display(Name = "National ID")]
        [StringLength(20)]
        public string MemNationalID { get; set; }


        [Display(Name = "Member ID")]
        [StringLength(20)]
        public string MemberID { get; set; }


        [Display(Name = "Member Name")]
        [StringLength(50)]
        public string MemName { get; set; }


        [Display(Name = "Beneficiary National ID")]
        [StringLength(20)]
        public string BenfNationalID { get; set; }


        [Display(Name = "Beneficiary Name")]
        [StringLength(50)]
        public string BenfName { get; set; }


        [Display(Name = "Place Of Burial")]
        [StringLength(1500)]
        public string PlaceOfBurial { get; set; }


        [Display(Name = "Mortuary")]
        [StringLength(500)]
        public string Mortuary { get; set; }


        [Display(Name = "Entry")]
        [StringLength(50)]
        public string Entery { get; set; }


        [Display(Name = "Date Of Burial")]
        public DateTime? DateOfBurial { get; set; }


        [Display(Name = "Nominee Name")]
        [StringLength(50)]
        public string NomineeName { get; set; }


        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }


        [Display(Name = "Revived By")]
        [StringLength(50)]
        public string ReciviedBy { get; set; }


        [Display(Name = "Reviving Remarks")]
        [StringLength(1500)]
        public string RecivingRemarks { get; set; }


        [Display(Name = "Entry User")]
        [StringLength(50)]
        public string EnteryUser { get; set; }


        [Display(Name = "Entry Date")]
        public DateTime? EnteryDate { get; set; }


        [Display(Name = "Entry Remarks")]
        [StringLength(100)]
        public string EnteryRemarks { get; set; }


        [Display(Name = "Chairperson Name")]
        [StringLength(20)]
        public string Chariperson_Name { get; set; }


        [Display(Name = "Chairperson Approval Date")]
        public DateTime? Chariperson_Date { get; set; }


        [Display(Name = "Chairperson Remarks")]
        public string Chariperson_Remarks { get; set; }

        [Display(Name = "Chairperson Approval Status")]

        public string Chariperson_Status { get; set; }


        [Display(Name = "Sectary Name")]

        public string Secteatary_Name { get; set; }


        [Display(Name = "Sectary Approval Date")]
        public DateTime? Secteatary_Date { get; set; }


        [Display(Name = "Sectary Remarks")]
        public string Secteatary_Remarks { get; set; }


        [Display(Name = "Sectary Approval Status")]

        public string Secteatary_Status { get; set; }


        [Display(Name = "Treasurer Name")]
        public string Treasurer_Name { get; set; }

        [Display(Name = "Treasurer Approval Date")]
        public DateTime? Treasurer_Date { get; set; }


        [Display(Name = "Treasurer Remarks")]
        public string Treasurer_Remarks { get; set; }


        [Display(Name = "Treasurer Approval Status")]
        public string Treasurer_Status { get; set; }


        [Display(Name = "Claim Status")]
        public string ClaimStatus { get; set; }


        [Display(Name = "Claim Posting Status")]
        public string cPostStatus { get; set; }


        //[Display(Name = "National ID")]
        //[StringLength(20)]
        //public string CreatedBy { get; set; }


        //[Display(Name = "National ID")]
        //public DateTime? CreateDate { get; set; }


        //[Display(Name = "National ID")]
        //[StringLength(20)]
        //public string UpdateBy { get; set; }


        //[Display(Name = "National ID")]
        //public DateTime? UpdateDate { get; set; }
    }
}