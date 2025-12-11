using Microsoft.EntityFrameworkCore;
using OpdHospital.Database;
using OpdHospital.Interfaces;
using OpdHospital.Models;

namespace OpdHospital.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
