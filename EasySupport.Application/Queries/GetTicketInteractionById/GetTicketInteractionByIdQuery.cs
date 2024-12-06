using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetTicketInteractionById
{
    public class GetTicketInteractionByIdQuery : IRequest<ResultViewModel<TicketInteractionsViewModel>>
    {
        public GetTicketInteractionByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
