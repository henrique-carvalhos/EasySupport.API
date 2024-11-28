using EasySupport.Core.Entities;

namespace EasySupport.Core.Repositories
{
    public interface ISubcategoriesRepository
    {
        Task<Subcategory?> GetByIdAsync(int id);
        Task<List<Subcategory>> GetAllAsync(string search);
        Task<int> AddAsync(Subcategory subcategory);
        Task UpdateAsync(Subcategory subcategory);
    }
}
