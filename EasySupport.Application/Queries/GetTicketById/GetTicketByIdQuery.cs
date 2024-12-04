using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetTicketById
{
    public class GetTicketByIdQuery : IRequest<ResultViewModel<TicketViewModel>>
    {
        public GetTicketByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
