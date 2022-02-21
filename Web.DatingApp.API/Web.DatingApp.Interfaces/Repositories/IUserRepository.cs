using System.Collections.Generic;
using Web.DatingApp.API.Web.DatingApp.Entities;

namespace Web.DatingApp.API.Web.DatingApp.Interfaces.Repositories
{
    public interface IUserRepository
    {
        void Update(AppUser appUser);
        Task<bool> SaveAllChanges();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByNameAsync(string username);
    }
}
