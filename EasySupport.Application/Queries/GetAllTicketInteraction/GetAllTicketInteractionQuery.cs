using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetAllTicketInteraction
{
    public class GetAllTicketInteractionQuery : IRequest<ResultViewModel<List<TicketInteractionsViewModel>>>
    {
        public GetAllTicketInteractionQuery(int ticketId)
        {
            TicketId = ticketId;
        }

        public int TicketId { get; set; }
    }
}
