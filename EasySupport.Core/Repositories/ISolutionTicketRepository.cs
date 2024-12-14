using EasySupport.Core.Entities;

namespace EasySupport.Core.Repositories
{
    public interface ISolutionTicketRepository
    {
        Task<SolutionTicket?> GetByIdAsync(int id);
        Task<List<SolutionTicket>> GetAllAsync(string search);
        Task<int> AddAsync(SolutionTicket solution);
        Task UpdateAsync(SolutionTicket solution);
    }
}
