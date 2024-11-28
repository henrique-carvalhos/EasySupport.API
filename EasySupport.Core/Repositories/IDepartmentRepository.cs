using EasySupport.Core.Entities;

namespace EasySupport.Core.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetByIdAsync(int id);
        Task<List<Department>> GetAllAsync(string search);
        Task<int> AddAsync(Department department);
        Task UpdateAsync(Department department);
    }
}
