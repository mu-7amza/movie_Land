using MovieWorld.Models;
using MovieWorld.ViewModels;

namespace MovieWorld.Data.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int? id);
        Task AddAsync(Movie movie);
        Task AddAsync1(User user);
        //Task AddAsync2(int? uid , int? mid);
        Task<User> GetByIdAsync1(int? id);
       
        Task<Movie> UpdateAsync(int id, Movie newMovie);
        Task DeleteAsync(int id);
        Task<User> loginAsync(LoginVM login);
        Task<User> emailAsync(RegisterVM vM);
       
    }
}
