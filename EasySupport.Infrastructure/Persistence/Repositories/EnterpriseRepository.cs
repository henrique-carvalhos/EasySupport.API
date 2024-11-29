using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasySupport.Infrastructure.Persistence.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {

        private readonly EasySupportDbContext _context;
        public EnterpriseRepository(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Enterprise enterprise)
        {
            _context.Enterprises.Add(enterprise);
            await _context.SaveChangesAsync();

            return enterprise.Id;
        }

        public Task<List<Enterprise>> GetAllAsync(string search)
        {
            var enterprises = _context
                .Enterprises
                .Where(s => !s.IsDeleted && (search == "" || s.Name.Contains(search)))
                .ToListAsync();
            
            return enterprises;
        }

        public async Task<Enterprise?> GetByIdAsync(int id)
        {
            return await _context
                .Enterprises
                .Where(s => !s.IsDeleted)
                .SingleAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Enterprise enterprise)
        {
            _context.Update(enterprise);
            await _context.SaveChangesAsync();
        }
    }
}
