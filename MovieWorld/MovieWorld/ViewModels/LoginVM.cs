using System.ComponentModel.DataAnnotations;

namespace MovieWorld.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        //[RegularExpression("\"^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$\""
        //    , ErrorMessage = "password must be Minimum eight characters, at least one letter and one number:")]
        public string Password { get; set; } = null!;
        public string Message { get; set; } = "";
    }
}

