using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertSolutionTicket
{
    public class InsertSolutionTicketCommandHandler : IRequestHandler<InsertSolutionTicketCommand, ResultViewModel<int>>
    {
        private readonly ISolutionTicketRepository _repository;
        public InsertSolutionTicketCommandHandler(ISolutionTicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertSolutionTicketCommand request, CancellationToken cancellationToken)
        {
            var solution = request.ToEntity();

            await _repository.AddAsync(solution);

            return ResultViewModel<int>.Success(solution.Id);
        }
    }
}
