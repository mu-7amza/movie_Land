namespace MovieWorld.Models
{
    public class Movie_User
    {

        public int MID { get; set; }

        public Movie Movie { get; set; }

        public int UID { get; set; }

        public User User { get; set; }   
    }
}
