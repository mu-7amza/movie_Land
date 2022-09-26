using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieWorld.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(20, ErrorMessage = "max length is 20 char")]
        public string Fname { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        [StringLength(20, ErrorMessage = "max length is 20 char")]
        public string Lname { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        //[RegularExpression("\"^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$\""
        //    , ErrorMessage = "password must be Minimum eight characters, at least one letter and one number:")]
        public string Password { get; set; } = null!;
        [NotMapped]
        [Compare("Password", ErrorMessage = "password does not match")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^01[0125][0-9]{8}")]

        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "*")]
        public string Address { get; set; } = null!;
        [Display(Name = "Profile Picture Url")]
        public string profileUrl { get; set; }
         public List<Movie_User> movie_users { get; set; }
      
    }
}

    

