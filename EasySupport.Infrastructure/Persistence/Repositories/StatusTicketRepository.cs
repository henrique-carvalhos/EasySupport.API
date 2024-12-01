using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasySupport.Infrastructure.Persistence.Repositories
{
    public class StatusTicketRepository : IStatusTicketRepository
    {
        private readonly EasySupportDbContext _context;
        public StatusTicketRepository(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(StatusTicket status)
        {
            _context.StatusTickets.Add(status);
            await _context.SaveChangesAsync();

            return status.Id;
        }

        public async Task<List<StatusTicket>> GetAllAsync(string search)
        {
            var status = await _context
                .StatusTickets
                .Where(s => !s.IsDeleted && (search == "" || s.Name.Contains(search)))
                .ToListAsync();

            return status;
        }

        public async Task<StatusTicket?> GetByIdAsync(int id)
        {
            return await _context
                .StatusTickets
                .Where(s => !s.IsDeleted)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(StatusTicket status)
        {
            _context.Update(status);
            await _context.SaveChangesAsync();
        }
    }
}
