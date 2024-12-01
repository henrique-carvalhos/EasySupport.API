using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasySupport.Infrastructure.Persistence.Repositories
{
    public class SubcategoriesRepository : ISubcategoriesRepository
    {
        private readonly EasySupportDbContext _context;
        public SubcategoriesRepository(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            await _context.SaveChangesAsync();

            return subcategory.Id;
        }

        public async Task<List<Subcategory>> GetAllAsync(string search)
        {
            var subcategories = await _context
                .Subcategories
                .Include(c => c.Category)
                .Where(c => !c.IsDeleted &&(search == "" || c.Name.Contains(search)))
                .ToListAsync();

            return subcategories;
        }

        public async Task<Subcategory?> GetByIdAsync(int id)
        {
            return await _context
                .Subcategories
                .Include(c => c.Category)
                .Where(c => !c.IsDeleted)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Subcategory subcategory)
        {
            _context.Subcategories.Update(subcategory);
            await _context.SaveChangesAsync();
        }
    }
}
