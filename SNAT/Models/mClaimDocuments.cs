using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    [Table("T_ClaimDocuments")]
    public class mClaimDocuments
    {
        [Key]
       public int id { get; set; }
        [Display(Name = "Claim ID")]
        public int claimid { get; set; }
        [Display(Name = "National ID")]
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
        
    
        [Display(Name = "Mandatory")]
        public bool IsMandatory { get; set; }
        [Display(Name = "Document Location")]
        public string docLocation { get; set; }
        [Display(Name = "Is Document Uploaded")]
        public bool docUploaded { get; set; }



    }
}