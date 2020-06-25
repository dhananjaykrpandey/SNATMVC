using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    [Table("M_School")]
    public class mSchool
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int id { get; set; }

        [Key]
        [Column("code")]
        [Display(Name = "School Code")]
        [StringLength(15)]
        public string code { get; set; }
        [ForeignKey("code")]
        public virtual ICollection<mMember> mMemberCollection { get; set; }


        [Column("name")]
        [Display(Name = "School Name")]
        [StringLength(50)]
        public string name { get; set; }

        [Column("status")]
        [Display(Name = "Status")]
        public bool? status { get; set; }

        [Column("remarks")]
        [Display(Name = "Remarks")]
        [StringLength(500)]
        public string remarks { get; set; }
    }
}