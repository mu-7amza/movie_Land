using Microsoft.Extensions.DependencyInjection;
using MovieWorld.Models;

namespace MovieWorld.Data
{
    public class Initializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<itiDBContext>();
                context.Database.EnsureCreated();

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Avengers: Endgame (2019)" ,
                            Category = "Action",
                            Description = "After Thanos executes his evil plan after taking the quality stones on the other children, please, please, please, please, please, please, the other, the other. Is there a new law?",
                            ImageUrl = "https://i.egycdn.com/pic/RHNhSUNlY21MY212bWptdm12bWpFY2NOVHBqbUl4UFA.jpg"


                        },
                         new Movie()
                        {
                            Name = "Joker (2019)" ,
                            Category = "Documentary",
                            Description = "Little by little, pressure and circumstances combine to make a failed comedian go crazy and turn into a criminal and a maniacal killer.\r\n",
                            ImageUrl = "https://i.egycdn.com/pic/RHNhSUNlY21MTnZtYm1qbWptYWNtSWxtRWxtYm1ibWptYg.jpg"


                        },
                          new Movie()
                        {
                            Name = "Bohemian Rhapsody (2018)" ,
                            Category = "Comedian",
                            Description = "The film tells the story of British musician (Freddie Mercury) and lead singer of the English rock band Queen. The film documents the events of the years and the long rise story that led Queen to dominate the music scene in the seventies and eighties.\r\n",
                            ImageUrl = "https://i.egycdn.com/pic/RHNhSUNlY21URW1tbVlUbW12RWNtam12bWJtSXhtRW1FbUk.jpg"


                        }

                    });
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                       new User()
                       {
                           Fname = "Muhammed",
                           Lname = "Hamza" ,
                           Email = "Hamza@gmail.com",
                           Password = "123",
                           ConfirmPassword = "123",
                           Phone = "01093816443" ,
                           Address = "Menouf" ,
                           profileUrl = "https://scontent.fcai20-3.fna.fbcdn.net/v/t39.30808-6/305116432_2149787665203482_7490196847174226753_n.jpg?_nc_cat=106&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=Z_EBeOZSPcYAX96Nl0L&_nc_ht=scontent.fcai20-3.fna&oh=00_AT_V1X4sTnqrrZyo68QGtVZvLtMLeftwM67mb_gH_eif6w&oe=633214E7"

                       }


                    });
                    context.SaveChanges();

                }
            }
        }
    }
}
