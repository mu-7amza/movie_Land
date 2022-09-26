using System.ComponentModel.DataAnnotations;

namespace MovieWorld.ViewModels
{
   
        public class RegisterVM
        {
            [Required(ErrorMessage = "*")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; } = null!;
           
            public string Message { get; set; } = "";
        }
    }



