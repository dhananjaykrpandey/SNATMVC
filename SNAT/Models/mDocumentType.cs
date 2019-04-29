using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    [Table("M_DocumentType")]
    public class mDocumentType
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int id { get; set; }

        [Key]
        [Column("code")]
        [Display(Name = "Document Code")]
        [StringLength(15)]
        public string code { get; set; }
        public virtual ICollection<mMemberDocument> mMemberDocumentCollection { get; set; }
        public virtual ICollection<mBeneficiryDocuments> mBeneficiryDocumentsCollection { get; set; }

        [Column("name")]
        [Display(Name = "Document Name")]
        [StringLength(50)]
        public string name { get; set; }
        [Column("status")]
        [Display(Name = "Status")]
        public bool status { get; set; } = false;

        [Column("remarks")]
        [Display(Name = "Remarks")]
        [StringLength(500)]
        public string remarks { get; set; }
    }
}