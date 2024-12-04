using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasySupport.Infrastructure.Persistence.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly EasySupportDbContext _context;
        public TicketRepository(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket.Id;
        }

        public async Task<List<Ticket>> GetAllAsync(string search)
        {
            var tickets = await _context
                .Tickets
                .Include(i => i.Interactions)
                .Include(c => c.Category)
                .Include(s => s.Subcategory)
                .Include(u => u.Client)
                .Include(st => st.StatusTicket)
                .Where(s => search == "" || s.Description.Contains(search) || s.Client.Name.Contains(search) || s.Client.Email.Contains(search))
                .ToListAsync();

            return tickets;
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _context
                .Tickets
                .Include(i => i.Interactions)
                .Include(c => c.Category)
                .Include(s => s.Subcategory)
                .Include(u => u.Client)
                .Include(st => st.StatusTicket)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
