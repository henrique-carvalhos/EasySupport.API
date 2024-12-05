using EasySupport.Core.Entities;

namespace EasySupport.Core.Repositories
{
    public interface ITicketInteractionRepository
    {
        Task<List<TicketInteraction>> GetAllInteractionsAsync(int ticketId);
        Task<int> AddAsync(TicketInteraction category);
    }
}
