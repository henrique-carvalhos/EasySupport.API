using EasySupport.Core.Entities;
using EasySupport.Core.Services;
using EasySupport.Infrastructure.Notifications.TicketCreated;
using EasySupport.Infrastructure.Notifications.TicketInteractionCreated;
using MediatR;

namespace EasySupport.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMediator _mediator;
        public NotificationService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task NotifyTicketCreated(Ticket ticket)
        {
            var ticketCreated = new TicketCreatedNotification(
            ticket.Id,
            ticket.CreatedAt,
            ticket.Client.Name,
            ticket.Client.Email,
            ticket.Category.Name,
            ticket.Subcategory.Name,
            ticket.Description);

            await _mediator.Publish(ticketCreated);
        }

        public async Task NotifyTicketInteraction(TicketInteraction interaction, Ticket ticketResult)
        {
            var ticket = new TicketInteractionNotification(
                interaction.Id,
                ticketResult.Id,
                ticketResult.Description,
                ticketResult.StatusTicket.Name,
                ticketResult.Category.Name,
                ticketResult.Subcategory.Name,
                ticketResult.Attendant.Id,
                ticketResult.Attendant.Name,
                ticketResult.Attendant.Email,
                ticketResult.Client.Name,
                ticketResult.Client.Email,
                interaction.Message,
                ticketResult.SolutionTicket.Name,
                ticketResult.Attendant.Role,
                interaction.CreatedAt,
                ticketResult.CreatedAt,
                ticketResult.Interactions);

            await _mediator.Publish(ticket);
        }
    }
}
