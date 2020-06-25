using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SNAT.Models
{
    public class mDepartment
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int id { get; set; }

        [Key]
        [Column("code")]
        [Display(Name = "Department Code")]
        [StringLength(15)]
        public string code { get; set; }
        [ForeignKey("code")]
        public virtual ICollection<mDesignation> mDesignationCollection { get; set; }
        public virtual ICollection<mEmployeeDetails> mEmployeeDetailsCollection { get; set; }
        [Column("name")]
        [Display(Name = "Department Name")]
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