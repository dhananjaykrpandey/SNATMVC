using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    [Table("T_BeneficiryDocuments")]
    public class mBeneficiryDocuments
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int id { get; set; }

        [Key]
        [Column("nationalid", Order = 1)]
        [Display(Name = "Member National ID")]
        [StringLength(20)]
        public string nationalid { get; set; }


        [Column("memberid")]
        [Display(Name = "Member ID")]
        [StringLength(20)]
        public string memberid { get; set; }


        [Column("membername")]
        [Display(Name = "Member Name")]
        [StringLength(20)]
        public string membername { get; set; }

        [Key]
        [Column("beneficirynationalid", Order = 2)]
        [Display(Name = "Beneficiry National ID")]
        [StringLength(20)]
        public string beneficirynationalid { get; set; }
                       
        [Column("beneficiaryname")]
        [Display(Name = "Beneficiary Name")]
        [StringLength(20)]
        public string beneficiaryname { get; set; }

        [Key]
        [Column("doccode", Order = 3)]
        [Display(Name = "Document Code")]
        [StringLength(20)]
        public string doccode { get; set; }

        [ForeignKey("doccode")]
        public virtual mDocumentType mDocumentTypeCollectoin { get; set; }

        [Column("docLocation")]
        [Display(Name = "Document Location")]
        [StringLength(20)]
        public string docLocation { get; set; }

        [Column("docUploaded")]
        [Display(Name = "Document Uploaded Status")]
        public bool docUploaded { get; set; }


    }
}