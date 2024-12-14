using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetSolutionTicketById
{
    public class GetSolutionTicketByIdQuery : IRequest<ResultViewModel<SolutionViewModel>>
    {
        public GetSolutionTicketByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
