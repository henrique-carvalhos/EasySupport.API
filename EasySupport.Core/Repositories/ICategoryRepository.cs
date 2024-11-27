using EasySupport.Core.Entities;

namespace EasySupport.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync(string search);
        Task<int> AddAsync(Category category);
        Task UpdateAsync(Category category);
    }
}
