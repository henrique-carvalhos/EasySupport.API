using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetStatusTicketById
{
    public class GetStatusTicketByIdQuery : IRequest<ResultViewModel<StatusTicketViewModel>>
    {
        public GetStatusTicketByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
