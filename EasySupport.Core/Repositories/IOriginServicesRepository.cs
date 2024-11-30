using EasySupport.Core.Entities;

namespace EasySupport.Core.Repositories
{
    public interface IOriginServicesRepository
    {
        Task<OriginService?> GetByIdAsync(int id);
        Task<List<OriginService>> GetAllAsync(string search);
        Task<int> AddAsync(OriginService originService);
        Task UpdateAsync(OriginService originService);
    }
}
