using EasySupport.Core.Entities;

namespace EasySupport.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync(string search);
        Task<int> AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
