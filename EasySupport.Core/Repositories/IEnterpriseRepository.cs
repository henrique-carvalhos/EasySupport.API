using EasySupport.Core.Entities;

namespace EasySupport.Core.Repositories
{
    public interface IEnterpriseRepository
    {
        Task<Enterprise?> GetByIdAsync(int id);
        Task<List<Enterprise>> GetAllAsync(string search);
        Task<int> AddAsync(Enterprise enterprise);
        Task UpdateAsync(Enterprise enterprise);
    }
}
