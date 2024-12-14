using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetAllSolutionTicket
{
    public class GetAllSolutionTicketQueryHandler : IRequestHandler<GetAllSolutionTicketQuery, ResultViewModel<List<SolutionViewModel>>>
    {
        private readonly ISolutionTicketRepository _repository;
        public GetAllSolutionTicketQueryHandler(ISolutionTicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<SolutionViewModel>>> Handle(GetAllSolutionTicketQuery request, CancellationToken cancellationToken)
        {
            var solutions = await _repository.GetAllAsync(request.Search);

            var model = solutions.Select(SolutionViewModel.FromEntity).ToList();

            return ResultViewModel<List<SolutionViewModel>>.Success(model);
        }
    }
}
