using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetSolutionTicketById
{
    public class GetSolutionTicketByIdQueryHandler : IRequestHandler<GetSolutionTicketByIdQuery, ResultViewModel<SolutionViewModel>>
    {
        private readonly ISolutionTicketRepository _repository;
        public GetSolutionTicketByIdQueryHandler(ISolutionTicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<SolutionViewModel>> Handle(GetSolutionTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var solution = await _repository.GetByIdAsync(request.Id);

            if (solution is null)
            {
                return ResultViewModel<SolutionViewModel>.Error("Solução para o chamado não encontrado");
            }

            var model = SolutionViewModel.FromEntity(solution);

            return ResultViewModel<SolutionViewModel>.Success(model);
        }
    }
}
