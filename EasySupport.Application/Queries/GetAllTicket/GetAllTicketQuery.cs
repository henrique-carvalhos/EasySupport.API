using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetAllTicket
{
    public class GetAllTicketQuery : IRequest<ResultViewModel<List<TicketViewModel>>>
    {
        public GetAllTicketQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
