using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetAllSolutionTicket
{
    public class GetAllSolutionTicketQuery : IRequest<ResultViewModel<List<SolutionViewModel>>>
    {
        public GetAllSolutionTicketQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
