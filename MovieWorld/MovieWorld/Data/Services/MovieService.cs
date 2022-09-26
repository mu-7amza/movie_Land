using Microsoft.EntityFrameworkCore;
using MovieWorld.Models;
using MovieWorld.ViewModels;

namespace MovieWorld.Data.Services
{
    public class MovieService : IMovieService
    {
        itiDBContext dBContext;
        public MovieService(itiDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<IEnumerable<User>> GetAllAsync1()
        {
            var result = await dBContext.Users.ToListAsync();
            return result;
        }
        public async Task AddAsync1(User user)
        {
            await dBContext.Users.AddAsync(user);
            await dBContext.SaveChangesAsync();
        }
        public async Task AddAsync(Movie movie)
        {
            await dBContext.Movies.AddAsync(movie);
            await dBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await dBContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            dBContext.Movies.Remove(result);
            await dBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {

            var result = await dBContext.Movies.ToListAsync();
            return result;
        }

        public async Task<Movie> GetByIdAsync(int? id)
        {
            var result = await dBContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Movie> UpdateAsync(int id, Movie newMovie)
        {
            dBContext.Update(newMovie);
            await dBContext.SaveChangesAsync();
            return newMovie;
        }
        public async Task<User> loginAsync(LoginVM login)
        {
            User user = await dBContext.Users.SingleOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);
            return user;
        }
        public async Task<User> GetByIdAsync1(int? id)
        {
            var result = await dBContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<User> emailAsync(RegisterVM vM)
        {
            User user = await dBContext.Users.SingleOrDefaultAsync(u => u.Email == vM.Email);
            return user;
        }

        //public async Task addFavAsync(Movie_User movie_User)
        //{
        //  await dBContext.Movie_Users.AddAsync(movie_User);

        //    await dBContext.SaveChangesAsync();


        //}

   

      
        //public async Task AddAsync2(int?uid, int? mid)
        //{
        //    User user;
        //    Movie movie;
        //    await dBContext.Movie_Users.AddAsync(user);
        //    await dBContext.SaveChangesAsync();
        //}
    }
}
