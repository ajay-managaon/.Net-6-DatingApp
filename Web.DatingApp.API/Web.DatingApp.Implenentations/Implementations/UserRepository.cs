using Microsoft.EntityFrameworkCore;
using Web.DatingApp.API.Web.DatingApp.Database;
using Web.DatingApp.API.Web.DatingApp.Entities;
using Web.DatingApp.API.Web.DatingApp.Interfaces.Repositories;

namespace Web.DatingApp.API.Web.DatingApp.Implenentations.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DatingAppDbContext datingAppDbContext;

        public UserRepository(DatingAppDbContext datingAppDbContext)
        {
            this.datingAppDbContext = datingAppDbContext;
        }
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await datingAppDbContext.tbl_User.Include(p=>p.Photos).SingleOrDefaultAsync(s=>s.Id == id);
        }

        public async Task<AppUser> GetUserByNameAsync(string username)
        {
            return await datingAppDbContext.tbl_User.Include(p => p.Photos).SingleOrDefaultAsync(s => s.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await datingAppDbContext.tbl_User.Include(p => p.Photos).ToListAsync();
        }

        public async Task<bool> SaveAllChanges()
        {
            return await datingAppDbContext.SaveChangesAsync() > 0;
        }

        public void Update(AppUser appUser)
        {
            datingAppDbContext.Entry(appUser).State = EntityState.Modified;
        }
    }
}
