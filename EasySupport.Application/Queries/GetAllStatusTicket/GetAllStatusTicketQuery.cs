using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetAllStatusTicket
{
    public class GetAllStatusTicketQuery : IRequest<ResultViewModel<List<StatusTicketViewModel>>>
    {
        public GetAllStatusTicketQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
