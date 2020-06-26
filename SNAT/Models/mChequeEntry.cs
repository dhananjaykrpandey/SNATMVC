using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    [Table("T_ChequeEntry")]
    public class mChequeEntry
    {
        [Display(Name ="Cheque Entry ID")]
        public int id { get; set; }
        [Display(Name ="Claim ID")]
        public int ClaimID { get; set; }
        [Display(Name ="Let Person")]
        public string letperson { get; set; }
        [Display(Name ="Member National ID")]
        public string MemNationalID { get; set; }
        [Display(Name ="Member ID")]
        public string MemberID { get; set; }
        [Display(Name ="Member Name")]
        public string MemName { get; set; }

        [Display(Name ="Beneficiary National ID")]
        public string BeneNationalID { get; set; }

        [Display(Name ="Beneficiary Name")]
        public string BeneName { get; set; }

        [Display(Name ="Payee")]
        public string Payee { get; set; }

        [Display(Name ="Payee National ID")]
        public string PayeeNationalID { get; set; }

        [Display(Name ="Total Amount")]
        public decimal TotalAmount { get; set; }

        [Display(Name ="Cheque No")]
        public string ChequeNo { get; set; }

        [Display(Name ="Request By")]
        public string RequestBy { get; set; }

        [Display(Name ="Requested Date")]
        public DateTime? RequestedDate { get; set; }

        [Display(Name ="Reason For")]
        public string ResonFor { get; set; }

        [Display(Name ="Entry User Name")]
        public string EnteryUser { get; set; }

        [Display(Name ="Entry Date")]
        public DateTime? EnteryDate { get; set; }

        [Display(Name ="Entry Remarks")]
        public string EnteryRemarks { get; set; }

        [Display(Name ="Chairperson _Name")]
        public string Chariperson_Name { get; set; }

        [Display(Name ="Chairperson Date")]
        public DateTime? Chariperson_Date { get; set; }

        [Display(Name ="Chairperson Remarks")]
        public string Chariperson_Remarks { get; set; }

        [Display(Name ="Chairperson Status")]
        public string Chariperson_Status { get; set; }

        [Display(Name ="Sectary Name")]
        public string Secteatary_Name { get; set; }

        [Display(Name ="Sectary Date")]
        public DateTime? Secteatary_Date { get; set; }

        [Display(Name ="Sectary Remarks")]
        public string Secteatary_Remarks { get; set; }

        [Display(Name ="Sectary Status")]
        public string Secteatary_Status { get; set; }

        [Display(Name ="Treasurer Name")]
        public string Treasurer_Name { get; set; }

        [Display(Name ="Treasurer Date")]
        public DateTime? Treasurer_Date { get; set; }

        [Display(Name ="Treasurer Remarks")]
        public string Treasurer_Remarks { get; set; }

        [Display(Name ="Treasurer Status")]
        public string Treasurer_Status { get; set; }

        [Display(Name ="Cheque Status")]
        public string ChqStatus { get; set; }

        [Display(Name ="Cheque Posted Status")]
        public string cPostStatus { get; set; }

        [Display(Name ="Cheque Received By")]
        public string ChqRecivedy { get; set; }

        [Display(Name ="Cheque Receiver National ID")]
        public string ChqRecivedNationalID { get; set; }

        [Display(Name ="Cheque Receiving Date")]
        public DateTime? ChqRecivingDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string CreateDate { get; set; }
        //public string UpdateBy { get; set; }
        //public string UpdateDate { get; set; }
    }
}