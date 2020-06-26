using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    [Table("T_ChequeDocuments")]
    public class mChequeDocuments
    {
        public int id { get; set; }
        public int ChqReqID { get; set; }
        [Display(Name = "Member National ID")]
        public string nationalid { get; set; }
        
        [Display(Name = "Member ID")]
        public string memberid { get; set; }
        [Display(Name = "Member Name")]
        public string membername { get; set; }
        [Display(Name = "Beneficiary National ID")]
        public string beneficirynationalid { get; set; }
        [Display(Name = "Beneficiary Name")]
        public string beneficiaryname { get; set; }
        [Display(Name = "Document Code")]
        public string doccode { get; set; }
        //[ForeignKey("code")]
        //public virtual ICollection<mChequeDocType> mChequeDocTypeCollection { get; set; }
        [Display(Name = "Is Mandatory")]
        public string IsMandatory { get; set; }
        [Display(Name = "Document Location")]
        public string docLocation { get; set; }
        [Display(Name = "Is Document Uploaded")]
        public string docUploaded { get; set; }

    }
}