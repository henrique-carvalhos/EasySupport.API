using EasySupport.Core.Entities;

namespace EasySupport.Core.Repositories
{
    public interface IStatusTicketRepository
    {
        Task<StatusTicket?> GetByIdAsync(int id);
        Task<List<StatusTicket>> GetAllAsync(string search);
        Task<int> AddAsync(StatusTicket status);
        Task UpdateAsync(StatusTicket status);
    }
}
