using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasySupport.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EasySupportDbContext _context;
        public UserRepository(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<List<User>> GetAllAsync(string search)
        {
            var users = await _context
                .Users
                .Include(e => e.Enterprise)
                .Include(d => d.Department)
                .Where(u => !u.IsDeleted && (search == "" || u.Name.Contains(search)))
                .ToListAsync();

            return users;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context
                .Users
                .Include(e => e.Enterprise)
                .Include(d => d.Department)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
