using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.DeleteSolutionTicket
{
    public class DeleteSolutionTicketCommandHandler : IRequestHandler<DeleteSolutionTicketCommand, ResultViewModel>
    {
        private readonly ISolutionTicketRepository _repository;
        public DeleteSolutionTicketCommandHandler(ISolutionTicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteSolutionTicketCommand request, CancellationToken cancellationToken)
        {
            var solution = await _repository.GetByIdAsync(request.Id);

            if (solution == null)
            {
                return ResultViewModel.Error("Solução para do ticket não encontrada");
            }

            solution.SetAsDeleted();
            await _repository.UpdateAsync(solution);

            return ResultViewModel.Success();
        }
    }
}
