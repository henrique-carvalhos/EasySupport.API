using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasySupport.Infrastructure.Persistence.Repositories
{
    public class OriginServicesRepository : IOriginServicesRepository
    {
        private readonly EasySupportDbContext _context;
        public OriginServicesRepository(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(OriginService originService)
        {
            _context.OriginServices.Add(originService);
            await _context.SaveChangesAsync();

            return originService.Id;
        }

        public async Task<List<OriginService>> GetAllAsync(string search)
        {
            var originServices = await _context
                .OriginServices
                .Where(s => !s.IsDeleted && (search == "" || s.Name.Contains(search)))
                .ToListAsync();

            return originServices;
        }

        public async Task<OriginService?> GetByIdAsync(int id)
        {
            return await _context
                .OriginServices
                .Where(s => !s.IsDeleted)
                .SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(OriginService originService)
        {
            _context.Update(originService);
            await _context.SaveChangesAsync();
        }
    }
}
