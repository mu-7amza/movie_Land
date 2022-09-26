using Microsoft.EntityFrameworkCore;
using MovieWorld.Models;
using MovieWorld.ViewModels;

namespace MovieWorld.Data.Services
{
    public class UsersService : IUsersService
    {
        itiDBContext dBContext;
       
        public UsersService(itiDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task AddAsync(User user)
        {
            await dBContext.Users.AddAsync(user);
            await dBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await dBContext.Users.FirstOrDefaultAsync(x => x.Id == id);
             dBContext.Users.Remove(result);
            await dBContext.SaveChangesAsync();

        }

        public async Task <IEnumerable<User>> GetAllAsync()
        {
            var result = await dBContext.Users.ToListAsync();
            return result;
        }

        public async Task<User> GetByIdAsync(int id)
        {
           var result = await dBContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<User> loginAsync(LoginVM login)
        {
            User user = await dBContext.Users.SingleOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);
            return user;
        }

        public async Task<User> UpdateAsync(int id, User newUser)
        {
            dBContext.Update(newUser);
            await dBContext.SaveChangesAsync();
            return newUser;
        }

      
    }
}
