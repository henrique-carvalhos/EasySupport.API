using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasySupport.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EasySupportDbContext _context;
        public CategoryRepository(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category.Id;
        }

        public async Task<List<Category>> GetAllAsync(string search)
        {
            var category = await _context
                .Categories
                .Include(s => s.Subcategories)
                .Where(s => !s.IsDeleted &&(search == "" || s.Name.Contains(search)))
                .ToListAsync();

            return category;
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context
                .Categories
                .Include(s => s.Subcategories)
                .Where(s => !s.IsDeleted)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Category category)
        {
            category.Update(category.Name);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
