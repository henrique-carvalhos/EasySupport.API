using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EasySupport.Infrastructure.Persistence.Repositories
{
    public class TicketInteractionRepository : ITicketInteractionRepository
    {
        private readonly EasySupportDbContext _context;
        public TicketInteractionRepository(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(TicketInteraction interaction)
        {
            _context.TicketInteractions.Add(interaction);
            await _context.SaveChangesAsync();

            return interaction.Id;
        }

        public async Task<List<TicketInteraction>> GetAllInteractionsAsync(int ticketId)
        {
            var interactions = await _context
                .TicketInteractions
                .Include(u => u.Attendant)
                .Include(t => t.Ticket)
                .Where(t => t.Ticket.Id == ticketId)
                .ToListAsync();

            return interactions;
        }

        public async Task<TicketInteraction?> GetByIdAsync(int id)
        {
            return await _context
                .TicketInteractions
                .Include(u => u.Attendant)
                .Include(t => t.Ticket)
                .SingleOrDefaultAsync(t => t.Id == id);
        }
    }
}
