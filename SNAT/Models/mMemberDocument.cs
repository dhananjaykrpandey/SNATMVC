using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SNAT.Models
{
    [Table("T_MemberDocuments")]
    public class mMemberDocument
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


        [Key]
        [Column("memberid", Order = 2)]
        [Display(Name = "Member ID")]
        [StringLength(20)]
        public string memberid { get; set; }


        [Column("membername")]
        [Display(Name = "Member Name")]
        [StringLength(20)]
        public string membername { get; set; }

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