using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SNAT.Models
{
    [Table("T_MemberWegesProcess")]
    public class mMemberWegesProcess
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int id { get; set; }

        [Key]
        [Column("wageMonthYear", Order = 1)]
        [Display(Name = "Premium Month-Year")]
        [StringLength(20)]
        public string wageMonthYear { get; set; }

        [Key]
        [Column("wageFrom", Order = 2)]
        [Display(Name = "Premium From")]
        [StringLength(20)]
        public string wageFrom { get; set; }

        [Key]
        [Column("memNationalID", Order = 3)]
        [Display(Name = "Member National ID")]
        [StringLength(20)]
        public string memNationalID { get; set; }

        [Key]
        [Column("memMemberID", Order = 4)]
        [Display(Name = "Member ID")]
        [StringLength(20)]
        public string memMemberID { get; set; }

        [Key]
        [Column("memEmployeeNo", Order =5)]
        [Display(Name = "Employee No.")]
        [StringLength(20)]
        public string memEmployeeNo { get; set; }

        [Column("memTSCNo")]
        [Display(Name = "TSC No.")]
        [StringLength(20)]
        public string memTSCNo { get; set; }

        [Column("memName")]
        [Display(Name = "Member Name")]
        [StringLength(20)]
        public string memName { get; set; }
               
        [Column("wagecredit")]
        [Display(Name = "Credited Premium")]
        public decimal wagecredit { get; set; }

        [Column("wagePending")]
        [Display(Name = "Pending Premium")]
        public decimal wagePending { get; set; }

        [Column("wagebalnace")]
        [Display(Name = "Premium Blance")]
        public decimal wagebalnace { get; set; }

        [Column("memWegeRemarks")]
        [Display(Name = "Premium Remarks")]
        [StringLength(500)]
        public string memWegeRemarks { get; set; }

        [Column("processingdate")]
        [Display(Name = "Premium Upload Date")]
        public DateTime? processingdate { get; set; }

        [Column("Remarks")]
        [Display(Name = "Upload Remarks")]
        [StringLength(1000)]
        public string Remarks { get; set; }


        [Column("luploaded")]
        [Display(Name = "Premium Upload Status")]
        public bool? luploaded { get; set; }

        [Column("cProcessed")]
        [Display(Name = "Premium Processe By")]
        [StringLength(50)]
        public string cProcessed { get; set; }

        [Column("lProcessed")]
        [Display(Name = "Premium Processe Status")]
        public bool? lProcessed { get; set; }

        [Column("ProcessedBy")]
        [Display(Name = "Premium Processe By")]
        [StringLength(50)]
        public string ProcessedBy { get; set; }

        [Column("Processeddate")]
        [Display(Name = "Premium Processe Date")]
        public DateTime? Processeddate { get; set; }

        [Column("lApproved")]
        [Display(Name = "Premium Appoved Status")]
        public bool? lApproved { get; set; }

        [Column("ApprovedBy")]
        [Display(Name = "Premium Approved By")]
        [StringLength(50)]
        public string ApprovedBy { get; set; }

        [Column("ApprovedDate")]
        [Display(Name = "Premium Approved Date")]
        public DateTime? ApprovedDate { get; set; }

        [Column("cApprovalRemarks")]
        [Display(Name = "Premium Approved Remarks")]
        [StringLength(1000)]
        public string cApprovalRemarks { get; set; }
    }
}