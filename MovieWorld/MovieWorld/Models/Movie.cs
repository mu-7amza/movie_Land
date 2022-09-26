
using System.ComponentModel.DataAnnotations;

namespace MovieWorld.Models
{
    public class Movie
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Movie Name is required")]
        [MinLength(3, ErrorMessage = "Name must be more than 3 letters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Movie category is required")]
        public string Category { get; set; } = null!;
        [Required(ErrorMessage = "Movie Description is required")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Enter photo url")]
        public string ImageUrl { get; set; }

        public List<Movie_User> movie_Users { get; set; }

      
    }

}

