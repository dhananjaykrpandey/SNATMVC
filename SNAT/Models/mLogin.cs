using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNAT.Models
{
    [Table("logintable")]
    public class mLogin
    {
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int id { get; set; }

        [Key]
        [Column("username")]
        [Display(Name = "Login ID")]
        [Required(ErrorMessage = "The user ID is required")]
        [StringLength(20)]
        public string username { get; set; }

        [Column("password")]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Password Must Contain At Lest 1 Character.")]
        public string password { get; set; }

        [Column("usertype")]
        [Display(Name = "User Type")]
        [StringLength(10)]
        public string usertype { get; set; }

        [Column("userstatus")]
        [Display(Name = "User Status")]
        public bool userstatus { get; set; }

        [Column("employee")]
        [Display(Name = "User Type")]
        [StringLength(1)]
        public string employee { get; set; }

        [Column("employeeno")]
        [Display(Name = "User Type")]
        [StringLength(20)]
        public string employeeno { get; set; }

        [Column("Memnationalid")]
        [Display(Name = "User Type")]
        [StringLength(20)]
        public string Memnationalid { get; set; }

        [Column("remarks")]
        [Display(Name = "User Type")]
        [StringLength(20)]
        public string remarks { get; set; }


        [Column("contactno")]
        [Display(Name = "Phone #")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{9})$", ErrorMessage = "Not a valid phone number")]
        [StringLength(13)]
        public string contactno { get; set; }

        [Column("emailid")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50)]
        public string emailid { get; set; }
    }

    [NotMapped]
    public class mRegister : mLogin
    {
        [NotMapped] // Does not effect with your database
        [Display(Name = "Confirm Password")]
        [Required]
        [Column(Order = 6)]
        [Compare("Password", ErrorMessage = "Confirm Password Must Match With Password")]
        public string ConfirmPassword { get; set; }
    }
}