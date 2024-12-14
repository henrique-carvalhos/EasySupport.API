using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.UpdateSolutionTicket
{
    public class UpdateSolutionTicketCommandHandler : IRequestHandler<UpdateSolutionTicketCommand, ResultViewModel>
    {
        private readonly ISolutionTicketRepository _repository;
        public UpdateSolutionTicketCommandHandler(ISolutionTicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateSolutionTicketCommand request, CancellationToken cancellationToken)
        {
            var solution = await _repository.GetByIdAsync(request.SolutionTicketId);

            if (solution is null)
            {
                return ResultViewModel.Error("Solução para o ticket não encontrado");
            }

            solution.Update(request.Name);
            await _repository.UpdateAsync(solution);

            return ResultViewModel.Success();
        }
    }
}
