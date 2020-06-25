using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    [Table("T_WagesUpload")]
    public class mWagesUpload
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public string id { get; set; }


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
        [Column("memEmployeeNo", Order = 5)]
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

        [Column("processingdate")]
        [Display(Name = "Premium Upload Date")]
        public DateTime? processingdate { get; set; }
        [Column("wagecredit")]
        [Display(Name = "Credited Premium")]
        public decimal wagecredit { get; set; }

        [Column("wagebalnace")]
        [Display(Name = "Premium Blance")]
        public decimal wagebalnace { get; set; }
        [Column("memWegeRemarks")]
        [Display(Name = "Premium Remarks")]
        [StringLength(500)]
        public string memWegeRemarks { get; set; }

        [Column("Remarks")]
        [Display(Name = "Upload Remarks")]
        [StringLength(1000)]
        public string Remarks { get; set; }

        [Column("luploaded")]
        [Display(Name = "Premium Upload Status")]
        public bool? luploaded { get; set; }

        [Column("lValidMemmber")]
        [Display(Name = "Registerd Member")]
        public bool? lValidMemmber { get; set; }

        [Column("lWagesProcessed")]
        [Display(Name = "Premium Processe Status")]
        public bool? lWagesProcessed { get; set; }

        [Column("lApproved")]
        [Display(Name = "Premium Appoved Status")]
        public bool? lApproved { get; set; }

        [Column("iPremiumMonth")]
        [Display(Name = "Premium Uploaded Month")]
        public int iPremiumMonth //{ get; set; }
        {
            get { return Convert.ToInt32(wageMonthYear.Substring(0, 2)); }
        }
        [Column("iPremiumYear")]
        [Display(Name = "Premium Uploaded Year")]
        public int iPremiumYear //{ get; set; }
        {
            get { return Convert.ToInt32(wageMonthYear.Substring(3, 4)); }
        }
    }
}