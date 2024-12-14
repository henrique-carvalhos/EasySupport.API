using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasySupport.Infrastructure.Persistence.Repositories
{
    public class SolutionTicketRepository : ISolutionTicketRepository
    {
        private readonly EasySupportDbContext _context;
        public SolutionTicketRepository(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(SolutionTicket solution)
        {
            _context.SolutionTickets.Add(solution);
            await _context.SaveChangesAsync();

            return solution.Id;
        }

        public async Task<List<SolutionTicket>> GetAllAsync(string search)
        {
            var solutions = await _context
                .SolutionTickets
                .Where(s => !s.IsDeleted && (search == "" || s.Name.Contains(search)))
                .ToListAsync();

            return solutions;
        }

        public async Task<SolutionTicket?> GetByIdAsync(int id)
        {
            return await _context
                .SolutionTickets
                .Where(s => !s.IsDeleted)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(SolutionTicket solution)
        {
            _context.SolutionTickets.Update(solution);
            await _context.SaveChangesAsync();
        }
    }
}
