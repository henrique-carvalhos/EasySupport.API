using EasySupport.Core.Entities;

namespace EasySupport.Core.Services
{
    public interface INotificationService
    {
        Task NotifyTicketCreated(Ticket ticket);
        Task NotifyTicketInteraction(TicketInteraction interaction, Ticket ticketResult);
    }
}
