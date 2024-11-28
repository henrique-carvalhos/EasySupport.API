using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasySupport.Infrastructure.Persistence.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EasySupportDbContext _context;
        public DepartmentRepository(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Department department)
        {
            _context.Add(department);
            await _context.SaveChangesAsync();

            return department.Id;
        }

        public async Task<List<Department>> GetAllAsync(string search)
        {
            var departments = await _context
                .Departments
                .Where(d => !d.IsDeleted && (search == "" || d.Name.Contains(search)))
                .ToListAsync();

            return departments;
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context
                .Departments
                .Where(d => !d.IsDeleted)
                .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task UpdateAsync(Department department)
        {
            _context.Update(department);
            await _context.SaveChangesAsync();
        }
    }
}
