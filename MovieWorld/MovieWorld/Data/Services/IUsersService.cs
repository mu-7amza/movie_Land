using MovieWorld.Models;
using MovieWorld.ViewModels;

namespace MovieWorld.Data.Services
{
    public interface IUsersService
    {
       Task <IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<User> UpdateAsync(int id ,User newUser);
        Task DeleteAsync(int id);

        Task<User> loginAsync(LoginVM login);
        

     
    }
}
