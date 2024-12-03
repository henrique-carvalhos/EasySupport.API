using EasySupport.Core.Entities;

namespace EasySupport.Core.Repositories
{
    public interface ITicketRepository
    {
        Task<Ticket?> GetByIdAsync(int id);
        Task<List<Ticket>> GetAllAsync(string search);
        Task<int> AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
    }
}
