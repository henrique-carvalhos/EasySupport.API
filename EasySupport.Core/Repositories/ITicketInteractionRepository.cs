using EasySupport.Core.Entities;

namespace EasySupport.Core.Repositories
{
    public interface ITicketInteractionRepository
    {
        Task<TicketInteraction?> GetByIdAsync(int id);
        Task<List<TicketInteraction>> GetAllInteractionsAsync(int ticketId);
        Task<int> AddAsync(TicketInteraction interaction);
    }
}
